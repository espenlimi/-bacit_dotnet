#!/bin/bash

# Kill running instance of tomcat
docker kill tomcat

# Compile and packages source code into .war file via maven volume in docker container
docker run --rm -it --name mavenbuild -v maven-repo:/root/.m2 -v "$(pwd)":/usr/src/mymaven -w /usr/src/mymaven maven mvn clean install

# Copy and rebuilds tomcat image with latest .war file
docker image build -t trym/tomcat .

# Start tomcat container, making the webapp available.
docker container run --rm -it -d --name tomcat --publish 8081:8080 trym/tomcat

echo ""
echo "Link: http://localhost:8081/bacit-web-1.0-SNAPSHOT/"
echo ""

read -n 1 -s -r -p "Press any key to continue..."
echo ""
