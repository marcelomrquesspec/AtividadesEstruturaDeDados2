using System;
using System.Collections.Generic;
using System.Text;

namespace ED1I4.Atividade4
{
    public class Data
    {

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public Data()
            : this(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year)
        {
        }

        public Data(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public void setData(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public override string ToString() => $"{Dia:00}/{Mes:00}/{Ano:0000}";
    }
}
