<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <!--THIS WILL DISPLAY THE IMAGE-->
    <?php
        include("connect.php");
    ?>

    <!-- <?php $result = mysqli_query($con, "SELECT * FROM personal_info"); ?>
    <?php while($row = mysqli_fetch_array($result)); ?>
        <div style="width:300px; float:left; margin:10px">
            <img src="originals/<?php echo $row["image"]; ?>" >
        </div>
    <?php endwhile; ?> -->

    
    <?php
        $result = mysqli_query($con, "SELECT * FROM personal_info")
    ?>
    <?php while($row = mysqli_fetch_array($result)); ?>
        echo $row["first_name"];
    <?php endwhile; ?>


</body>
</html>