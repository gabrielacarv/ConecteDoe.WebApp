using ConecteDoe.Dados;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ConecteDoe.WebApp.Controllers
{
    public class LogarController : Controller
    {
        private Contexto db = new Contexto();

        //public async Task<IActionResult> Autenticar(string email, string senha)
        //{
        //    var usuario = await db.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

        //    if (usuario != null)
        //    {
        //        // Autenticação bem-sucedida
        //        // Você pode adicionar o usuário à sessão ou fornecer um token de autenticação aqui
        //        return RedirectToAction("Index", "Plataforma");
        //    }
        //    else
        //    {
        //        // Falha na autenticação
        //        ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
        //        return View();
        //    }
        //}

        //public async Task<IActionResult> Autenticar(string email, string senha)
        //{
        //    var usuario = await db.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

        //    if (usuario != null)
        //    {
        //        // Autenticação bem-sucedida
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, usuario.Nome), // Substitua com o campo de nome real do usuário
        //            new Claim(ClaimTypes.Email, usuario.Email), // Substitua com o campo de email do usuário
        //            // Você pode adicionar outras informações do usuário, se necessário
        //            new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString())

        //        };

        //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var authProperties = new AuthenticationProperties
        //        {
        //            IsPersistent = true, // Se deseja manter o usuário logado permanentemente ou até logout
        //        };

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        //        return RedirectToAction("Index", "Plataforma"); // Redirecione para a página desejada após o login
        //    }
        //    else
        //    {
        //        // Falha na autenticação
        //        ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
        //        return View();
        //    }
        //}


        public async Task<IActionResult> SolucaoAutenticar(string email, string senha)
        {
            var usuario = await db.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                // Autenticação bem-sucedida
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome), // Substitua com o campo de nome real do usuário
                    new Claim(ClaimTypes.Email, usuario.Email), // Substitua com o campo de email do usuário
                    // Você pode adicionar outras informações do usuário, se necessário
                    new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString())

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Se deseja manter o usuário logado permanentemente ou até logout
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Plataforma"); // Redirecione para a página desejada após o login
            }
            else
            {
                var instituicao = await db.Instituicao.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

                if (instituicao != null)
                {
                    // Autenticação bem-sucedida
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, instituicao.RazaoSocial), // Substitua com o campo de nome real do usuário
                            new Claim(ClaimTypes.Email, instituicao.Email), // Substitua com o campo de email do usuário
                            // Você pode adicionar outras informações do usuário, se necessário
                            new Claim(ClaimTypes.NameIdentifier, instituicao.InstituicaoId.ToString())

                        };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, // Se deseja manter o usuário logado permanentemente ou até logout
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("IndexInstituicao", "Plataforma"); // Redirecione para a página desejada após o login
                }
                else
                {
                    var admin = await db.Instituicao.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

                    if (admin != null)
                    {
                        // Autenticação bem-sucedida
                        var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, admin.RazaoSocial), // Substitua com o campo de nome real do usuário
                                new Claim(ClaimTypes.Email, admin.Email), // Substitua com o campo de email do usuário
                                // Você pode adicionar outras informações do usuário, se necessário
                                new Claim(ClaimTypes.NameIdentifier, admin.InstituicaoId.ToString())

                            };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true, // Se deseja manter o usuário logado permanentemente ou até logout
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                        return RedirectToAction("Index", "Plataforma"); // Redirecione para a página desejada após o login
                    }
                    else
                    {
                        // Falha na autenticação
                        ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
                        return View();
                    }
                }
            }
        }

        //public async Task<IActionResult> Autenticar(string email, string senha)
        //{
        //    var usuario = await db.Instituicao.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

        //    if (usuario != null)
        //    {
        //        // Autenticação bem-sucedida
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, usuario.RazaoSocial), // Substitua com o campo de nome real do usuário
        //            new Claim(ClaimTypes.Email, usuario.Email), // Substitua com o campo de email do usuário
        //            // Você pode adicionar outras informações do usuário, se necessário
        //            new Claim(ClaimTypes.NameIdentifier, usuario.InstituicaoId.ToString())

        //        };

        //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var authProperties = new AuthenticationProperties
        //        {
        //            IsPersistent = true, // Se deseja manter o usuário logado permanentemente ou até logout
        //        };

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        //        return RedirectToAction("Index", "Plataforma"); // Redirecione para a página desejada após o login
        //    }
        //    else
        //    {
        //        // Falha na autenticação
        //        ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos.");
        //        return View();
        //    }
        //}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Redirecione para a página inicial ou outra página após o logout         
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
