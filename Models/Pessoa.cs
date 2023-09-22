using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class Pessoa { 

        private Guid _id;
        private string _nome;
        private string _nif;
        private string _contacto;

        //criar propriedades desta classe
        public Guid Id { 
            get { return _id; }
            set {
                //Só atualizo o id se este estiver VAZIO
                if (_id == Guid.Empty) _id = value;
            }
        }

        public string Nome {
            get { return _nome; }
            set {
                _nome = value;
                if (_nome.Equals("")) _nome = "Nome a Definir";
                
            }
        }

        public string Nif {
            get { return _nif; }
            set {
                _nif = value;
                if (_nif.Length != 9) _nif = "000000000";
            }
        }

        public string Contacto {
            get { return _contacto; }
            set {
                _contacto = value;
                if (_contacto.Length != 9) _contacto = "000000000";
            }
        }

        //construtor default
        public Pessoa() {
            Nome = "";
            Contacto="";
            Nif="";
            Id = Guid.Empty;        //EmptyID = modo inserção
        }

    }
}
