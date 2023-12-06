using ConecteDoe.Dados;
using ConecteDoe.Dominio.Entities;
using ConecteDoe.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult PerfilExibicao()
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
            return RedirectToAction("IndexInstituicao", "Plataforma");
        }


        //public IActionResult PerfilInstituicao()
        //{

        //    //var email = "teste@gmail.com";
        //    //var senha = "teste";

        //    //var userName = User.Identity.Name;
        //    var userEmail = User.FindFirstValue(ClaimTypes.Email);

        //    var instituicao = db.Instituicao.FirstOrDefault(u => u.Email == userEmail);

        //    var EnderecoID = instituicao.EnderecoId;

        //    var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == EnderecoID);

        //    var dadosInstituicao = db.DadosInstituicao.FirstOrDefault(d => d.InstituicaoId == instituicao.InstituicaoId);

        //    var viewModel = new PerfilInstituicaoViewModel
        //    {
        //        Instituicao = instituicao,
        //        DadosInstituicao = dadosInstituicao,
        //        Endereco = endereco
        //    };

        //    return View("PerfilInstituicao", viewModel); // Escolha a view que deseja exibir aqui
        //}

        public IActionResult PerfilInstituicao()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var instituicao = db.Instituicao.FirstOrDefault(u => u.Email == userEmail);

            if (instituicao != null)
            {
                var EnderecoID = instituicao.EnderecoId;
                var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == EnderecoID);

                // Verifica se DadosInstituicao não é nulo
                var dadosInstituicao = db.DadosInstituicao.FirstOrDefault(d => d.InstituicaoId == instituicao.InstituicaoId);
                if (dadosInstituicao == null)
                {
                    // Se DadosInstituicao é nulo, cria uma instância vazia
                    dadosInstituicao = new DadosInstituicao();
                }

                var viewModel = new PerfilInstituicaoViewModel
                {
                    Instituicao = instituicao,
                    DadosInstituicao = dadosInstituicao,
                    Endereco = endereco
                };

                return View("PerfilInstituicao", viewModel);
            }

            // Se a instituição não for encontrada, você pode lidar com isso adequadamente, por exemplo, redirecionar ou retornar uma mensagem de erro.
            return NotFound(); // Ou qualquer outra lógica que você preferir
        }


        //public IActionResult PerfilInstituicaoExibicao()
        //{
        //    var userEmail = User.FindFirstValue(ClaimTypes.Email);

        //    var instituicao = db.Instituicao.FirstOrDefault(u => u.Email == userEmail);

        //    var EnderecoID = instituicao.EnderecoId;

        //    var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == EnderecoID);

        //    var dadosInstituicao = db.DadosInstituicao.FirstOrDefault(d => d.InstituicaoId == instituicao.InstituicaoId);

        //    var viewModel = new PerfilInstituicaoViewModel
        //    {
        //        Instituicao = instituicao,
        //        DadosInstituicao = dadosInstituicao,
        //        Endereco = endereco
        //    };

        //    return View("PerfilExibicao", viewModel);
        //}


        public IActionResult PerfilInstituicaoExibicao(int id)
        {
            // Remova a lógica de obter a instituição pelo e-mail, pois agora usaremos o ID fornecido como parâmetro
            var instituicao = db.Instituicao.FirstOrDefault(u => u.InstituicaoId == id);

            // Verifique se a instituição foi encontrada
            if (instituicao == null)
            {
                return NotFound(); // Retorna 404 se a instituição não for encontrada
            }

            // Agora, você pode continuar com a lógica para obter outras informações
            var endereco = db.Endereco.FirstOrDefault(e => e.EnderecoId == instituicao.EnderecoId);
            var dadosInstituicao = db.DadosInstituicao.FirstOrDefault(d => d.InstituicaoId == instituicao.InstituicaoId);

            var viewModel = new PerfilInstituicaoViewModel
            {
                Instituicao = instituicao,
                DadosInstituicao = dadosInstituicao,
                Endereco = endereco
            };

            return View("PerfilExibicao", viewModel);
        }


        [HttpPost]
        public IActionResult SalvarEdicao(PerfilInstituicaoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var Id = int.Parse(userId);

                // Obtenha o registro existente do banco de dados, incluindo suas propriedades relacionadas (Endereco)
                var instituicaoExistente = db.Instituicao
                    .Include(u => u.Endereco)
                    .FirstOrDefault(u => u.InstituicaoId == Id);

                if (instituicaoExistente != null)
                {
                    // Atualize apenas as propriedades que foram alteradas no objeto existente
                    instituicaoExistente.RazaoSocial = viewModel.Instituicao.RazaoSocial;
                    instituicaoExistente.CNPJ = viewModel.Instituicao.CNPJ;
                    instituicaoExistente.Telefone = viewModel.Instituicao.Telefone;
                    instituicaoExistente.Senha = viewModel.Instituicao.Senha;
                    //usuarioExistente.Email = viewModel.Usuario.Email;
                    // Atualize outras propriedades conforme necessário

                    // Se você deseja atualizar o objeto relacionado (Endereco), faça o mesmo para ele.
                    instituicaoExistente.Endereco.Logradouro = viewModel.Endereco.Logradouro;
                    instituicaoExistente.Endereco.CEP = viewModel.Endereco.CEP;
                    instituicaoExistente.Endereco.Bairro = viewModel.Endereco.Bairro;
                    instituicaoExistente.Endereco.Numero = viewModel.Endereco.Numero;
                    instituicaoExistente.Endereco.Complemento = viewModel.Endereco.Complemento;
                    instituicaoExistente.Endereco.Cidade = viewModel.Endereco.Cidade;
                    instituicaoExistente.Endereco.Estado = viewModel.Endereco.Estado;

                    // Salve as alterações no contexto do Entity Framework Core
                    db.SaveChanges();

                    return RedirectToAction("PerfilInstituicao");
                }
            }

            return View("PerfilInstituicao", viewModel);
        }

        [HttpPost]
        public IActionResult SalvarEdicaoDados(PerfilInstituicaoViewModel viewModel, IFormFile imagem)
        {
            if (!ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var Id = int.Parse(userId);

                var instituicaoExistente = db.Instituicao
                    .Include(u => u.DadosInstituicao)
                    .FirstOrDefault(u => u.InstituicaoId == Id);

                if (instituicaoExistente != null)
                {
                    if (instituicaoExistente.DadosInstituicao == null)
                    {
                        instituicaoExistente.DadosInstituicao = new DadosInstituicao();
                    }

                    instituicaoExistente.DadosInstituicao.InstituicaoId = instituicaoExistente.InstituicaoId;
                    instituicaoExistente.DadosInstituicao.Coordenador = viewModel.DadosInstituicao.Coordenador;
                    instituicaoExistente.DadosInstituicao.Categoria = viewModel.DadosInstituicao.Categoria;
                    instituicaoExistente.DadosInstituicao.DataCriacao = viewModel.DadosInstituicao.DataCriacao;
                    instituicaoExistente.DadosInstituicao.QuantidadeCarentes = viewModel.DadosInstituicao.QuantidadeCarentes;
                    instituicaoExistente.DadosInstituicao.Causa = viewModel.DadosInstituicao.Causa;
                    instituicaoExistente.DadosInstituicao.Descricao = viewModel.DadosInstituicao.Descricao;
                    instituicaoExistente.DadosInstituicao.ChavePix = viewModel.DadosInstituicao.ChavePix;

                    if (imagem != null && imagem.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            imagem.CopyTo(ms);
                            viewModel.DadosInstituicao.Imagem = ms.ToArray();
                        }
                    }

                    instituicaoExistente.DadosInstituicao.Imagem = viewModel.DadosInstituicao.Imagem;

                   
                    db.DadosInstituicao.Add(instituicaoExistente.DadosInstituicao);
                    

                    db.SaveChanges();

                    return RedirectToAction("PerfilInstituicao");
                }
            }

            return View("PerfilInstituicao", viewModel);
        }


        //[HttpPost]
        //public IActionResult SalvarEdicaoDados(PerfilInstituicaoViewModel viewModel, IFormFile imagem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var username = User.Identity.Name;
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //        var Id = int.Parse(userId);

        //        // Obtenha o registro existente do banco de dados, incluindo suas propriedades relacionadas (Endereco)
        //        var instituicaoExistente = db.Instituicao
        //            .Include(u => u.DadosInstituicao)
        //            .FirstOrDefault(u => u.InstituicaoId == Id);

        //        if (instituicaoExistente != null)
        //        {
        //            instituicaoExistente.DadosInstituicao.InstituicaoId = instituicaoExistente.InstituicaoId;
        //            instituicaoExistente.DadosInstituicao.Coordenador = viewModel.DadosInstituicao.Coordenador;
        //            instituicaoExistente.DadosInstituicao.Categoria = viewModel.DadosInstituicao.Categoria;
        //            instituicaoExistente.DadosInstituicao.DataCriacao = viewModel.DadosInstituicao.DataCriacao;
        //            instituicaoExistente.DadosInstituicao.QuantidadeCarentes = viewModel.DadosInstituicao.QuantidadeCarentes;
        //            instituicaoExistente.DadosInstituicao.Causa = viewModel.DadosInstituicao.Causa;
        //            instituicaoExistente.DadosInstituicao.Descricao = viewModel.DadosInstituicao.Descricao;
        //            instituicaoExistente.DadosInstituicao.ChavePix = viewModel.DadosInstituicao.ChavePix;

        //            if (imagem != null && imagem.Length > 0)
        //            {
        //                using (var ms = new MemoryStream())
        //                {
        //                    imagem.CopyTo(ms);
        //                    viewModel.DadosInstituicao.Imagem = ms.ToArray();
        //                }
        //            }

        //            instituicaoExistente.DadosInstituicao.Imagem = viewModel.DadosInstituicao.Imagem;

        //            db.SaveChanges();

        //            return RedirectToAction("PerfilInstituicao");
        //        }
        //    }

        //    return View("PerfilInstituicao", viewModel);
        //}

        //[HttpPost]
        //public IActionResult SalvarEdicaoDados(PerfilInstituicaoViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Código para obter informações do usuário...

        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var Id = int.Parse(userId);

        //        var instituicaoExistente = db.Instituicao
        //            .Include(u => u.DadosInstituicao)
        //            .FirstOrDefault(u => u.InstituicaoId == Id);

        //        if (instituicaoExistente != null)
        //        {
        //            // Converte a imagem para um array de bytes
        //            byte[] imagemBytes = ConvertImageToBytes(viewModel.DadosInstituicao.Imagem);

        //            instituicaoExistente.DadosInstituicao.Coordenador = viewModel.DadosInstituicao.Coordenador;
        //            instituicaoExistente.DadosInstituicao.Categoria = viewModel.DadosInstituicao.Categoria;
        //            instituicaoExistente.DadosInstituicao.DataCriacao = viewModel.DadosInstituicao.DataCriacao;
        //            instituicaoExistente.DadosInstituicao.QuantidadeCarentes = viewModel.DadosInstituicao.QuantidadeCarentes;
        //            instituicaoExistente.DadosInstituicao.Causa = viewModel.DadosInstituicao.Causa;
        //            instituicaoExistente.DadosInstituicao.Descricao = viewModel.DadosInstituicao.Descricao;
        //            instituicaoExistente.DadosInstituicao.ChavePix = viewModel.DadosInstituicao.ChavePix;
        //            instituicaoExistente.DadosInstituicao.Imagem = imagemBytes;

        //            db.SaveChanges();

        //            return RedirectToAction("PerfilInstituicao");
        //        }
        //    }

        //    return View("PerfilInstituicao", viewModel);
        //}

        //private byte[] ConvertImageToBytes(byte[] imagem)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        imagem.CopyTo(ms);
        //        return ms.ToArray();
        //    }
        //}

    }
}
