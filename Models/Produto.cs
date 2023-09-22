using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class Produto {
        private Guid _id;
        private string _designacao;

        //criar propriedades desta classe
        public Guid Id {
            get { return _id; }
            set {
                //Só atualizo o id se este estiver VAZIO
                if (_id == Guid.Empty) _id = value;
            }
        }

        public string Designacao {
            get { return _designacao; }
            set {
                _designacao = value;
                if (_designacao.Equals("")) _designacao = "Designação a Definir";

            }
        }

        //construtor default
        public Produto() {
            Designacao = "";
            Id = Guid.Empty;        //EmptyID = modo inserção
        }

        //string de saida desta classe, com utilização de overriding
        public Guid getId() {
            return Id;
        }
    }
}
