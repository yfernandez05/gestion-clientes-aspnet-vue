using apiservicesv1.Connection;
using apiservicesv1.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace apiservicesv1.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly string _connectionString;

        public ClienteRepository(ConnectionDB connectionDB)
        {
            _connectionString = connectionDB.cadenaSQL();
        }
        


        public async Task<IEnumerable<Cliente>> ListarCliente(string filterConditions)
        {
            var clientes = new List<Cliente>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                var queryBuilder = new StringBuilder("SELECT * FROM Cliente");

                if (!string.IsNullOrEmpty(filterConditions))
                {
                    queryBuilder.Append(filterConditions);
                }

                using (var sqlCommand = new SqlCommand(queryBuilder.ToString(), sqlConnection)) {

                    using (var reader = await sqlCommand.ExecuteReaderAsync()){

                        while (await reader.ReadAsync()){

                            var cliente = new Cliente{
                                id = (int)reader["id"],
                                nombre = (string)reader["nombre"],
                                apellidos = (string)reader["apellidos"],
                                edad = (string)reader["edad"],
                                correo = (string)reader["correo"],
                                telefono = (string)reader["telefono"],
                                estado = Convert.ToChar(reader["estado"]),
                                created_at = (DateTime)reader["created_at"]
                            };
                            clientes.Add(cliente);

                        }
                    }
                }
            }

            return clientes;
        }

        public async Task<Cliente> BuscarClienteID(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString)){
                
                using (var sqlCommand = new SqlCommand("ShowClienteID", sqlConnection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    await sqlConnection.OpenAsync();

                    using (var reader = await sqlCommand.ExecuteReaderAsync(CommandBehavior.SingleRow)){

                        if (await reader.ReadAsync()){

                            return new Cliente{
                                id = (int)reader["id"],
                                nombre = (string)reader["nombre"],
                                apellidos = (string)reader["apellidos"],
                                edad = (string)reader["edad"],
                                correo = (string)reader["correo"],
                                telefono = (string)reader["telefono"],
                                estado = Convert.ToChar(reader["estado"]),
                                created_at = (DateTime)reader["created_at"]
                            };

                        }
                        return null;
                    }

                }
            }
        }

        public async Task GuardarCliente(Cliente cliente)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        using (var sqlCommand = new SqlCommand("SaveCliente", sqlConnection, transaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@nombre", cliente.nombre);
                            sqlCommand.Parameters.AddWithValue("@apellidos", cliente.apellidos);
                            sqlCommand.Parameters.AddWithValue("@edad", cliente.edad);
                            sqlCommand.Parameters.AddWithValue("@correo", cliente.correo);
                            sqlCommand.Parameters.AddWithValue("@telefono", cliente.telefono);

                            await sqlCommand.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }
        }

        public async Task UpdateCliente(Cliente cliente, int clienteId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString)) {
                await sqlConnection.OpenAsync();

                using (var query = new SqlCommand("UpdateCliente", sqlConnection)) {
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.AddWithValue("@id", clienteId);
                    query.Parameters.AddWithValue("@nombre", cliente.nombre);
                    query.Parameters.AddWithValue("@apellidos", cliente.apellidos);
                    query.Parameters.AddWithValue("@edad", cliente.edad);
                    query.Parameters.AddWithValue("@correo", cliente.correo);
                    query.Parameters.AddWithValue("@telefono", cliente.telefono);
                    query.Parameters.AddWithValue("@estado", cliente.estado);

                    await query.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarCliente(int id, char nuevoEstado)
        {
            using (var sqlConnection = new SqlConnection(_connectionString)) {
                await sqlConnection.OpenAsync();

                using (var query = new SqlCommand("DeleteCliente", sqlConnection)) {
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.AddWithValue("@id", id);
                    query.Parameters.AddWithValue("@estado", nuevoEstado);

                    await query.ExecuteNonQueryAsync();
                }
            }
        }


        private bool IsValidFilterField(string fieldName)
        {
            var validFields = new List<string> { "nombre", "apellidos", "edad", "correo", "telefono", "estado" };
            return validFields.Contains(fieldName);
        }

    }
}
