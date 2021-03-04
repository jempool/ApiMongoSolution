docker build -f multistage.webapi.dockerfile -t projectwebapimulti .
#To run:
#docker run -d -p 5000:80 --name testproject projectwebapimulti

#docker run -d -p 3000:80 -p 5000:5000 -p 5001:5001 --name testproject projectwebapimulti