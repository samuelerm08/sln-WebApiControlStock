using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

            if (producto != null)
            {
                return Ok(producto);
            }

            return NotFound();
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
            return Ok(producto);
        }

        //PUT
        [HttpPut("{id}")]
        public ActionResult<Producto> Edit(int id, [FromBody] Producto producto)
        {

            if (id != producto.Id)
            {
                return BadRequest();
            }

            context.Entry(producto).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var p = GetProducto(id);

            if (p != null)
            {
                context.Productos.Remove(p);
                context.SaveChanges();
                return Ok(p);
            }

            return NotFound();
        }

        public Producto GetProducto(int id)
        {
            return context.Productos.Find(id);
        }
    }
}
