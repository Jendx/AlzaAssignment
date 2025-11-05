# Introduction
This is simple REST API project using .NET 8, Entity Framework & MSSQL

What is missing?
Currently the project has some unit test coverage.
It would be great to add also System / Api test to verify that the whole flow works.

## List of content
+ API - Handling requests
+ Domain - Services & common logic
+ Data - Handling DB using EF6 core & MSSQL as DB
+ KafkaJob - Consumer of the product topic responsible for updating the data (Could use some more work but it works)
+ Unit Tests - containing unit test for the whole app


## Setup
### Docker

To start project you should only need to run `docker-compose up`
in the root folder of the project

Docker will set up the API & MSSQL server

For MSSQL server docker will run SQL scripts from init folder to create & seed the db

.ENV are attached in email

### Local Development
+ .NET 8 SDK
+ MSSQL server
+ Kafka

I highly suggest to run MSSQL & Kafka, KafkaJob in docker.
You should be able to run the API project in your IDE along the containers 