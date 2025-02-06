using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {

                options.Equals("Data Source=oop-tutorial-2025-02-06.db");

            }

        }
    }
}
