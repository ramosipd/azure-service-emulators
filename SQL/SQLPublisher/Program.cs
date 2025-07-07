using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "Server=127.0.0.1,1433;Database=SampleDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;Connection Timeout=30;";
        string databaseName = "SampleDB";
        string tableName = "Employees";

        try
        {
            // Create database if it doesn't exist
            await CreateDatabaseIfNotExistsAsync(connectionString, databaseName);
            Console.WriteLine($"Database '{databaseName}' is ready.");

            // Create table if it doesn't exist
            await CreateTableIfNotExistsAsync(connectionString, tableName);
            Console.WriteLine($"Table '{tableName}' is ready.");

            // Insert sample data
            await InsertSampleDataAsync(connectionString, tableName);
            Console.WriteLine("Sample data inserted successfully.");

            // Display current data
            await DisplayDataAsync(connectionString, tableName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task CreateDatabaseIfNotExistsAsync(string connectionString, string databaseName)
    {
        // Use master database to create SampleDB
        var masterConnectionString = connectionString.Replace($"Database={databaseName}", "Database=master");
        
        using var connection = new SqlConnection(masterConnectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand($@"
            IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}')
            CREATE DATABASE [{databaseName}]", connection);
        
        await command.ExecuteNonQueryAsync();
    }

    static async Task CreateTableIfNotExistsAsync(string connectionString, string tableName)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand($@"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' AND xtype='U')
            CREATE TABLE {tableName} (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name NVARCHAR(100) NOT NULL,
                Department NVARCHAR(50),
                Salary DECIMAL(10,2),
                CreatedDate DATETIME DEFAULT GETDATE()
            )", connection);
        
        await command.ExecuteNonQueryAsync();
    }

    static async Task InsertSampleDataAsync(string connectionString, string tableName)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var employees = new[]
        {
            new { Name = "John Doe", Department = "Engineering", Salary = 75000m },
            new { Name = "Jane Smith", Department = "Marketing", Salary = 65000m },
            new { Name = "Bob Johnson", Department = "Sales", Salary = 55000m },
            new { Name = "Alice Brown", Department = "HR", Salary = 60000m },
            new { Name = "Charlie Wilson", Department = "Engineering", Salary = 80000m }
        };

        foreach (var employee in employees)
        {
            var command = new SqlCommand($@"
                INSERT INTO {tableName} (Name, Department, Salary)
                VALUES (@Name, @Department, @Salary)", connection);
            
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Department", employee.Department);
            command.Parameters.AddWithValue("@Salary", employee.Salary);
            
            await command.ExecuteNonQueryAsync();
            Console.WriteLine($"Inserted: {employee.Name} - {employee.Department} - ${employee.Salary:N2}");
        }
    }

    static async Task DisplayDataAsync(string connectionString, string tableName)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand($"SELECT Id, Name, Department, Salary, CreatedDate FROM {tableName} ORDER BY Id", connection);
        using var reader = await command.ExecuteReaderAsync();
        
        Console.WriteLine("\nCurrent data in the table:");
        Console.WriteLine("Id\tName\t\tDepartment\tSalary\t\tCreatedDate");
        Console.WriteLine(new string('-', 80));
        
        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t{reader["Department"]}\t${reader["Salary"]:N2}\t{reader["CreatedDate"]}");
        }
    }
} 