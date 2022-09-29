USE webAppDatabase;

CREATE OR REPLACE TABLE users (
    id INT PRIMARY KEY,
    name VARCHAR(20),
    email VARCHAR(30),
    phone VARCHAR(12)
);

CREATE OR REPLACE TABLE suggestions (
    id int primary key auto_increment,
    title varchar(20),
    name varchar(20),
    team varchar(20),
    description varchar(500),
    timeStamp varchar(255)
);


