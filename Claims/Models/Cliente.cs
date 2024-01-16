using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claims.Models
{
    public class Cliente
    {
        [Key]
        public int IdClientePk { get; set; }
        public string Nombre { get; set; }
        public decimal Deuda { get; set; }
        public bool Envio { get; set; }
        public bool PagoEnvio { get; set; }
       
    }
}
