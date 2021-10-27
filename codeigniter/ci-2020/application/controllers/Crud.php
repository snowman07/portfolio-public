<?php 
    defined('BASEPATH') OR exit('No direct script access allowed'); 
    
    class Crud extends CI_Controller { 
        
        function __construct() { 
            parent::__construct(); 
            
            $this->load->helper('form'); // loading this for the entire class/controller /////this is Form Helper
            $this->load->library('form_validation'); // loading this for the entire class/controller 
            $this->load->database(); // ummm…ditto 
        } 
        
        // public function index() { 
        //     echo "CRUD"; 
        // } 

        public function index(){ 
            $data['heading'] = "List of Articles"; 
            $this->load->model('crud_model'); 
            $data['results'] = $this->crud_model->get_animals(); 
            
            // echo "<pre>"; 
            // print_r($data); 
            // echo "</pre>"; 

            $this->load->view('includes/header', $data); 
            $this->load->view('crud_read_view',$data); 
            $this->load->view('includes/footer');
        }


        public function detail($id) { 
            /* We need to add some security and a "graceful exit: in case of a URL manipulation or other error that prevents us from getting the required $id */ 
            if(!is_numeric($id)){ 
                /* if this parameter is missing, or wrong format...*/ 
                /* best to just redirect*/ 
                redirect('/', 'location'); 
            } 
            $this->load->library('typography'); 
            $data['heading'] = "Reading from a DB"; 
            $this->load->model('crud_model'); 
            $data['results'] = $this->crud_model->get_animal_detail($id); 
            
            $this->load->view('includes/header',$data); 
            $this->load->view('crud_detail_view',$data);
            $this->load->view('includes/footer'); 
        }// ENDOF detail


        public function write() { 
            // Validation Library was loaded in the constructor. 

            if (!$this->ion_auth->logged_in()) 
            { 
                redirect('/auth/login/'); 
            }
            else
            { 
                $data['author_id'] = $this->ion_auth->user()->row()->id; 
            }
            
            
            $this->form_validation->set_error_delimiters('<div class="alert alert-danger">', '</div>');
            $this->form_validation->set_rules('animal_name', 'Animal Name', 'required|min_length[3]|max_length[40]'); $this->form_validation->set_rules('description', 'Description', 'required|min_length[20]|max_length[2000]');

            if ($this->form_validation->run() == FALSE) { 
                $this->load->view('includes/header'); 
                $this->load->view('crud_write_view'); 
                $this->load->view('includes/footer'); 
            } else { 
                //echo "SUCCESS"; 
                // retrieve POSTED form data 
                $data['animal_name'] = $this->input->post('animal_name'); 
                $data['description']= $this->input->post('description'); 
                
                $this->load->model('crud_model'); 
                $this->crud_model->insert_animal($data);

                $this->session->set_flashdata('message', 'Insert Successful');


                redirect("crud/index", 'location');
            } 
        } 
        //ENDOF write


        public function edit($id) { // we change the name to edit from write and we add the $id parameter
            
            if(!is_numeric($id)){ 
                redirect('/', 'location'); 
            }


            $this->form_validation->set_error_delimiters('<div class="alert alert-danger">', '</div>');
            $this->form_validation->set_rules('animal_name', 'Animal Name', 'required|min_length[4]|max_length[40]'); $this->form_validation->set_rules('description', 'Description', 'required|min_length[20]|max_length[2000]');

            $this->load->model('crud_model'); // just moved this up so we can call the model function

            if ($this->form_validation->run() == FALSE) { 

                $data['results'] = $this->crud_model->get_animal_detail($id);

                $this->load->view('includes/header'); 
                $this->load->view('crud_edit_view',$data); // a new view here
                $this->load->view('includes/footer'); 
            } else { 
                //echo "SUCCESS"; 
                // retrieve POSTED form data 
                $data['animal_name'] = $this->input->post('animal_name'); 
                $data['description']= $this->input->post('description'); 
                
                $this->load->model('crud_model'); 
                //$this->crud_model->insert_animal($data); // make sure we remove this from our copy/paste of write 
                
                // and comment out or remove any redirects, etc. so we can see errors as we test

                //$this->session->set_flashdata('message', 'Insert Successful');
                //redirect("crud/index", 'location');

                $this->crud_model->edit_animal($data,$id);

                $this->session->set_flashdata('message', 'Edit Successful'); 
                redirect('crud/edit/' . $id, 'location');
            } 
        }
        //ENDOF edit


        // //------------------------------------//
        // //----- START OF DELETE FUNCTION -----//

        // public function delete() {
            
        //     $this->load->model('crud_model'); 
            
        //     $id=$this->input->get('animal_id');
        //     $this->crud_model->delete_animal($id);
        //     //echo "Successfully deleted!";
        //     $this->session->set_flashdata('message', 'Successfully deleted!'); 
        //     redirect('crud/');

        // } 

        // //------ END OF DELETE FUNCTION ------//
        // //------------------------------------//


        //------------------------------------//
        //----- START OF DELETE FUNCTION -----//

        public function delete($id) {
            
            $this->load->model('crud_model'); 
            
            $this->crud_model->delete_animal($id);
            //echo "Successfully deleted!";
            $this->session->set_flashdata('message', 'Successfully deleted!'); 
            redirect('crud/', 'location');

        } 

        //------ END OF DELETE FUNCTION ------//
        //------------------------------------//
    }