using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;

namespace ConecteDoe.WebApp.Controllers
{
    public class DoacaoController : Controller
    {
        private Contexto db = new Contexto();
        private object userIdClaim;

        public IActionResult SelecionaTipoUsuario()
        {
            return View();
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = Convert.ToInt32(userId);
            // Remova a lógica de obter a instituição pelo e-mail, pois agora usaremos o ID fornecido como parâmetro
            //var instituicao = db.Instituicao.FirstOrDefault(u => u.InstituicaoId == id);

            //var doacao = db.Doacao.FirstOrDefault(u => u.InstituicaoId == id);

            // Verifique se a instituição foi encontrada
            //if (instituicao == null)
            //{
            //    return NotFound(); // Retorna 404 se a instituição não for encontrada
            //}

            // Agora, você pode continuar com a lógica para obter outras informações
            //var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == instituicao.EnderecoId);
            //var dadosInstituicao = db.DadosInstituicao.FirstOrDefault(d => d.InstituicaoId == instituicao.InstituicaoId);

            //var viewModel = new PerfilInstituicaoViewModel
            //{
            //    Instituicao = instituicao,
            //    DadosInstituicao = dadosInstituicao,
            //    Endereco = endereco
            //};

            var doacoesDaInstituicao = db.Doacao.ToList().Where(u => u.InstituicaoId == id);
            decimal totalAmount = db.Doacao.Sum(t => t.Valor);

            var viewModel = new DoacaoViewModel
            {
                DoacoesDaInstituicao = doacoesDaInstituicao,
                TotalAmount = totalAmount
            };

            return View(viewModel);
        }

    }
}
