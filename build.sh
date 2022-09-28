#!/bin/zsh

docker kill webapp

docker image build -t webapp .

docker container run --rm -it -d --name webapp --publish 80:80 webapp

echo
echo "Link: http://localhost:80/"
echo

