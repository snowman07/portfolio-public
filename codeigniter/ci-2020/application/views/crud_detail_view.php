

<div class="row">
    <div class="col-md-12 text-center">
        <div class="jumbotron">
            <h1>View Article</h1> 
        </div>
    </div>
</div><br/>
<!-- <h1><?php echo $heading?></h1> -->

<?php if(($results)) : ?> 
    <?php foreach($results as $row): ?> 
        <div class="row"> 
            <div class="col-md-12" style="display:flex; justify-content: space-between; border-bottom: 1px solid gray">
                <h3><?php echo $row->animal_name ?></h3> 

                <!-- To display the username -->
                <p style="font-style: italic;">Added by: <?php echo $row->username ?> on 
                    <?php $date = $row->timedate;
                            $newdate = date("F d, Y g:ia", strtotime($date));
                            echo $newdate        
                    ?>
                </p> 
            </div>
        </div> <br/><br/>
        <div class="row">
            <div class="col-md-12">
                <p><?php echo $this->typography->nl2br_except_pre($row->description); ?></p>
            </div>
        </div><br/>
        <div class="row">
            <div class="col-md-12">
                <?php if ($row->author_id == $this->session->userdata('user_id')): ?>
                    <a href="<?php echo base_url() ."crud/edit/" .$row->animal_id;?>" class="btn btn-primary btn-sm"> 
                        <i class="material-icons">edit</i>Edit
                    </a> 
                    <a href="<?php echo base_url() ."crud/delete/" .$row->animal_id;?>" class="btn btn-danger btn-sm" 
                        onClick="return confirm('Are you sure to delete data?')"> 
                        <i class="material-icons">delete</i>Delete
                    </a>
                <?php endif; ?>
                <br/><br/>
            </div>
        </div>          

    <?php endforeach;?> 

<?php else:?> 
    <p>No results</p> 
<?php endif; ?>