using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claims.Models
{
    public class Direccion
    {
        [Key]
        public int IdDireccionPk { get; set; }
        public string NombreRemitente { get; set; }
        public string CalleNumero { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int Celular { get; set; }

        
    }

}
