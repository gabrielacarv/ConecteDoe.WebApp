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

        //public IActionResult Index()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var id = Convert.ToInt32(userId);

        //    var doacoesDaInstituicao = db.Doacao.ToList().Where(u => u.InstituicaoId == id);
        //    decimal totalAmount = db.Doacao.Sum(t => t.Valor);

        //    var doadores = db.Usuario.ToList().Where(u => u.UsuarioId == id);

        //    var viewModel = new DoacaoViewModel
        //    {
        //        DoacoesDaInstituicao = doacoesDaInstituicao,
        //        TotalAmount = totalAmount
        //    };

        //    return View(viewModel);
        //}

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = Convert.ToInt32(userId);

            var doacoesDaInstituicao = db.Doacao
                .Include(d => d.Usuario) // Inclua a tabela do doador (assumindo que sua propriedade se chama Doador)
                .Where(u => u.InstituicaoId == id)
                .ToList();

            decimal totalAmount = doacoesDaInstituicao.Sum(t => t.Valor);

            var doadores = db.Usuario
                .Where(u => u.UsuarioId == id)
                .ToList();

            var viewModel = new DoacaoViewModel
            {
                DoacoesDaInstituicao = doacoesDaInstituicao,
                TotalAmount = totalAmount,
                Doadores = doadores
            };

            return View(viewModel);
        }


        //[HttpGet]

        //public ActionResult FiltrarPorData(DateTime? startDate, DateTime? endDate)
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var id = Convert.ToInt32(userId);

        //    // Verificar se as datas foram fornecidas
        //    if (startDate.HasValue && endDate.HasValue)
        //    {
        //        var resultadoFiltrado = db.Doacao
        //            .Where(u => u.InstituicaoId == id && u.DataDoacao >= startDate && u.DataDoacao <= endDate)
        //            .ToList();

        //        // Restante do código para enviar o modelo para a View

        //        return PartialView("RelatorioDoacaoPartial", resultadoFiltrado);

        //    }
        //    else
        //    {
        //        // Se as datas não foram fornecidas, retornar a lista sem filtro
        //        var resultado = db.Doacao.Where(u => u.InstituicaoId == id).ToList();
        //        return View("Index", resultado);
        //    }
        //}


    }
}
