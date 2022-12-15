using Atividade8.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8.Models
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Queue<Log> Logs { get; }

        public Ambiente() : this(0, "")
        {
        }
        public Ambiente(int id) : this(id, "")
        {
        }
        public Ambiente(int id, string nome) : this(id, "", new List<Log>())
        {
        }
        [JsonConstructor]
        public Ambiente(int id, string nome, IEnumerable<Log> logs)
        {
            Id = id;
            Nome = nome;
            Logs = logs.ToQueue();
        }

        public void registrarLog(Log log)
        {
            while (Logs.Count >= 100)
            {
                Logs.Dequeue();
            }

            Logs.Enqueue(log);
        }

        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome}";
        }
    }
}