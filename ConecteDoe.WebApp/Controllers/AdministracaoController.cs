using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class AdministracaoController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult Index()
        {
            var resultado = db.Usuario.ToList();

            return View(resultado);
        }

        public IActionResult IndexInstituicao()
        {
            var resultado = db.Instituicao.ToList();

            return View(resultado);
        }

        //public ActionResult Busca(string searchTerm)
        //{
        //    // Consulta no banco de dados com base no termo de pesquisa
        //    var results = db.Usuario
        //        .Where(m => m.Nome.Contains(searchTerm)) // Substitua "Nome" pelo campo que deseja pesquisar
        //        .ToList();

        //    // Mapeie os resultados para o modelo de visualização (PerfilUsuarioViewModel)
        //    var viewModel = results.Select(result => new PesquisaModel
        //    {
        //        UsuarioId = result.UsuarioId,
        //        Nome = result.Nome,
        //        DataNascimento = result.DataNascimento,
        //        Sexo = result.Sexo.ToString(),
        //        CPF = result.CPF,
        //        Telefone = result.Telefone,
        //        Email = result.Email
        //    }).ToList();

        //    return View(viewModel);
        //}

        public ActionResult Busca(string searchTerm)
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

        public ActionResult BuscaInstituicao(string searchTerm)
        {
            // Consulta no banco de dados com base no termo de pesquisa
            var results = db.Instituicao
                .Where(m => m.RazaoSocial.Contains(searchTerm))
                .ToList();

            var pesquisaModelResults = results.Select(result => new PesquisaModelInstituicao
            {
                InstituicaoId = result.InstituicaoId,
                RazaoSocial = result.RazaoSocial,
                CNPJ = result.CNPJ,
                Telefone = result.Telefone,
                Email = result.Email
            }).ToList();

            var usuarioResults = results.Select(result => new Instituicao
            {
                InstituicaoId = result.InstituicaoId,
                RazaoSocial = result.RazaoSocial,
                CNPJ = result.CNPJ,
                Telefone = result.Telefone,
                Email = result.Email
            }).ToList();

            return View("IndexInstituicao", usuarioResults);
        }

    }
}
