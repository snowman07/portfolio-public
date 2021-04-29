<!--This is the connection to xampp DB-->
<?php

    $username = "root"; // by deafault, this is the username in xampp. If there's a live website, this will change
    $password = ""; // by default, passwword is disabled in xampp
    $db = "snowman_test_db"; // change this to the DB name

    // "localhost" is the only default in the arguments
    $con = new mysqli("localhost", $username, $password, $db) or die("Unable to connect");
    //$con = mysqli_connect("localhost", "arr", "arr", "snowman_test_db") or die("Unable to connect");

?>