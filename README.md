# Introduction
This is simple REST API project using .NET 8, Entity Framework & MSSQL

What is missing?
Currently, the project has some unit test coverage.
It would be great to add also System / Api test to verify that the whole flow works.

## List of content
+ API - Handling requests
+ Domain - Services & common logic
+ Data - Handling DB using EF6 core & MSSQL as DB
+ KafkaJob - Consumer of the product topic responsible for updating the data (Could use some more work, but it works)
+ Unit Tests - containing unit test for the whole app


## Setup
### Docker

To start project you should only need to run `docker-compose up`
in the root folder of the project

Docker will set up the API & MSSQL server

For MSSQL server docker will run SQL scripts from init folder to create & seed the db

<img width="1605" height="292" alt="image" src="https://github.com/user-attachments/assets/7e73ea8a-cccd-49f5-b059-e9f32f06993e" />

### Local Development
+ .NET 8 SDK
+ MSSQL server
+ Kafka

I highly suggest to run MSSQL & Kafka, KafkaJob in docker.
You should be able to run the API project in your IDE along the containers

## .Env
Previously I kept it out of source control to be secure.
These files should never be in version control, but I added it for convenience + this is just assignment.
I'm just leaving comment here for clarity

## links

+ App with swagger created from Docker is hosted on: http://localhost:7742/swagger/index.html
+ Swagger when launching app from IDE: https://localhost:7042/swagger/index.html
Ports can be configured in dockerfile/.env


