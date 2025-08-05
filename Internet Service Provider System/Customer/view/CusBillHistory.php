<?php
include '../control/customer_billing_history_control.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../styles/billinghistory.css"> 
</head>
<body>

<div class="container">
  
    <div class="sidebar">
        <h2>Menu</h2>
        <ul>
            <li><a href="CustomerDashboard.php">Available Services</a></li>
            <li><a href="subscriptions.php">Subscribed Plans</a></li>
            <li><a href="Cusprofile.php">Profile</a></td>
            <li><a href="CusBillHistory.php">Billing History</a></li>
            <li><a href="CustomerComplaints.php">Add Complaint</a></li>
            <li><a href="CustomerComplaintHistory.php">Complaints History</a></li>
       </ul>
        </div>

   
    <div class="content">
        <h1>Customer Billing History</h1>

        <?php
        if (isset($_SESSION["email"])) {
            $email = $_SESSION["email"]; 

            $mydb = new mydb();
            $connobject = $mydb->openCon();

            
            $results = $mydb->getbillingByEmail("billing_history", $email, $connobject);

            if ($results && $results->num_rows > 0) {
                echo "<table class='billing-table'>";
                echo "<thead>
                        <tr>
                            <th>Transaction ID</th>
                            <th>Speed</th>
                            <th>Price</th>
                            <th>Description</th>
                            <th>Payment Method</th>
                            <th>Account Number</th>
                        </tr>
                      </thead>";
                echo "<tbody>";

                while ($data = $results->fetch_assoc()) {
                    echo "<tr>";
                    echo "<td>" . $data['Transaction_ID'] . "</td>";
                    echo "<td>" . $data['Speed'] . "</td>";
                    echo "<td>" . $data['Price'] . "</td>";
                    echo "<td>" . $data['Description'] . "</td>";
                    echo "<td>" . $data['Payment_Method'] . "</td>";
                    echo "<td>" . $data['Account_Number'] . "</td>";
                    echo "</tr>";
                }

                echo "</tbody>";
                echo "</table>";
            } else {
                echo "<p>No billing history found for this email.</p>";
            }

            
            $connobject->close();
        }
        ?>
    </div>
</div>

</body>
</html>
