<?php
session_start();
include '../model/db.php'; 



if (isset($_SESSION["email"])) {
    $email = $_SESSION["email"]; 

    $mydb = new mydb();
    $connobject = $mydb->openCon(); 

    
    $results = $mydb->getbillingByEmail("billing_history", $email, $connobject);

    if ($results && $results->num_rows > 0) {
       

        while ($data = $results->fetch_assoc()) { 
         
            
            $speed = $data["Speed"];
            $price = $data["Price"];;
            $description = $data["Description"];;
            $payment_method = $data["Payment_Method"];;
            $ac = $data["Account_Number"];;
        
        }

    } else {
        echo "<p>No billing history found for this email.</p>";
    }

    
    $connobject->close();
}
?>
