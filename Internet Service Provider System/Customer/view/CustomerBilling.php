<?php
include '../control/customer_billing_control.php';
?>



<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../styles/customer_billing.css">
    <title>Payment - Broadband Service Management</title>
</head>
<body>
<form action="../control/customer_billing_control.php" method="POST" onsubmit="return validatePayment()">

   
    <h1 align="center">Payment Page</h1>
    
 
    <h3>Selected Plan Details</h3>

                <label for="Speed">Speed:</label>
                <input type="text"  name="speed" id="speed" value="<?php echo $speed?>">
                
                
                <label for="Price">Price:</label>
                <input type="text"  name="price" id="price" value="<?php echo $price?>">


                <label for="Description">Description</label>
                <input type="text"  name="description" id="description" value="<?php echo $description?>"><br><br>


                


    <h3 align="center">Select Payment Method</h3>
    <label for="payment_method">Select Payment Method:</label>
        <select name="payment_method" id="payment_method">
            <option value="bkash">Bkash</option>
            <option value="nagad">Nagad</option>
        </select>
        <p id="error_payment_method"></p>
        <br><br>

    
        <label for="account_number">Mobile Number:</label>
        <input type="text" id="ac" name="ac" placeholder="01XXXXXXXXX" >
        <p id="error_phone"></p>
        <br><br>
 
        <label for="password">Password:</label>
        <input type="text" id="password" name="password" placeholder="01XXXXXXXXX" >
        <p id="error_password"></p>
        <br><br>

    
        <input type="submit" name="pay" value="Pay Now">
        <input type="reset" name="clear" value="clear">
        <a href="subscriptions.php">Back </a>

    </form>
    <script src="../js/myjs.js"></script>
</body>
</html>
