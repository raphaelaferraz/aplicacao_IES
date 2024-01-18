using Capitulo03.Data;
using Capitulo03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capitulo03.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;

        public InstituicaoController(IESContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.InstituicaoID).ToListAsync());
        }

        //GET: Instituicao/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, Endereco")] Instituicao instituicao)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível adicionar os dados.");
            }

            return View(instituicao);
        }

        //GET: Instituicao/Edit/id
        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("InstituicaoID, Nome, Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(instituicao);
        }


        private bool InstituicaoExists(long? id)
        {
            return _context.Instituicoes.Any(i => i.InstituicaoID == id);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);

            if(instituicao == null)
            {
                return NotFound();  
            }

            return View(instituicao);
        }

        // GET: Instituicao/Delete/id
        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);

            if(instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }
    }
}
