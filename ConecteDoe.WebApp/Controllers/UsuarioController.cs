using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.Dominio.ValuesObjects;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ConecteDoe.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Contexto db = new Contexto();
        private object userIdClaim;

        public IActionResult CadastrarUsuario(string tipo)
        {
            return View();
        }

        public IActionResult Excluir(int usuarioId)
        {
            var usuario = db.Usuario.FirstOrDefault(f => f.UsuarioId == usuarioId);

            var enderecoID = usuario.EnderecoId;

            var endereco = db.Endereco.FirstOrDefault(f => f.EnderecoId == enderecoID);

            db.Endereco.Remove(endereco);
            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return RedirectToAction("Index", "Administracao");
        }

        [Authorize]
        public IActionResult PerfilUsuario()
        {

            //var email = "teste@gmail.com";
            //var senha = "teste";

            //var userName = User.Identity.Name;
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var usuario = db.Usuario.FirstOrDefault(u => u.Email == userEmail);

            var EnderecoID = usuario.EnderecoId;

            var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == EnderecoID);

            var viewModel = new PerfilUsuarioViewModel
            {
                Usuario = usuario,
                Endereco = endereco
            };

            return View("PerfilUsuario", viewModel); // Escolha a view que deseja exibir aqui
        }


        [HttpPost]
        public IActionResult InserirConfirmar(Usuario usuario, IFormFile imagem)
        {
            db.Usuario.Add(usuario);
            if (imagem != null && imagem.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imagem.CopyTo(ms);
                    usuario.Imagem = ms.ToArray();
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Plataforma");
        }


        //[HttpPost]
        //public IActionResult SalvarEdicao(PerfilUsuarioViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var username = User.Identity.Name;
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //        var Id = int.Parse(userId);

        //        var usuarioExistente = db.Usuario.FirstOrDefault(u => u.UsuarioId == Id);


        //        // Realize a lógica de atualização no banco de dados usando o Entity Framework Core
        //        // Atualize as propriedades do modelo com as informações do formulário
        //        var usuario = viewModel.Usuario;
        //        var endereco = viewModel.Endereco;


        //        // Salve as alterações no contexto do Entity Framework Core
        //        db.Update(endereco);
        //        db.Update(usuario);            
        //        db.SaveChanges();

        //        return RedirectToAction("PerfilUsuario");
        //    }

        //    return View("PerfilUsuario", viewModel);
        //}

        [HttpPost]
        public IActionResult SalvarEdicao(PerfilUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var Id = int.Parse(userId);

                // Obtenha o registro existente do banco de dados, incluindo suas propriedades relacionadas (Endereco)
                var usuarioExistente = db.Usuario
                    .Include(u => u.Endereco)
                    .FirstOrDefault(u => u.UsuarioId == Id);

                if (usuarioExistente != null)
                {
                    // Atualize apenas as propriedades que foram alteradas no objeto existente
                    usuarioExistente.Nome = viewModel.Usuario.Nome;
                    usuarioExistente.DataNascimento = viewModel.Usuario.DataNascimento;
                    usuarioExistente.Sexo = viewModel.Usuario.Sexo;
                    usuarioExistente.CPF = viewModel.Usuario.CPF;
                    usuarioExistente.Telefone =viewModel.Usuario.Telefone;
                    usuarioExistente.Senha = viewModel.Usuario.Senha;
                    //usuarioExistente.Email = viewModel.Usuario.Email;
                    // Atualize outras propriedades conforme necessário

                    // Se você deseja atualizar o objeto relacionado (Endereco), faça o mesmo para ele.
                    usuarioExistente.Endereco.Logradouro = viewModel.Endereco.Logradouro;
                    usuarioExistente.Endereco.CEP = viewModel.Endereco.CEP;
                    usuarioExistente.Endereco.Bairro = viewModel.Endereco.Bairro;
                    usuarioExistente.Endereco.Numero = viewModel.Endereco.Numero;
                    usuarioExistente.Endereco.Complemento = viewModel.Endereco.Complemento;
                    usuarioExistente.Endereco.Cidade = viewModel.Endereco.Cidade;
                    usuarioExistente.Endereco.Estado = viewModel.Endereco.Estado;

                    // Salve as alterações no contexto do Entity Framework Core
                    db.SaveChanges();

                    return RedirectToAction("PerfilUsuario");
                }
            }

            return View("PerfilUsuario", viewModel);
        }


    }
}