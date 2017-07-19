using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinWindowsKochbuchProjekt.Datenmodell
{
    class RezeptDataContext : DbContext
    {
        public DbSet<Rezept> Rezepte { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<RezeptKategorie> RezeptKategorien { get; set; }
        public DbSet<Anleitung> Anleitungen { get; set; }
        public DbSet<Lebensmittel> Lebensmittels { get; set; }
        public DbSet<Naehrwerttabelle> Naehrwerttabellen { get; set; }
        public DbSet<LebensmittelKategorie> LebensmittelKategorien { get; set; }
        public DbSet<Bild> Bilder { get; set; }

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\myCookbook.db";

        public RezeptDataContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RezeptKategorie>()
                .HasKey(rk => new { rk.RezeptID, rk.KategorieID });

            modelBuilder.Entity<RezeptKategorie>()
                .HasOne(rk => rk.Rezept)
                .WithMany(t => t.RezeptKategorien);

            modelBuilder.Entity<RezeptKategorie>()
                .HasOne(rk => rk.Kategorie)
                .WithMany(k => k.RezeptKategorien);
        }

      
    }
}
