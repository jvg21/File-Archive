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
        public bool IsActive { get; set; } = true;

    }

    public class UrlInsertDTO
    {
        public string? Name { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? Book_Id { get; set; }
        public int? Author_Id { get; set; }
    }

    public class UrlUpsertDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public class UrlGetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }

    public class UrlUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? Book_Id { get; set; }
        public int? Author_Id { get; set; }
        public bool? IsActive { get; set; }

    }



}
