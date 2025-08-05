<?php
session_start();
include '../model/db.php';


if(isset($_POST['register'])){


if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $errors = [];

  
    $name = trim($_POST["name"]);
    if (!preg_match("/^[a-zA-Z\s]+$/", $name)) {
        $errors[] = "Full name should contain only letters and spaces.";
    }

  
    $email = trim($_POST["email"]);
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $errors[] = "Invalid email format. It must contain '@'.";
    }

  
    $password = trim($_POST["password"]);
    if (strlen($password) < 5) {
        $errors[] = "Password must be at least 5 characters long.";
    }

   
    $confirm_password = trim($_POST["confirm_password"]);
    if ($password !== $confirm_password) {
        $errors[] = "Password and confirm password must match.";
    }

    
    $phone = trim($_POST["phone"]);
    if (!preg_match("/^\d{11}$/", $phone)) {
        $errors[] = "Phone number must be exactly 11 digits and contain no letters.";
    }


    
    
    $Address = trim($_POST["address"]);


    $Profile_Pic = $_FILES["Profile_Pic"]["name"];
        move_uploaded_file($_FILES["Profile_Pic"]["tmp_name"],
        "../uploads/".$_FILES["Profile_Pic"]["name"]
        );


    
    if (!empty($errors)) {
        foreach ($errors as $error) {
            echo "$error"; 
        }
    } 

    
    else{

        
        $mydb = new mydb();
        $conobj = $mydb->openCon();
        $result = $mydb->customer_reg(
            "customer_reg",  
            $name,
            $email,
            $password,
            $confirm_password,
            $phone,
            $Address,
            $Profile_Pic,
            $conobj
        );

        header("Location: ../view/CustomerLogin.php");
    }
}
}

?>
