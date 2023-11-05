using Microsoft.AspNetCore.Authentication.Cookies;

namespace ConecteDoe.WebApp
{
    public static class AuthenticationExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Logar"; // Página de login
                    options.AccessDeniedPath = "/Conta/AcessoNegado"; // Página de acesso negado
                });
        }
    }

}
