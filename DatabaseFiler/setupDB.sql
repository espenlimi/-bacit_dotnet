DROP DATABASE IF EXISTS propositio;
CREATE DATABASE propositio;
USE propositio;


DROP TABLE IF EXISTS employee;
DROP TABLE IF EXISTS team;
DROP TABLE IF EXISTS suggestion;
DROP TABLE IF EXISTS comments;

CREATE TABLE team(
team_id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
team_name varchar(30) NOT NULL); 

CREATE TABLE employee(
emp_id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
first_name varchar(30) NOT NULL, 
last_name varchar(30) NOT NULL, 
password varchar(30) NOT NULL, 
is_teamlead bool NOT NULL DEFAULT 0, 
is_admin bool NOT NULL DEFAULT 0, 
team_id int NOT NULL,
team_lead_id int,
CONSTRAINT Team_FK FOREIGN KEY (team_id) REFERENCES team(team_id),
CONSTRAINT Team_Lead_FK FOREIGN KEY (team_lead_id) REFERENCES team(team_id)
); 



CREATE TABLE suggestion(
suggestion_id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
title varchar(60) NOT NULL, 
description text NOT NULL, 
time_stamp datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
file_path varchar(60), 
status varchar(30) NOT NULL, 
emp_id int NOT NULL, 
ownership_emp_id int NOT NULL DEFAULT emp_id, 
CONSTRAINT Emp_Id_FK FOREIGN KEY (emp_id) REFERENCES employee(emp_id), 
CONSTRAINT Ownership_Emp_Id_FK FOREIGN KEY (ownership_emp_id) REFERENCES employee(emp_id)); 

CREATE TABLE comments(
comment_id int NOT NULL PRIMARY KEY AUTO_INCREMENT, 
emp_id int NOT NULL, 
time_stamp datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
suggestion_id int NOT NULL, 
description text NOT NULL, 
CONSTRAINT Com_Emp_Id_FK FOREIGN KEY (emp_id) REFERENCES employee(emp_id),
CONSTRAINT Sugg_Id_FK FOREIGN KEY (suggestion_id) REFERENCES suggestion(suggestion_id));

