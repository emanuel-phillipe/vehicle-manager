using Dapper;
using Microsoft.Data.SqlClient;

namespace VehicleManager.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static void Migrate(string connectionString)
    {
        EnsureDatabaseExists(connectionString);
    }

    private static void EnsureDatabaseExists(string connectionString)
    {
        var connectionBuilder = new SqlConnectionStringBuilder(connectionString);
        var databaseName = connectionBuilder.InitialCatalog;
        
        connectionBuilder.Remove("Initial Catalog");
        
        using var dbConnection = new SqlConnection(connectionBuilder.ConnectionString);
        var parameters = new DynamicParameters();
        parameters.Add("name", databaseName);

        var records = dbConnection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);
        if (!records.Any())
        {
            dbConnection.Execute($"CREATE DATABASE {databaseName}");
        }
    }
}