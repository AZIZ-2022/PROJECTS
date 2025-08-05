
<?php
include '../model/db.php';
session_start();

$email = $_SESSION["email"]; 


  


if (isset($_GET["id"])) {
    $id = intval($_GET["id"]); 

    $mydb = new mydb();
    $connectionObject = $mydb->openCon();
    $results = $mydb->UnsubscriberByID( $connectionObject, $id);

    if ($results && $results->num_rows > 0) {
        while ($data = $results->fetch_assoc()) {
            $id = $data["ID"];
            $speed = $data["Speed"];
            $price = $data["Price"];
            $description = $data["Description"];
        }
    } else {
        echo "No Data Available";
    }  
    
}

if(isset($_POST['pay'])){


    $email = $_SESSION["email"]; 

  
$ac = trim($_POST["ac"]);
if (!preg_match("/^\d{11}$/", $ac)) {
    $errors[] = "Phone number must be exactly 11 digits and contain no letters.";
}


$password = trim($_POST["password"]);
if (strlen($password) < 5) {
    $errors[] = "Password must be at least 5 characters long.";
}


$payment_method = trim($_POST["payment_method"]);
if (empty($_POST['payment_method'])) {
    $errors[] = "Payment Method Must be selected";
}
if (!empty($errors)) {
  foreach ($errors as $error) {
      echo "$error"; 
  }
}

    else{

    $id = trim($_POST["id"]);
    $speed = trim($_POST["speed"]);
    $price = trim($_POST["price"]);
    $description = trim($_POST["description"]);
    $pay = trim($_POST["pay"]);
    $ac = trim($_POST["ac"]);



   



   $mydb = new mydb();
   $conobj = $mydb->openCon();
   $result = $mydb->billing("billing_history",$speed,$price,$description,$payment_method,$ac,$email, $conobj);
   header("Location: ../view/CustomerDashboard.php");

}
}



?>
