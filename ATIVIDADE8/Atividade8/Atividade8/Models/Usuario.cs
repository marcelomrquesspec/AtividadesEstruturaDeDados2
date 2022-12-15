using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Ambiente> Ambientes { get; }

        public Usuario() : this(0, "")
        {
        }
        public Usuario(int id) : this(id, "")
        {
        }
        public Usuario(int id, string nome) : this(id, nome, new List<Ambiente>())
        {
        }
        public Usuario(int id, string nome, List<Ambiente> ambientes)
        {
            Id = id;
            Nome = nome;
            Ambientes = ambientes;
        }


        public bool concederPermissao(Ambiente ambiente)
        {
            if (!hasPermissaoCadastrada(ambiente))
            {
                Ambientes.Add(ambiente);
                return true;
            }

            return false;
        }
        public bool revogarPermissao(Ambiente ambiente)
        {
            if (hasPermissaoCadastrada(ambiente))
            {
                var ambienteItem = Ambientes.FirstOrDefault(a => a.Id == ambiente.Id);

                Ambientes.Remove(ambienteItem);
                return true;
            }

            return false;
        }

        public bool hasPermissaoCadastrada(Ambiente ambiente)
        {
            var hasPermissao = Ambientes.Any(a => a.Id == ambiente.Id);
            return hasPermissao;
        }

        public override string ToString()
        {
            string retorno = $"Id: {Id} - Nome: {Nome}\nAmbientes: ";

            if (Ambientes.Count <= 0)
                retorno += "Sem ambientes";
            else
                foreach (var ambiente in Ambientes)
                {
                    retorno += $"\n\t{ambiente.ToString()}";
                }

            return retorno;
        }
    }
}
