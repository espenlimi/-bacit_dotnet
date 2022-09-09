@echo off

:: Kill running instance of container
docker kill webapp

:: Builds image specified in Dockerfile
docker image build -t webapp .

:: Starts container with web application and maps port 80 (ext) to 80 (internal)
docker container run --rm -it -d --name webapp --publish 80:80 webapp

echo.
echo "Link: http://localhost:80/"
echo.

pause
