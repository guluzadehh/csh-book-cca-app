using BookDataAccess.Models;
using BookDataAccess.Repositories;
using ConsoleCommandApp.Exceptions;
using ConsoleCommandApp.Feature;

namespace BookCCA;

public class GetAuthorFeature : BaseFeature
{
    public override void Run()
    {
        App.Output.Write("Enter Author fullname");
        string fullName = App.Input.ReadClear();

        var repository = new AuthorRepository(Helpers.GetConnectionString(App.Config));

        var authors = repository.AllAuthorsByFullName(fullName).ToList();
        if (authors.Count == 0)
        {
            App.Output.WriteAndWait($"Author with fullname `{fullName}` doesn't exist.\n");
            return;
        }

        Author author = authors.Count > 1 ? SelectAuthor(authors, fullName) : authors.First();

        App.Output.Write($"{author}\n\n");

        var bookRepository = new BookRepository(Helpers.GetConnectionString(App.Config));
        IEnumerable<Book> books = bookRepository.AllBooksByAuthor(author.Id);

        App.Output.Write("Author books:\n\n");
        foreach (Book book in books)
        {
            App.Output.Write($"{book} ({book.Genre})\n");
        }

        App.Output.Write("\n");
        App.Output.Wait();
    }

    protected Author SelectAuthor(List<Author> authors, string fullName)
    {
        App.Output.Write($"Authors with fullname `{fullName}`\n\n");

        int i = 1;
        foreach (Author author in authors)
        {
            App.Output.Write($"{i++}. {author.FullName}\n");
        }

        App.Output.Write("\n");

        int index = 0;

        App.Output.Write("Enter index");
        App.Input.ReadClear(value => int.TryParse(value, out index));

        if (index - 1 < 0 || index - 1 >= authors.Count)
        {
            throw new FeatureException($"Wrong index for authors `{index}`\n");
        }

        return authors[index - 1];
    }
}
