
<?php

    class Mycal_model extends CI_Model {
        public $prefs;
        public function __construct()
        {
            //parent::Model();
            $this->prefs = array(
            'start_day'    => 'saturday',
            'month_type'   => 'long',
            'day_type'     => 'short',
            'show_next_prev' => TRUE,
            'next_prev_url'   => base_url().'/mycal/index/'
            );
            }
        public function getcalender($year , $month)
        {
            $this->load->library('calendar',$this->prefs); // Load calender library
            $data = array(
            3  => 'check',
            7  => 'check1',
            13 => 'bar',
            26 => 'ytr'
            );
            return $this->calendar->generate($year , $month , $data);
        }
    }