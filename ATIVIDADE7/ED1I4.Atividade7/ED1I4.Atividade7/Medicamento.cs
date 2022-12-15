using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade7
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public Queue<Lote> Lotes { get; }


        public Medicamento() : this(0, "", "")
        {
        }
        public Medicamento(int id) : this(id, "", "")
        {
        }
        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            Lotes = new Queue<Lote>();
        }


        public int qtdeDisponivel()
        {
            return Lotes.Select(l => l.Qtde).Sum();
        }
        public void comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }
        public bool vender(int qtde)
        {
            if (qtde > qtdeDisponivel())
                return false;

            int qtdeRestante = qtde;

            foreach (var lote in Lotes)
            {
                if (lote.Qtde >= qtdeRestante)
                {
                    lote.Qtde -= qtdeRestante;
                    qtdeRestante = 0;
                }
                else
                {
                    qtdeRestante -= lote.Qtde;
                    lote.Qtde = 0;
                }

                if (qtdeRestante == 0)
                    break;
            }

            removerLotesVazios();

            return true;

        }

        private void removerLotesVazios()
        {
            int qtdeLotesVazios = Lotes.Count(l => l.Qtde == 0);

            while (qtdeLotesVazios > 0)
            {
                Lotes.Dequeue();
                qtdeLotesVazios--;
            }
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Laboratorio} - {qtdeDisponivel()}";
        }
        public override bool Equals(object obj)
        {
            return Id.Equals(((Medicamento)obj).Id);
        }
    }
}
