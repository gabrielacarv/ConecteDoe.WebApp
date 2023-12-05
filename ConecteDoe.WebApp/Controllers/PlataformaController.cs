using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

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

        public IActionResult Agradecimento()
        {
            return View();
        }

        public IActionResult IndexAdmin()
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
                DadosInstituicao = (Dominio.Entities.DadosInstituicao)instituicao.DadosInstituicao,
                Endereco = instituicao.Endereco
            }).ToList();

            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalItens = db.Instituicao.Count();
            ViewBag.ItensPorPagina = itensPorPagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)ViewBag.TotalItens / ViewBag.ItensPorPagina);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult RealizarDoacao([FromForm] int id, [FromForm] decimal valor, [FromForm] IFormFile arquivo)
        {
            // Obtenha a instituição e o usuário autenticado, se necessário
            var instituicao = db.Instituicao.FirstOrDefault(i => i.InstituicaoId == id);
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdClaim.Value);
            var doador = db.Usuario.FirstOrDefault(d => d.UsuarioId == userId); // Ajuste conforme necessário

            // Verifique se a instituição e o doador existem
            if (instituicao == null || doador == null)
            {
                // Trate o erro, redirecione ou retorne uma resposta adequada
                return RedirectToAction("Index", "Usuario");
            }


            // Crie uma nova instância de Doacao
            var doacao = new Doacao
            {
                InstituicaoId = id,
                DoadorId = doador.UsuarioId,
                DataDoacao = DateTime.Now,
                Valor = valor,
            };

            if (arquivo != null && arquivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    arquivo.CopyTo(ms);
                    doacao.Comprovante = ms.ToArray();
                }
            }

            // Salve a doação no banco de dados
            db.Doacao.Add(doacao);
            db.SaveChanges();

            // Redirecione ou retorne uma resposta adequada
            return RedirectToAction("Agradecimento", "Plataforma");
        }

        public ActionResult BuscaCardInstituicao(string searchTerm)
        {
            // Consulta no banco de dados com base no termo de pesquisa
            var results = db.Usuario
                .Where(m => m.Nome.Contains(searchTerm))
                .ToList();

            var pesquisaModelResults = results.Select(result => new PesquisaModel
            {
                UsuarioId = result.UsuarioId,
                Nome = result.Nome,
                DataNascimento = result.DataNascimento,
                Sexo = result.Sexo.ToString(),
                CPF = result.CPF,
                Telefone = result.Telefone,
                Email = result.Email
            }).ToList();

            var usuarioResults = results.Select(result => new Usuario
            {
                UsuarioId = result.UsuarioId,
                Nome = result.Nome,
                DataNascimento = result.DataNascimento,
                Sexo = result.Sexo,
                CPF = result.CPF,
                Telefone = result.Telefone,
                Email = result.Email
            }).ToList();

            return View("Index", usuarioResults);
        }
    }
}
