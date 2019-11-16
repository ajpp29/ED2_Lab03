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
        public IEnumerable<Models.Pizza> Get()
        {
            return db.Listadopizzas.ToArray();
        }

        // GET: api/Pizza/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pizza
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pizza/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
