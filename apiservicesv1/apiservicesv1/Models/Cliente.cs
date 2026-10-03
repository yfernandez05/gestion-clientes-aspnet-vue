
using apiservicesv1.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apiservicesv1.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string edad { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public char estado { get; set; }

        [JsonIgnore]
        public DateTime created_at { get; set; }


        [JsonPropertyName("fecha")]
        public string FormattedCreatedAt => created_at.ToString("dd-MM-yyyy");


        public string statename => RuleManager.GetStateName(estado);   
        public bool isactive => RuleManager.GetIsActive(estado);


        public Cliente()
        {
        }

        public Cliente(int id, string nombre, string apellidos, string edad, string correo, string telefono, char estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.correo = correo;
            this.telefono = telefono;
            this.estado = estado;
        }


    }


}
