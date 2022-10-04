/*LAG TEAM FØRST FORDI DE IKKE HAR NOEN FOREIGN KEYS*/
INSERT INTO team(team_name) VALUES ("Ledergruppe");
INSERT INTO team(team_name) VALUES ("Salg Og Marked");
INSERT INTO team(team_name) VALUES ("Produksjon");
INSERT INTO team(team_name) VALUES ("Teknisk");
INSERT INTO team(team_name) VALUES ("Logistikk");



/*LAG SÅ ANSATTE FOR Å KUNNE REFERERE TIL DE I SUGGESTION FOREIGN KEY*/
INSERT INTO employee(first_name, last_name, password, is_teamlead, is_admin, team_id, team_lead_id) VALUES ("Geir", "Gunnar", "Passord", false, false, 1, 1);
INSERT INTO employee(first_name, last_name, password, is_teamlead, is_admin, team_id) VALUES ("Anne", "Gunnar", "Passord", true, false, 2);
INSERT INTO employee(first_name, last_name, password, is_teamlead, is_admin, team_id, team_lead_id) VALUES ("Johanne", "Gunnar", "Passord", false, false, 2, 2);
INSERT INTO employee(first_name, last_name, password, is_teamlead, is_admin, team_id) VALUES ("Neihanne", "Gunnar", "Passord", false, false, 1);
INSERT INTO employee(first_name, last_name, password, is_teamlead, is_admin, team_id, team_lead_id) VALUES ("Arnulf", "Gunnar", "Passord", false, false, 3, 3);


/*LAG SÅ SUGGESTION FOR Å KUNNE REFERERE TIL DE I COMMENT FOREIGN KEY*/
INSERT INTO suggestion(title, description, status, emp_id) VALUES ("Gulv", "Gulvet er skittent", "BRA!", 1);
INSERT INTO suggestion(title, description, status, emp_id) VALUES ("Tak", "Taket er skittent", "Dårlig!", 3);
INSERT INTO suggestion(title, description, status, emp_id) VALUES ("Vegg", "Veggen er blå!", "BRA!", 3);

/*LAG SÅ COMMENTS*/
INSERT INTO comments(emp_id, suggestion_id, description) VALUES (2, 1, "OIDA");
INSERT INTO comments(emp_id, suggestion_id, description) VALUES (3, 2, "NEIDA");
INSERT INTO comments(emp_id, suggestion_id, description) VALUES (1, 2, "ja");
INSERT INTO comments(emp_id, suggestion_id, description) VALUES (4, 1, "FAEN");
