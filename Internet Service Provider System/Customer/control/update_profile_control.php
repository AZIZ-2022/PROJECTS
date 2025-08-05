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

if (isset($_POST["update"])) {
    $name = $_POST["name"];
    $phone = $_POST["phone"];
    $address = $_POST["address"];
    $profile_pic = $_POST["Profile_Pic"];

    $mydb = new mydb();
    $conobj = $mydb->openCon();

    $result = $mydb->updateUser("customer_reg", $name, $phone, $address, $profile_pic, $conobj, $email);

    if ($result) {
        $success_message = "User information updated successfully.";
    } else {

        $error_message = "Failed to update user information.";
    }


    $conobj->close();

    header("Location: ../view/Cusprofile.php");

}

?>