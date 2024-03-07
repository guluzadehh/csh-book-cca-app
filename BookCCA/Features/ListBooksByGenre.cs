using BookDataAccess;
using BookDataAccess.Models;
using BookDataAccess.Repositories;
using ConsoleCommandApp.Exceptions;
using ConsoleCommandApp.Feature;

namespace BookCCA;

public class ListBooksByGenreFeature : BaseFeature
{
    public override void Run()
    {
        var genreRepository = new GenreRepository(Helpers.GetConnectionString(App.Config));
        var genres = genreRepository.AllGenres().ToList();

        int i = 1;
        foreach (Genre g in genres)
        {
            App.Output.Write($"{i++}. {g}\n");
        }

        App.Output.Write("\n");
        App.Output.Write("Select genre");

        int index = 0;
        App.Input.ReadClear(value => int.TryParse(value, out index));

        if (index - 1 < 0 || index - 1 >= genres.Count)
        {
            throw new FeatureException($"Wrong index for genres `{index}`\n");
        }

        Genre genre = genres[index - 1];
        App.Output.Write($"Genre: {genre}\n\n");

        var bookRepository = new BookRepository(Helpers.GetConnectionString(App.Config));

        i = 1;
        foreach (Book book in bookRepository.AllBooksByGenre(genre.Id))
        {
            App.Output.Write($"{i++}.\t{book}\n");
            App.Output.Write($"\t({book.Genre}) written by {book.Author.FullName}\n\n");
        }

        App.Output.Wait();
    }
}
