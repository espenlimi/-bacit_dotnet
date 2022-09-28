create database if not exists webAppDatabase;
use webAppDatabase;
create table if not EXISTS users
(
    Id              integer UNIQUE auto_increment,
    Name        varchar(255),
    Email     varchar(255) UNIQUE,
    Password        varchar(255) not null,
    EmployeeNumber        varchar(255) not null UNIQUE,
    Team        varchar(255) not null,
    Role        varchar(255) not null,
    CONSTRAINT U_User_ID_PK PRIMARY KEY (Id)
);
insert into users(Name, Email, Password,EmployeeNumber,Team, Role ) values('Hans Gruber', 'hans@gruber.net', 'MrCowboy', '1','BadGuys','Villain');
insert into users(Name, Email, Password,EmployeeNumber,Team, Role ) values('John McClane', 'jmcclane@nypd.com', 'yippekayay', '2','GoodGuys','Hero');
insert into users(Name, Email, Password,EmployeeNumber,Team, Role ) values('Colin Powell', 'cpowell@lapd.com', 'twinkie', '3','GoodGuys','Sidekick');
insert into users(Name, Email, Password,EmployeeNumber,Team, Role ) values('Mr Takagi', 'thebigcheeze@nakatomi.com', 'investments', '4','GoodGuys','CEO');
