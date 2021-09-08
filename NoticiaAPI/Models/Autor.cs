using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoticiaAPI.Models
{
    public class Autor
    {
        public int AutorID { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Autor> mapeoAutor)
            {
                mapeoAutor.HasKey(x => x.AutorID);
                mapeoAutor.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeoAutor.ToTable("Autor");
            }
        }
    }
}
