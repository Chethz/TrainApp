# TrainApp

Train App

This project provides a oneway rail network which connects number of towns. Application is a console application 
which provides distance to given destination or route, number of routes customers can reach the destination on given 
number of stops, shortest route between given starting and end towns and different routes from one starting point 
to another within a given distance.

Getting Started
Clone or download the repository from git hub. Application built on .Net Core version 2.2 and tested on nUnit framework 
version$$$.

Prerequisites
Visual studio  (I used Visual Studio Community 2019)
nUnit for unit testing

Give examples

Running application

The application provides commandline interface for the user.

initial setup : option 1

At the begining to setup the rail network please press option 1 to create transport network.
under option 1 enter routes seperated by commas to create verticies and edges for the rail graph
Input template : AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7
To confirm and submit press S.
Once graph is created, menu will exit to the main menu without error messages.

Using application

From option 2 - 7 application will provide different options for user

Option 2:

Option 2 will print distance for gien route if it exists. Route sohould be destination seperated by -.
Input example : A-B-C

Option 3:
Option 3 will provide number of trips starting and end at C with maximum of 3 steps.

Option 4: 
Option 4 will provide number of trips starting at A and ending at C wih exactly 4 stops.

Option 5:
Option 5 will provide shortest route from A to C

Option 6:
Option 6 will provide shortest route from B to B

Option 7:
Option 7 will provide different routes from C to C with a distance of less than 30.

Error:
In each step if inputs are not correct it will throw error with message. Please read them and provide correct inputs.


Running the tests
Explain how to run the automated tests for this system

Break down into end to end tests
Explain what these tests test and why

Give an example
And coding style tests
Explain what these tests test and why

Give an example
Deployment
Add additional notes about how to deploy this on a live system

Built With
.Net Core - version
nUmit Framework - version

Author
Chethiya Wijesinghe (Cheth)


Acknowledgments
Hat tip to anyone whose code was used
Inspiration
etc