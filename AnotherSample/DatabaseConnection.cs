using System;
using System.Data.SqlClient;

public class DatabaseConnection
{
    private static DatabaseConnection _instance;
    private SqlConnection _connection;

    // Replace with your actual connection string
    private readonly string _connectionString = "Server=localhost;Database=inventory_system;Trusted_Connection=True;";

    // Private constructor to prevent instantiation
    private DatabaseConnection()
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }
        catch (Exception ex)
        {
            // Log or handle the error appropriately
            throw new Exception("Failed to initialize database connection.", ex);
        }
    }

    // Public static method to get the single instance
    public static DatabaseConnection Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
            }
            return _instance;
        }
    }

    // Expose the SQL connection
    public SqlConnection Connection
    {
        get
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }
    }


    // Optional: Method to close the connection
    public void CloseConnection()
    {
        if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }
}
