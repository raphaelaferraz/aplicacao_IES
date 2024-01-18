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
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
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

    }
}
