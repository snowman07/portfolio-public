<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Error404 extends CI_Controller {

	/**
	 * Index Page for this controller.
	 *
	 * Maps to the following URL
	 * 		http://example.com/index.php/welcome
	 *	- or -
	 * 		http://example.com/index.php/welcome/index
	 *	- or -
	 * Since this controller is set as the default controller in
	 * config/routes.php, it's displayed at http://example.com/
	 *
	 * So any other public methods not prefixed with an underscore will
	 * map to /index.php/welcome/<method_name>
	 * @see https://codeigniter.com/user_guide/general/urls.html
	 */
	// public function index()
	// {
    //     $this->load->view('includes/header');
	// 	$this->load->view('home_view');
    //     $this->load->view('includes/footer');
    //     //echo "<h1>This is home.</h1>";
	// }

    // public function test()
    // {
    //     $this->load->view('includes/header');
    //     $this->load->view('test_view');
    //     $this->load->view('includes/footer');
    //     //echo "<h1>This is TEST function in Home controller</h1>";
    // }

    public function index() 
    { 
        $data['heading'] = "404 – Page Not Found."; 
        $data['picture'] = "owl.jpg"; 
        $data['message'] = "<p>Sorry. It appears the page you are looking for does not exist.</p>
                            <p>The reason........</p>"; 

        // echo "<pre>"; 
        // print_r($data); 
        // echo "</pre>";

        $this->load->view('includes/header'); 
        $this->load->view('bird_view',$data); // we need to pass the array to the view 
        $this->load->view('includes/footer');
    } 
}
