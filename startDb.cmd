docker run --rm ^
  --env "TZ=Europe/Oslo" ^
  --name mariadb ^
  --publish 3308:3306/tcp ^
  --volume "%cd%\database":/var/lib/mysql ^
  --env MYSQL_ROOT_PASSWORD=12345 ^
  --detach mariadb:10.5.11