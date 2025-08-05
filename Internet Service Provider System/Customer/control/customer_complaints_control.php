<?php
session_start();
include '../model/db.php'; 


if (isset($_SESSION["email"])) {
    $email = $_SESSION["email"]; 
if(isset($_POST['submit'])){

    $description = trim($_POST["description"]);

$mydb = new mydb();
$conobj = $mydb->openCon();
$result = $mydb->add_complaints("complaint_history", $description, $email , $conobj);

header("Location: ../view/CustomerComplaints.php");
}


}