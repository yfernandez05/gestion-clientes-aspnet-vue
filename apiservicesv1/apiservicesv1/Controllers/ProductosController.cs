using apiservicesv1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiservicesv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        public DbContext conexion;

        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<string> POST(Cliente request)
        {

            /*Cliente cliente = new Cliente();
            cliente = request.nombre;
            conexion.cliente.Add(cliente);
            //Guardar
            conexion.SaveChanges();

           
            return new string[] { "value1", "value2" , milista = cliente};*/
            return null;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
