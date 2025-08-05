<?php

include '../model/db.php';

session_start();

if (isset($_SESSION["email"])) {
    $email = $_SESSION["email"]; 

}


if (isset($_GET["id"])) {
    $id = intval($_GET["id"]); 

    $mydb = new mydb();
    $connectionObject = $mydb->openCon();
    $results = $mydb->getServiceByID( $connectionObject, $id);

    if ($results && $results->num_rows > 0) {
        while ($data = $results->fetch_assoc()) {
            $id = $data["ID"];
            $speed = $data["Speed"];
            $price = $data["price"];
            $description = $data["Description"];
            
        }
    } else {
        echo "No Data Available";
    } 
    
} 

if (isset($_POST["back"])){
    header("Location: ../view/customerDashboard.php");
}
    if (isset($_POST["subscribe"])){
        $id = trim($_POST["id"]);
        $speed = trim($_POST["speed"]);
        $price = trim($_POST["price"]);
        $description = trim($_POST["description"]);

       $mydb = new mydb();
       $connobject = $mydb->openCon();
       $results = $mydb->subscribedplans_table('subscribed_plans',$email,$id, $speed, $price, $description,$connobject);
    
       header("Location: ../view/subscriptions.php");



}
