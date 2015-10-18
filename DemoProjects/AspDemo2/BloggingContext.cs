using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7Demo
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(EntityOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.ConsoleApp;Trusted_Connection=True;");

        //    // Visual Studio 2013 | Use the LocalDb 11 instance created by Visual Studio
        //    // optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=EFGetStarted.ConsoleApp;Trusted_Connection=True;");

        //    // Visual Studio 2012 | Use the SQL Express instance created by Visual Studio
        //    // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EFGetStarted.ConsoleApp;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make Blog.Url required
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .Required(true);
        }
    }


}
