using BookCCA;
using BookCCA.Commands;
using BookCCA.Features;
using ConsoleCommandApp.App;
using ConsoleCommandApp.Command;
using Microsoft.Extensions.DependencyInjection;

var host = BaseApp.CreateDefaultBuilder().Build();
var app = host.Services.GetRequiredService<IApp>();

app.Route(new BaseConsoleCommand { Value = "lb", Description = "List books" }, new ListBooksFeature());
app.Route(new FindBooksByTitleCommand(), new FindBooksByTitleFeature());
app.Route(new BaseConsoleCommand { Value = "la", Description = "List authors" }, new ListAuthorsFeature());
app.Route(new GetAuthorCommand(), new GetAuthorFeature());
app.Route(new ListBooksByGenreCommand(), new ListBooksByGenreFeature());

app.Start();