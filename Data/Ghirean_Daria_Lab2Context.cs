using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ghirean_Daria_Lab2.Models;

namespace Ghirean_Daria_Lab2.Data
{
    public class Ghirean_Daria_Lab2Context : DbContext
    {
        public Ghirean_Daria_Lab2Context (DbContextOptions<Ghirean_Daria_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ghirean_Daria_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Ghirean_Daria_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Ghirean_Daria_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
