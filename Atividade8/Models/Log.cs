using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8.Models
{
    public class Log
    {
        public DateTime DtAcesso { get; set; }
        public Usuario Usuario { get; set; }
        public bool TipoAcesso { get; set; }

        public Log(Usuario usuario, bool tipoAcesso)
            : this(usuario, tipoAcesso, DateTime.Now)
        {
        }
        [JsonConstructor]
        public Log(Usuario usuario, bool tipoAcesso, DateTime dtAcesso)
        {
            Usuario = usuario;
            TipoAcesso = tipoAcesso;
            DtAcesso = dtAcesso;
        }

        public string formatarTipoAcesso() => TipoAcesso ? "Autorizado" : "Negado";

        public override string ToString()
        {
            return $"Usuario: {Usuario.Nome} - Data de Acesso: {DtAcesso.ToString("dd/MM/yy HH:mm:ss")} - Tipo Acesso: {formatarTipoAcesso()}";
        }
    }
}