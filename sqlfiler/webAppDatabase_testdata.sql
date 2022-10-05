USE webAppDatabase;

insert into users (name, email, phone) 
values 
('Sandra', 'email@email.com', '42424242'),
('Sarah', 'email@email.com', '12345678'),
('Even', 'email@email.com', '23456789'),
('Kasper', 'email@email.com', '34567891'),
('Sander', 'email@email.com', '45678912'),
('Oskar', 'email@email.com', '56789123');

select * from users;



delete from team; 

insert into team (teamName) 
values 
('HMS'),
('HR'); 

select * from team; 

insert into suggestions (title, description, teamId, userId)
values 
('Vask opp', 'Dere må vaske opp i kantina', 1, 3),
('Kost gulvet', 'Dere må koste gulvet i møterom 1', 2, 2),
('Lyspære', 'Må bytte lyspære ved inngangen', 1, 5);

select * from suggestions; 

insert into teamUser (teamId, userId)
values 
(2, 1),
(1, 5), 
(1, 6), 
(2, 2), 
(2, 3), 
(1, 4);

select * from teamUser; 

insert into subTeam (teamId, subTeamName)
values
(1, 'Helse'),
(1, 'Miljo'),
(1, 'Sikkerhet'),
(2, 'Human'),
(2, 'Resources');

select * from subTeam;