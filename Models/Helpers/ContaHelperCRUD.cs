using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models.Helpers {
    public class ContaHelperCRUD {

        private string _conexaoBD_;

        private string guidMentiroso = "67AFC1E7-AC5F-4CE8-A5AE-185A9F2A531D";

        public ContaHelperCRUD(string conexao) {
            _conexaoBD_ = conexao;
        }

        public Conta Autenticar(string email, string senha) {
            Conta c = new Conta();    //Já tenho um anonimo
            if (email.Equals("admin@admin.pt") && senha.Equals("admin123")) {
                c.GuidConta = Guid.Parse(guidMentiroso);
                c.Nome = "Administrador";
                c.Email = "admin@admin.pt";
                c.NivelAcesso = 1;
            }
            return c;
        }

        public Conta getContaPorUid(Guid uid) {
            Conta c = new Conta();   //Pelo menos, é guest
            if (uid == Guid.Parse(guidMentiroso)) {
                c.GuidConta = uid;
                c.Nome = "Administrador";
                c.Email = "admin@admin.pt";
                c.NivelAcesso = 1;
            }
            return c;
        }
    }
}
