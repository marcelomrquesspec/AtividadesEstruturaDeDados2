using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade6
{
    public class Guiche
    {
        private int id;

        public int Id { get => id; }

        public Queue<Senha> Atendimentos { get; }


        public Guiche() : this(0)
        {
        }

        public Guiche(int id)
        {
            this.id = id;
            Atendimentos = new Queue<Senha>();
        }

        public bool chamar(Queue<Senha> senhas)
        {
            if (senhas.Count == 0)
                return false;
            
            var senha = senhas.Dequeue();

            senha.atender();

            Atendimentos.Enqueue(senha);

            return true;
        }
    }
}
