using Capitulo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capitulo01.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao() {
                InsituticaoID = 1,
                Nome = "UniParaná",
                Endereco = "Paraná"
            },
            new Instituicao() {
                InsituticaoID = 2,
                Nome = "UniSanta",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InsituticaoID = 3,
                Nome = "UniSãoPaulo",
                Endereco = "São Paulo"
            },
            new Instituicao()
            {
                InsituticaoID = 4,
                Nome = "UniSulGrandense",
                Endereco = "Rio Grande do Sul"
            },
            new Instituicao()
            {
                InsituticaoID = 5,
                Nome = "UniCarioca",
                Endereco = "Rio de Janeiro"
            }
        };

        public IActionResult Index()
        {
            return View(instituicoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InsituticaoID = instituicoes.Select(i => i.InsituticaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InsituticaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes[instituicoes.IndexOf(instituicoes.Where(i => i.InsituticaoID == instituicao.InsituticaoID).First())] = instituicao;
            return RedirectToAction("Index");
        }
    }
}
