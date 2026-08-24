

namespace FILEAPI.Data.Models
{
    public class FileArchive
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? StorageName { get; set; }
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public long? StorageBytes { get; set; }
        public string Path { get; set; } = string.Empty;
        public int? Book_Id { get; set; }
        public Book? Book { get; set; }
        public int? Author_Id { get; set; }
        public Author? Author { get; set; }

    }

    public class FileArchiveGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? StorageName { get; set; }
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public long? StorageBytes { get; set; }
        public string Path { get; set; } = string.Empty;
        public int? Book_Id { get; set; }
        public int? Author_Id { get; set; }

    }

    public class FileArchiveInsertDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? StorageName { get; set; }
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public long? StorageBytes { get; set; }
        public string Path { get; set; } = string.Empty;
        public int? Book_Id { get; set; }
        public int? Author_Id { get; set; }

    }

    public class FileArchiveUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? StorageName { get; set; }
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public long? StorageBytes { get; set; }
        public string Path { get; set; } = string.Empty;
        public int? Book_Id { get; set; }
        public int? Author_Id { get; set; }

    }
}
