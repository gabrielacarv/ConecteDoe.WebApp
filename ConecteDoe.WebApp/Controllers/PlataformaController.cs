using ConecteDoe.Dados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class PlataformaController : Controller
    {
        private Contexto db = new Contexto();

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult FeedInstituicao()
        //{
            

        //    return View();
        //}

        public IActionResult FeedInstituicao(int pagina = 1, int itensPorPagina = 10)
        {
            int indiceInicial = (pagina - 1) * itensPorPagina;

            var resultadoPaginado = db.Usuario
                .OrderBy(u => u.Nome)
                .Skip(indiceInicial)
                .Take(itensPorPagina)
                .ToList();

            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalItens = db.Usuario.Count();
            ViewBag.ItensPorPagina = itensPorPagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)ViewBag.TotalItens / ViewBag.ItensPorPagina);

            return View(resultadoPaginado);
        }

    }
}
