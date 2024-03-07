namespace BookDataAccess.Repositories;

public class BaseRepository
{
    public string ConnectionString { get; }

    public BaseRepository(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) throw new Exception("Invalid connection string");
        ConnectionString = connectionString;
    }
}
