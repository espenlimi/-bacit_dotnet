# -bacit_dotnet
Base project for IS202 in dotnet
Text provided by Trym (https://github.com/Nosp1) - Modified slightly to fit this project. 

## Notice
Please read and understand how the dockerfile works. 
Understand that all scripts used (`build.*` & `startDb.*`) can be run in the terminal without the scripts.
I recommend getting familiar with executing docker commands in the terminal before using the scripts.

## How to use
### Prerequisites:
To make this work, you need to have [Docker](https://www.docker.com/) installed and running on your system.    

### Via commandline with docker (Recommended):
> Note: On Unix and Unix-like systems (Mac and Linux) you might need to run the commands with `sudo` to make them work.

##### 1. Build then start the docker container with the web application:    
`docker image build -t webapp .`    
`docker container run --rm -it -d --name webapp --publish 80:80 webapp`

##### 2. Start a mariadb container using the localdirectory "database" to store the data:    

|Bash (Mac and Linux)|Powershell (Windows)|
|--------------------|--------------------|
|`docker run --rm --name mariadb -p 3308:3306/tcp -v "$(pwd)/database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11`|`docker run --rm --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11`|

##### 3. Enter the database and create the database and table for this skeleton:    
`docker exec -it mariadb mysql -p`    
When prompted enter the password (`12345`), then type or copy in the SQL from [this file](CreateDb.sql) (line by line).

##### 4. Test out the code at http://localhost:80/

<br>

### Via scripts:
The following takes the above steps and deduce them into scripts. (all the above commands are present in the below scripts).
The scripts allow us to build and deploy our application faster, which can be beneficial when the core concepts of using docker are understood.
|Bash (Mac and Linux)|Powershell (Windows)|
|--------------------|--------------------|
|Run `build.sh` to compile source code and build tomcat docker image.|Run `build.cmd` to compile source code and build tomcat docker image.|
|Run `startDb.sh` to start database|Run `startDb.cmd` to start database|

> Note: On Unix and Unix-like systems (Mac and Linux) you might need to run the scripts with `sudo` to make them work.

<br>

#### PS
Have fun and experiment :)

Code can be copied freely
