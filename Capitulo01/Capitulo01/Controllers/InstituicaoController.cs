﻿using Capitulo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capitulo01.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao() {
                InstituicaoID = 1,
                Nome = "UniParaná",
                Endereco = "Paraná"
            },
            new Instituicao() {
                InstituicaoID = 2,
                Nome = "UniSanta",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoID = 3,
                Nome = "UniSãoPaulo",
                Endereco = "São Paulo"
            },
            new Instituicao()
            {
                InstituicaoID = 4,
                Nome = "UniSulGrandense",
                Endereco = "Rio Grande do Sul"
            },
            new Instituicao()
            {
                InstituicaoID = 5,
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
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes[instituicoes.IndexOf(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First())] = instituicao;
            instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First();
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id) 
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }

    }
}
