<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Customer Login - City Broadband</title>
    <link rel="stylesheet" href="../styles/login.css"> 
</head>
<body>
    <div class="login-container">
        <h1>City Broadband Service</h1>
        <h2>Customer Login</h2>

        <form action="../control/CustomerLogin_control.php" method="post">
            <div class="input-group">
                <label for="email">Email:</label>
                <input type="email" name="email" id="email" placeholder="Enter your email" required>
            </div>

            <div class="input-group">
                <label for="password">Password:</label>
                <input type="password" name="password" id="password" placeholder="Enter your password" required>
            </div>

            <div class="button-group">
                <input type="submit" value="Login" class="btn">
                <input type="reset" value="Clear" class="btn btn-clear">
            </div>

            <p class="register-link">
                Doesn't have an account? <a href="CRegistration.php">Register</a>
            </p>
        </form>
    </div>
</body>
</html>
