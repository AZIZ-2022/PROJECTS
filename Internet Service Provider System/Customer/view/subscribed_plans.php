<?php
include '../control/subscribedplans_control.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../styles/subscribedplans.css">
    <title>Customer Dashboard - Broadband Service Management</title>
</head>
<body>

<form action="../control/subscribedplans_control.php" method="post">

                
                <h2>Subscribed Plans</h2>
                
                
                <label for="ID">ID:</label>
                <input type="text"  name="id" value="<?php echo $id?>">

                <label for="Speed">Speed:</label>
                <input type="text"  name="speed" value="<?php echo $speed?>">
                
                
                <label for="Price">Price:</label>
                <input type="text"  name="price" value="<?php echo $price?>">


                <label for="Description">Description</label>
                <input type="text"  name="description" value="<?php echo $description?>"><br><br>


                <input type="submit" name="subscribe" value = "Subscribe">
                <input type="submit" name="back" value = "Back">



               
            </td>
        </tr>
    </table>

</body>
</html>
