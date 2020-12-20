<!--This is the connection to a DB from infinityfree
REFERENCES:
https://www.youtube.com/watch?v=8hVnwyfFyyI&app=desktop
-->
<?php

    $server = "sql310.epizy.com";
    $username = "epiz_27152559"; // by deafault, this is the username in xampp. If there's a live website, this will change
    $password = "f4ADJTlk5j"; // by default, passwword is disabled in xampp
    $db = "epiz_27152559_try_dynamic_host"; // change this to the DB name

    // "localhost" is the only default the the arguments
    $con = new mysqli($server, $username, $password, $db) or die("Unable to connect");
    //$con = mysqli_connect("localhost", "arr", "arr", "snowman_test_db") or die("Unable to connect");


    // // Check connection // This can be use as well instead of die
    // if (mysqli_connect_errno()) {
    //     echo "Failed to connect to MySQL: " . mysqli_connect_error();
    // }
?>