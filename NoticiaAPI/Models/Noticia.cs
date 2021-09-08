using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoticiaAPI.Models
{
    public class Noticia
    {
        public int NoticiaID { get; set; }

        public String Titulo { get; set; }

        public String Descripcion { get; set; }

        public String Contenido { get; set; }

        public DateTime Fecha { get; set; }

        public int AutorID { get; set; }

        public Autor Autor { get; set; }


        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Noticia> mapeoNoticia)
            {
                mapeoNoticia.HasKey(x => x.NoticiaID);
                mapeoNoticia.Property(x => x.Titulo).HasColumnName("Titulo");
                mapeoNoticia.Property(x => x.Descripcion).HasColumnName("Descripcion");
                mapeoNoticia.ToTable("Noticia");
                mapeoNoticia.HasOne(x => x.Autor);
            }
        }
    }
}
