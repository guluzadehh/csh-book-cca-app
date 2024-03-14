using System.Data;
using BookDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BookDataAccess.Repositories;

public class BookRepository(string connectionString) : BaseRepository(connectionString)
{
    private Book ReadData(Book book, Author author, Genre genre)
    {
        book.Author = author;
        book.Genre = genre;
        return book;
    }

    public IEnumerable<Book> AllBooks()
    {
        return GetBooks("spBooks_GetAll");
    }

    public IEnumerable<Book> AllBooksByTitle(string title)
    {
        return GetBooks("spBooks_GetLikeTitle", new { title });
    }

    public IEnumerable<Book> AllBooksByAuthor(int authorId)
    {
        return GetBooks("spBooks_GetByAuthor", new { authorId });
    }

    public IEnumerable<Book> AllBooksByGenre(int genreId)
    {
        return GetBooks("spBooks_GetByGenre", new { genreId });
    }

    protected IEnumerable<Book> GetBooks(string procName, object? parameters = null)
    {
        using IDbConnection connection = new SqlConnection(ConnectionString);
        return connection.Query<Book, Author, Genre, Book>(
            procName,
            ReadData,
            param: parameters,
            splitOn: "AuthorId,GenreId",
            commandType: CommandType.StoredProcedure);
    }
}
