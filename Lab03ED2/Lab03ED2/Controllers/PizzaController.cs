using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab03ED2.DBContext;
using Lab03ED2.Services;

namespace Lab03ED2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public DefaultConnection db = DefaultConnection.getInstance;
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET: api/Pizza
        [HttpGet]
        public IActionResult Get()
        {
            //Models.Pizza aux = new Models.Pizza();
            //aux.Nombre = "Pizza1";
            //aux.Tamanio = "Pequenia";
            //db.Listadopizzas.Add(aux);
            if (_pizzaService.Get().Count == 0)
                return NotFound();
            return Ok(_pizzaService.Get().ToArray());
        }

        // GET: api/Pizza/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (_pizzaService.Get().Count == 0)
                return NotFound();
            if (_pizzaService.Get().Count < id-1 || id < 0)
                return NotFound();

            var pizza = _pizzaService.Get(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        // POST: api/Pizza
        [HttpPost]
        public IActionResult Post([FromBody] Models.Pizza value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Tipo de dato no valido");
            if (value.Ingredientes == null|| value.Nombre == null || value.Cantidad_Porciones == 0 || value.Ingredientes == null || value.Tamanio == null || value.Tipo_Masa == null)
                return BadRequest("Valores no validos");
            value.Id = db.obtenerId();
            _pizzaService.Create(value);
            return Ok(CreatedAtRoute("GetPizza", new { id = value.Id.ToString() }, value));
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
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
            {
                return NotFound();
            }
            value.Id = id;
            _pizzaService.Update(id, value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (db.Listadopizzas.Count == 0)
                return NotFound();
            if (db.Listadopizzas.Count < id - 1 || id < 0)
                return NotFound();

            var pizza = _pizzaService.Get(id);
            if (pizza == null)
            {
                return NotFound();
            }
            _pizzaService.Remove(pizza.Id);

            return Ok();
        }
    }
}
