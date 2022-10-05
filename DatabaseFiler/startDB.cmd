
docker run --rm --env "TZ=Europe/Oslo" --name mariadb -p 3306:3306/tcp  -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:latest

docker cp "%cd%\setupDB.sql" mariadb:"bin"
docker cp "%cd%\genmockdata.sql" mariadb:"bin"

docker exec -it mariadb bash


::-v %cd%\testfolder:/var/lib/mysql
