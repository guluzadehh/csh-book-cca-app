using ConsoleCommandApp.Feature;
using BookDataAccess.Models;
using BookDataAccess.Repositories;

namespace BookCCA.Features;

public class FindBooksByTitleFeature : BaseFeature
{
    public override void Run()
    {
        App.Output.Write("Enter title");
        string title = App.Input.Read();

        var repository = new BookRepository(Helpers.GetConnectionString(App.Config));

        List<Book> books = repository.AllBooksByTitle(title).ToList();
        if (books.Count == 0)
        {
            App.Output.WriteAndWait($"Couldn't find books by title {title}\n");
            return;
        }

        int i = 1;
        foreach (Book book in books)
        {
            App.Output.Write($"{i++}.\t{book}\n");
            App.Output.Write($"\t({book.Genre}) written by {book.Author.FullName}\n\n");
        }

        App.Output.Wait();
    }
}
