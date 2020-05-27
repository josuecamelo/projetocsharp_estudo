using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebEscola.Data;
using WebEscola.Models;

namespace WebEscola.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly WebEscolaContext _context;

        public DepartamentosController(WebEscolaContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            var webEscolaContext = _context.Departamento.Include(d => d.Instrutor);
            return View(await webEscolaContext.ToListAsync());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .Include(d => d.Instrutor)
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            ViewData["InstrutorID"] = new SelectList(_context.Instrutor, "InstrutorID", "Nome");
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoID,InstrutorID,Nome,Orcamento,Inicio,RowVersion")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrutorID"] = new SelectList(_context.Instrutor, "InstrutorID", "Nome", departamento.InstrutorID);
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamento
                .Include(i => i.Instrutor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);

            if (departamento == null)
            {
                return NotFound();
            }

            ViewData["InstrutorID"] = new SelectList(_context.Instrutor, "InstrutorID", "Nome",
            departamento.InstrutorID);

            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .Include(i => i.Instrutor)
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);


            if (departamento == null)
            {
                Departamento excluirDepartamento = new Departamento();
                await TryUpdateModelAsync(excluirDepartamento);
                ModelState.AddModelError(string.Empty, "Departamento excluído por outro usuário.");
                ViewData["InstrutorID"] = new SelectList(_context.Instrutor, "InstrutorID", "Nome",
                excluirDepartamento.InstrutorID);
                return View(excluirDepartamento);
            }

            _context.Entry(departamento).Property("RowVersion").OriginalValue = rowVersion;
            
            if (await TryUpdateModelAsync<Departamento>(departamento, "",
                s => s.Nome, s => s.Inicio, s => s.Orcamento, s => s.InstrutorID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Departamento)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Departamento excluído por outro usuário.");
                    }
                    else
                    {
                        var databaseValues = (Departamento)databaseEntry.ToObject();
                        ModelState.AddModelError(string.Empty, "O departamento que você tentou alterar "
                        + "foi modificado por outro usuário.");
                        ModelState.AddModelError(string.Empty, "Clique no botão Salvar para gravar seu dados "
                        + " ou clique no link Voltar para a Lista para cancelar a sua gravação.");
                        if (databaseValues.Nome != clientValues.Nome)
                        {
                            ModelState.AddModelError("Nome", $"Valor atual: {databaseValues.Nome}");
                        }
                        if (databaseValues.Orcamento != clientValues.Orcamento)
                        {
                            ModelState.AddModelError("Orcamento", $"Valor atual: {databaseValues.Orcamento:c}");
                        }
                        if (databaseValues.Inicio != clientValues.Inicio)
                        {
                            ModelState.AddModelError("Inicio", $"Valor atual: {databaseValues.Inicio:d}");
                        }
                        if (databaseValues.InstrutorID != clientValues.InstrutorID)
                        {
                            Instrutor databaseInstrutor = await _context.Instrutor.FirstOrDefaultAsync(i =>
                            i.InstrutorID == databaseValues.InstrutorID);
                            ModelState.AddModelError("InstrutorID", $"Valor atual: {databaseInstrutor?.Nome}");
                        }
                        departamento.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }

            ViewData["InstrutorID"] = new SelectList(_context.Instrutor, "InstrutorID", "Nome", departamento.InstrutorID);
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamento
                .Include(d => d.Instrutor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartamentoID == id);

            if (departamento == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {               
                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "O departamento que voçê tentou excluir "
                + "foi modificado por outro usuário. "
                + "Clique no botão Excluir para confirmar a exclusão. "
                + "ou clique no link Voltar para a Lista para cancelar a sua gravação. ";
            }
            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Departamento departamento)
        {
            try
            {
                if (await _context.Departamento.AnyAsync(m => m.DepartamentoID == departamento.DepartamentoID))
                {
                    _context.Departamento.Remove(departamento);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException /* ex */)
            {
                return RedirectToAction(nameof(Delete),
                new { concurrencyError = true, id = departamento.DepartamentoID });
            }
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.DepartamentoID == id);
        }
    }
}
