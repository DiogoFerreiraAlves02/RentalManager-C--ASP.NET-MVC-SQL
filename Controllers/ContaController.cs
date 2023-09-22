using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGestor.Models;
using ProjetoGestor.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Controllers {
    public class ContaController : Controller {
        public IActionResult Entrar() {
            Conta c = new Conta();
            ContaHelperCRUD chc = new ContaHelperCRUD(Program.ligacao);
            c = chc.Autenticar("admin@admin.pt", "admin123");
            HttpContext.Session.SetString("mySessionID", c.GuidConta.ToString());
            return RedirectToAction("Index", "Portal");
        }
        public IActionResult Sair() {
            Conta c = new Conta();      //c é anonimo com guid empty e nivel 0
            HttpContext.Session.SetString("mySessionID", c.GuidConta.ToString());
            return RedirectToAction("Index", "Portal");
        }
    }
}
