namespace LifeSafeAPI.Data.Models
{
    public class Book
    {
        public Book(string Name)
        {
            this.Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AuthorGetDTO> Authors { get; set; } = new List<AuthorGetDTO>();
        public ICollection<Url> URLS { get; set; } = new List<Url>();

    }
}
