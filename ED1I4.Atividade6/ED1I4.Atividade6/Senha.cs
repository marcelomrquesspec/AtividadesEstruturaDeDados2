using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade6
{
    public class Senha
    {
        public int Id { get; set; }
        public DateTime DataGerac { get; set; }
        public DateTime? DataAtend { get; set; }

        public Senha(int id)
        {
            Id = id;
            DataGerac = DateTime.Now;
            DataAtend = null;
        }

        public string dadosParciais()
        {
            return $"{Id} - {DataGerac.ToString("yyyy/MM/dd HH:mm:ss")}";
        }
        public string dadosCompletos()
        {
            return $"{dadosParciais()} - {DataAtend?.ToString("yyyy/MM/dd HH:mm:ss")}";
        }
        public void atender()
        {
            DataAtend = DateTime.Now;
        }
    }
}
