# Database Migration Workflow 🗄️

This document explains the workflow for managing database schema changes using Entity Framework Core migrations in a production environment with separate repositories for code and migrations.

## Overview 📋

The Student Management application has the following setup:

1. **Main API Repository**: Contains the application code, models, and business logic
2. **Migrations Repository**: Contains the database migration history and scripts

This separation allows for independent management of code and database schema, with proper coordination through CI/CD pipelines.

## Development Workflow 🔄

### 1. Making Model Changes ✏️

When you need to modify the database schema, first update the model classes in the API project:

```csharp
// Example: Adding a new property to the Student model
public class Student
{
    // Existing properties
    
    [StringLength(20)]
    public string PhoneNumber { get; set; }
}
```

### 2. Creating a Migration 🆕

After updating the model, create a new migration in the migrations project:

```bash
# Navigate to the migrations project
cd migrations/StudentManagement.Migrations

# Create a new migration with a descriptive name
dotnet ef migrations add AddStudentPhoneNumber
```

### 3. Verify Migration Code ✅

Review the generated migration file to ensure it correctly represents your model changes:

```csharp
public partial class AddStudentPhoneNumber : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "PhoneNumber",
            table: "Students",
            type: "varchar(20)",
            maxLength: 20,
            nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "PhoneNumber",
            table: "Students");
    }
}
```

### 4. Test Migration Locally 🧪

Apply the migration to your local development database:

```bash
dotnet ef database update
```

### 5. Commit Changes 💾

Commit and push changes to both repositories:

```bash
# In API repository
git add .
git commit -m "Add phone number to Student model"
git push

# In migrations repository
git add .
git commit -m "Add migration for student phone number"
git push
```

## Production Deployment 🚀

### 1. Azure DevOps Pipeline 🔧

The deployment is handled by the Azure DevOps pipeline, which has three main stages:

1. **Database Migration**: Applies pending migrations to the production database
2. **Application Deployment**: Builds and deploys the updated API
3. **Verification**: Ensures the API is running correctly after deployment

### 2. Managing Database Changes 📊

For sensitive database changes, consider the following best practices:

- **Data Loss**: Be careful with migrations that might result in data loss (e.g., dropping columns)
- **Large Tables**: For large tables, consider creating custom migrations to minimize impact
- **Downtime**: Schedule database changes during low-traffic periods
- **Backup**: Always take a database backup before applying migrations
- **Performance**: Consider the impact on database performance during migration

### 3. Rollback Procedures 🔙

If you need to rollback a database migration:

```bash
# Rollback to a specific migration
dotnet ef database update PreviousMigrationName --connection "$(ProductionDbConnection)"
```

To rollback the application code:

1. Redeploy the previous version of the API application
2. Ensure the model version matches the database schema

## Best Practices ⭐

1. **Descriptive Migration Names**: Use clear, descriptive names for migrations
2. **Small, Incremental Changes**: Prefer small, focused migrations over large ones
3. **Test Migrations Thoroughly**: Test on development/staging before production
4. **Version Coordination**: Ensure API and database versions are compatible
5. **Consider Data Seeding**: Use migrations for reference data or initial data
6. **Documentation**: Keep migration documentation up to date
7. **Code Review**: Always have migrations reviewed by another team member
8. **Performance Testing**: Test migration performance with production-like data volumes

## Troubleshooting 🔍

### Common Issues ⚠️

1. **Migration Failing**: 
   - Check if the database server is accessible
   - Verify connection string
   - Check for SQL syntax errors
   - Ensure sufficient database permissions

2. **Model Snapshot Conflicts**:
   - Ensure the model snapshot is up to date
   - Rebuild the migrations project
   - Check for conflicting model changes

3. **Pipeline Failures**:
   - Check the connection string variable in Azure DevOps
   - Verify the Azure service connection
   - Check pipeline logs for specific errors
   - Validate environment variables

### Getting Help 🆘

If you encounter issues with migrations:

1. Check Entity Framework Core documentation
2. Review migration logs in Azure DevOps
3. Contact the database administrator or DevOps team
4. Check the team's knowledge base
5. Review similar past migrations

## Migration Checklist 📝

Before deploying a migration to production, ensure you have:

- [ ] Tested the migration locally
- [ ] Verified the migration script
- [ ] Created a database backup
- [ ] Scheduled the deployment during low-traffic period
- [ ] Notified relevant stakeholders
- [ ] Prepared rollback plan
- [ ] Updated documentation
- [ ] Performed code review
- [ ] Tested with production-like data volume 