TopStyle API
Project Overview
The TopStyle API is a backend solution crafted specifically for TopStyle, a dynamic online retail platform specializing in clothing and footwear. Designed and deployed on Microsoft Azure, this API is constructed using ASP.NET Core Web API and integrates with a SQL database via Entity Framework. The project aims to provide a robust and scalable infrastructure to support an e-commerce platform with efficient data handling and user interaction capabilities.

Key Features
Product Search: Enables users to search for products by name, description, price, and category, enhancing the shopping experience.
User Management: Supports user account creation and authentication using JSON Web Tokens (JWT), ensuring secure and personalized user interactions.
Order Processing: Allows logged-in users to create orders, handling multiple products and integrating user authentication to secure transactions.
Database Integration: Utilizes Entity Framework for a code-first approach to database management, simplifying deployment and updates.
Asynchronous API Calls: Implements asynchronous endpoints using the Task Parallel Library (TPL) to improve performance and scalability.
Azure Deployment: Configured for deployment on Azure, demonstrating a cloud-native approach to application development.
Technologies
ASP.NET Core Web API
Entity Framework Core
Azure SQL Database
Swagger for API Documentation
GitHub for version control and source code management
Getting Started
To run the TopStyle API locally:

Clone the repository to your local machine.
Ensure you have .NET 5.0 or higher installed.
Set up your Azure SQL database and update the connection string in the appsettings.json.
Use Visual Studio or the .NET CLI to build and run the application.
Navigate to https://localhost:<port>/swagger to view the API documentation and test endpoints.
Documentation
The API is fully documented using Swagger UI, which provides detailed information about all the endpoints, including request formats, response types, and error codes.

Contributions
Contributions to the TopStyle API are welcome. Please fork the repository, make your changes, and submit a pull request for review.

License
This project is licensed under the MIT License - see the LICENSE.md file for details.
