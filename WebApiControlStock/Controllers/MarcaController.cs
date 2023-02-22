using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiControlStock.Data;
using WebApiControlStock.Models;

namespace WebApiControlStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly DBStockContext context;

        public MarcaController(DBStockContext context)
        {
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Marca>> Get()
        {
            List<Marca> marcas = context.Marcas.Include(m => m.Categoria).ToList();
            return marcas;
        }

        //GET by ID
        [HttpGet("{id}")]
        public ActionResult<Marca> GetById(int id)
        {
            var marca = context.Marcas.Include(m => m.Categoria).FirstOrDefault(x => x.Id == id);

            if (marca != null)
            {
                return Ok(marca);
            }

            return NotFound();
        }

        //POST
        [HttpPost]
        public ActionResult Post(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Marcas.Add(marca);
            context.SaveChanges();
            return Ok(marca);
        }

        [HttpPut("{id}")]
        public ActionResult<Marca> Edit(int id, [FromBody] Marca marca)
        {
            if (id != marca.Id)
            {
                return BadRequest();
            }

            context.Entry(marca).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(marca);
        }

        [HttpDelete("{id}")]
        public ActionResult<Marca> Delete(int id)
        {
            var marca = GetCategoria(id);

            if (marca != null)
            {
                context.Marcas.Remove(marca);
                context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        public Marca GetCategoria(int id)
        {
            return context.Marcas.Find(id);
        }
    }
}
