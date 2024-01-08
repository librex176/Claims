using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claims.Models
{
    public class ListaCartas
    {
        [Key]
        public int IdListaCartasPk { get; set; }
        public int IdCliente { get; set; }
        public string NombreCarta { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }

        // Relación con la tabla Cliente
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
    }
}
