using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var medicamentos = new Medicamentos();
            var seletor = new Seletor(medicamentos);

            int opcao = -1;
            while (opcao != 0) {
                opcao = seletor.EscolherOpcao();
            }
        }
    }
}
