
<div class="row">
    <div class="col-md-12 text-center">
        <div class="jumbotron">
            <h1><?php echo $heading?></h1> 
            <p class="lead">This project is base on code igniter</p>
        </div>
    </div>
</div><br/>



<?php if(($results)) : ?> 
    
    <?php foreach($results as $row): ?> 

        <div class="alert alert-info clearfix">
            <h4 style="border-bottom: 1px solid gray"><?php echo $row->animal_name ?></h4><br/> 
            
            <p><?php echo  substr($row->description, 0, 300) ?></p>
            <a href="<?php echo base_url() . "crud/detail/" .$row->animal_id; ?>" class="btn btn-primary btn-sm">Read more</a>
        </div><br/>

    <?php endforeach;?> 
    
<?php endif;?>