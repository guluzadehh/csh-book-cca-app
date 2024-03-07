using System.Data;
using BookDataAccess.Models;
using BookDataAccess.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BookDataAccess;

public class GenreRepository : BaseRepository
{
    public GenreRepository(string connectionString) : base(connectionString)
    {
    }

    public IEnumerable<Genre> AllGenres()
    {
        using IDbConnection connection = new SqlConnection(ConnectionString);
        return connection.Query<Genre>(
            "spGenres_GetAll",
            commandType: CommandType.StoredProcedure
        );
    }
}
