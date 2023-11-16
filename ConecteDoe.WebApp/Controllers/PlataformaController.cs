using ConecteDoe.Dados;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult IndexInstituicao()
        {
            return View();
        }

        //public IActionResult FeedInstituicao(int pagina = 1, int itensPorPagina = 10)
        //{
        //    int indiceInicial = (pagina - 1) * itensPorPagina;

        //    var resultadoPaginado = db.Instituicao
        //        .OrderBy(u => u.RazaoSocial)
        //        .Skip(indiceInicial)
        //        .Take(itensPorPagina)
        //        .ToList();

        //    ViewBag.PaginaAtual = pagina;
        //    ViewBag.TotalItens = db.Instituicao.Count();
        //    ViewBag.ItensPorPagina = itensPorPagina;
        //    ViewBag.TotalPaginas = (int)Math.Ceiling((double)ViewBag.TotalItens / ViewBag.ItensPorPagina);

        //    return View(resultadoPaginado);
        //}


        public IActionResult FeedInstituicao(int pagina = 1, int itensPorPagina = 10)
        {
            int indiceInicial = (pagina - 1) * itensPorPagina;

            // Use a função Include para carregar as tabelas relacionadas
            var resultadoPaginado = db.Instituicao
                .Include(i => i.DadosInstituicao)
                .Include(i => i.Endereco)
                .OrderBy(u => u.RazaoSocial)
                .Skip(indiceInicial)
                .Take(itensPorPagina)
                .ToList();

            // Mapeie os dados para a sua ViewModel
            var viewModel = resultadoPaginado.Select(instituicao => new PerfilInstituicaoViewModel
            {
                Instituicao = instituicao,
                DadosInstituicao = instituicao.DadosInstituicao,
                Endereco = instituicao.Endereco
            }).ToList();

            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalItens = db.Instituicao.Count();
            ViewBag.ItensPorPagina = itensPorPagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)ViewBag.TotalItens / ViewBag.ItensPorPagina);

            return View(viewModel);
        }

    }
}
