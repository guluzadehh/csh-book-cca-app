using BookDataAccess.Models;
using BookDataAccess.Repositories;
using ConsoleCommandApp.Feature;

namespace BookCCA;

public class ListAuthorsFeature : BaseFeature
{
    public override void Run()
    {
        var repository = new AuthorRepository(Helpers.GetConnectionString(App.Config));

        int i = 1;
        foreach (Author author in repository.AllAuthors())
        {
            App.Output.Write($"{i++}. {author.FullName}\n");
        }

        App.Output.WriteAndWait("\n");
    }
}
