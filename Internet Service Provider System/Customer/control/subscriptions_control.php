<?php
session_start();
include '../model/db.php'; 

echo "<h1>Subscriptions</h1>";


if (!isset($_SESSION["email"])) {
    echo "You must be logged in to view your subscriptions.";
    exit;
}











$email = $_SESSION["email"]; 

$mydb = new mydb();
$connobject = $mydb->openCon(); 

$results = $mydb->getSubscriptionsByEmail("subscribed_plans", $email, $connobject);

if ($results && $results->num_rows > 0) {
    echo "<table class='show_table' border='1' width='100%' cellpadding='10'>";
    echo "<thead>
            <tr class='table_head'>
                 <th>Subscription ID</th>
                <th>ID</th>
                <th>Speed</th>
                <th>Price</th>
                <th>Description</th>
                <th>Actions</th>
            </tr>
          </thead>";
    echo "<tbody>";

    while ($data = $results->fetch_assoc()) {
        echo "<tr class='table_row'>";
        echo "<td>" . $data['Subscription_ID'] . "</td>";
        echo "<td>" . $data['ID'] . "</td>";
        echo "<td>" . $data['Speed'] . "</td>";
        echo "<td>" . $data['Price'] . "</td>";
        echo "<td>" . $data['Description'] . "</td>";
        echo "<td>
                <a href='../view/CustomerBilling.php?id=" . $data['ID'] . "'>Pay Bill</a>  |
                <a href='../view/unsubscribe.php?subscription_id=" . $data['Subscription_ID'] . "'>Unsubscribe</a> 

              </td>";
        echo "</tr>";
    }

    echo "</tbody>";
    echo "</table>";
} 


$connobject->close();
?>
