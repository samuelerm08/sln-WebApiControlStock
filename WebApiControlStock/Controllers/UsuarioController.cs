using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebApiControlStock.Data;
using WebApiControlStock.Models;

namespace WebApiControlStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DBStockContext context;

        public UsuarioController(DBStockContext context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            List<Usuario> usuarios = context.Usuarios.ToList();
            return usuarios;
        }

        //GET by ID
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuarios = context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuarios != null)
            {
                return Ok(usuarios);
            }

            return NotFound();
        }

        //GET by Nombre o Apellido
        [HttpGet("filter/{text}")]
        public ActionResult<Usuario> GetByNombreApellido(string text)
        {
            var usuarios = context.Usuarios
                           .Where(i => i.Nombre == text || i.Apellido == text)
                           .FirstOrDefault();

            if (usuarios != null)
            {
                return Ok(usuarios);
            }

            return NotFound();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //context.Usuarios.Add(usuario);
            //context.SaveChanges();
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public ActionResult<Usuario> Edit(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            //context.Entry(usuario).State = EntityState.Modified;
            //context.SaveChanges();
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            var usuario = GetCategoria(id);

            if (usuario != null)
            {
                //context.Usuarios.Remove(usuario);
                //context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        public Usuario GetCategoria(int id)
        {
            return context.Usuarios.Find(id);
        }
    }
}
