using Microsoft.AspNetCore.Mvc;

namespace Capitulo01.Controllers
{
    public class InstituicaoController : Controller
    {
        public IActionResult Index()
        {
            return View("oi");
        }
    }
}
