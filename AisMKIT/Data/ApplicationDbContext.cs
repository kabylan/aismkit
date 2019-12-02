using System;
using System.Collections.Generic;
using System.Text;
using AisMKIT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AisMKIT.Data
{
    

   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Departments> Departments { get; set; }
        public DbSet<ClOKNTypes> ClOKNTypes { get; set; }
        public DbSet<ClServices> ClServices { get; set; }
        public DbSet<ClUchZavedCategory> ClUchZavedCategory { get; set; }
        public DbSet<ClObjProizIskusCategory> ClObjProizIskusCategory { get; set; }
        public DbSet<ClObjProizIskusTypes> ClObjProizIskusTypes { get; set; }
        public DbSet<ClNagradTypes> ClNagradTypes { get; set; }
        public DbSet<ListOfEducations> ListOfEducations { get; set; }        
        public DbSet<ListISRCFilms> listISRCFilms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Для postgresql
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AisMKIT;Username=postgres;Password=admin");
        //}
    }
}
