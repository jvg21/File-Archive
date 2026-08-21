namespace FILEAPI.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();
    }


    public class AuthorGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public ICollection<Models.Book> Books { get; set; } = new List<Models.Book>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();


    }

    public class AuthorInsertDTO
    {
        public string Name { get; set; } = string.Empty;
        //public ICollection<Models.Book> Books { get; set; } = new List<Models.Book>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();


    }

    public class AuthorUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public ICollection<Url> URLS { get; set; } = new List<Url>();


    }
}
