using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Mission6.Models
{

    // Set up database table with various columns related to Films

    // Some of the fields are required and some (edited, lent, and notes) can be left blank 

    public class Form
    {
        [Key]
        [Required]
        public int MovieID { get; set; } //If only get, read only

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        public string Category { get; set; }


        [Required(ErrorMessage = "Category is required.")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Director name is required.")]
        public string Director { get; set; }


        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string? Lent { get; set; }


        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }


    }
}
