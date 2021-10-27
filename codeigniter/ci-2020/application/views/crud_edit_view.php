    
    
    
    <div class="row">
        <div class="col-md-12 text-center">
            <div class="jumbotron">
                <h1>Edit Article</h1><br/>
            </div>
        </div>
    </div>

    <?php 
    if($results){ 
        foreach($results as $row){ 
            $animal_name = $row->animal_name; 
            $description = $row->description; 
            $id = $row->animal_id; 
            //echo $animal_name; //just to test 
        } 
    } 
    ?>

    <?php echo form_open_multipart("crud/edit/$id"); ?>
        <div class="form-group"> 
            <label for="animal_name">Title</label>

            <input type="text" name="animal_name"
                class="form-control form-width" 
                value="<?php echo set_value('animal_name',$animal_name); ?>"
            /> 
                
            <?php echo form_error('animal_name'); ?> 
        </div> 
                
        <div class="form-group"> 
            <label for="description">Content</label> 
            <textarea name="description" class="form-control form-width textarea-height" rows="10">
                <?php echo set_value('description',$description); ?>
            </textarea> 
            
            <?php echo form_error('description'); ?> 
        </div><br/>
        <div class="form-group">
            <!-- <input type="submit" value="Submit" class="btn" /> -->
            <button type="submit" class="btn btn-primary">Submit</button>
        </div> 
    </form>


