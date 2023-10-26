![Nøsted logo](https://raw.githubusercontent.com/Prosjekt2023/Reficio/main/bacit-dotnet.MVC/wwwroot/nlogo.png)

## Før du kjører programmet:
* Lag en database i MariaDB
    * Du kan installere lokalt i Docker. Se veiledningen 'MariaDb database som Docker container'.
  

* Sett inn en connection string i filen `appsettings.json`, der du ser `ConnectionString.DefaultConnection`


* Denne skal følge dette formatet:
    * server=localhost; user=root; database=ReficioDB; port=3306; password=Reficio`
    * Dersom du kjører database og server på samme maskin, kan du bruke `localhost` eller `172.17.0.1` som IP-adresse
    * Det er anbefalt å bruke port 3306, da dette er standard for MySQL og MariaDB


### MariaDb database som Docker container

1. Opprett MariaDb container.


```docker
docker run --name Reficio -e MYSQL_ROOT_PASSWORD=Reficio -p 3306:3306 -d mariadb:latest
```

```
docker ps
```
2. Verifiser at container har status 'Running'

3. Koble til container og logg på som root.

  ```
  docker exec -it Reficio bash
  mariadb -u root –p 
  ```

4. Skriv inn PASSORD som ble satt ved opprettelse av konteiner. I dette tilfellet: Reficio

  ```
  Enter password: Reficio 
  ```
5. Bruk SQL kommando 

```
  USE DATABASE ReficioDB;
```
6. Lag en samsvarende tabell for din webapplikasjon f.eks
```
  CREATE TABLE ServiceFormEntry (
    Id INT(11) NOT NULL AUTO_INCREMENT,
    Customer NVARCHAR(255) NOT NULL,
    DateReceived DATE NOT NULL,
    Address NVARCHAR(255),
    Email NVARCHAR(255),
    OrderNumber INT(11),
    Phone INT(11),
    ProductType NVARCHAR(255),
    Year INT(11),
    Service NVARCHAR(255),
    Warranty NVARCHAR(255),
    SerialNumber INT(11),
    Agreement NVARCHAR(255),
    RepairDescription NVARCHAR(255),
    UsedParts NVARCHAR(255),
    WorkHours NVARCHAR(255),
    CompletionDate DATE NOT NULL,
    ReplacedPartsReturned NVARCHAR(255),
    ShippingMethod NVARCHAR(255),
    CustomerSignature NVARCHAR(255),
    RepairerSignature NVARCHAR(255),
    PRIMARY KEY (Id)
);
```
Ferdig! Kjør programmet.
Husk å legge til connectionstring og connect to database.