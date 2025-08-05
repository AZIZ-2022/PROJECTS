<?php
session_start();
include '../model/db.php'; 


if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['subscribe'])) {
    $service_id = $_POST['id']; 

    $mydb = new mydb();
    $connobject = $mydb->openCon();

    
    $service = $mydb->getServiceByID("service", $service_id, $connobject);

    if ($service->num_rows > 0) {
        $service_data = $service->fetch_assoc();

        
        $speed = $service_data['Speed'];
        $price = $service_data['price'];
        $description = $service_data['Description'];

        
        $result = $mydb->subscribePlan("subscribed_plan", $email, $service_id, $speed, $price, $description, $connobject);

        if ($result) {
            echo "<p>Subscription successful!</p>";
        } else {
            echo "<p>Failed to subscribe to the plan. Please try again later.</p>";
        }
    } else {
        echo "<p>Service not found.</p>";
    }

    $connobject->close();
}



if (isset($_POST["logout"])) {
    session_destroy();
    header("Location:../view/CustomerLogin.php");



}



echo "<h2>Available Services</h2>";

$mydb = new mydb();
$connobject = $mydb->openCon();
$results = $mydb->show_services("service", $connobject);

if ($results->num_rows > 0) {
    echo "<form method='POST' action='customer_dashboard_control.php'>";
    echo "<table class='show_table' border='1' width='100%' cellpadding='10'>";
    echo "<thead>
            <tr class='table_head'>
                <th>ID</th>
                <th>Speed</th>
                <th>Price</th>
                <th>Description</th>
                <th>Action</th>
            </tr>
          </thead>";
    echo "<tbody>";

    foreach ($results as $data) {
        echo "<tr class='table_row'>";
        echo "<td>" . $data['ID'] . "</td>";
        echo "<td>" . $data['Speed'] . "</td>";
        echo "<td>" . $data['price'] . "</td>";
        echo "<td>" . $data['Description'] . "</td>";
        echo "<td>
        <a href='../view/subscribed_plans.php?id=" . $data['ID'] . "'>subscribe</a>
      </td>";
              
        echo "</tr>";
    }

    echo "</tbody>";
    echo "</table>";
    echo "</form>";

} else {
    echo "<p>No services found.</p>";
}

$connobject->close();
?>
