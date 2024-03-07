using BookDataAccess.Models;
using BookDataAccess.Repositories;
using ConsoleCommandApp.Feature;

namespace BookCCA.Features;

public class ListBooksFeature : BaseFeature
{
    public override void Run()
    {
        var repo = new BookRepository(Helpers.GetConnectionString(App.Config));

        int i = 1;
        foreach (Book book in repo.AllBooks())
        {
            App.Output.Write($"{i++}.\t{book}\n");
            App.Output.Write($"\t({book.Genre}) written by {book.Author.FullName}\n\n");
        }

        App.Output.Wait();
    }
}