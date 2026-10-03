using apiservicesv1.Models;
using apiservicesv1.Repositories;
using apiservicesv1.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using static NuGet.Packaging.PackagingConstants;

namespace apiservicesv1.Controllers
{
    [Route("rest/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }



        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), 200)]
        public async Task<IActionResult> Index() {



            /*var defaultFilters = new Dictionary<string, string> {
                { "estado", "A" }
            };*/

            var filters = FilterManager.GetFilters(Request);
            var filterConditions = FilterManager.conditionsFilters<Cliente>(filters);

            var clientes = await _clienteRepository.ListarCliente(filterConditions);
            var queryorder = clientes.OrderByDescending(cli => cli.id);

            return Ok(queryorder);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            IActionResult result;

            try {
                var showcliente = await _clienteRepository.BuscarClienteID(id);
                result = Ok(showcliente);

            }catch(Exception e) {

                Console.WriteLine($"Ocurrió un error: {e.Message}");
                Debug.WriteLine($"Ocurrió un error: {e.Message}");
                result = StatusCode(500, "Ocurrió un error en el servidor"); ;
                
            }

            return result;
        }


        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), 200)]
        public async Task<IActionResult> Store([FromBody] Cliente cliente)
        {
            IActionResult result;

            try {

                await _clienteRepository.GuardarCliente(cliente);

                var response = new { Message = "Cliente guardado exitosamente." };
                result = Ok(response);

            }
            catch(Exception e)
            {
                Console.WriteLine($"Ocurrió un error: {e.Message}");
                Debug.WriteLine($"Ocurrió un error: {e.Message}");
                result = StatusCode(500, $"Ocurrió un error en el servidor DETALLES: { e.Message}");
            }
            return result;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            IActionResult result;

            try {

                await _clienteRepository.UpdateCliente(cliente, id);

                var response = new { Message = "Cliente actualizado exitosamente." };
                result = Ok(response);

            }
            catch (Exception e) {
                Console.WriteLine($"Ocurrió un error: {e.Message}");
                Debug.WriteLine($"Ocurrió un error: {e.Message}");
                result = StatusCode(500, $"Ocurrió un error en el servidor DETALLES: {e.Message}");
            }

            return result;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IActionResult result;

            try {

                var cliente = await _clienteRepository.BuscarClienteID(id);

                if (cliente == null)
                {
                    return NotFound(new { Message = "Cliente no encontrado." });
                }

                char nuevoEstado = (cliente.estado == 'A') ? 'E' : 'A';
                await _clienteRepository.EliminarCliente(id, nuevoEstado);

                string mensaje = (nuevoEstado == 'A') ? "restaurado" : "eliminado";

                return Ok(new { Message = $"Cliente {mensaje} correctamente." });
            }
            catch(Exception e) {
                Console.WriteLine($"Ocurrió un error: {e.Message}");
                Debug.WriteLine($"Ocurrió un error: {e.Message}");
                result = StatusCode(500, $"Ocurrió un error en el servidor DETALLES: {e.Message}");
            }

            return result;
        }
    }
}
