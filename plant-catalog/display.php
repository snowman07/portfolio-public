<!---------------------------------------------------------------------------->
<!--------------------  Page to display individual image  -------------------->
<!---------------------------------------------------------------------------->
<?php
  include ("includes/header.php");
?>

<div class="jumbotron clearfix">
  <h1><?php echo APP_NAME ?></h1>
  <p class="lead">
    This is image information.
  </p>
  <!-- <a class="btn btn-primary float-right" href="#" role="button">Button</a> -->
</div>

<?php 
  $id = $_GET["id"]; 
?>

<?php
  // Here, lets retrieve and list all images
  $result = mysqli_query($con, "SELECT * FROM plant_catalog WHERE id = '$id'");    
?>

<?php while($row = mysqli_fetch_array($result)): ?> <!--ternary operator with a colon ":" -->
  <!-- ALL of this is simple HTML, then I uses PHP "mixins" to grab the data-->
  <h2><?php echo $row["plant_name"]; ?></h2><br>
  <!--This is an alternate syntax-->
  <!--If the info in DB doesn't exist, there's no output -->
  <?php if($row["plant_description"]): ?>
      <p><b>Description: </b><?php echo $row["plant_description"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_price"]): ?>
      <p><b>Price: $</b><?php echo $row["plant_price"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_size"]): ?>
      <p><b>Size: </b><?php echo $row["plant_size"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_type"]): ?>
      <p><b>Type: </b><?php echo $row["plant_type"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_indoor"]): ?>
      <p><b>Plant Indoor:</b><?php echo $row["plant_indoor"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_inventory"]): ?>
      <p><b>Plant Inventory: </b><?php echo $row["plant_inventory"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_allseason"]): ?>
      <p><b>Plant All Season: </b><?php echo $row["plant_allseason"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_bestseller"]): ?>
      <p><b>Plant Best Seller: </b><?php echo $row["plant_bestseller"]; ?></p>
  <?php endif; ?>
  <?php if($row["plant_image"]): ?>
      <img src="uploads/display/<?php echo $row["plant_image"]; ?>" > <br>
  <?php endif; ?> 
<?php endwhile; ?> <!-- to end while loop-->

<!--simple trick to add space-->
<div>
    <br /><br />
</div>

<?php
  include ("includes/footer.php");
?>
