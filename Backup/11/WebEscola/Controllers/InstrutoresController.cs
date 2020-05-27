using System;
using System.Collections.Generic;
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
            var instrutor = new Instrutor();
            instrutor.CursosInstrutor = new List<CursoInstrutor>();
            CarregarCursosAtribuidos(instrutor);
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Sobrenome,Contratacao, Escritorio")] Instrutor instrutor, string[] cursosSelecionados)
        {
            if (cursosSelecionados != null)
            {
                instrutor.CursosInstrutor = new List<CursoInstrutor>();
                foreach (var curso in cursosSelecionados)
                {
                    var cursoToAdd = new CursoInstrutor { InstrutorID = instrutor.InstrutorID, CursoID = int.Parse(curso) };
                    instrutor.CursosInstrutor.Add(cursoToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(instrutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CarregarCursosAtribuidos(instrutor);

            return View(instrutor);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var instrutor = await _context.Instrutor.FindAsync(id);
            var instrutor = await _context.Instrutor
               .Include(e => e.Escritorio)
                .Include(i => i.CursosInstrutor)//adicionado para exibir Cursos/Instrutor  - A consulta daqui em diante adiciona o carregamento adiantado até Curso
                    .ThenInclude(i => i.Curso) 
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.InstrutorID == id);

            if (instrutor == null)
            {
                return NotFound();
            }
            CarregarCursosAtribuidos(instrutor);
            return View(instrutor);
        }

        private void CarregarCursosAtribuidos(Instrutor instrutor)
        {
            var todosCursos = _context.Curso;
            var instrutorCursos = new HashSet<int?>(instrutor.CursosInstrutor.Select(c => c.CursoID));

            var viewModel = new List<InstrutorCursoData>();

            foreach (var curso in todosCursos)
            {
                viewModel.Add(new InstrutorCursoData
                {
                    CursoID = curso.CursoID,
                    Titulo = curso.Titulo,
                    Atribuido = instrutorCursos.Contains(curso.CursoID)
                });
            }
            ViewData["Cursos"] = viewModel;
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstrutorID,Nome,Sobrenome,Contratacao")] Instrutor instrutor)
        {
            if (id != instrutor.InstrutorID)
            {
                return NotFound();
            }

            //adicionado 26-05-2020 as 21:35
            var instrutorToUpdate = await _context.Instrutor
                   .Include(i => i.Escritorio)
                   .FirstOrDefaultAsync(s => s.InstrutorID == id);

            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync<Instrutor>(instrutorToUpdate, "",
                    i => i.Nome, i => i.Sobrenome, i => i.Contratacao, i => i.Escritorio))
                {
                    if (String.IsNullOrWhiteSpace(instrutorToUpdate.Escritorio?.Localizacao))
                    {
                        instrutorToUpdate.Escritorio = null;
                    }

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        ModelState.AddModelError("", "Não foi possível salvar as alterações.");
                    }

                    return RedirectToAction(nameof(Index));

                }

            }

            return View(instrutorToUpdate);
        }*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] cursosSelecionados)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrutorToUpdate = await _context.Instrutor
                .Include(i => i.Escritorio)
                .Include(i => i.CursosInstrutor)
                    .ThenInclude(i => i.Curso)
                .FirstOrDefaultAsync(s => s.InstrutorID == id);

            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync<Instrutor>(instrutorToUpdate, "",
                    i => i.Nome, i => i.Sobrenome, i => i.Contratacao, i => i.Escritorio))
                {
                    if (String.IsNullOrWhiteSpace(instrutorToUpdate.Escritorio?.Localizacao))
                    {
                        instrutorToUpdate.Escritorio = null;
                    }

                    AtualizarCursosInstrutor(cursosSelecionados, instrutorToUpdate);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        ModelState.AddModelError("", "Não foi possível salvar as alterações.");
                    }
                    return RedirectToAction(nameof(Index));
                }
            }

            AtualizarCursosInstrutor(cursosSelecionados, instrutorToUpdate);
            CarregarCursosAtribuidos(instrutorToUpdate);
            return View(instrutorToUpdate);
        }


        private void AtualizarCursosInstrutor(string[] cursosSelecionados, Instrutor instrutorToUpdate)
        {
            if (cursosSelecionados == null)
            {
                instrutorToUpdate.CursosInstrutor = new List<CursoInstrutor>();
                return;
            }

            var cursosSelecionadosHS = new HashSet<string>(cursosSelecionados);
            var CursosInstrutor = new HashSet<int>
                (instrutorToUpdate.CursosInstrutor.Select(c => c.Curso.CursoID));

            foreach (var curso in _context.Curso)
            {
                if (cursosSelecionadosHS.Contains(curso.CursoID.ToString()))
                {
                    if (!CursosInstrutor.Contains(curso.CursoID))
                    {
                        instrutorToUpdate.CursosInstrutor.Add(new CursoInstrutor
                        {
                            InstrutorID = instrutorToUpdate.InstrutorID,
                            CursoID = curso.CursoID
                        });
                    }
                }
                else
                {
                    if (CursosInstrutor.Contains(curso.CursoID))
                    {
                        CursoInstrutor cursoToRemove = instrutorToUpdate.CursosInstrutor.FirstOrDefault(i => i.CursoID == curso.CursoID);
                        _context.Remove(cursoToRemove);
                    }
                }
            }

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
            /*var instrutor = await _context.Instrutor.FindAsync(id);
            _context.Instrutor.Remove(instrutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/

            var instrutor = await _context.Instrutor
                .Include(i => i.CursosInstrutor)
                .SingleAsync(i => i.InstrutorID == id);

            var departamentos = await _context.Departamento
                .Where(d => d.InstrutorID == id)
                .ToListAsync();

            departamentos.ForEach(d => d.InstrutorID = null);
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
