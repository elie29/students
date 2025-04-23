# Student Management Application

A .NET C# application that manages students with a MySQL database using EF Core. The project is structured to separate migrations from source code into two Git repositories.

## Project Structure

- **StudentManagement.Api**: The main API application with controllers, models, and business logic
- **StudentManagement.Migrations**: A separate project for managing database migrations

## Requirements

- .NET 9.0 SDK
- MySQL Server
- Entity Framework Core Tools

## Setup Instructions

### 1. Install Required Tools

```bash
# Install EF Core tools globally
dotnet tool install --global dotnet-ef
```

### 2. Create and configure MySQL database

Ensure you have MySQL server running. You can update the connection string in:

- `students/StudentManagement.Api/appsettings.json`
- `migrations/StudentManagement.Migrations/appsettings.json`

Default connection string:

```JSON
Server=localhost;Database=StudentManagement;User=root;Password=212752;
```

### 3. Run Migrations

Navigate to the migrations project and run:

```bash
cd migrations/StudentManagement.Migrations
dotnet ef database update
```

### 4. Run the API

```bash
cd src/StudentManagement.Api
dotnet run
```

The API will be available at:

- https://localhost:5001/api/students (HTTPS)
- http://localhost:5000/api/students (HTTP)

## Managing Migrations

To add new migrations when the model changes, run:

```bash
cd migrations/StudentManagement.Migrations
dotnet ef migrations add [MigrationName]
```

To apply migrations to the database:

```bash
cd migrations/StudentManagement.Migrations
dotnet ef database update
```

## API Endpoints

### Students

- `GET /api/students` - Get all students
- `GET /api/students/{id}` - Get a specific student
- `POST /api/students` - Create a new student
- `PUT /api/students/{id}` - Update a student
- `DELETE /api/students/{id}` - Delete a student

### Sample Student JSON

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "dateOfBirth": "2000-01-01",
  "address": "123 Main St"
}
```

## Separate Repository Pattern

The benefit of this structure is that you can keep your migrations in a separate Git repository from your source code. This way:

1. Your application code doesn't need to carry the entire migration history
2. You can manage database schema changes separately from application code changes
3. Different teams can manage database schema and application code separately

To use this pattern in production:

1. Clone both repositories (src and migrations)
2. Set up CI/CD pipelines to apply migrations before deploying application code

## Azure DevOps CI/CD Pipelines

This project includes ready-to-use Azure DevOps pipelines for continuous integration and deployment.

### Individual Pipelines

- **migrations/azure-pipelines.yml**: Dedicated pipeline for migration project
  - Builds and applies database migrations
  - Publishes migration artifacts

- **src/azure-pipelines.yml**: Dedicated pipeline for API project
  - Builds and tests the API
  - Publishes and deploys to Azure Web App

### Setting Up Azure DevOps Pipelines

1. Create an Azure DevOps project and connect to your repository

2. Create the following pipeline variables:
   - `ProductionDbConnection`: Connection string to production MySQL database
   - `webAppName`: Name of your Azure Web App

3. Create a service connection to your Azure subscription
   - Update the `azureSubscription` value in the pipeline files with your connection name

4. Create the pipeline in Azure DevOps pointing to the desired YAML file

5. Run the pipeline to deploy your application
