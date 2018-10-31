# Finaly project - Task Managment

## Using this technologies:
* MySql
* Web api
* WinForms
* Angular

## System diagram:
![picture](step1.png)

***
## Web api
### Models
* Worker:
    * Id - int 
    * Name - string - minLength: 2, maxLength:15, reqiered
    * UserName - string - minLength: 2, maxLength:10, reqiered, uniqe
    * Password - string - minLength: 6, maxLength:10, reqiered
    * Email - string  ,minLength: 6, maxLength:30,reqiered
    * job - int - will contain the id of job's type
    * ManagerName - string -minLength: 2, maxLength:15   
* Project:
    * Id - int 
    * Name - string -  minLength: 2, maxLength:25,uniqe, reqiered,
    * CustomerName - string -  minLength: 2, maxLength:15, reqiered,
    * TeamLeader - `Worker` type - reqiered-  will contain the id of the project manager
    * DevelopHoures - int - reqiered
    * QAHoures - int - reqiered
    * UIUXHoures - int - reqiered
    * StartDate - date - reqiered 
    * EndDate - date - reqiered, must be after `StartDate`
* ProjectWorker:
    * Id - int 
    * Worker - `Worker` type
    * Project - `Project` type
    * AllocatedHours - int 
    * WorkHours - int

### Controllers
* Home controller:
    * Post - sign in to the system    
    requierd data: 
        * userName
        * password
    If the user is valid - we will check his status and navigate him to the currect main page, Else - we will return a matching error
* Manager controller:
    * Post - add a new project   
    requierd data: 
        * ProjectName
        * CostumerName
        * TeamLeaderName
        * DevelopHoures
        * QAHoures
        * UIUXHoures
        * StartDate 
        * EndDate 
    If the project details is valid - we will add the project to the DB
    * Post - add a new worker
    requierd data: 
          * Name
          * UserName 
          * Password 
          * Email 
          * job 
          * Manager 
    * Get - get all the details that the manager need to the report
    * Put - edit worker's details      
    * Delete - the manager can delete worker
* TeamLeader controller:
    * Get - get the details and status of the current project that the teamLeader manage
    * Get - get all the hours that used in this month 
    * Get - get worker's hours to each worker
    * Put - update worker's hours
* Worker controller:
    * Put - update work hours
    * Post - the worker can send massage to contact with the office
    * Get - get the worker details
    * Get - get the task that he need to do
    * Get - get the hours that he worked this month

***
## WinForms +  Angular
### Manager page
![picture](step2.png)   
![picture](step3.png)   
![picture](step4.png)  
### Manager page
![picture](step5.png)   
![picture](step6.png)  
![picture](step7.png) 
### Worker page  
![picture](step8.png) 
![picture](step9.png) 
![picture](step10.png) 

