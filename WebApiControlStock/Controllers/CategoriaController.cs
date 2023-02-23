using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiControlStock.Data;
using WebApiControlStock.Models;

namespace WebApiControlStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DBStockContext context;

        public CategoriaController(DBStockContext context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = context.Categorias.Include(c => c.Marcas).ToList();
            return categorias;
        }

        //GET by ID
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            var categoria = context.Categorias.Include(p => p.Marcas).FirstOrDefault(x => x.Id == id);

            if (categoria != null)
            {
                return Ok(categoria);
            }

            return NotFound();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Categorias.Add(categoria);
            context.SaveChanges();
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public ActionResult<Categoria> Edit(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            context.Entry(categoria).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var c = GetCategoria(id);

            if (c != null)
            {
                context.Categorias.Remove(c);
                context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        public Categoria GetCategoria(int id)
        {
            return context.Categorias.Find(id);
        }
    }
}
