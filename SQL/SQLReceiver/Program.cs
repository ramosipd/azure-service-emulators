using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "Server=127.0.0.1,1433;Database=SampleDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;Connection Timeout=30;";
        string tableName = "Employees";

        try
        {
            // Check if database exists
            if (!await DatabaseExistsAsync(connectionString))
            {
                Console.WriteLine("Database 'SampleDB' does not exist. Please run the Publisher first.");
                return;
            }

            // Display all employees
            await DisplayEmployeesAsync(connectionString, tableName);
            
            // Display department statistics
            await DisplayDepartmentStatisticsAsync(connectionString, tableName);
            
            // Display salary statistics
            await DisplaySalaryStatisticsAsync(connectionString, tableName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task<bool> DatabaseExistsAsync(string connectionString)
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    static async Task DisplayEmployeesAsync(string connectionString, string tableName)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand($@"
            SELECT Id, Name, Department, Salary, CreatedDate 
            FROM {tableName} 
            ORDER BY Id", connection);
        
        using var reader = await command.ExecuteReaderAsync();
        
        Console.WriteLine("📋 All Employees");
        Console.WriteLine("================");
        Console.WriteLine("Id\tName\t\tDepartment\tSalary\t\tCreatedDate");
        Console.WriteLine(new string('-', 80));
        
        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["Id"]}\t{reader["Name"],-15}\t{reader["Department"],-12}\t${reader["Salary"]:N2}\t{reader["CreatedDate"]:yyyy-MM-dd HH:mm:ss}");
        }
        Console.WriteLine();
    }

    static async Task DisplayDepartmentStatisticsAsync(string connectionString, string tableName)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand($@"
            SELECT 
                Department, 
                COUNT(*) as EmployeeCount,
                AVG(Salary) as AverageSalary,
                MIN(Salary) as MinSalary,
                MAX(Salary) as MaxSalary
            FROM {tableName} 
            GROUP BY Department
            ORDER BY Department", connection);
        
        using var reader = await command.ExecuteReaderAsync();
        
        Console.WriteLine("📊 Department Statistics");
        Console.WriteLine("========================");
        Console.WriteLine("Department\tEmployees\tAvg Salary\tMin Salary\tMax Salary");
        Console.WriteLine(new string('-', 75));
        
        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader["Department"],-12}\t{reader["EmployeeCount"]}\t\t${reader["AverageSalary"]:N2}\t\t${reader["MinSalary"]:N2}\t\t${reader["MaxSalary"]:N2}");
        }
        Console.WriteLine();
    }

    static async Task DisplaySalaryStatisticsAsync(string connectionString, string tableName)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand($@"
            SELECT 
                COUNT(*) as TotalEmployees,
                AVG(Salary) as AverageSalary,
                MIN(Salary) as MinSalary,
                MAX(Salary) as MaxSalary,
                SUM(Salary) as TotalSalary
            FROM {tableName}", connection);
        
        using var reader = await command.ExecuteReaderAsync();
        
        Console.WriteLine("💰 Overall Salary Statistics");
        Console.WriteLine("============================");
        
        if (await reader.ReadAsync())
        {
            Console.WriteLine($"Total Employees: {reader["TotalEmployees"]}");
            Console.WriteLine($"Average Salary: ${reader["AverageSalary"]:N2}");
            Console.WriteLine($"Minimum Salary: ${reader["MinSalary"]:N2}");
            Console.WriteLine($"Maximum Salary: ${reader["MaxSalary"]:N2}");
            Console.WriteLine($"Total Payroll: ${reader["TotalSalary"]:N2}");
        }
        Console.WriteLine();
    }
} 