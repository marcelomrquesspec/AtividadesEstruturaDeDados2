using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8.Repository
{
    public abstract class BaseRepository<T>
    {
        public void salvar(IList<T> entidade)
        {
            using (StreamWriter sw = File.CreateText(getPath()))
            {
                entidade.ToList().ForEach(e =>
                {
                    sw.WriteLine(JsonConvert.SerializeObject(e));
                });
            }
        }

        public IList<T> listar()
        {
            IList<T> entidades = new List<T>();

            if (!File.Exists(getPath()))
                return entidades;

            string[] linhas = File.ReadAllLines(getPath(), Encoding.UTF8);

            foreach (string linha in linhas)
            {
                entidades.Add(JsonConvert.DeserializeObject<T>(linha));
            }

            return entidades;
        }

        private string getPath()
        {
            string path = Directory.GetCurrentDirectory();
            var nomeEntidade = typeof(T).Name;

            return $"{path}\\{nomeEntidade}.txt";
        }
    }
}
