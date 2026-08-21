namespace FILEAPI.Data.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string Content { get; set; } = string.Empty;

        public int? Book_Id { get; set; }
        public Book? Book { get; set; }
        public int? Author_Id { get; set; }
        public Author? Author { get; set; }

    }
}
