﻿using ConecteDoe.Dados;
using Microsoft.AspNetCore.Mvc;

namespace ConecteDoe.WebApp.Controllers
{
    public class DoacaoController : Controller
    {
        private readonly Contexto _contexto;

        public DoacaoController()
        {
            _contexto = new Contexto();
        }

        public IActionResult SelecionaTipoUsuario()
        {
            return View();
        }
    }
}