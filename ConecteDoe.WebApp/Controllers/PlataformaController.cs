using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class PlataformaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
