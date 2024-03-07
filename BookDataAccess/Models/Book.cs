namespace BookDataAccess.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PubYear { get; set; }
    public Author Author { get; set; }
    public Genre Genre { get; set; }

    public override string? ToString()
    {
        return $"{Title} ({PubYear.ToShortDateString()})";
    }
}
