<?php
    include ("includes/header.php");
    
    $searchtext = trim($_POST["searchtext"]);
    //echo $term;
?>

<div class="jumbotron clearfix">
    <h1>Plant Search Result/s</h1>
</div>

<?php
    if(isset($_POST['searchsubmit']) && $searchtext != "") {

        $sql = "SELECT * FROM plant_catalog WHERE
                plant_name LIKE '%$searchtext%'"; // % - wildcard


        $result = mysqli_query($con, $sql);

        // Lets deal with NO results from this query

        if (mysqli_num_rows($result) > 0) {

            // Now, we have to loop thru all records and display to the user
            while($row = mysqli_fetch_array($result)){
                // echo $row["username"] . "<br>"; // $row["name-of-column"]
                // echo $row["address"] . "<br>";
                // echo $row["occupation"] . "<br>";
                // echo "<hr>"; // hr = horizontal row

                $plant_name = $row['plant_name'];
                $id = $row["id"];
                // $last_name = $row['last_name'];
                // $description = $row['description'];

                //echo $first_name;

                echo "\n <h3><a href=\"display.php?id=$id\">$plant_name</a></h3><br />";

                // for this project, we will simply echo all the output html. In future projectc, we will use Alt syntax
                // (ternary operators, etc.), for more HTML and less ECHO
                // echo "\n<h2>$first_name $last_name</h2>";
                // echo "\n<div><b>Description: </b><br><em>$description</em></div>";
                // echo "<br><br>";
            } // end of while 
        } else {
            echo "\n<div class=\"alert alert-warning\">No results</div>\n";
        }
    } // end of if
?>
<?php
  include ("includes/footer.php");
?>
