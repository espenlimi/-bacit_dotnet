USE webAppDatabase;

delete from users;

insert into users (id, name, email, phone) 
values 
(1, 'Sandra', 'email@email.com', '42424242'),
(2, 'Sarah', 'email@email.com', '12345678'),
(3, 'Even', 'email@email.com', '23456789'),
(4, 'Kasper', 'email@email.com', '34567891'),
(5, 'Sander', 'email@email.com', '45678912');

select * from users;


