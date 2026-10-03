using System.Configuration;

namespace apiservicesv1.Connection
{
    public class ConnectionDB
    {
        private readonly string cnn;

        public ConnectionDB(IConfiguration configuration) {
            cnn = configuration.GetConnectionString("DefaultConnection");
        }

        public string cadenaSQL() {
            return cnn;
        }
    }
}
