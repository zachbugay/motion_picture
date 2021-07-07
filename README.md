# Startup for Development
This is a very simple application used to store Motion Pictures. You can get the application running if you have docker.
Simply run the following command, and then open up a browser to http://localhost:8080.


```sh
docker-compose up --build
```

## File Layout

### ./services
This folder contains the services necessary to run the application.

### ./services/api
This folder contains the backend api, and database setup information.

Navigate to `./services/api/db` to view the create.sql file for the basic layout of the database. However, this
application was created using Entity Framework Core Code First.

### ./services/client
This folder contains the client, and some basic cypress integration tests.
