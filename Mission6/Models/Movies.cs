using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Mission6.Models
{

    // Set up database table with various columns related to Films

    // Some of the fields are required and some (edited, lent, and notes) can be left blank 

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

        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set; }


        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }


    }
}
