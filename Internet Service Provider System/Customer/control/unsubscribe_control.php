<?php

include '../model/db.php';
  


if (isset($_GET["subscription_id"])) {
    $id = intval($_GET["subscription_id"]); 
    $subscription_id = $_GET['subscription_id'];
    $mydb = new mydb();
    $connectionObject = $mydb->openCon();
    $results = $mydb->UnsubscriberByID( $connectionObject, $subscription_id);

    if ($results && $results->num_rows > 0) {
        while ($data = $results->fetch_assoc()) {
            $subscription_id = $data["Subscription_ID"];
            $id = $data["ID"];
            $speed = $data["Speed"];
            $price = $data["Price"];
            $description = $data["Description"];
        }
    } else {
        echo "No Data Available";
    }  
    
} 

if (isset($_POST['unsubscribe'])){

      $subscription_id = ($_POST['subscription_id']);

       $mydb = new mydb();
       $connectionObject = $mydb->openCon();
       $results = $mydb->Unsubscribe($subscription_id, 'subscribed_plans' , $connectionObject);

       header("Location: ../view/subscriptions.php");

}
if (isset($_POST['back'])){

     header("Location: ../view/subscriptions.php");

}



