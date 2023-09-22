using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class Conta {
        public Guid GuidConta { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int NivelAcesso { get; set; }

        public Conta() {
            setGuest();
        }

        private void setGuest() {
            GuidConta = Guid.Empty;
            Nome = "Convidado";
            Email = "";
            NivelAcesso = 0;
        }
    }
}
