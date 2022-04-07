using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity_Frametamer
{
    public class Application : DbContext
    {
        public Application()
        {
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\Mssqllocaldb;Database=Libriary;Trusted_Connection=True;");
        }
        public DbSet<Book> Books { get; set; }
    }
}