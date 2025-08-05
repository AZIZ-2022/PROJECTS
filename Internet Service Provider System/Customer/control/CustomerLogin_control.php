<?php

include '../model/db.php';
session_start();

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $errors = [];

 
    $email = trim($_POST["email"]);
    if (empty($email) || !filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $errors[] = "Invalid email format.";
    }

    $password = trim($_POST["password"]);
    if (empty($password)) {
        $errors[] = "Password cannot be empty.";
    }

    if (!empty($errors)) {
        
        foreach ($errors as $error) {
            echo $error . "<br>";
        }
    } else {
     
        $mydb = new mydb();
        $conobj = $mydb->openCon();

  
        $result = $mydb->login("customer_reg", $email, $password, $conobj);

        if ($result->num_rows > 0) {
      
            $_SESSION["email"] = $email; 
           
        } else {
            echo "Invalid email or password.";
        }
        header("Location: ../view/CustomerDashboard.php"); 
    
        $conobj->close();
    }
}
?>
