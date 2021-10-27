<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <!-- link to CSS -->
    <link href="<?php echo base_url(); ?>css/styles.css" rel="stylesheet">

    <!-- link to google icon -->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">


    <script type="text/javascript"> 
        $(document).ready(function(){ 
            //console.log('ready');

            // fade #message if exists
            if($('#message').length){ 
                $( "#message" ).delay(3000).fadeOut({}, 3000); 
            }
        }); 
    </script>


    <title>
        <?php
            if(APP_NAME){ 
                $title = APP_NAME; 
            } 
            if(isset($heading)){ 
                $title = $title . " - " . $heading; 
            } 
            echo $title;
        ?>
    </title>
  </head>
  <body>

    <div class="container">
        
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <!-- <a class="navbar-brand" href="<?php echo base_url() ?>">Home</a>                                                                                                                                                                                                                                           -->
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                <ul class="navbar-nav">
                    <!-- <li class="nav-item active">
                        <a class="navbar-brand" href="<?php echo base_url()?>"> <i class="material-icons">home</i></a>
                    </li> -->
                    <!-- <li class="nav-item">
                        <a class="nav-link" href="#">Features</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Pricing</a>
                    </li> -->
                    <li class="nav-item active">
                        <a class="navbar-brand" href="<?php echo base_url()?>crud"><i class="material-icons">home</i></a>
                    </li>
                    <li class="nav-item active">
                        <a class="navbar-brand" href="<?php echo base_url()?>mycal">Calendar</a>
                    </li>
                    <!-- <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Article
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                            <a class="dropdown-item" href="<?php echo base_url()?>crud/write">Write an Article</a>
                        </div>
                    </li> -->
                    <!-- <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Birds
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                            <a class="dropdown-item" href="<?php echo base_url()?>birds">Birds Main</a> 
                            <a class="dropdown-item" href="<?php echo base_url()?>birds/loon">Loon</a> 
                            <a class="dropdown-item" href="<?php echo base_url()?>birds/sparrow">Sparrow</a>
                            <a class="dropdown-item" href="<?php echo base_url()?>birds/falcon">Falcon</a>
                        </div>
                    </li> -->

                    <li class="nav-item">
                        <?php if (!$this->ion_auth->logged_in()) : ?>
                            <a href="<?php echo base_url(); ?>auth/login" class="nav-link">Login</a>
                    </li>
                    <?php else : ?>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <?php $user = $this->ion_auth->user()->row();
                                echo $user->username; ?>
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="<?php echo base_url(); ?>crud/write">Write</a>
                                <!-- <a class="dropdown-item" href="<?php echo base_url(); ?>auth/change_password">Change Password</a> -->
                                <a class="dropdown-item" href="<?php echo base_url(); ?>auth/logout">Logout</a>
                            </div>
                        </li>
                    <?php endif ?>


                </ul>
            </div>

            <!-- <a href="<?php echo base_url()?>auth/login" class="btn btn-primary">Login</a> -->

            
            <!-- <?php if ($this->ion_auth->logged_in()) : ?> 
            <?php 
                $user_id = $this->ion_auth->user()->row()->id ; 
                $username = $this->ion_auth->user()->row()->username ; 
            ?>  -->
            <!-- Here you do your links & Bootstrap for the Logged in part: Links to logout, change password, and create article would be nice. --> 
            <!-- Logged in <?php echo $username; ?> 
            
            <?php else: ?> 
            <a href="<?php echo base_url()?>auth/login">Login </a> 
            <?php endif; ?> -->


        </nav> <br/>

    
        <?php $message = $this->session->flashdata('message'); ?> 
        <?php if ($message): ?> 
            <h3 class="alert alert-primary" id="message"><i class="material-icons">thumb_up</i>&nbsp;<?php echo $message ?></h3> 
        <?php endif; ?>

        <!-- This ends the header include -->