﻿using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    // Create the Category table to match the database
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
