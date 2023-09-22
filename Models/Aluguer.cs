using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models.Helpers {
    public class Aluguer {
        public enum TipoEstado { Devolvido, PorDevolver, PorLevantar };

        private Guid _id;
        private Cliente _cliente;
        private Funcionario _funcionario;
        private Produto _produto;
        private decimal _precoDiario;
        private int _dias;
        private decimal _precoTotal;
        private decimal _caucao;
        private DateTime _dataAluguer;
        private DateTime _dataLimite;
        private TipoEstado _estado;

        //criar propriedades desta classe
        //Apenas o getter pois o constructor atribui o valor ao _idProduto
        public Guid Id {
            get { return _id; }
            set {
                //Só atualizo o id se este estiver VAZIO
                if (_id == Guid.Empty) _id = value;
            }
        }

        public decimal PrecoDiario {
            get { return _precoDiario; }
            set {
                _precoDiario = value;
                if (_precoDiario < 0) _precoDiario = 0;
            }
        }

        public int Dias{
            get { return _dias; }
            set {
                _dias = value;
                if (_dias < 0) _dias = 0;
            }
        }

        public decimal PrecoTotal { //calcula o preço total do aluguer, tendo em conta o preço do aluguer ao dia e os dias de aluguer
            get { return PrecoDiario*Dias; }
            set {
                _precoTotal = value;
                if (_precoTotal < 0) _precoTotal = 0;
            }
        } 

        public DateTime DataLimite {  //calcular data de entrega, tendo a data de aluguer e os dias que vai estar alugado
            get { return DataAluguer.AddDays(Dias); }
            set {
                _dataLimite = value;
                if (_dataLimite.Year < 1900) _dataLimite = Convert.ToDateTime("01-01-1900");
            }
        }
        
        public decimal Caucao {
            get { return _caucao; }
            set {
                _caucao = value;
                if (_caucao < 0) _caucao = 0;
            }
        }

        public DateTime DataAluguer {
            get { return _dataAluguer; }
            set {
                _dataAluguer = value;
                if (_dataAluguer.Year < 1900) _dataAluguer = Convert.ToDateTime("01-01-1900");
            }
        }

        public TipoEstado Estado {
            get { return _estado; }
            set { _estado = value; }
        }

        public Cliente Cliente {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public Funcionario Funcionario {
            get { return _funcionario; }
            set { _funcionario = value; }        
        }

        public Produto Produto {
            get { return _produto; }
            set { _produto = value; }
  
        }

        //construtor default
        public Aluguer() {
            //-OS ATRIBUTOS DEVEM SER INICIALIZADOS
            Id = Guid.Empty;
            Produto = new Produto();
            Funcionario = new Funcionario();
            Cliente = new Cliente();
            PrecoDiario = 0.0M;
            Dias = 0;
            Caucao = 0.0M;
            DataAluguer = DateTime.Now;
            Estado = TipoEstado.PorDevolver;
        }

    }
}
