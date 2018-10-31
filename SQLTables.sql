
CREATE DATABASE  `task_managment`

CREATE TABLE IF NOT EXISTS `task_managment`.`access` (
  `access_id` INT NOT NULL AUTO_INCREMENT,
  `name` NVARCHAR(15) NOT NULL,
  PRIMARY KEY (`access_id`)
 )ENGINE=INNODB;

CREATE TABLE IF NOT EXISTS `task_managment`.`jobs` (
  `job_id` INT NOT NULL AUTO_INCREMENT,
  `name` NVARCHAR(15) NOT NULL,
  PRIMARY KEY (`job_id`)
 )
ENGINE = InnoDB
SELECT worker_id FROM task_managment.workers WHERE user_name='mmmm'
delete from task_managment.workers where worker_id!=6
SELECT * FROM task_managment.workers
CREATE TABLE IF NOT EXISTS `task_managment`.`workers` (
  `worker_id` INT NOT NULL AUTO_INCREMENT,
  `name` NVARCHAR(15) NOT NULL,
  `user_name` NVARCHAR(10) NOT NULL,
  `password` NVARCHAR(10) NOT NULL,
  `email` NVARCHAR(30) NOT NULL,
  `job` INT NULL,
  `manager` INT NULL,
  PRIMARY KEY (`worker_id`),
 
  CONSTRAINT `fk_job`
    FOREIGN KEY (`job`)
    REFERENCES `task_managment`.`jobs` (`job_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_manager`
    FOREIGN KEY (`manager`)
    REFERENCES `task_managment`.`workers` (`worker_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
CREATE TABLE IF NOT EXISTS `task_managment`.`projects` (
  `project_id` INT NOT NULL AUTO_INCREMENT,
  `name` NVARCHAR(15)NOT NULL,
  `customer` NVARCHAR(15) NOT NULL,
  `team_leader` INT NOT NULL,
  `develop_houres` INT NOT NULL,
  `qa_houres` INT NOT NULL,
  `ui_ux_houres` INT NOT NULL,
  `start_date` DATE NOT NULL,
  `end_date` DATE NOT NULL,
  PRIMARY KEY (`project_id`),
  CONSTRAINT `check_end_date` CHECK (end_date>start_date),
  CONSTRAINT `fk_team_leader`
    FOREIGN KEY (`team_leader`)
    REFERENCES `task_managment`.`workers` (`worker_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
     
    )
ENGINE = InnoDB

INSERT INTO task_managment.projects VALUES (0,'ProjectA','cA',5,300,250,100,'02/02/2018 00:00:00','07/07/2018 00:00:00')
select * from task_managment.projects


CREATE TABLE IF NOT EXISTS `task_managment`.`job_access` (
  `job_access_id` INT NOT NULL AUTO_INCREMENT,
  `job_id` INT NOT NULL,
  `access_id` INT NOT NULL,
  PRIMARY KEY (`job_access_id`),
  CONSTRAINT `fk_jobs`
    FOREIGN KEY (`job_id`)
    REFERENCES `task_managment`.`jobs` (`job_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_access`
    FOREIGN KEY (`access_id`)
    REFERENCES `task_managment`.`access` (`access_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB

CREATE TABLE IF NOT EXISTS `task_managment`.`work_hours` (
  `work_hours_id` INT NOT NULL AUTO_INCREMENT,
  `project_work_id` INT NOT NULL,
  `date` DATE NOT NULL,
  `start` TIME NULL,
  `end` TIME NULL,
  PRIMARY KEY (`work_hours_id`),
 
  CONSTRAINT `fk_project_worker`
    FOREIGN KEY (`project_work_id`)
    REFERENCES `task_managment`.`project_workers` (`project_worker_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB

CREATE TABLE IF NOT EXISTS `task_managment`.`project_workers` (
  `project_worker_id` INT NOT NULL AUTO_INCREMENT,
  `worker_id` INT NOT NULL,
  `project_id` INT NOT NULL,
  `allocated_hours` FLOAT NULL,
 
  PRIMARY KEY (`project_worker_id`),

  CONSTRAINT `fk_worker`
    FOREIGN KEY (`worker_id`)
    REFERENCES `task_managment`.`workers` (`worker_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_project`
    FOREIGN KEY (`project_id`)
    REFERENCES `task_managment`.`projects` (`project_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB

select * from jobs

INSERT INTO jobs
VALUES(
0,'developer'
);
INSERT INTO access
VALUES(
0,'update workHours'
)
delete from access 
where access_id=4
