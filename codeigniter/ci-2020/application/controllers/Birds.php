<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Birds extends CI_Controller {

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
        $data['heading'] = "The Birds of Alberta"; 
        $data['picture'] = "owl.jpg"; 
        $data['message'] = "<p>Birds (class Aves or clade Avialae) are feathered, winged, two-legged, warm-blooded, egg-laying vertebrates. Aves ranks as the tetrapod class with the most living species, approximately ten thousand. </p> 

        <p>Extant birds belong to the subclass Neornithes, living worldwide and ranging in size from the 5 cm (2 in) Bee Hummingbird to the 2.75 m (9 ft) Ostrich. The fossil record indicates that birds emerged within the theropod dinosaurs during the Jurassic period, around 150 million years ago. <br>Most researchers agree that modern-day birds are the only living members of the Dinosauria clade.</p>"; 

        // echo "<pre>"; 
        // print_r($data); 
        // echo "</pre>";

        $this->load->view('includes/header',$data); // here we add the $data array so that the $heading is available to the header view
        $this->load->view('bird_view',$data); // we need to pass the array to the view 
        $this->load->view('includes/footer');

    } 
    
    public function loon() 
    { 
        // echo "Birds - Loon";
        
        $data['heading'] = "The Loon"; 
        $data['picture'] = "loon.jpg"; 
        $data['message'] = "<p>The loon, the size of a large duck or small goose, resembles these birds in shape when swimming. Like ducks and geese but unlike coots (which are Rallidae) and grebes (Podicipedidae), the loon's toes are connected by webbing. The bird may be confused with cormorants (Phalacrocoracidae), not too distant relatives of divers and like them are heavy set birds whose bellies - unlike those of ducks and geese - are submerged when swimming.</p> 

        <p> Flying loons resemble a plump goose with a seagull's wings, relatively small in proportion to the bulky body. The bird holds its head pointing slightly upwards during swimming, but less so than cormorants do. In flight the head droops more than in similar aquatic birds.</p>"; 

        $this->load->view('includes/header',$data); // here we add the $data array so that the $heading is available to the header view
        $this->load->view('bird_view',$data); 
        $this->load->view('includes/footer');
    } 
    
    public function sparrow() 
    { 
        //echo "Birds - Sparrow";
        
        $data['heading'] = "The Sparrows"; 
        $data['picture'] = "sparrow.jpg"; 
        $data['message'] = "<p>One of the most common and widespread sparrows in North America. Fairly large with a long, rounded tail. Overall coarsely patterned with gray and brown, usually with more reddish-brown wings and tail. Look especially for thick brown streaks on the underparts and a broad dark mustache stripe. Significant variation in plumage geographically: relatively pale and rusty in the southwestern U.S.; blacker streaking in California; overall dusky in the Pacific Northwest.</p> 

        <p>Larger, longer-tailed and usually more rusty than Savannah Sparrow. Found in a variety of scrubby habitats both near and far from human development, especially edges of fields, often near water. Listen for husky chimp calls and melodic song with chips and trills.</p>"; 

        $this->load->view('includes/header',$data); // here we add the $data array so that the $heading is available to the header view 
        $this->load->view('bird_view',$data); 
        $this->load->view('includes/footer');
    }

    public function falcon() 
    { 
        //echo "Birds - Sparrow";
        
        $data['heading'] = "The Falcon"; 
        $data['picture'] = "falcon.jpg"; 
        $data['message'] = "<p>Adult falcons have thin, tapered wings, which enable them to fly at high speed and change direction rapidly. Fledgling falcons, in their first year of flying, have longer flight feathers, which make their configuration more like that of a general-purpose bird such as a broad-wing. This makes flying easier while learning the exceptional skills required to be effective hunters as adults.</p> 

        <p>The falcons are the largest genus in the Falconinae subfamily of Falconidae, which itself also includes another subfamily comprising caracaras and a few other species. All these birds kill with their beaks, using a tooth on the side of their beaks—unlike the hawks, eagles, and other birds of prey in the Accipitridae, which use their feet.</p>"; 

        $this->load->view('includes/header',$data); // here we add the $data array so that the $heading is available to the header view  
        $this->load->view('bird_view',$data); 
        $this->load->view('includes/footer');
    }
}
