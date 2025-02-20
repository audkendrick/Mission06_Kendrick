using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Mission6.Models
{

// Set up the table for the movie list database
// Make sure moveId, Title, Year (at least 1888), Edited, and Copied to Plex are required

    public class Movies
    {
        [Key]
        [Required]
        public int MovieId { get; set; } //If only get, read only

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        [Range(1888, 2025)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }


    }
}
