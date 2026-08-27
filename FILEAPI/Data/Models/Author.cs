namespace FILEAPI.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<FileArchive>? Files { get; set; } = new List<FileArchive>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();
    }


    public class AuthorGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<BookGetSummaryDTO> Books { get; set; } = new List<BookGetSummaryDTO>();
        public ICollection<UrlGetDTO> URLS { get; set; } = new List<UrlGetDTO>();
        public ICollection<FileArchive>? Files { get; set; } = new List<FileArchive>();
    }

    public class AuthorGetSummaryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class AuthorInsertDTO
    {
        public string Name { get; set; } = string.Empty;
        //public ICollection<BookInsertDTO>? Books { get; set; } = new List<BookInsertDTO>();
        public ICollection<UrlInsertDTO> URLS { get; set; } = new List<UrlInsertDTO>();
        //public ICollection<FileArchive>? Files { get; set; } = new List<FileArchive>();
    }

    public class AuthorUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
