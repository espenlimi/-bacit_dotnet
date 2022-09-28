USE webAppDatabase;

CREATE OR REPLACE TABLE users (
    id INT PRIMARY KEY,
    name VARCHAR(20),
    email VARCHAR(30),
    phone VARCHAR(12)
);

CREATE OR REPLACE TABLE suggestions (
    Id int primary key,
    Title varchar(20),
    Name varchar(20),
    Team varchar(20),
    Description varchar(500),
    TimeStamp datetime
);


