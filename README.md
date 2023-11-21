# ASP.NET REST API Demo

This repository contains a simple ASP.NET REST API demo project, which demonstrates my implementacion about a task manager. The mains propous of project are demostrate a simple crud, implement authentication with JWToken, use dependency injection and show how to consume an external API.


## Table of Contents

- [ASP.NET REST API Demo](#aspnet-rest-api-demo)
  - [Table of Contents](#table-of-contents)
  - [Description](#description)
  - [Features](#features)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
  - [Usage](#usage)
  - [Project Structure](#project-structure)
  - [Contributing](#contributing)
  - [License](#license)
  - [Acknowledgments](#acknowledgments)

## Description

The task manager allows users to create their own task and assign Categories to them. It's a simple CRUD of Users, Categories and Tasks, with Json Web Token as authentication. Moreover, the project contains a demo of how to consume an external API base on Hacker Rank challenge.

## Features

- **User Authentication:** Secure user authentication using JWT tokens.
- **CRUD Operations:** Full CRUD (Create, Read, Update, Delete) operations for managing resources.
- **Swagger Documentation:** Interactive API documentation with Swagger for easy testing and exploration.
- **Data Validation:** Input validation and error handling to ensure data integrity.
- **Database Integration:** Integration with a relational database (PostgreSQL).
- **Migration integration:** Database vertioning with migration.
- **Fluent API** Context formater with Fluente API (with Entity Framework).
- **Dependency Injection:** Utilization of dependency injection for maintainability and testability.
- **Environment Configuration:** Configuration setup for different environments (development, production).


## Getting Started

These instructions will help you get a copy of the project up and running on your local machine.

### Prerequisites

- Mention any software, tools, or dependencies that users need to have installed before running your API.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/mmmoises/aspDotnet_apiDemo.git
   ```

2. Navigate to the project directory:

    ```bash
    cd aspDotnet_apiDemo
    ```

3. Install dependencies:

    ```bash
    dotnet restore
    ```
    
4. set appsettings env variables:

    ```json
      "ConnectionStrings": {
        "TaskDb" : "User ID=;Password=;Host=;Port=5432;Database=;"
      },
      "ConfigurationJwt":{
        "Key":""
      }
     ```

5. Build and run the application:

    ```bash
    dotnet run
    ```
    The API will be accessible at http://localhost:5191.

## Usage
The project has endpoints with securtiry and another without it

- **With security**
  - Category
    - List
    - Create
    - Update
    - Delete
  - Task by user
    - List
    - Create
    - Update
    - Delete
- **Without security**
  - User
    - Login
    - Signup


You can consume the api with an json web token, for generate that you can login or signup with same api. For more details, this porject generate swagger documentation and also you can review and use [postman documentation](https://documenter.getpostman.com/view/12698509/2s9Ye8hw1F)

## Project Structure
The project have been developed with dependency injection (DI) software design pattern, with the purpose of showing my own implemetation of that. In general, the dependency injection use for decouple components of our software and ease their integration and testing. It does so by asking for their sub-components instead of creating them. For this reason that is the structure and the main purpose of the files.

- **dot_webapi**
  - Controllers
        In this path we created the common controllers with their routings and we pass service interfaces to respective controllers.
  - Exceptions
        Use for define custome class exeption.
  - Interfaces
        we defined all interfaces the we'll use through project.
  - Models
        there are classes that define the behavior of our models and will be able to maped with fluent api.
  - Services
        Here we implemented the interfaces of service that will be inyected on  the run time.
  - Program.cs (file)
        In this file, we decided wich service will be implemented in the service interfaces.

  

## Acknowledgments
The base idea of project comes from [Plazi APIs with .NET](https://platzi.com/clases/2983-apis-net/48339-domina-las-api-con-net/) and the challenge of showing how to consume an external api comes from [Hacker Rank](https://www.hackerrank.com/skills-verification/rest_api_intermediate).

## Author

[Ing. Moises Morales](https://github.com/mmmoises) ☕️