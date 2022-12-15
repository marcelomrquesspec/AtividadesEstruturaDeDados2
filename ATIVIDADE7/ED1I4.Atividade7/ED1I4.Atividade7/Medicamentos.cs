using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade7
{
    public class Medicamentos
    {
        public List<Medicamento> listaMedicamentos { get; }

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(m => m.Equals(medicamento));

            return medicamentoEncontrado;
        }

        public bool deletar(Medicamento medicamento)
        {
            var medicamentoEncontrado = pesquisar(medicamento);

            if (medicamentoEncontrado == null)
                return false;

            if (medicamento.qtdeDisponivel() >= 0)
                return false;

            listaMedicamentos.Remove(medicamentoEncontrado);
            return true;
        }
    }
}
