<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Customer Registration</title>
    <link rel="stylesheet" href="../styles/registration.css"> 
</head>
<body>
    <div class="registration-container">
        <h1>Customer Registration</h1>
        <form action="../control/CustomerReg_control.php" method="post" onsubmit="return validateReg()" enctype="multipart/form-data">
            <div class="input-group">
                <label for="name">Full Name:</label>
                <input type="text" name="name" id="name" placeholder="Enter your full name">
                <p id="error_Name" class="error"></p>
            </div>

            <div class="input-group">
                <label for="email">Email:</label>
                <input type="text" name="email" id="email" placeholder="Enter your email">
                <p id="error_email" class="error"></p>
            </div>

            <div class="input-group">
                <label for="password">Password:</label>
                <input type="password" name="password" id="password" placeholder="Create a password">
                <p id="error_password" class="error"></p>
            </div>

            <div class="input-group">
                <label for="confirm_password">Confirm Password:</label>
                <input type="password" name="confirm_password" id="confirm_password" placeholder="Confirm your password">
                <p id="error_confirm_password" class="error"></p>
            </div>

            <div class="input-group">
                <label for="phone">Phone:</label>
                <input type="text" name="phone" id="phone" placeholder="Enter your phone number">
                <p id="error_phone" class="error"></p>
            </div>

            <div class="input-group">
                <label for="address">Address:</label>
                <textarea name="address" id="address" placeholder="Enter your address" rows="4"></textarea>
                <p id="error_address" class="error"></p>
            </div>

            <div class="input-group">
                <label for="file">Profile Picture:</label>
                <input type="file" name="Profile_Pic" id="file" accept="image/*">
                <p id="error_file" class="error"></p>
            </div>

            <div class="button-group">
                <input type="submit" name="register" value="Register" class="btn">
                <input type="reset" value="Clear" class="btn btn-clear">
            </div>

            <p class="login-link">
                Already have an account? <a href="CustomerLogin.php">Login</a>
            </p>
        </form>
    </div>
    <script src="../js/myjs.js"></script>
</body>
</html>
