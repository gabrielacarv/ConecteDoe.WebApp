using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        public IActionResult PerfilUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InserirConfirmar(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}