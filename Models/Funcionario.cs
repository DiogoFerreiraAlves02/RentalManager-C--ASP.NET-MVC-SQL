using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class Funcionario : Pessoa {
        private string _nrFuncionario;

        //criar propriedades desta classe
        public string NrFuncionario {
            get { return _nrFuncionario; }
            set {
                _nrFuncionario = value;
                if (_nrFuncionario.Equals("")) _nrFuncionario = "0000";
            }
        }

        //construtor default
        public Funcionario() : base() {
            NrFuncionario = "";
        }
    }
}
