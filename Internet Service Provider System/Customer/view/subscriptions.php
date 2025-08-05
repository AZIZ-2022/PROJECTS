<?php include '../control/subscriptions_control.php'; ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Customer Dashboard - Broadband Service Management</title>
    <link rel="stylesheet" href="../styles/dashboard.css">
</head>
<body>
    <div class="dashboard-container">
      
        <div class="sidebar">
            <h2>Menu</h2>
            <ul>
                <li><a href="CustomerDashboard.php">Available Services</a></li>
                <li><a href="subscriptions.php">Subscribed Plans</a></li>
                <li><a href="Cusprofile.php">Profile</a></li>
                <li><a href="CusBillHistory.php">Billing History</a></li>
                <li><a href="CustomerComplaints.php">Add Complaint</a></li>
                <li><a href="CustomerComplaintHistory.php">Complaints History</a></li>
            </ul>
            <form action="../control/customer_dashboard_control.php" method="POST">
                
            </form>
        </div>

        
        <div class="content">
            
        </div>
    </div>
</body>
</html>