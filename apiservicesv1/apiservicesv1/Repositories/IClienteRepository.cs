using apiservicesv1.Models;

namespace apiservicesv1.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarCliente(string filterConditions);

        Task<Cliente> BuscarClienteID(int id);

        Task GuardarCliente(Cliente cliente);

        Task UpdateCliente(Cliente cliente, int id);

        Task EliminarCliente(int id, char nuevoEstado);

    }
}
