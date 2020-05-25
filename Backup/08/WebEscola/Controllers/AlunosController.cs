using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEscola.Data;
using WebEscola.Models;

namespace WebEscola.Controllers
{
    public class AlunosController : Controller
    {
        private readonly WebEscolaContext _context;

        public AlunosController(WebEscolaContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index(string sortOrder,
           string currentFilter, string searchString, int? pageNumber)
        {
            //return View(await _context.Aluno.ToListAsync());
            /*ViewData["NomeSort"] = String.IsNullOrEmpty(sortOrder) ? "Nome_desc" : "";
            ViewData["DataSort"] = sortOrder == "Data" ? "Data_desc" : "Data";
            var alunos = from s in _context.Aluno
                         select s;

            switch (sortOrder)
            {
                case "Nome_desc":
                    alunos = alunos.OrderByDescending(s => s.Nome);
                    break;
                case "Data":
                    alunos = alunos.OrderBy(s => s.Data);
                    break;
                case "Data_desc":
                    alunos = alunos.OrderByDescending(s => s.Data);
                    break;
                default:
                    alunos = alunos.OrderBy(s => s.Nome);
                    break;
            }

            return View(await alunos.AsNoTracking().ToListAsync());*/

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NomeSort"] = String.IsNullOrEmpty(sortOrder) ? "Nome_desc" : "";
            ViewData["DataSort"] = sortOrder == "Data" ? "Data_desc" : "Data";
            ViewData["SobrenomeSort"] = sortOrder == "Sobrenome" ? "Sobrenome_desc" : "Sobrenome";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
                ViewData["CurrentFilter"] = searchString;
            }

            var alunos = from s in _context.Aluno
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                alunos = alunos.Where(s => s.Nome.Contains(searchString)
                                       || s.Sobrenome.Contains(searchString));
            }

            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Nome";
            }

            bool descending = false;

            if (sortOrder.EndsWith("_desc"))
            {
                sortOrder = sortOrder.Substring(0, sortOrder.Length - 5);
                descending = true;
            }

            if (descending)
            {
                alunos = alunos.OrderByDescending(e => EF.Property<object>(e, sortOrder));
            }
            else
            {
                alunos = alunos.OrderBy(e => EF.Property<object>(e, sortOrder));
            }

            int pageSize = 3;

            return View(await PageList<Aluno>.CreateAsync(alunos.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);*/

            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .Include(s => s.Matriculas)
                .ThenInclude(e => e.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AlunoID == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoID,Nome,Sobrenome,Data")] Aluno aluno)
        {
            /*if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);*/

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(aluno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Não foi possível salvar. Tente novamente mais tarde.");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunoID,Nome,Sobrenome,Data")] Aluno aluno)
        {
            if (id != aluno.AlunoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.AlunoID))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.AlunoID == id);
        }
    }
}
