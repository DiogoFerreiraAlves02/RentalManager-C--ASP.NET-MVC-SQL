using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGestor.Models;
using ProjetoGestor.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Controllers {
    public class ProdutoController : Controller {

        private Conta conta;

        public IActionResult Listar() {
            AutenticarUtilizador();
            ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);
            List<Produto> produtosParaAView = ph.list();
            if (conta.NivelAcesso > 0) {
                return View(produtosParaAView);
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpGet]
        public IActionResult Criar() {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                return View();
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpPost]
        public IActionResult Criar(Produto produto) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);
                    Guid idDevolvido = ph.insert(produto);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Produto");
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpGet]
        public IActionResult Consultar(string id) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                Guid idAPesquisar = Guid.Empty;
                Boolean idIsOk = Guid.TryParse(id, out idAPesquisar);

                if (idIsOk) {
                    ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);
                    Produto produto = ph.read(id);
                    if (produto.Id != Guid.Empty) {
                        return View(produto);
                    }
                    return RedirectToAction("Listar", "Produto");
                }
                else {
                    return RedirectToAction("Listar", "Produto");
                }
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpGet]
        public IActionResult Editar(string id) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                Guid idAPesquisar = Guid.Empty;
                Boolean idIsOk = Guid.TryParse(id, out idAPesquisar);

                if (idIsOk) {
                    ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);
                    Produto produto = ph.read(id);
                    if (produto.Id != Guid.Empty) {
                        return View(produto);
                    }
                    return RedirectToAction("Listar", "Produto");
                }
                else {
                    return RedirectToAction("Listar", "Produto");
                }
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpPost]
        public IActionResult Editar(Produto produtoEditado) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    //informacao += $"ID: {produto.Id}; Designação: {produto.Designacao}; Stock: {produto.StkAtual}; PU: {produto.PUnitario}";
                    ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);
                    Guid idDevolvido = ph.update(produtoEditado);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Produto");
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpGet]
        public IActionResult Eliminar(string id) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                Guid idAEliminar = Guid.Empty;
                Boolean idIsOk = Guid.TryParse(id, out idAEliminar);
                if (idIsOk) {
                    ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);
                    ph.eliminar(id);
                    return RedirectToAction("Listar", "Produto");
                }
                else {
                    return RedirectToAction("Listar", "Produto");
                }
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        private void AutenticarUtilizador() {
            string uid = "";
            conta = new Conta();
            try {
                uid = HttpContext.Session.GetString("mySessionID");
            }
            catch {

            }
            if (uid == null || uid.Equals("")) uid = Guid.Empty.ToString();
            Authenticator auth = new Authenticator();
            conta = auth.Authenticate(Guid.Parse(uid));
            HttpContext.Session.SetString("mySessionID", uid);
            ViewBag.ContaAtiva = conta;
        }

    }
}
