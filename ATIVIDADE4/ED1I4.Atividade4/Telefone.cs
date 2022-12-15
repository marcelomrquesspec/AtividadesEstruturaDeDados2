using System;
using System.Collections.Generic;
using System.Text;

namespace ED1I4.Atividade4
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
