<?php 

    class Crud_model extends CI_Model { 
        
        function __construct() { 
            // Call the Model constructor 
            parent::__construct(); 
        } 
        
        function get_animals(){ 
            $query = $this->db->get('ci_animals'); 
            
            if ( $query->num_rows() > 0 ){ 
                return $query->result(); 
            }else{ 
                return FALSE; 
            } 
        } 

        //---------For display of whats in the db
        function get_animal_detail($id)
        { 
            $this->db->where('animal_id', $id, 'username'); 
            $this->db->join('users', 'users.id = ci_animals.author_id'); //JOIN; to display username
            $query = $this->db->get('ci_animals'); 
            
            if ( $query->num_rows() > 0 ){ 
                return $query->result(); 
            }else{ 
                return FALSE; 
            } 

            // //----JOIN here
            // $this->db->table('ci_animals');
            // $this->select('*');
            // $this->join('users', 'users.id = ci_animals.author_id');
            // $query = $this->get('users.username');
            // // echo "added by " . $query;

        }
        
        function insert_animal($data){ 
            $this->db->insert('ci_animals', $data); 
        }

        function edit_animal($data,$id){ 
            $this->db->where('animal_id', $id); 
            $this->db->update('ci_animals', $data); 
        }
        
        //------------------------------------//
        //----- START OF DELETE FUNCTION -----//

        function delete_animal($id) {
            $this->db->where('animal_id', $id);
            $this->db->delete('ci_animals');
            //return true;
        } 
        
        // reference: https://www.studentstutorial.com/codeigniter/delete-data-codeigniter
        //------ END OF DELETE FUNCTION ------//
        //------------------------------------//
    }