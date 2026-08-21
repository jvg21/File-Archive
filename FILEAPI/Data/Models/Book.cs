namespace FILEAPI.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();

    }
    public class BookGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Models.Author> Authors { get; set; } = new List<Models.Author>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();
    }

}
