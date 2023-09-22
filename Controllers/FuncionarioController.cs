using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGestor.Models;
using ProjetoGestor.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Controllers {
    public class FuncionarioController : Controller {

        private Conta conta;

        public IActionResult Listar() {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                List<Funcionario> funcionariosParaAView = fh.list();
                return View(funcionariosParaAView);
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
        public IActionResult Criar(Funcionario funcionario) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                    Guid idDevolvido = fh.insert(funcionario);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Funcionario");
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
                    FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                    Funcionario funcionario = fh.read(id);
                    if (funcionario.Id != Guid.Empty) {
                        return View(funcionario);
                    }
                    else return RedirectToAction("Listar", "Funcionario");
                }
                else {
                    return RedirectToAction("Listar", "Funcionario");
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
                    FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                    Funcionario funcionario = fh.read(id);
                    if (funcionario.Id != Guid.Empty) {
                        return View(funcionario);
                    }
                    else return RedirectToAction("Listar", "Funcionario");
                }
                else {
                    return RedirectToAction("Listar", "Funcionario");
                }
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpPost]
        public IActionResult Editar(Funcionario funcionarioEditado) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                    Guid idDevolvido = fh.update(funcionarioEditado);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Funcionario");
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
                    FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                    fh.eliminar(id);
                    return RedirectToAction("Listar", "Funcionario");
                }
                else {
                    return RedirectToAction("Listar", "Funcionario");
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
