using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NoticiaAPI.Models;

namespace NoticiaAPI.Services
{
    public class NoticiaService
    {
        private readonly NoticiaDBContext noticiaDBContext;

        public NoticiaService(NoticiaDBContext noticiaDBContext)
        {
            this.noticiaDBContext = noticiaDBContext;
        }

        public List<Noticia> Obtener()
        {
            return noticiaDBContext.Noticia.Include(x => x.Autor).ToList();
           
        }


        public Boolean AgregarNoticia(Noticia noticia)
        {
            try
            {
                noticiaDBContext.Noticia.Add(noticia);
                noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean EditarNoticia(int id, Noticia noticia)
        {
            try
            {

                //var noticiaDB = noticiaDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == noticia.NoticiaID).FirstOrDefault();
                var noticiaDB = noticiaDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == id).FirstOrDefault();
                noticiaDB.Titulo = noticia.Titulo;
                noticiaDB.Descripcion = noticia.Descripcion;
                noticiaDB.Contenido = noticia.Contenido;
                noticiaDB.Fecha = noticia.Fecha;
                noticiaDB.AutorID = noticia.AutorID;

                noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean EliminarNoticia(int NoticiaID)
        {
            try
            {
                var noticiaDB = noticiaDBContext.Noticia.Where(busqueda => busqueda.NoticiaID == NoticiaID).FirstOrDefault();
                noticiaDBContext.Noticia.Remove(noticiaDB);
                noticiaDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
