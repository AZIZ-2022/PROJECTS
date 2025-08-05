<?php
session_start();
include '../model/db.php'; 

echo "<h1>Customer Complaints</h1>";

if (isset($_SESSION["email"])) {
    $email = $_SESSION["email"]; 

    $mydb = new mydb();
    $connobject = $mydb->openCon(); 


    $results = $mydb->showComplaintByEmail("complaint_history", $email, $connobject);

    if ($results && $results->num_rows > 0) {
       

        while ($data = $results->fetch_assoc()) { 
            
            $id = $data["ID"];
            $description = $data["Description"];
            
        }

    } else {
        echo "<p>No complaints found for this email.</p>";
    }

    
    $connobject->close();
}
?>
