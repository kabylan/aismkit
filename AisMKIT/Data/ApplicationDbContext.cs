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
        
        // Список выданных гос. сертификатов к фильмам за 2019 
        public DbSet<ListISRCFilms> listISRCFilms { get; set; }

        // Реестр учебных заведений
        //public DbSet<EduInstitution> EduInstitutions { get; set; }

        // Реестр библиотек республики
        public DbSet<Library> Libraries { get; set; }

        // Реестр охраняемых объектов культурного наследия
        public DbSet<CultHeritage> CultHeritages { get; set; }

        // Реестр объектов произведений культуры и искусства
        public DbSet<CultObjectAndArt> CultObjectsAndArts { get; set; }

        // Реестр подведомственных учреждений Министерства
        public DbSet<SubInstitution> SubInstitutions { get; set; }

        // Реестр государственных и ведомственных наград    
        public DbSet<Award> Awards { get; set; }
        // персональные данные награжденных
        public DbSet<AwardedPerson> AwardedPersons { get; set; }


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
