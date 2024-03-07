using System.Diagnostics.CodeAnalysis;
using ConsoleCommandApp.Command;

namespace BookCCA.Commands;

public class FindBooksByTitleCommand : BaseConsoleCommand
{
    [SetsRequiredMembers]
    public FindBooksByTitleCommand()
    {
        Value = "lbt";
        Description = "Find books by title";
    }
}

public class GetAuthorCommand : BaseConsoleCommand
{
    [SetsRequiredMembers]
    public GetAuthorCommand()
    {
        Value = "ga";
        Description = "Get Author by fullname";
    }
}

public class ListBooksByGenreCommand : BaseConsoleCommand
{
    [SetsRequiredMembers]
    public ListBooksByGenreCommand()
    {
        Value = "lbg";
        Description = "List books by genre";
    }
}