@echo off

:: Kill running instance of tomcat
docker kill webapp

:: Compiles and packages source code into .war file via maven volume in docker container


:: Copies and rebuilds tomcat image with latest .war file
docker image build -t webapp .

:: Starts tomcat container, making the webapp available.
docker container run --rm -it -d --name webapp --publish 80:80 webapp

echo.
echo "Link: http://localhost:80/"
echo.

pause
