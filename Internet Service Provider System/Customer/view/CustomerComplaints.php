<?php
include '../control/customer_complaints_control.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Customer Complaint - Broadband Service Management</title>
    <link rel="stylesheet" href="../styles/addcomplaint.css"> 
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
        <h1>Add Complaint</h1>

   
        <div class="customer-info">
            <h3>Customer Information</h3>
            <table>
                <tr>
                    <td><strong>From:</strong></td>
                    <td><input type="text" value="<?php echo htmlspecialchars($email); ?>" readonly class="input-field"></td>
                </tr>
                <tr>
                    <td><strong>To:</strong></td>
                    <td><input type="text" value="admin@gmail.com" readonly class="input-field"></td>
                </tr>
            </table>
        </div>

       
        <div class="complaint-form">
            <h3>Write Your Complaint</h3>
            <form action="../control/customer_complaints_control.php" method="POST">
                <textarea name="description" placeholder="Enter your complaint here..." class="complaint-textarea"></textarea>
                <br>
                <input type="submit" name="submit" value="Submit Complaint" class="submit-btn">
            </form>
        </div>
    </div>
</div>

</body>
</html>
