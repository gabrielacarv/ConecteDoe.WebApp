using ConecteDoe.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConecteDoe.WebApp.Controllers
{
    public class LogarController : Controller
    {
        private Contexto db = new Contexto();

        public async Task<IActionResult> Autenticar(string email, string senha)
        {
            var usuario = await db.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                // Autenticação bem-sucedida
                // Você pode adicionar o usuário à sessão ou fornecer um token de autenticação aqui
                return RedirectToAction("Index", "Plataforma");
            }
            else
            {
                // Falha na autenticação
                ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult SelecionaTipoUsuario()
        {
            return View();
        }
    }
}
