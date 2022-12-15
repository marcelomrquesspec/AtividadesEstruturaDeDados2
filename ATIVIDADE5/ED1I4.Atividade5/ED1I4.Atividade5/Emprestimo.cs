using System;

namespace ED1I4.Atividade5
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime DtDevolucao { get; set; }

        public Emprestimo()
            : this(DateTime.Now, DateTime.Now.AddDays(7))
        {
        }
        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = dtDevolucao;
        }

        public override string ToString()
        {
            return $"{DtEmprestimo.ToString("G")} - {DtDevolucao.ToString("G")}";
        }
    }
}