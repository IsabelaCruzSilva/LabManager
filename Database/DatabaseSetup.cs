namespace LabManager.Database;

using Microsoft.Data.Sqlite;

class DatabaseSetup
{

    private readonly DatabaseConfig _databaseConfig; //readonly (depois que você colocar um valor, não é possível mais alterá-lo)

    public DatabaseSetup (DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig; //o primeiro é o atrubuto (por isso o this, para difrenciar)
        CreateCompuertTable();
        CreateLabTable(); 
    }
    public void CreateCompuertTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();


        var command = connection.CreateCommand();
        command.CommandText = @"
            
            CREATE TABLE IF NOT EXISTS Computers(
                id int not null primary key,
                ram varchar(100) not null, 
                processor varchar(100) not null
            );
        ";  

        command.ExecuteNonQuery();
        connection.Close(); 
    }

    public void CreateLabTable()
    {

    }

}