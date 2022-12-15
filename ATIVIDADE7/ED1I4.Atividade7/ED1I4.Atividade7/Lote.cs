using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade7
{
    public class Lote
    {
        public int Id { get; set; }
        public int Qtde { get; set; }
        public DateTime Vencimento { get; set; }

        public Lote() : this(0, 0, DateTime.Now)
        {
        }
        public Lote(int id, int qtde, DateTime vencimento)
        {
            this.Id = id;
            this.Qtde = qtde;
            this.Vencimento = vencimento;
        }

        public override string ToString()
        {
            return $"{Id} - {Qtde} - {Vencimento.ToString("dd/MM/yyyy")}";
        }
    }
}
