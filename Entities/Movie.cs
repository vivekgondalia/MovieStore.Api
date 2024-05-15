namespace MovieStore.Api.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public required string ImageUri { get; set; }
    }
}