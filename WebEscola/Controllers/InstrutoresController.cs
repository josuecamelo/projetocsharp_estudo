using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEscola.Data;
using WebEscola.Models;
using WebEscola.Models.ViewModels;

namespace WebEscola.Controllers
{
    public class InstrutoresController : Controller
    {
        private readonly WebEscolaContext _context;

        public InstrutoresController(WebEscolaContext context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index(int? instrutorID, int? cursoID)
        {
            //return View(await _context.Instrutor.ToListAsync());
            var viewModel = new InstrutorIndexData();

            viewModel.Instrutores = await _context.Instrutor
                  .Include(i => i.Escritorio)
                  .Include(i => i.CursosInstrutor)
                    .ThenInclude(i => i.Curso)
                        .ThenInclude(i => i.Matriculas)
                            .ThenInclude(i => i.Aluno)
                  .Include(i => i.CursosInstrutor)
                    .ThenInclude(i => i.Curso)
                        .ThenInclude(i => i.Departamento)
                  .AsNoTracking()
                  .OrderBy(i => i.Sobrenome)
                  .ToListAsync();

            if (instrutorID != null)
            {
                ViewData["InstrutorID"] = instrutorID.Value;
                Instrutor instrutor = viewModel.Instrutores.Where(
                    i => i.InstrutorID == instrutorID.Value).Single();
                viewModel.Cursos = instrutor.CursosInstrutor.Select(s => s.Curso);
            }

            if (cursoID != null)
            {
                ViewData["CursoID"] = cursoID.Value;
                viewModel.Matriculas = viewModel.Cursos.Where(
                    x => x.CursoID == cursoID).Single().Matriculas;
            }

            return View(viewModel);
        }

        // GET: Instrutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutor
                .FirstOrDefaultAsync(m => m.InstrutorID == id);
            if (instrutor == null)
            {
                return NotFound();
            }

            return View(instrutor);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstrutorID,Nome,Sobrenome,Contratacao")] Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrutor);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutor.FindAsync(id);
            if (instrutor == null)
            {
                return NotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstrutorID,Nome,Sobrenome,Contratacao")] Instrutor instrutor)
        {
            if (id != instrutor.InstrutorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutorExists(instrutor.InstrutorID))
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
            return View(instrutor);
        }

        // GET: Instrutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutor = await _context.Instrutor
                .FirstOrDefaultAsync(m => m.InstrutorID == id);
            if (instrutor == null)
            {
                return NotFound();
            }

            return View(instrutor);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrutor = await _context.Instrutor.FindAsync(id);
            _context.Instrutor.Remove(instrutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrutorExists(int id)
        {
            return _context.Instrutor.Any(e => e.InstrutorID == id);
        }
    }
}
