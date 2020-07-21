# ManageCustomerInfo
This solution is to Implement Customer management API
Repository pattern is used for the CRUD operations 
Unit test project is defined for basic tests
It contains following projects 

CustomerInfo.Entities 

Entities (data models) are defined here.At the moment only one entity model is present - Customer. 
But in the future , new entities can be added here . 
This project also popluates initial data required for the project 
PopulateStartupData class servers the purpose of adding initial entries to to Customer entity
In this implementation, it uses in memory database

CustomerInfo.Api

This is the Web API project . This should be set as the start up project.
Swagger is configured along with this API project. So all the apis defined here can be viewed and tested from Swagger UI
Currently the following APIs are defined
Get --> Retrieves all the employees
Search --> Searches employees based on Name. Checks for matching first name or last name
Add --> To create new employee
Edit --> Updates details of the existing employee .Employee id and other details are passed to the api
Delete--> Deletes the employee based on the Id passed

CustomerInfo.Contracts
All the interface contracts are defined here 

CustomerInfo.Repository
CRUD operations are defined here 

CustomerInfo.Test
Test project using XUnit tests 
Fluent assertions are used for validating the http status codes
