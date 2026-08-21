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
        public ICollection<UrlGetDTO> URLS { get; set; } = new List<UrlGetDTO>();
    }

    public class AuthorInsertDTO
    {
        public string Name { get; set; } = string.Empty;
        //public ICollection<Models.Book> Books { get; set; } = new List<Models.Book>();
        public ICollection<UrlInsertDTO> URLS { get; set; } = new List<UrlInsertDTO>();
    }

    public class AuthorUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
