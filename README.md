# AcmeDirectorySearch

A C#/Angular web application attempting to accomplish the following activies
- User Directory Search based on First or Last name
    - Records will contain Name, Address, Age, Interests and a Picture
- Ability to Create new Users

Technologies used within the solution include
- Angular
- .Net Core (C#)
- Dapper
- Automapper
- Xunit & Moq
- MS SQL Server
- Docker & Docker-Compse


## Quick Start
- Open Visual Studio and Choose Clone or Checkout Code
    - https://github.com/david-fitzgibbons/AcmeDirectorySearch.git
- Build the Solution 
- Run the solution using Docker Compose as the startup project
    - **_Note: The database binds to the host on port 1433_**
    - This step builds the containers and binds Docker-Compse as the owner of those containers
- Stop the project
- On the AcmeDatabase project
    - Right click and 'Publish...'
    - Target Database Connection:
        - Server Name: localhost
        - Authentication: Sql Server Authentication
        - User Name: SA
        - Password: T3mp0rary!
    - Database Name: Acme
    - Click Publish
- Run the AcmeTest test suite

- Run the Docker Compose project again to test the API endpoints
    - example https://localhost:[port]/api/v1/property/states

## Endpoint Examples
- GET: /api/v1/property/states  :  Returns a list of states
- GET: /api/v1/user/1           :  Returns a specific user by Id
- GET: /api/v1/user/1/image     :  Returns the User's image or a default one

##### Searching
- GET: /api/v1/user?filter=ma     :  Returns any User with a First or Last name containing 'ma'
- GET: /api/v1/user?filter=abel&filter=kris     :  Returns any User with a First or Last name of either 'abel' or 'kris'

##### Creating a User
- POST: /api/v1/user            :  Returns the User that was created

Sample Payload
```
{
	"firstname" : "Katie",
	"lastname" : "Hoek",
	"birthday" : "01/10/1980",
	"address" : {
		"street1" : "123 Main St",
		"city" : "Saratoga Springs",
		"state" : "NY",
		"zip" : "12866"
	}
}
```

## Architecture

Mid-tier project is broken down in to three primary areas 
- API / Controllers
- Service / Models
- Repositories

#### General
The core of the application deals with managing User / Address data as it flows from the API endpoints to the Repositories.  Utilizing Dependency Injection for the Service and Repository layers allows for separation of concerns within the application.  DTO objects are used for the transfer of information between the API and Service layers.  Also, Contract objects exist to ensure backwards compatability during API changes.

Overview of data flow:  Contracts <> DTO <> Service & Models <> Repository

#### API / Controllers
The controllers follow REST API standards and are versioned starting with v1.  Along with the versioning of the controllers, the input / output objects the user interacts with are also bound to the version of the controller.  This allows for Unit Tests that monitor the state of the objects to confirm consistency during versioning changes within the system

#### DTO / Models
The DTO's are purposefully light and should only behave as a data transfer medium without performing any logic.  The models are meant to store all of the business validation and logic for the system.  

#### Services / Repositories
The services and repositories in the system follow the repository pattern where the instance of the object is provided at runtime creating loose coupling between the layers with IoC


## Database
Database design for the system is straight forward and simplified.  Consisting of only 5 tables: 
- Address
- Property
- State
- User
- UserImage

The User & Address tables are the bulk of the data storage for the system.  Address utilizes States as a form of extracting repetitive data in accordance with Database Normalization

The UserImage table will only contain records for User's who provided an image during their creation.  If no image was provided, then a default image will be returned for the user

Property table contains properties to be utilized by the system.  In this instance, there is currently only one property which is the default image for a user who has not provided an image during creation






