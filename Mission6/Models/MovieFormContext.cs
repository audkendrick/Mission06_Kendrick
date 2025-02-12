using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Mission6.Models
{
    // Set up the DB Connection
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }


    }
}
