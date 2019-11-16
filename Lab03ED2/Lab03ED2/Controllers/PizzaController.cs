using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab03ED2.DBContext;

namespace Lab03ED2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public DefaultConnection db = DefaultConnection.getInstance;

        // GET: api/Pizza
        [HttpGet]
        public IActionResult Get()
        {
            Models.Pizza aux = new Models.Pizza();
            aux.Nombre = "Pizza1";
            aux.Tamanio = "Pequenia";
            db.Listadopizzas.Add(aux);
            if (db.Listadopizzas.Count == 0)
                return NotFound();
            return Ok(db.Listadopizzas.ToArray());
        }

        // GET: api/Pizza/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (db.Listadopizzas.Count == 0)
                return NotFound();
            if (db.Listadopizzas.Count < id-1 || id < 0)
                return NotFound();
            return Ok(db.Listadopizzas[id]);
        }

        // POST: api/Pizza
        [HttpPost]
        public IActionResult Post([FromBody] Models.Pizza value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Tipo de dato no valido");
            if (value.Ingredientes == null|| value.Nombre == null || value.Cantidad_Porciones == 0 || value.Ingredientes == null || value.Tamanio == null || value.Tipo_Masa == null)
                return BadRequest("Valores no validos");
            db.Listadopizzas.Add(value);
            return Ok();
        }

        // PUT: api/Pizza/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Pizza value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Tipo de dato no valido");
            if (db.Listadopizzas.Count < id - 1 || id < 0)
                return NotFound();
            if (value.Ingredientes == null || value.Nombre == null || value.Cantidad_Porciones == 0 || value.Ingredientes == null || value.Tamanio == null || value.Tipo_Masa == null)
                return BadRequest("Valores no validos");
            db.Listadopizzas.Insert(id, value);
            return Ok(db.Listadopizzas[id]);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (db.Listadopizzas.Count == 0)
                return NotFound();
            if (db.Listadopizzas.Count < id - 1 || id < 0)
                return NotFound();
            db.Listadopizzas.RemoveAt(id);
            return Ok();
        }
    }
}
