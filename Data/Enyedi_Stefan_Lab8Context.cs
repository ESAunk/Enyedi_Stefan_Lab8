using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Enyedi_Stefan_Lab8.Models;

namespace Enyedi_Stefan_Lab8.Data
{
    public class Enyedi_Stefan_Lab8Context : DbContext
    {
        public Enyedi_Stefan_Lab8Context (DbContextOptions<Enyedi_Stefan_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Enyedi_Stefan_Lab8.Models.Book> Book { get; set; }

        public DbSet<Enyedi_Stefan_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Enyedi_Stefan_Lab8.Models.Category> Category { get; set; }
    }
}
