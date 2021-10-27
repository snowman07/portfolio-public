
    
    <h2><?php echo $heading; ?></h2> <!-- each array item in the controller become a PHP variable in the view--> 
    <div class="whatever">
        <?php 
            echo $message; 
            // echo "<img src=\"\" alt=\"\">";
        ?>
        <img src=<?php echo base_url() . "img/birds/$picture" ?> alt="bird">
    </div>
