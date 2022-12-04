using System;
using Microsoft.EntityFrameworkCore;

namespace Polaris.Data
{
        public class DataContext : DbContext
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options)
                {

                }

                public DbSet<Character> Characters { get; set; }
                //public DbSet<Character> Characters => Set<Character>();
        }
}
