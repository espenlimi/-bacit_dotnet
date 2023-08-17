--drop database webAppDatabase;
create database if not exists webAppDatabase;
use webAppDatabase;
create table if not EXISTS users
(
    Id int not null unique auto_increment,
    Name varchar(255),
    Email varchar(255) UNIQUE,
   
    CONSTRAINT U_User_ID_PK PRIMARY KEY (Id)
);

create table if not EXISTS AspNetRoles
(
    Id varchar(255) not null,
    Name varchar(255),
    NormalizedName  varchar(255),
    ConcurrencyStamp  varchar(255),
    CONSTRAINT U_ROLE_ID_PK PRIMARY KEY (Id)
);
insert into AspNetRoles(id, Name, NormalizedName) values('Administrator', 'Administrator', 'Administrator');
create table if not EXISTS AspNetUsers
(
         Id varchar(255) not null unique,
         UserName varchar(255),
         NormalizedUserName varchar(255),
         Email varchar(255),
         NormalizedEmail varchar(255),
         EmailConfirmed bit not null,
         PasswordHash varchar(255),
         SecurityStamp varchar(255),
         ConcurrencyStamp varchar(255),
         PhoneNumber varchar(50),
         PhoneNumberConfirmed bit not null,
         TwoFactorEnabled bit not null,
         LockoutEnd TIMESTAMP,
         LockoutEnabled bit not null,
         AccessFailedCount int not null,
          CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
);
create table if not EXISTS AspNetUserTokens
(
    UserId varchar(255) not null,
    LoginProvider varchar(255) not null ,
    Name  varchar(255) not null,
    Value  varchar(255),
    CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId, LoginProvider)
);

create table if not EXISTS AspNetRoleClaims
(
    Id int UNIQUE auto_increment,
    ClaimType varchar(255) not null ,
    ClaimValue  varchar(255) not null,
    RoleId  varchar(255),
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    foreign key(RoleId) 
        references AspNetRoles(Id)
);      

 create table if not EXISTS AspNetUserClaims
(
    Id int UNIQUE auto_increment,
    ClaimType varchar(255) ,
    ClaimValue  varchar(255),
    UserId  varchar(255),
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    foreign key(UserId) 
        references AspNetUsers(Id)
);           

 create table if not EXISTS AspNetUserLogins
(
    LoginProvider int UNIQUE auto_increment,
    ProviderKey varchar(255) not null ,
    ProviderDisplayName  varchar(255) not null,
    UserId  varchar(255) not null,
    CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider),
    foreign key(UserId) 
        references AspNetUsers(Id)
);         

 create table if not EXISTS AspNetUserRoles
(
    UserId varchar(255) not null,
    RoleId varchar(255) not null,
    CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId,RoleId),
    foreign key(UserId) 
        references AspNetUsers(Id),
    foreign key(RoleId) 
        references AspNetRoles(Id)
); 

        
     