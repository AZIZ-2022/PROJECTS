<?php
include '../control/complaint_history_control.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Customer Complaint History - Broadband Service Management</title>
    <link rel="stylesheet" href="../styles/complainthistory.css">
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

   
    <div class="complaint-history">
        <h1>Customer Complaints</h1>

        <?php
        if (isset($_SESSION["email"])) {
            $email = $_SESSION["email"];

            $mydb = new mydb();
            $connobject = $mydb->openCon(); 

    
            $results = $mydb->showComplaintByEmail("complaint_history", $email, $connobject);

            if ($results && $results->num_rows > 0) {
                echo "<table class='show_table'>";
                echo "<thead>
                        <tr class='table_head'>
                            <th>ID</th>
                            <th>Complaints</th>
                        </tr>
                      </thead>";
                echo "<tbody>";

                while ($data = $results->fetch_assoc()) {
                    echo "<tr class='table_row'>";
                    echo "<td>" . $data['ID'] . "</td>";
                    echo "<td>" . ($data['Description']) . "</td>";
                    echo "</tr>";
                }

                echo "</tbody>";
                echo "</table>";
            } else {
                echo "<p>No complaints found for this email.</p>";
            }

           
            $connobject->close();
        }
        ?>
    </div>
</div>

</body>
</html>
