using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConecteDoe.WebApp.Controllers
{
    public class InstituicaoController : Controller
    {
        private Contexto db = new Contexto();
        private object userIdClaim;
        public IActionResult CadastrarInstituicao()
        {
            return View();
        }


        [HttpPost]
        public IActionResult InserirConfirmar(Instituicao instituicao, IFormFile imagem)
        {
            db.Instituicao.Add(instituicao);
            if (imagem != null && imagem.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imagem.CopyTo(ms);
                    instituicao.Imagem = ms.ToArray();
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Plataforma");
        }


        public IActionResult PerfilInstituicao()
        {

            //var email = "teste@gmail.com";
            //var senha = "teste";

            //var userName = User.Identity.Name;
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var instituicao = db.Instituicao.FirstOrDefault(u => u.Email == userEmail);

            var EnderecoID = instituicao.EnderecoId;

            var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == EnderecoID);

            var dadosInstituicao = db.DadosInstituicao.FirstOrDefault(d => d.InstituicaoId == instituicao.InstituicaoId);

            var viewModel = new PerfilInstituicaoViewModel
            {
                Instituicao = instituicao,
                DadosInstituicao = dadosInstituicao,
                Endereco = endereco
            };

            return View("PerfilInstituicao", viewModel); // Escolha a view que deseja exibir aqui
        }
    }
}
