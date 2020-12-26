<!-- this is a secured page -->
<?php
    session_start();
    //echo session_id();

    //if(!isset($_SESSION['aasdffrtgfb'])) {        //<-- from here     isset means something is set
    if(isset($_SESSION['aasdffrtgfbqw'])) {                //<-- to here
        //header("Location: login.php");
        //echo "Logged in";

        // //Added this!
        // $_SESSION['aasdffrtgfbqw'] = TRUE;
        // header('location:' .$_SESSION['redirectURL']);

    } else {
        //echo "NOT logged in";
        header("Location: login.php");
    }
?>


<?php
    include("../includes/header-without-search.php");

    /*
    1. Get all existing items and create dynamic nav system
    2. Prepop form fields with the selected item data
    3. If user submit the form, UPDATE the item in the DB
    */

    // Lets retrieve our "page setter" variable that will define the content, In this case, which item do we edit
    $pageID = $_GET['id'];
    //echo "<h1>$pageID</h1>";

    // but, what happens if we  just come to edit and havent yet selected an item to edit? Lets have a default item that is chosen as soon as we load the page

    if(!isset($pageID)) {
        $tmp = mysqli_query($con, "SELECT id FROM plant_catalog LIMIT 0 "); //from LIMIT 1
        while($row = mysqli_fetch_array($tmp)){
			$pageID = $row["id"];	// here is our default value
		}
	}
    //echo "<h1>$pageID</h1>";

    
    // Step 3: If user submitted the form, then do UPDATE

	// if statement if the button has been pressed. Test that too!
	if(isset($_POST["mysubmit"])) {

        $plant_name = trim($_POST["plant-name"]);
        $plant_description = trim($_POST["plant-description"]);
        $plant_price = trim($_POST["plant-price"]);
        $plant_size = trim($_POST["plant-size"]);
        $plant_type = trim($_POST["plant-type"]);
        $plant_indoor = trim($_POST["plant-indoor"]);
        $plant_inventory = trim($_POST["plant-inventory"]);
        $plant_allseason = trim($_POST["plant-allseason"]);
        $plant_bestseller = trim($_POST["plant-bestseller"]);
 
		// VALIDATION HERE!!!

		// lets set some variables for later use
		$valid = 1;	//assume everyting is OK, go ahead and process form data
			// vars here are for bootstrap design
		$msgPreError = "\n<div class=\"alert alert-danger\" role=\"alert\">";
		$msgPreSuccess = "\n<div class=\"alert alert-primary\" role=\"alert\">";
		$msgPost = "\n</div>";

        //Plant Name validation
        if((strlen($plant_name) < 1) || (strlen($plant_name) > 100)) {
            $valid = 0;
            $valPlantNameMsg = "\nPlease enter plant name from 1 to 100 characters";
        }
        //end of Plant Name validation

        //Plant Description validation
        if($plant_description != "") {
			if((strlen($plant_description) < 3) || (strlen($plant_description) > 1000)) {
				$valid = 0;
				$valPlantDescriptionMsg = "Description must be 3 to 1000 characters";
			}
		}
        //end of Plant Description validation

        //Plant Price Validation
        if($plant_price == "") {
            $valid = 0;
			$valPlantPriceMsg = "\nPlease enter price";
        }
        //END of Plant Price Validation

        //Plant Size Validation
        if($plant_size == "") {
			$valid = 0;
			$valPlantSizeMsg = "Please select a plant size";
		}
        //END of Plant Size Validation

        //Plant Type Validation
        if($plant_type == "") {
			$valid = 0;
			$valPlantTypeMsg = "Please select a plant type";
		}
        //END of Plant Type Validation

        //Plant Indoor Validation
        if($plant_indoor == "") {
            $valid = 0;
            $valPlantIndoorMsg = "Please select Yes or No.";
        }
        //END of Plant Indoor Validation

        //Plant Inventory Validation
        if($plant_inventory == "") {
            $valid = 0;
            $valPlantInventoryMsg = "Please select In Stock or Out of Stock.";
        }
        //END of Plant Inventory Validation

        //Plant All Season Validation
        if($plant_allseason == "") {
            $valid = 0;
            $valPlantAllSeasonMsg = "Please select Yes or No.";
        }
        //END of Plant All Season Validation

        //Plant Best Seller Validation
        if($plant_bestseller == "") {
            $valid = 0;
            $valPlantBestSellerMsg = "Please select Yes or No.";
        }
        //END of Plant Best Seller Validation


		//SUCCESS!!! If boolean ($valid) is still 1, then user form data is good, go ahead and process this form
		if($valid == 1) {

            // THIS IS TO UPDATE THE EDIT PAGE
            // doNOT add a comma after the last item
            //column_name = $php variable
			mysqli_query($con, "UPDATE plant_catalog SET 
                    plant_name = '$plant_name', 
                    plant_description = '$plant_description',
                    plant_price = '$plant_price',
                    plant_size = '$plant_size',
                    plant_type = '$plant_type',
                    plant_indoor = '$plant_indoor',
                    plant_inventory = '$plant_inventory',
                    plant_allseason = '$plant_allseason',
                    plant_bestseller = '$plant_bestseller'
                    WHERE id = '$pageID'") or die(mysqli_error($con));
        
            $msgSuccess = "Plants has been updated.";

			// IF SUCCESS, form will be blank
			// $title = "";
			// $message = "";
        }
        
    } // END of if
    
    // //==========================================
    // /*Step 1: Create dynamic nav system */

    // $result = mysqli_query($con, "SELECT * FROM arr_blog");

    // // Now, we have to loop thru all records and display to the user

    // while($row = mysqli_fetch_array($result)){
    //     $thisTitle = $row["arr_title"];
    //     $thisId = $row["id"];

    //     // from this data, create some links which shows the character names to the user

    //     $editLinks .= "\n<a href=\"edit.php?id=$thisId\">$thisTitle</a><br>";

    //     /* Query string syntax: pagename.php?var=value&var2=value2&var3=value3 */
    
    // } // end of while
    // //==========================================
    

    /* Step 2: Prepop form fields with existing values for selected item */
    $result = mysqli_query($con, "SELECT * FROM plant_catalog WHERE id = '$pageID'");

    // Now, we have to loop thru all records and display to the user
    while($row = mysqli_fetch_array($result)){
        $plant_name = $row["plant_name"];
        $plant_description = $row["plant_description"];
        $plant_price = $row["plant_price"];
        $plant_size = $row["plant_size"];
        $plant_type = $row["plant_type"];
        $plant_indoor = $row["plant_indoor"];
        $plant_inventory = $row["plant_inventory"];
        $plant_allseason = $row["plant_allseason"];
        $plant_bestseller = $row["plant_bestseller"];
    }
    //echo $first_name . " " . $last_name . " " . $age . " " . $occupation . " " . $description;
?>

<div class="jumbotron clearfix">
  <h1>Edit Plants</h1>
  <p class="lead">
    You can edit plants here.
  </p>
  <a class="btn btn-primary float-right" href="logout.php" role="button">Logout</a>
</div>

<div class="row"> 

    <div class="col-sm-5">
		<div class="alert alert-info">
            <p><b>Select plants:</b></p>
            <select name="entryselect" id="entryselect" class="form-control" onchange="go()"> <!-- id="entryselect"-->
                <option value="">---Select here---</option> <!--selected="selected"-->
                <!--figure out how to prepopulate the select option-->
                <!--
                    <option value="<?php echo $thisTitle?>"<?php if(isset($thisTitle) && ($thisTitle == $thisId)) {echo "selected";} ?>></option>
                -->
                <!--
                <option value="<?php echo $thisTitle?>"<?php if(isset($thisTitle)) {echo "selected";} ?>></option>
                -->
                <?php  
                    $result = mysqli_query($con, "SELECT * FROM plant_catalog ORDER BY id");// added ORDER BY id to sort option select in ASC
                    while($row = mysqli_fetch_array($result)){
                        $thisPlantName = $row["plant_name"];
                        $thisId = $row["id"];
                        // //from this data, show the option of titles to user
                        // $titleQueryString = "edit.php?id=$thisId";
                        
                        // //echo "<option value=\"$titleOptionLink\">$thisTitle</option>";
                        // echo "\n<option value=\"$titleQueryString\">$thisTitle</option>";
                       echo "\n<option value=\"edit.php?id=$thisId\">$thisPlantName</option>";
                    }
                ?>        
            </select>            
		</div>
	</div> <!-- END of col-sm-4 -->

    <div class="col-sm-7">
        <div class="alert alert-info">
            <?php
                /*
                $_SERVER['REQUEST_URI'] will retain the necessary Query String (appended URL) info <-- use this for form updates
                $_SERVER['PHP_SELF'] will NOT retain the necessary Query String (appended URL) info
                */
            ?>

            <form id="myform" name="myform" method="post" action="<?php echo htmlspecialchars($_SERVER['REQUEST_URI']); ?>"> <!--from PHP_SELF to REQUEST_URI-->
                <!-- <div class="form-group">
                    <label for="alpha">Alpha:</label>
                    <input type="text" name="alpha" class="form-control">
                </div>
                <div class="form-group">
                    <label for="beta">Beta:</label>
                    <textarea name="beta" class="form-control"></textarea>
                </div>
                <div class="form-group">
                    <label for="submit">&nbsp;</label>
                    <input type="submit" name="submit" class="btn btn-info" value="Submit">
                </div> -->

                <?php
                    if($msgSuccess) {
                        echo $msgPreSuccess.$msgSuccess.$msgPost;
                    }
                ?>

                <!--start of Plant Name-->
                <div class="form-group">
                    <label for="plant-name">Plant Name</label>
                    <input 
                        type="text"
                        class="form-control"
                        name="plant-name"
                        placeholder="Enter plant name here"
                        value="<?php echo $plant_name; // prepopulate the value type text input?>"
                    >
                    <?php
                        if($valPlantNameMsg) { echo $msgPreError. $valPlantNameMsg. $msgPost; } // this is validation
                    ?>
                </div>
                <!--end of Plant Name-->

                <!--start of Plant Description-->
                <div class="form-group">
                    <label for="plant-description">Plant Description</label>
                    <textarea class="form-control" name="plant-description" rows="10"><?php if($plant_description) {echo $plant_description;} ?></textarea>
                    <?php
                        if($valPlantDescriptionMsg) { echo $msgPreError. $valPlantDescriptionMsg. $msgPost; }
                    ?>
                </div>
                <!--end of Plant Description-->


                <!--Plant Price-->
                <div class="form-group">
                    <label for="plant-price">Plant Price</label>
                    <input 
                        type="number"
                        class="form-control"
                        name="plant-price"
                        placeholder="Enter plant price here"
                        value="<?php echo $plant_price; // prepopulate the value type text input?>"
                    >
                    <?php
                        if($valPlantPriceMsg) { echo $msgPreError. $valPlantPriceMsg. $msgPost; } // this is validation
                    ?>
                </div>
                <!--Plant Price-->

                <!--Plant Size-->
                <div class="form-group">
                    <label for="plant-size">Plant Size</label>
                    <select class="form-control" name="plant-size">
                        <option value="">---Select size---</option>
                        <!--this serve as the placeholder-->
                        <option value="small" <?php if(isset($plant_size) && $plant_size == "small") {echo "selected";} ?>>Small</option>
                        <option value="medium" <?php if(isset($plant_size) && $plant_size == "medium") {echo "selected";} ?>>Medium</option>
                        <option value="large" <?php if(isset($plant_size) && $plant_size == "large") {echo "selected";} ?>>Large</option>
                        <!-- if(isset($province) && $province == "AB") {echo "selected";}  to prepop select options -->
                    </select>
                    <?php
                        if($valPlantSizeMsg) { echo $msgPreError. $valPlantSizeMsg. $msgPost; }
                    ?>
                </div>
                <!--END OF Plant Size-->

                <!--Plant Type-->
                <div class="form-group">
                    <label for="plant-type">Plant Type</label>
                    <select class="form-control" name="plant-type">
                        <option value="">---Select plant type---</option>
                        <!--this serve as the placeholder-->
                        <option value="common" <?php if(isset($plant_type) && $plant_type == "common") {echo "selected";} ?>>Common</option>
                        <option value="flowering" <?php if(isset($plant_type) && $plant_type == "flowering") {echo "selected";} ?>>Flowering</option>
                        <option value="lowlight" <?php if(isset($plant_type) && $plant_type == "lowlight") {echo "selected";} ?>>Lowlight</option>
                        <option value="cactus" <?php if(isset($plant_type) && $plant_type == "cactus") {echo "selected";} ?>>Cactus</option>
                        <!-- if(isset($province) && $province == "AB") {echo "selected";}  to prepop select options -->
                    </select>
                    <?php
                        if($valPlantTypeMsg) { echo $msgPreError. $valPlantTypeMsg. $msgPost; }
                    ?>
                </div>
                <!--END OF Plant Type-->

                <!--Plant Indoor-->
                <div class="form-group">
                    <label for="plant-indoor">Plant Indoor</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-indoor" value="yes" <?php if(isset($plant_indoor) && $plant_indoor == "yes"){echo "checked";} ?>>Yes
                        </label>
                    </div>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-indoor" value="no" <?php if(isset($plant_indoor) && $plant_indoor == "no"){ echo "checked";} ?>>No
                        </label>
                    </div>
                    <?php
                        if($valPlantIndoorMsg) { echo $msgPreError. $valPlantIndoorMsg. $msgPost; }
                    ?>
                </div>
                <!--END of Plant Indoor-->

                <!--Plant Inventory-->
                <div class="form-group">
                    <label for="plant-inventory">Plant Inventory</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-inventory" value="in-stock" <?php if(isset($plant_inventory) && $plant_inventory== "in-stock"){echo "checked";} ?>>In Stock
                        </label>
                    </div>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-inventory" value="out-of-stock" <?php if(isset($plant_inventory) && $plant_inventory == "out-of-stock"){ echo "checked";} ?>>Out of Stock
                        </label>
                    </div>
                    <?php
                        if($valPlantInventoryMsg) { echo $msgPreError. $valPlantInventoryMsg. $msgPost; }
                    ?>
                </div>
                <!--END of Plant Inventory-->

                <!--Plant All Season-->
                <div class="form-group">
                    <label for="plant-allseason">Plant All Season</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-allseason" value="yes" <?php if(isset($plant_allseason) && $plant_allseason == "yes"){echo "checked";} ?>>Yes
                        </label>
                    </div>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-allseason" value="no" <?php if(isset($plant_allseason) && $plant_allseason == "no"){ echo "checked";} ?>>No
                        </label>
                    </div>
                    <?php
                        if($valPlantAllSeasonMsg) { echo $msgPreError. $valPlantAllSeasonMsg. $msgPost; }
                    ?>
                </div>
                <!--END of Plant All Season-->

                <!--Plant Best Seller-->
                <div class="form-group">
                    <label for="plant-bestseller">Plant Best Seller</label>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-bestseller" value="yes" <?php if(isset($plant_bestseller) && $plant_bestseller == "yes"){echo "checked";} ?>>Yes
                        </label>
                    </div>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="radio" class="form-check-input" name="plant-bestseller" value="no" <?php if(isset($plant_bestseller) && $plant_bestseller == "no"){ echo "checked";} ?>>No
                        </label>
                    </div>
                    <?php
                        if($valPlantBestSellerMsg) { echo $msgPreError. $valPlantBestSellerMsg. $msgPost; }
                    ?>
                </div>
                <!--END of Plant Best Seller-->



                <!-- Submit button -->
                <button type="submit" name="mysubmit" class="btn btn-primary mb-2">
                    Submit
                </button>
                <!-- End of Submit button -->
            </form>

            <!--Here we will put our Delete links-->
            <!-- <button type="submit" name="mysubmit" class="btn btn-primary mb-2">
            Submit
            </button> -->
            <button class="btn btn-danger">
                <a href="delete.php?id=<?php echo $pageID ?>" onclick="return confirm('Are you sure?')">Delete Character</a>
                <!--onClick is an "inline JS confrim"-->
            </button>
        </div>
    </div> <!-- END OF col-sm-8-->

    <!--There's an echo $editLinks; here!!-->



</div> <!--END of class="row"-->

<?php
	include("../includes/footer.php");
?>

