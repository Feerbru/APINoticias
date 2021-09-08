using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoticiaAPI.Models;
using NoticiaAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoticiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : Controller
    {

        private readonly NoticiaService noticiaService;

        public NoticiaController(NoticiaService noticiaService)
        {
            this.noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            return Ok(noticiaService.Obtener());
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] Noticia noticia)
        {
            var resultado = noticiaService.AgregarNoticia(noticia);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar/{id}")]
        public IActionResult Editar(int id, [FromBody] Noticia noticia)
        {
            var resultado = noticiaService.EditarNoticia(id, noticia);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            var resultado = noticiaService.EliminarNoticia(id);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
      
    }
}
