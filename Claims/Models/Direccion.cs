using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claims.Models
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }
        public int IdCliente { get; set; }
        public string NombreRemitente { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int Celular { get; set; }

        

        // Relación con la tabla Direccion
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
    }

}
