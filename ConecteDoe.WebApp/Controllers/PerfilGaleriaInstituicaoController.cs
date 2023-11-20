using ConecteDoe.Dados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class PerfilGaleriaInstituicaoController : Controller
    { 
        

        private Contexto db = new Contexto();

        [Authorize]
        public IActionResult PerfilGaleriaInstituicao()
        {
            return View();
        }
    }
}
