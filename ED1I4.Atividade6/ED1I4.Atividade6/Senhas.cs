using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade6
{
    public class Senhas
    {
        private int proximoAtendimento;
        public int ProximoAtendimento { get => proximoAtendimento; }

        public Queue<Senha> FilaSenhas { get; }

        public Senhas()
        {
            proximoAtendimento = 1;
            FilaSenhas = new Queue<Senha>();
        }

        public void gerar()
        {
            var novaSenha = new Senha(proximoAtendimento++);

            FilaSenhas.Enqueue(novaSenha);
        }
    }
}
