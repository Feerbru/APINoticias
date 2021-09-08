using System;
using Microsoft.EntityFrameworkCore;
using NoticiaAPI.Models;

namespace NoticiaAPI
{
    public class NoticiaDBContext : DbContext
    {
        public NoticiaDBContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Noticia.Mapeo(modelBuilder.Entity<Noticia>());
            new Autor.Mapeo(modelBuilder.Entity<Autor>());
        }
    }
}
