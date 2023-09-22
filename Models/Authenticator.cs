using ProjetoGestor.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class Authenticator {
        public Conta Authenticate(Guid guid) {
            Conta c;
            ContaHelperCRUD chc = new ContaHelperCRUD(Program.ligacao);
            c = chc.getContaPorUid(guid);
            return c;
        }
    }
}
