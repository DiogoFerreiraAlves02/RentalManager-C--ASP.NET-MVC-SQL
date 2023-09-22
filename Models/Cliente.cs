using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class Cliente : Pessoa {
        private string _morada;

        //criar propriedades desta classe
        public string Morada {
            get { return _morada; }
            set {
                _morada = value;
                if (_morada.Equals("")) _morada = "Morada a Definir";
            }
        }

        //construtor default
        public Cliente() : base() {
            Morada = "";
        }
    }
}
