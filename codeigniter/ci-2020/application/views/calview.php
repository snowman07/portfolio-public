

<?php
    defined('BASEPATH') OR exit('No direct script access allowed');
?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Welcome to CodeIgniter</title>

</head>
<body>
    <?php $this->load->view('includes/header');?><br/>
   
        <!-- <h1>Welcome to CodeIgniter!</h1> -->

        <div id="body" class="col-md-12 text-center">
            <?php echo $calender; ?>
        </div>

    <br/>
    <?php $this->load->view('includes/footer'); ?>

</body>
</html>