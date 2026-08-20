

namespace FILEAPI.Data.Models
{
    public class File
    {
        public File(string Name,string Path)
        {
            this.Name = Name;
            this.Path = Path;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? StorageName { get; set; }
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public long? StorageBytes { get; set; }
        public string Path { get; set; }
        public int? Book_Id { get; set; }
        public Book? Book { get; set; }
        public int? Author_Id { get; set; }
        public Author? Author { get; set; }




    }
}
