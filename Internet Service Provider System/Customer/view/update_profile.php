<?php
include '../control/update_profile_control.php';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../styles/editprofile.css">
    <title>Update Information</title>
</head>
<body >

      
    </div>
    <div id="edit_user_body">
        <form  id="update_from"action="" method="post" >
        <h1 id="edit_user_h1">Edit User</h1>
        <br>
        <label for="name">Name:</label>
        <input type="text" id="name" name="name" value="<?php echo $name; ?>"><br>
 

        <label for="email">Email:</label>
        <input type="text" id="email" name="email" readonly value="<?php echo $email; ?>"><br>
 

        <label for="password">Password:</label>
        <input type="password" id="password" name="password" value="<?php echo $password; ?>"><br>


        <label for="phone">Phone:</label>
        <input type="text" id="phone" name="phone" value="<?php echo $phone; ?>"><br>


        <label for="address">Address:</label>
        <textarea id="address" name="address"><?php echo $address; ?></textarea><br>
    


  
        <div class="profile-picture">
         
            <input type="file" name="Profile_Pic" id="profileInput"  value="<?php echo $Profile_Pic; ?>" >
            </div>


        <input type='submit' name='update' value='Update Profile'>
        <input type='submit' name='back' value='Back'>

      
    </form>
    </div>
</body>
</html>