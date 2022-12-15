using System;
using System.Collections.Generic;
using System.Linq;

namespace ED1I4.Atividade5
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; }


        public Exemplar() : this(0)
        {
        }
        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }


        public bool emprestar()
        {
            if (!disponivel())
            {
                return false;
            }

            Emprestimos.Add(new Emprestimo());
            return true;
        }
        public bool devolver()
        {
            var ultimoEmprestimo = Emprestimos.LastOrDefault();

            if (ultimoEmprestimo != null && ultimoEmprestimo.DtDevolucao >= DateTime.Now) 
            {
                int indexUltimoEmprestimo = Emprestimos.IndexOf(ultimoEmprestimo);
                Emprestimos[indexUltimoEmprestimo].DtDevolucao = DateTime.Now;

                return true;
            }

            return false;
        }
        public bool disponivel()
        {
            var ultimoEmprestimo = Emprestimos.LastOrDefault();

            if (ultimoEmprestimo == null)
                return true;

            if (ultimoEmprestimo.DtDevolucao < DateTime.Now)
                return true;

            return false;
        }
        public int qtdeEmprestimos() => Emprestimos.Count;

        public override bool Equals(object obj)
        {
            return Tombo.Equals(((Exemplar)obj).Tombo);
        }
        public override string ToString()
        {
            string retornoFormatado = $"Tombo: {Tombo}\n\tEmprestimos:";

            foreach (var emprestimo in Emprestimos)
            {
                retornoFormatado += "\n\t\t" + emprestimo.ToString();
            }


            return retornoFormatado;
        }
    }
}