USE webAppDatabase;

drop table teamUser;
drop table suggestions;
drop table users;
drop table subTeam;
drop table team;

CREATE TABLE users (
    userId INT auto_increment PRIMARY KEY,
    name VARCHAR(20),
    email VARCHAR(30),
    phone VARCHAR(12)
);

CREATE TABLE suggestions (
    sugId int auto_increment primary key,
    title varchar(20),
    teamId INT,
    description varchar(500),
    timeAdded TIMESTAMP,
    userId INT,
    CONSTRAINT userFK
    FOREIGN KEY (userId) REFERENCES users(userId),
    CONSTRAINT teamFK
    FOREIGN KEY (teamId) REFERENCES team(teamId)
);


CREATE TABLE team (
    teamId INT auto_increment primary key, 
    teamName VARCHAR(20)
);

CREATE TABLE teamUser (
    teamId INT,
    userId INT, 
    timeAdded TIMESTAMP,
    CONSTRAINT teamUserPK
    PRIMARY KEY (teamId, userId),
    CONSTRAINT userTeamFK
    FOREIGN KEY (userId) REFERENCES users(userId),
    CONSTRAINT teamUserFK
    FOREIGN KEY (teamId) REFERENCES team(teamId)
);

CREATE TABLE subTeam (
    subTeamId INT auto_increment primary key, 
    subTeamName VARCHAR(20),
    teamId INT, 
    CONSTRAINT subTeamFK
    FOREIGN KEY (teamId) REFERENCES team(teamId)
);
