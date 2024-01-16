
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Claims.Data;
using Claims.Models;

namespace Claims.Controllers
{
    public class ListaCartasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaCartasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaCartas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListasCartas.Include(l => l.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListaCartas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaCartas = await _context.ListasCartas
                .Include(l => l.Cliente)
                .FirstOrDefaultAsync(m => m.IdListaCartasPk == id);
            if (listaCartas == null)
            {
                return NotFound();
            }

            return View(listaCartas);
        }

        // GET: ListaCartas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientePk", "IdClientePk");
            return View();
        }

        // POST: ListaCartas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdListaCartasPk,IdCliente,NombreCarta,Precio,Cantidad,FechaCompra")] ListaCartas listaCartas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaCartas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientePk", "IdClientePk", listaCartas.IdCliente);
            return View(listaCartas);
        }

        // GET: ListaCartas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaCartas = await _context.ListasCartas.FindAsync(id);
            if (listaCartas == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientePk", "IdClientePk", listaCartas.IdCliente);
            return View(listaCartas);
        }

        // POST: ListaCartas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdListaCartasPk,IdCliente,NombreCarta,Precio,Cantidad,FechaCompra")] ListaCartas listaCartas)
        {
            if (id != listaCartas.IdListaCartasPk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaCartas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaCartasExists(listaCartas.IdListaCartasPk))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientePk", "IdClientePk", listaCartas.IdCliente);
            return View(listaCartas);
        }

        // GET: ListaCartas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaCartas = await _context.ListasCartas
                .Include(l => l.Cliente)
                .FirstOrDefaultAsync(m => m.IdListaCartasPk == id);
            if (listaCartas == null)
            {
                return NotFound();
            }

            return View(listaCartas);
        }

        // POST: ListaCartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaCartas = await _context.ListasCartas.FindAsync(id);
            if (listaCartas != null)
            {
                _context.ListasCartas.Remove(listaCartas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaCartasExists(int id)
        {
            return _context.ListasCartas.Any(e => e.IdListaCartasPk == id);
        }
    }
}
