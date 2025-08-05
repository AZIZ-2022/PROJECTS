<?php

class mydb {
    function openCon() {
        $dbhost = "localhost";
        $dbusername = "root";
        $dbpassword = "";
        $dbname = "broadband service management system";


        $connobject = new mysqli($dbhost, $dbusername, $dbpassword, $dbname);

        if ($connobject->connect_error) {
            die("Connection failed: " . $connobject->connect_error);
        }

        return $connobject;
    }
    
    function customer_reg($table, $name, $email, $password, $confirm_password, $phone, $address, $Profile_Pic, $connobject) {
        $sql = "INSERT INTO $table (Name, Email, Password, Confirm_Password, Phone, Address, Profile_Pic) 
                VALUES ('$name', '$email', '$password', '$confirm_password', '$phone', '$address', '$Profile_Pic')";
        return $connobject->query($sql);
    }


        function login($table, $email, $password, $connobject) {
        $sql = "SELECT * FROM $table WHERE Email = '$email' AND Password = '$password'";
        return $connobject->query($sql);
    }

        
        function show_applied_customer($table,$connobject){
            $sql = "SELECT ID ,Name, Email,Phone,Address FROM $table";
            $resutlts = $connobject->query($sql);
            return $resutlts;
        }

            

    function addService($table, $speed, $price, $description, $connobject) {
        $sql = "INSERT INTO $table (Speed, price, Description) VALUES ('$speed', '$price', '$description')";
        return $connobject->query($sql);
        }

            
    function show_services($table, $conn)
    {
        $sql = "SELECT * FROM $table";
        return $conn->query($sql);
    }

    function getServiceByID( $connectionObject, $id) {
        $sql = "SELECT * FROM service WHERE id = ?";
        $stmt = $connectionObject->prepare($sql);
        $stmt->bind_param("i", $id);
        $stmt->execute();
        $results = $stmt->get_result();
        return $results;
    }
    function subscribedplans_table($table, $email,$id,$speed, $price, $description, $connobject) {
        $sql = "INSERT INTO $table (email,ID,Speed, Price, Description) 
                VALUES ('$email','$id','$speed', '$price', '$description')";
        return $connobject->query($sql);
    }
    

        function subscriptions_table($table,$connobject){
            $sql = "SELECT * FROM $table";
            $resutlts = $connobject->query($sql);
            return $resutlts;
        }

        function add_complaints($table, $description,$email, $conobj) {
            $sql = "INSERT INTO $table ( Description , Email) 
                    VALUES ( '$description','$email')";
            return $conobj->query($sql);
            }

        function show_complaints($table,$connobject){
            $sql = "SELECT * FROM $table";
            $resutlts = $connobject->query($sql);
            return $resutlts;
            }

            function UnsubscriberByID( $connectionObject, $subscription_id) {
                $sql = "SELECT * FROM subscribed_plans WHERE Subscription_ID = ?";
                $stmt = $connectionObject->prepare($sql);
                $stmt->bind_param("i", $subscription_id);
                $stmt->execute();
                $results = $stmt->get_result();
                return $results;
            }

            function Unsubscribe($subscription_id, $tableName, $connectionObject){
                $sql = "DELETE FROM $tableName WHERE Subscription_ID =?";
                $stmt = $connectionObject->prepare($sql);
                $stmt->bind_param("i", $subscription_id);
                if ($stmt->execute()) {
                    $stmt->close();
                    return 1; 
                } else {
                    $stmt->close();
                    return "Error executing statement: ". $stmt->error;
                }
            }

            function billing($table,$speed,$price,$description,$payment_method,$ac,$email, $conobj) {
                $sql = "INSERT INTO $table ( Speed,Price,Description,Payment_Method,Account_Number,Email) 
                        VALUES ( '$speed','$price','$description','$payment_method','$ac','$email')";
                return $conobj->query($sql);
                }
                
                function show_bills($table,$connobject){
                    $sql = "SELECT * FROM $table";
                    $resutlts = $connobject->query($sql);
                    return $resutlts;
                    }

                
                    function getUserByEmail($tableName, $connectionObject, $email) {
                        $sql = "SELECT * FROM $tableName WHERE Email = ?";
                        $stmt = $connectionObject->prepare($sql);
                        $stmt->bind_param("s", $email);
                        $stmt->execute();
                        $results = $stmt->get_result();
                        return $results;
                    }

                    function getSubscriptionsByEmail($table, $email, $connobject) {
                        $sql = "SELECT * FROM $table WHERE email = ?";
                        $stmt = $connobject->prepare($sql);
                        $stmt->bind_param("s", $email); 
                        $stmt->execute();
                        $results = $stmt->get_result();
                        return $results;
                    }

                    function getbillingByEmail($table, $email, $connobject) {
                        $sql = "SELECT * FROM $table WHERE email = ?";
                        $stmt = $connobject->prepare($sql);
                        $stmt->bind_param("s", $email); 
                        $stmt->execute();
                        $results = $stmt->get_result();
                        return $results;
                    }

                    function showComplaintByEmail($table, $email, $connobject) {
                        $sql = "SELECT * FROM $table WHERE email = ?";
                        $stmt = $connobject->prepare($sql);
                        $stmt->bind_param("s", $email); 
                        $stmt->execute();
                        $results = $stmt->get_result();
                        return $results;
                    }

                    function updateUser($table, $name, $phone, $address, $profile_pic, $connobject, $email) {
                        $sql = "UPDATE $table SET Name = '$name', Phone = '$phone', Address = '$address', Profile_Pic = '$profile_pic' WHERE Email = '$email'";
                        return $connobject->query($sql);
                       }
                    
               
                    

    
    }


    
   
   

/*function searchUserbyID($table,$connobject,$id){
    $sql="SELECT * FROM $table WHERE id='$id'";
    $result=$connobject->query($sql);
    return $result;
}
*/






?>