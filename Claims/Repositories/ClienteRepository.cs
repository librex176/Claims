using Claims.Data;
using Claims.Models;

namespace Claims.Repositories
{
    public class ClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // Método personalizado para obtener clientes con deuda
        public List<Cliente> ClientesConDeuda()
        {
            return _context.Clientes.Where(c => c.Deuda > 0).ToList();
        }
   
    }

}
