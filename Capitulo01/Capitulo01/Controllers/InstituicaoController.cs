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
    }
}
