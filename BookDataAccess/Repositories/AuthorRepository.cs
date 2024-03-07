using System.Data;
using BookDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BookDataAccess.Repositories;

public class AuthorRepository(string connectionString) : BaseRepository(connectionString)
{
    public IEnumerable<Author> AllAuthors()
    {
        using IDbConnection connection = new SqlConnection(ConnectionString);
        return connection.Query<Author>(
            "spAuthors_GetAll",
            commandType: CommandType.StoredProcedure
        );
    }

    public IEnumerable<Author> AllAuthorsByFullName(string fullName)
    {
        using IDbConnection connection = new SqlConnection(ConnectionString);
        return connection.Query<Author>(
            "spAuthors_GetLikeFullName",
            new { fullName },
            commandType: CommandType.StoredProcedure
        );
    }
}
