using LifeSafeAPI.Data.Models;

namespace LifeSafeAPI.Data.DTOs.Author
{
    public class AuthorGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();
    }
}
