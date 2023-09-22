using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor.Models {
    public class ItemCombo {

        public int Id { get; set; }
        public string Designacao { get; set; }

        public ItemCombo() {
            Id= 0;
            Designacao = "";
        }
    }
}
