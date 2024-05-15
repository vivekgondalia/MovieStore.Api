using System.ComponentModel.DataAnnotations;

namespace MovieStore.Api.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(20)]
        public required string Genre { get; set; }

        [Range(1, 3)]
        public decimal NumberOfCopies { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Url]
        [StringLength(100)]
        public required string ImageUri { get; set; }
    }
}