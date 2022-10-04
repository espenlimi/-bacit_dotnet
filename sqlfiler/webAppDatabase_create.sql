USE webAppDatabase;

CREATE OR REPLACE TABLE users (
    userId INT PRIMARY KEY,
    name VARCHAR(20),
    email VARCHAR(30),
    phone VARCHAR(12)
);

CREATE OR REPLACE TABLE suggestions (
    sugId int primary key auto_increment,
    title varchar(20),
    name varchar(20),
    team varchar(20),
    description varchar(500),
    timeStamp varchar(255)
);

CREATE OR REPLACE TABLE userSuggestions (
    userId INT, 
    sugId INT, 
    CONSTRAINT userSugPK
    PRIMARY KEY (userId, sugId),
    CONSTRAINT userSugFK
    FOREIGN KEY (userID) REFERENCES users(userId),
    CONSTRAINT sugUserFk
    FOREIGN KEY (sugId) REFERENCES suggestions(sugId)
);


