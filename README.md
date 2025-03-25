# Banking API

This project is a banking web API built with ASP.NET Core that contains functionality for managing accounts, making transactions and handling loans. It contains role-based access control, where customers can create and manage accounts, transfer money, and view transaction history, while admins can manage users and loans.

## Tech Stack

- **ASP.NET Core Web API**: For building the backend API.
- **SQL Server**: For managing the relational database that stores data for the application, such as customers, accounts, transactions and loans.
- **JWT (JSON Web Tokens)**: For handling user authentication through token-based access control.
- **Dapper**: For object-relational mapping from database tables to C# objects, providing efficient database access.
- **AutoMapper**: For simplifying object-to-object mapping between DTOs and models.
- **BCrypt**: For secure password hashing.
- **Moq**: For unit testing and mocking dependencies.
- **xUnit**: For writing unit tests in the backend, ensuring reliability and correctness of the API.
- **Swagger**: For API testing and documentation.
