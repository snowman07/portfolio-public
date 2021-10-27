<h1><?php echo lang('login_heading');?></h1>
<p><?php echo lang('login_subheading');?></p>

<div id="infoMessage"><?php echo $message;?></div>


  <?php echo form_open("auth/login");?>

    <div class="form-group row">
      <div class="col-sm-2 col-form-label">
        <?php echo lang('login_identity_label', 'identity');?>
      </div>
        <?php echo form_input($identity);?>
    </div>

    <div class="form-group row">
      <div class="col-sm-2 col-form-label">
        <?php echo lang('login_password_label', 'password');?>
      </div>
        <?php echo form_input($password);?>
    </div>

    <p>
      <?php echo lang('login_remember_label', 'remember');?>
      <?php echo form_checkbox('remember', '1', FALSE, 'id="remember"');?>
    </p>


    <p><?php echo form_submit('submit', lang('login_submit_btn'));?></p>

  <?php echo form_close();?>


<p><a href="forgot_password"><?php echo lang('login_forgot_password');?></a></p>

<!-- REGISTER HERE -->
<p><a href="<?php echo base_url()?>register">Register a New Account</a></p>
<br/>