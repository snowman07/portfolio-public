<?php
    include("../includes/mysql_connect.php");   // we MUST first connect to the DB to be able to delete, but we DONOT want the UI

    $charID = $_GET["id"];
    echo "<h1>$charID</h1>";

    if(is_numeric($charID)) {
        // on your own... do a DELETE statement
        mysqli_query($con, "DELETE FROM plant_catalog WHERE id = $charID") or die(mysqli_error($con)); 
        header("Location:edit.php"); // this will redirect after delete from db
    }
?>