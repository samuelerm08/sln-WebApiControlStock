using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using WebApiControlStock.Data;
using WebApiControlStock.Models;

namespace WebApiControlStock.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DBStockContext context;

        public ProductoController(DBStockContext context)
        { 
            this.context = context;
        }

        //GET
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return context.Productos.Include(c => c.Categoria).ToList();
        }

        //GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = context.Productos.Include(p => p.Categoria)
                           .FirstOrDefault(p => p.Id == id);
            return producto;
        }

        //POST
        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Productos.Add(producto);
            context.SaveChanges();
            return Ok();
        }
    }
}
