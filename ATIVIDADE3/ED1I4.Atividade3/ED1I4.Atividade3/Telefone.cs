using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade3
{
    public class Telefone
    {
        public string Tipo { get; set; }
        public string numero { get; set; }
        public bool principal { get; set; }

        public Telefone() : this("", "", false) { }

        public Telefone(string tipo, string numero, bool principal)
        {
            Tipo = tipo;
            this.numero = numero;
            this.principal = principal;
        }

        public override string ToString()
        {
            return $"Tipo: {Tipo} - Numero: {numero} - Principal: {(principal ? "Sim" : "Não")}";
        }
    }
}
