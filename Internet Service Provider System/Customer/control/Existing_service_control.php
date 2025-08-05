<?php
include '../model/db.php'; 

echo "<h1>Customer Registration Requests</h1>";

$mydb = new mydb();
$connobject = $mydb->openCon();
$results = $mydb->show_services("service", $connobject);

if ($results->num_rows > 0) {
    echo "<table class='show_table' border='1' width='100%' cellpadding='10'>";
    echo "<thead>
            <tr class='table_head'>
                <th>ID</th>
                <th>Speed</th>
                <th>price</th>
                <th>Description</th>
               
            </tr>
          </thead>";
    echo "<tbody>";

    foreach ($results as $data) {
        echo "<tr class='table_row'>";
        echo "<td>" . $data['ID'] . "</td>";
        echo "<td>" . ($data['Speed']) . "</td>";
        echo "<td>" . ($data['price']) . "</td>";
        echo "<td>" . ($data['Description']) . "</td>";
    
       
        echo "</tr>";
    }
    

    echo "</tbody>";
    echo "</table>";
} else {
    echo "<p>No Services found.</p>";
}



    

?>
