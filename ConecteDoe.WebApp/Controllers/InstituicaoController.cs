using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class InstituicaoController : Controller
    {
        public IActionResult CadastrarInstituicao()
        {
            return View();
        }
    }
}
