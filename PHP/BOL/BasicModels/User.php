<?php

class User implements JsonSerializable {

    public $Id;
    public $Name;
    public $UserName;
    public $Password;
    public $JobId;
    public $EMail;
    public $ManagerId;
    

    public function __construct($sqlRaw_) {
        
     
        $this->Id = $sqlRaw_['worker_id'];
         $this->Name = $sqlRaw_['name']; 
         $this->UserName = $sqlRaw_['user_name']; 
         $this->Password = $sqlRaw_['password']; 
         $this->EMail = $sqlRaw_['email'];
         $this->JobId = $sqlRaw_['job']; 
         $this->ManagerId = $sqlRaw_['manager']; 

       
    }
    public function jsonSerialize() {
        return get_object_vars($this);
    }

}

function test_variables() {
    
}