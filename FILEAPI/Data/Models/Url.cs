namespace LifeSafeAPI.Data.Models
{
    public class Url(string Text)
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string Text { get; set; } = Text;

        public int? Book_Id { get; set; }
        public Book? Book { get; set; }
        public int? Author_Id { get; set; }
        public AuthorGetDTO? Author { get; set; }

    }
}
