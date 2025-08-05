<?php
include '../control/unsubscribe_control.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../styles/unsubscribe.css">
    <title>Customer Dashboard - Broadband Service Management</title>
</head>
<body>

<form action="../control/unsubscribe_control.php" method="post">
    <h2>Subscribed Plans</h2>

    <p><b>Subscription_ID: <?php echo ($subscription_id); ?></b></p>
    <p>ID: <?php echo ($id); ?></p>
    <p>Speed: <?php echo ($speed); ?></p>
    <p>Price: <?php echo ($price); ?></p>
    <p>Description: <?php echo ($description); ?></p>

   
    <input type="hidden" name="subscription_id" value="<?php echo $subscription_id; ?>">

    <input type="submit" name="unsubscribe" value="Unsubscribe">
    <input type="submit" name="back" value="Back">
</form>

               

</body>
</html>
