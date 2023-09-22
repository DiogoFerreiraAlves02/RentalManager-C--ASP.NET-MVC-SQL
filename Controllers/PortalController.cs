using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGestor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Controllers {
    public class PortalController : Controller {

        private Conta conta;

        public IActionResult Index() {
            AutenticarUtilizador();
            return View();
        }

        public IActionResult SemAcesso() {
            AutenticarUtilizador();
            return View();
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
