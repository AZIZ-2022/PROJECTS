<?php
session_start();
include '../model/db.php';


$name = $phone = $address = $profile_pic = "";


if (isset($_SESSION["email"])) {
    $email = $_SESSION["email"]; 

  
    $mydb = new mydb();
    $conobj = $mydb->openCon();

  
    $results = $mydb->getUserByEmail("customer_reg", $conobj, $email);

    if ($results && $results->num_rows > 0) {
        while ($data = $results->fetch_assoc()) {
            $name = $data["Name"]; 
            $phone = $data["Phone"]; 
            $address = $data["Address"]; 
            $password= $data["Password"];
            $profile_Pic = "<img src='../uploads/" . htmlspecialchars($data['Profile_Pic']) . "' alt='Profile_Pic' id='Profile_Pic'>";
        }
    } else {
       
        $error_message = "No data found for the provided email.";
    }

 
    $conobj->close();
} else {
    header("Location: ../view/CustomerLogin.php");
    exit();
}


if(isset($_POST['update'])){

    header("Location: ../view/update_profile.php");


}


?>
