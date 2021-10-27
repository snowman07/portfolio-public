
<?php
defined('BASEPATH') OR exit('No direct script access allowed');
class Mycal extends CI_Controller 
{
    public function index($year = NULL , $month = NULL)
    {

        $this->load->model('Mycal_model');
		$data['calender'] = $this->Mycal_model->getcalender($year , $month);
		$this->load->view('calview', $data);


        // $prefs = array(
        //     'start_day'    => 'saturday',
        //     'month_type'   => 'long',
        //     'day_type'     => 'short',
        //     'show_next_prev' => TRUE,
        //     'next_prev_url'   => base_url().'/mycal/index/'
        // );

        // $this->load->library('calendar', $prefs); // Load calender library
        // echo $this->calendar->generate($year , $month);
    }

    // public function index($year = NULL , $month = NULL)
	// {
	// 	$this->load->model('Mycal_model');
	// 	$data['calender'] = $this->Mycal_model->getcalender($year , $month);
	// 	$this->load->view('calview', $data);
	// }

}