<?php
  include ("includes/header.php");
?>

<div class="jumbotron clearfix">
  <h1><?php echo APP_NAME ?></h1>
  <p class="lead">
    This is a final project in <i>DMIT 2025</i>. It will let buyers see the plants online.
    Users/buyers will see a bunch of plants with varying sizes, types and prices. <br>
  </p>
</div> <!--END of class="jumbotron clearfix" -->

<div class="row"> 
  <!------------------------------------------------------------------>
  <!--------------------  DISPLAY ALL PLANTS HERE -------------------->
  <!------------------------------------------------------------------>
  <div class="col-sm-9" style="display: flex; flex-wrap: wrap; justify-content: space-evenly;"> 
    
    <?php
      ///////////// DEFAULT QUERY: RETRIEVE EVERYTHING
      ///////////// IF NOTHING BELOW THEN THIS QUERY WILL STAND; OTHERWISE, IT WILL BE OVERWRITTEN
      $result = mysqli_query($con, "SELECT * FROM plant_catalog"); // SHOWS EVERYTHING

      //------------------------------------------------//
      //----------------  FILTERING DB  ----------------//
      $displayby = $_GET['displayby'];
      $displayvalue = $_GET['displayvalue'];
      if(isset($displayby) && isset($displayvalue)) {
        // HERE IS THE MAGIC: WE TELL OUR DB WHICH COLUMN TO LOOK IN, AND THEN WHICH VALUE FROM THAT COLUMN WE'RE LOOKING FOR
        $result = mysqli_query($con,"SELECT * FROM plant_catalog WHERE $displayby LIKE '$displayvalue' ") or die (mysql_error());   
      }
      //------------- END OF FILTERING DB --------------//
      //------------------------------------------------//

      //---------------------------------------------------//
      //--------  FILTERING DB USING BETWEEN QUERY  -------//
      $min = $_GET['min'];
      $max = $_GET['max'];
      if($displayby == "plant_price"){
        $result = mysqli_query($con,"SELECT * FROM plant_catalog WHERE plant_price BETWEEN '$min' AND '$max'");
      }
      //----  END OF FILTERING DB USING BETWEEN QUERY -----// 
      //---------------------------------------------------// 
    ?>

    <div class="square-cont">
      <!--------------------------------------------------------------------->
      <!-----------------  This is for the Thumbnail View. ------------------>
      <!------ This is where user can see the results of filter as well------>
      <?php while($row = mysqli_fetch_array($result)): ?> <!-- ternary operator with a colon ":" . THIS IS AN ALT SYNTAX-->
        
        <div style="float: left;
            width: 200px;
            height: 300px;
            border: 3px solid #ccc;
            border-radius: 10px;
            margin: 0 3px 10px 3px;
            padding:3px;"
            >
          
          <?php $id = ($row['id']); ?>
          <?php $plant_name = ($row['plant_name']); ?>
          <?php $plant_description = ($row['plant_description']); ?>
          <?php $plant_price = ($row['plant_price']); ?>
          <?php $plant_price = ($row['plant_image']); ?>
          <?php $plant_size = ($row['plant_size']); ?>
          <?php $plant_type = ($row['plant_type']); ?>
          <?php $plant_indoor = $row['plant_indoor']; ?>
          <?php $inventory = ($row['plant_inventory']); ?>
          <?php $inventory = ($row['plant_allseason']); ?>
          <?php $inventory = ($row['plant_bestseller']); ?> 

          <!----------------------------------------------------------------------------------->
          <!--------  THIS IS FOR IMAGES FROM SQUARE FOLDER, src is in the filezilla  ---------> 
          <!----------------------------------------------------------------------------------->

          <!----------------------------------------->
          <!-------- STYLE FOR HOVER IMAGES  -------->

          <style>
            .zoom {
              transition: transform .2s;             
            }
            .zoom:hover {
              -ms-transform: scale(1.1); /* IE 9 */
              -webkit-transform: scale(1.1); /* Safari 3-8 */
              transform: scale(1.1); 
            }
          </style>
          <!----- END OF STYLE FOR HOVER IMAGES  ---->
          <!----------------------------------------->
          <!-- onmouseover="shrinkImg(this)" onmouseout="normalImg(this)" -->
          <a href="display.php?id=<?php echo $row['id'] ?> ">
            <img class="zoom" src="uploads/square/<?php echo $row["plant_image"]; ?>" 
              style="display: block;
                    margin-left: auto;
                    margin-right: auto;
                    width: 100%;"
            >   
          </a><br/>

          <?php
            echo "<div class=\"square-img\">";
              echo "<center><b>" .$row["plant_name"] ."</center></b>\n";
              echo "<b>Price: $ </b>". $row["plant_price"] ."<br />\n";
              echo "<b>Size: </b>". $row["plant_size"] ."<br />\n";
            echo "</div>";
          ?>
        </div> <!--END of style-->
      <?php endwhile; ?>
      <!--------------  END OF This is for the Thumbnail View -------------->
      <!-------------------------------------------------------------------->
    </div>
  </div> 
  <!--END of col-sm-9-->

  <div class="col-sm-3">
    <!-------------------------------------->
    <!----------  FILTER SECTION  ---------->
    <section class="filter">
      <div class="alert alert-info">
        <?php
          include ("includes/filter.php");
        ?>
      </div>
    </section>
    <!-------  END OF FILTER SECTION ------->
    <!-------------------------------------->

    <section>
      <div class="alert alert-info"> 
        <h3><center>Alphabetical Links</h3></center>
        <?php
          $qry = "SELECT *, LEFT(plant_name, 1) AS first_char FROM plant_catalog 
                  WHERE UPPER(plant_name) BETWEEN 'A' AND 'Z'
                  ORDER BY plant_name";
          $result = mysqli_query($con,$qry);
          $current_char = '';
          while ($row = mysqli_fetch_assoc($result)) {
              if ($row['first_char'] != $current_char) {
                  $current_char = $row['first_char'];
                  $thisChar = strtoupper($current_char);
                  echo "<a href=\"index.php?displayby=plant_name&displayvalue=$thisChar%\">$thisChar</a> | ";
              }
          }
        ?>

      </div>
    </section>

    <!------------------------------------------>
    <!-------------  RANDOM PLANTS ------------->
    <section class="random">
      <div class="alert alert-info"> 
        <h3><center>Random Plants</h3></center>
        <div style="display: flex; flex-wrap: wrap; justify-content: space-evenly;">
          <?php   
            $randomPlants = mysqli_query($con, "SELECT * FROM plant_catalog ORDER BY RAND() LIMIT 1");
            while ($row = mysqli_fetch_array($randomPlants)){
              $plant_name = $row["plant_name"];
              $id = $row["id"];
              $plant_image = $row["plant_image"];

              // echo "<div style=\"float: left;
              //             width: 350px;
              //             height: 300px;
              //             border: 2px solid #ccc;
              //             margin-bottom: 20px;
              //             padding:3px;\"
              //       >";
              echo "<div style=\"           
                      border: 5px solid #ccc;
                      border-radius: 20px;
                      margin-bottom: 20px;
                      padding:15px;\"
                    >";
                //this will redirect user to display page
                echo "<center>" . $plant_name . "</center><br />" . "<a href=\"display.php?id=$id\"><img src=\"uploads/square/$plant_image\" /><br /></a>";
              echo "</div>";
            }
          ?>  
        </div>
      </div>
    </section>
    <!-----------  END OF RANDOM PLANTS  ----------->
    <!---------------------------------------------->

    <!---------------------------------------------->
    <!---------------  MEDIUM PLANTS --------------->
    <section class="random">
      <div class="alert alert-info"> 
        <h3><center>Medium Plants</h3></center>
        <div style="display: flex; flex-wrap: wrap; justify-content: space-evenly;">
          <?php   
            $randomPlants = mysqli_query($con, "SELECT * FROM plant_catalog WHERE plant_size LIKE 'medium' ORDER BY RAND() LIMIT 1");
            while ($row = mysqli_fetch_array($randomPlants)){
              $plant_name = $row["plant_name"];
              $id = $row["id"];
              $plant_image = $row["plant_image"];

              // echo "<div style=\"float: left;
              //             width: 350px;
              //             height: 300px;
              //             border: 2px solid #ccc;
              //             margin-bottom: 20px;
              //             padding:3px;\"
              //       >";
              echo "<div style=\"           
                      border: 5px solid #ccc;
                      border-radius: 20px;
                      margin-bottom: 20px;
                      padding:15px;\"
                    >";
                //this will redirect user to display page
                echo "<center>" . $plant_name . "</center><br />" . "<a href=\"display.php?id=$id\"><img src=\"uploads/square/$plant_image\" /><br /></a>";
              echo "</div>";
            }
          ?>  
        </div>
      </div>
    </section>
    <!-----------  END OF MEDIUM PLANTS  ----------->
    <!---------------------------------------------->

  </div> <!--END of col-sm-3-->
</div> <!--END of row-->

<?php
  include ("includes/footer.php");
?>

<!-- <script src="js/main.js">

</script> -->
