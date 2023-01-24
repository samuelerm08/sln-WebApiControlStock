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
            List<Categoria> categorias = context.Categorias.Include(c => c.Productos).ToList();
            return categorias;
        }

        //GET by ID
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            Categoria categoria = context.Categorias.Include(x => x.Productos).FirstOrDefault(x => x.Id == id);
            return categoria;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return Ok();
        }
    }
}
