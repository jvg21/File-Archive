using FILEAPI.Utils;

namespace FILEAPI.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string? Summary { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public int? Rating { get; set; } 
        public int? TotalChapters { get; set; }
        public int? CurrentChapter { get; set; }
        public int? Words { get; set; }
        public ModelEnums.ReadingStatus ReadingStatus { get; set; }
        public ModelEnums.WritingStatus WritingStatus { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<FileArchive>? Files { get; set; } = new List<FileArchive>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();

    }
    public class BookGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Summary { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public int? TotalChapters { get; set; }
        public int? CurrentChapter { get; set; }
        public int? Words { get; set; }
        public ModelEnums.ReadingStatus ReadingStatus { get; set; }
        public ModelEnums.WritingStatus WritingStatus { get; set; }

        public ICollection<FileArchive>? Files { get; set; } = new List<FileArchive>();
        public ICollection<UrlGetDTO> URLS { get; set; } = new List<UrlGetDTO>();
    }

    public class BookInsertDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Summary { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public int? TotalChapters { get; set; }
        public int? CurrentChapter { get; set; }
        public int? Words { get; set; }
        public ModelEnums.ReadingStatus ReadingStatus { get; set; }
        public ModelEnums.WritingStatus WritingStatus { get; set; }
        public ICollection<FileArchive>? Files { get; set; } = new List<FileArchive>();
        public ICollection<UrlInsertDTO> URLS { get; set; } = new List<UrlInsertDTO>();
    }

    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Summary { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public int? TotalChapters { get; set; }
        public int? CurrentChapter { get; set; }
        public int? Words { get; set; }
        public ModelEnums.ReadingStatus? ReadingStatus { get; set; }
        public ModelEnums.WritingStatus? WritingStatus { get; set; }
    }

}
