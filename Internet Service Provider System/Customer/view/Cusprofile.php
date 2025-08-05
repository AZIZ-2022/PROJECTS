<?php
include '../control/CustomerProfile_control.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../styles/profile.css">
    <title>Customer Profile - Broadband Service Management</title>
</head>
<body>
    <form action="../control/CustomerProfile_control.php" method="POST">


    <div class="dashboard-container">
       
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

       
        <div class="main-content">
            <h1>Customer Profile</h1>

           
            <div class="profile-picture">
                <label for="profile"></label> <?php echo $profile_Pic; ?>
            </div>

            
            <div class="form-group">
                <label for="Name">Name:</label>
                <input type="text" name="name" value="<?php echo $name; ?>">
            </div>

            <div class="form-group">
                <label for="Phone">Phone:</label>
                <input type="text" name="phone" value="<?php echo $phone; ?>">
            </div>

            <div class="form-group">
                <label for="Address">Address:</label>
                <input type="text" name="address" value="<?php echo $address; ?>">
            </div>

            <div class="form-group">
                <label for="Email">Email:</label>
                <input type="text" name="email" readonly value="<?php echo $email; ?>">
            </div>

            <div class="form-group">
                <label for="Password">Password:</label>
                <input type="password" name="password" value="<?php echo $password; ?>">
            </div>

            <div class="form-group">
                <input type="submit" name="update" value="Update Profile">
            </div>
        </div>
    </form>
</body>
</html>