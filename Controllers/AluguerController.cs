using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGestor.Models;
using ProjetoGestor.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Controllers {
    public class AluguerController : Controller {

        private Conta conta;

        public IActionResult Listar() {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                List<Aluguer> alugueresParaAView = ah.list();

                ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);

                foreach(var aluguer in alugueresParaAView) {
                    aluguer.Funcionario = fh.read(aluguer.Funcionario.Id.ToString());
                    aluguer.Produto = ph.read(aluguer.Produto.Id.ToString());
                    aluguer.Cliente = ch.read(aluguer.Cliente.Id.ToString());
                }

                //List<Cliente> clientes = ch.list();
                //List<Funcionario> funcionarios = fh.list();
                //List<Produto> produtos = ph.list();

                //ViewBag.listaClientes = clientes;
                //ViewBag.listaFuncionarios = funcionarios;
                //ViewBag.listaProdutos = produtos;

                return View(alugueresParaAView);
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        public IActionResult ListarDevolvidos() {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                List<Aluguer> alugueresParaAView = ah.listDevolvidos();

                ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);

                foreach (var aluguer in alugueresParaAView) {
                    aluguer.Funcionario = fh.read(aluguer.Funcionario.Id.ToString());
                    aluguer.Produto = ph.read(aluguer.Produto.Id.ToString());
                    aluguer.Cliente = ch.read(aluguer.Cliente.Id.ToString());
                }

                //List<Cliente> clientes = ch.list();
                //List<Funcionario> funcionarios = fh.list();
                //List<Produto> produtos = ph.list();

                //ViewBag.listaClientes = clientes;
                //ViewBag.listaFuncionarios = funcionarios;
                //ViewBag.listaProdutos = produtos;

                return View(alugueresParaAView);
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpGet]
        public IActionResult Criar() {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                List<ItemCombo> listaEstados = new List<ItemCombo>();
                listaEstados.Add(new ItemCombo { Id= (int)Aluguer.TipoEstado.PorDevolver, Designacao ="Por Devolver" });
                listaEstados.Add(new ItemCombo { Id= (int)Aluguer.TipoEstado.PorLevantar, Designacao ="Por Levantar" });
                listaEstados.Add(new ItemCombo { Id= (int)Aluguer.TipoEstado.Devolvido, Designacao ="Devolvido" });

                ViewBag.listaEstados = listaEstados;

                ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);

                List<Cliente> clientes = ch.list();
                List<Funcionario> funcionarios = fh.list();
                List<Produto> produtos = ph.list();

                ViewBag.listaClientes = clientes;
                ViewBag.listaFuncionarios = funcionarios;
                ViewBag.listaProdutos = produtos;

                return View();
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpPost]
        public IActionResult Criar(Aluguer aluguer) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                    Guid idDevolvido = ah.insert(aluguer);
                }
                else {
                    informacao += "Erro de Informação nos Campos / Experimente substituir os valores decimais por vírgula e não ponto";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Aluguer");
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
                    AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                    Aluguer aluguer = ah.read(id);
                    if (aluguer.Id != Guid.Empty) {

                        ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                        FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                        ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);

                        aluguer.Funcionario = fh.read(aluguer.Funcionario.Id.ToString());
                        aluguer.Produto = ph.read(aluguer.Produto.Id.ToString());
                        aluguer.Cliente = ch.read(aluguer.Cliente.Id.ToString());

                        return View(aluguer);
                    }
                    return RedirectToAction("Listar", "Aluguer");
                }
                else {
                    return RedirectToAction("Listar", "Aluguer");
                }
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
                    AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                    ah.eliminar(id);
                    return RedirectToAction("Listar", "Aluguer");
                }
                else {
                    return RedirectToAction("Listar", "Aluguer");
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
                    AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                    Aluguer aluguer = ah.read(id);
                    if (aluguer.Id != Guid.Empty) {

                        List<ItemCombo> estados = new List<ItemCombo>();
                        estados.Add(new ItemCombo { Id= (int)Aluguer.TipoEstado.PorDevolver, Designacao ="Por Devolver" });
                        estados.Add(new ItemCombo { Id= (int)Aluguer.TipoEstado.PorLevantar, Designacao ="Por Levantar" });
                        estados.Add(new ItemCombo { Id= (int)Aluguer.TipoEstado.Devolvido, Designacao ="Devolvido" });

                        ClienteHelperCRUD ch = new ClienteHelperCRUD(Program.ligacao);
                        FuncionarioHelperCRUD fh = new FuncionarioHelperCRUD(Program.ligacao);
                        ProdutoHelperCRUD ph = new ProdutoHelperCRUD(Program.ligacao);

                        List<Cliente> clientes = ch.list();
                        List<Funcionario> funcionarios = fh.list();
                        List<Produto> produtos = ph.list();

                        ViewBag.listaEstados = estados;
                        ViewBag.listaClientes = clientes;
                        ViewBag.listaFuncionarios = funcionarios;
                        ViewBag.listaProdutos = produtos;

                        aluguer.Funcionario = fh.read(aluguer.Funcionario.Id.ToString());
                        aluguer.Produto = ph.read(aluguer.Produto.Id.ToString());
                        aluguer.Cliente = ch.read(aluguer.Cliente.Id.ToString());

                        return View(aluguer);
                    }
                    return RedirectToAction("Listar", "Aluguer");
                }
                else {
                    return RedirectToAction("Listar", "Aluguer");
                }
            }
            return RedirectToAction("SemAcesso", "Portal");
        }

        [HttpPost]
        public IActionResult Editar(Aluguer aluguerEditado) {
            AutenticarUtilizador();
            if (conta.NivelAcesso > 0) {
                string informacao = "";
                if (ModelState.IsValid) {
                    AluguerHelperCRUD ah = new AluguerHelperCRUD(Program.ligacao);
                    Guid idDevolvido = ah.update(aluguerEditado);
                }
                else {
                    informacao += "Erro de Informação nos Campos";
                    return Content(informacao);
                }
                return RedirectToAction("Listar", "Aluguer");
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
