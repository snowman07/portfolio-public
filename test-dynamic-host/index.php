<?php
    include("connect.php"); // this is the connection to the DB


    // if button has been pressed
    if(isset($_POST["mysubmit"])) {

        // these are vars from the form
        $first_name = $_POST["first-name"];
        $last_name = $_POST["last-name"];

        $valid = 1; // assume everything is OK, go ahead and process form data

        if ($valid == 1) {
            // INSERT to the DB
            mysqli_query($con, "INSERT INTO personal_info(first_name, last_name)
                                VALUES('$first_name' , '$last_name')")
                                or die(mysqli_error($con));

            echo "Name successfully added!";
        }
    } //END of mysubmit

?>

<form id="myform" name="myform" method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>">
    Firstname: <input type="text" name="first-name" id="first-name">
    Lastname: <input type="text" name="last-name" id="last-name">
    <button type="submit" name="mysubmit" id="mysubmit">Submit</button>
</form>