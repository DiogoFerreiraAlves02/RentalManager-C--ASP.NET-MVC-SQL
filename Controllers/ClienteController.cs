using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGestor.Models;
using ProjetoGestor.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Controllers {
    public class ClienteController : Controller {

        private Conta conta;

        public IActionResult Listar() {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                List<Cliente> clientesParaAView = ch.list();
                return View(clientesParaAView);
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
        public IActionResult Criar(Cliente cliente) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                    Guid idDevolvido = ch.insert(cliente);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Cliente");
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
                    ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                    Cliente cliente = ch.read(id);
                    if (cliente.Id != Guid.Empty) {
                        return View(cliente);
                    }
                    return RedirectToAction("Listar", "Cliente");
                }
                else {
                    return RedirectToAction("Listar", "Cliente");
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
                    ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                    Cliente cliente = ch.read(id);
                    if (cliente.Id != Guid.Empty) {
                        return View(cliente);
                    }
                    return RedirectToAction("Listar", "Cliente");
                }
                else {
                    return RedirectToAction("Listar", "Cliente");
                }
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpPost]
        public IActionResult Editar(Cliente clienteEditado) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                    Guid idDevolvido = ch.update(clienteEditado);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Cliente");
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
                    ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                    ch.eliminar(id);
                    return RedirectToAction("Listar", "Cliente");
                }
                else {
                    return RedirectToAction("Listar", "Cliente");
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
