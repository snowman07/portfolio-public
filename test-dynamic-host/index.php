<?php
    include("connect.php"); // this is the connection to the DB
?>

<?php
    // Lets set some vars for the folders
    $originalsFolder = "originals/";
    $thumbsFolder = "thumbs/";


    // if button has been pressed
    if(isset($_POST["mysubmit"])) {

        // these are vars from the form
        $first_name = $_POST["first-name"];
        $last_name = $_POST["last-name"];
        $image = $_FILES["myfile"]["name"]; //to add an image in the database

        $valid = 1; // assume everything is OK, go ahead and process form data

        if ($valid == 1) {

            // https://www.php.net/manual/en/function.move-uploaded-file.php
            if(move_uploaded_file($_FILES["myfile"]["tmp_name"], $originalsFolder . $_FILES["myfile"]["name"])) {
                
                // INSERT to the DB
                mysqli_query($con, "INSERT INTO personal_info(first_name, last_name, image)
                VALUES('$first_name' , '$last_name' , '$image')")
                or die(mysqli_error($con));

                echo "Upload successful and Name successfully added!";
            } else {
                echo "ERROR";
            }

            
        }
    } //END of mysubmit

?>

<!--To use file uploads, we MUST include the enctype attribute in the form tag enctype="multipart/form-data"-->
<form id="myform" name="myform" method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" enctype="multipart/form-data">
    Firstname: <input type="text" name="first-name" id="first-name"><br />
    Lastname: <input type="text" name="last-name" id="last-name"><br />
    Image Upload: <input 
            type="file"  
            name="myfile"
            value="<?php echo $filename ?>">
    <button type="submit" name="mysubmit" id="mysubmit">Submit</button>
</form>

<!-- <a href="retrieve.php">Display image</a><br/>
<a href="test.php">Click here to go to test page</a> -->
