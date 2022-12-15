using Atividade8.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8.Utils
{
    public static class ListExtensions
    {
        public static IList<Usuario> cloneShalow(this IList<Usuario> usuarios)
        {
            var cloneUsuarios = new List<Usuario>();

            foreach (var usuario in usuarios)
            {
                var ambientes = usuario.Ambientes
                    .Select(a => new Ambiente(a.Id, a.Nome))
                    .ToList();

                cloneUsuarios.Add(new Usuario(usuario.Id, usuario.Nome, ambientes));
            }

            return cloneUsuarios;
        }

        public static IList<Ambiente> cloneShalow(this IList<Ambiente> ambientes)
        {
            var cloneAmbientes = new List<Ambiente>();

            foreach (var ambiente in ambientes)
            {
                var logs = ambiente.Logs
                    .Select(l => new Log(new Usuario(l.Usuario.Id, l.Usuario.Nome), l.TipoAcesso, l.DtAcesso))
                    .ToList();
                cloneAmbientes.Add(new Ambiente(ambiente.Id, ambiente.Nome, logs));
            }

            return cloneAmbientes;
        }

        public static Queue<T> ToQueue<T>(this IEnumerable<T> entidades)
        {
            var queue = new Queue<T>();

            foreach (var entidade in entidades)
            {
                queue.Enqueue(entidade);
            }

            return queue;
        }
    }
}
