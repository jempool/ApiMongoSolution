docker build -f multistage.webapi.dockerfile -t projectwebapimulti .
#To run:
#docker run -d -p 5000:80 --name testproject projectwebapimulti