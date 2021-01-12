

# Backend (FooBackBar)

## Database Management

### Add a new Migration
if any of the models were changed, create a new migration with:

Win: ``add-migration -context context migrationName``  
Linux: ``dotnet ef add-migration -context context migrationName``

### Create or update the database
to create or update database run:

Win: ``update-database -context context``  
Linux: ``dotnet ef update-database -context context``

SQLite does not support some SQL statements which can lead to migration errors during database creation. In these cases:
* delete all migrations
* create a new initial migration
* recreate the database
* tell the rest of us to recreate it

### Fill the database
execute the application and visit `http://localhost:50660/api/infection/infect`

## Backend tests

Run them via Visual Studio: ``right click project -> run Test(s)``  
Run them via CLI: ``dotnet test``

mini documentation on Xunit here: `https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test`

## Compilation

Open the Solution with Visual Studio and use the GUI tools or  
`dotnet build` to compile the solution  
`dotnet run` to compile the solution and host it, use the `--watch` flag to detect change and recompile automatically

## Relevant Application Settings:
`CovidDataApi` These 3 keys are the apis that will be called to initialize the database  
`AllowedOrigin` Specify the hosts that may request data from the backend. All other hosts will be denied per CORS-Policy

# Frontend (FooFrontBar)

## First Time Setup
* install node.js and npm. To test if they are installed run:  
    `npm --version`  
    `node --version` 
* install the angular CLI: ``npm install - g @angular/cli``
* get all dependencies: run `npm i` within FooFrontBar

## Hosting the application

Run `ng build` to compile the application
Run `ng serve` to compile the application, host it and initialize a watch. It will be hosted on `http://localhost:4200/` by default.

## Code generation

the angular CLI has ready-made templates for most common classes. These commands also take care of Module Declarations, Imports, Exports etc.
just run `ng generate [item] [name]`  
where item is one of `directive|pipe|service|class|guard|interface|enum|module`

## Frontend Test

the cli commands always generate test classes `*spec.ts`. To run tests, just run `ng test`