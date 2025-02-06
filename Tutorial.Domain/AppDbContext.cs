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
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {

                options.Equals("Data Source=c:/sqlite/students-2025-02-06.db");

            }

        }
    }
}
