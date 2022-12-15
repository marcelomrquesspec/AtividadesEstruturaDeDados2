using Atividade8.Models;
using Atividade8.Repository;
using Atividade8.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8
{
    public class Cadastro
    {
        public List<Usuario> Usuarios { get; internal set; }
        public List<Ambiente> Ambientes { get; internal set; }

        private readonly UsuarioRepository usuarioRepository;
        private readonly AmbienteRepository ambienteRepository;

        public Cadastro()
        {
            Usuarios = new List<Usuario>();
            Ambientes = new List<Ambiente>();
            usuarioRepository = new UsuarioRepository();
            ambienteRepository = new AmbienteRepository();

            download();
        }

        public void adicionarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
        public bool removerUsuario(Usuario usuario)
        {
            var usuarioPesquisa = pesquisarUsuario(usuario);

            if (usuarioPesquisa == null) return false;

            if (usuarioPesquisa.Ambientes.Count > 0) return false;

            Usuarios.Remove(usuarioPesquisa);

            return true;
        }
        public Usuario pesquisarUsuario(Usuario usuario)
        {
            var usuarioPesquisa = Usuarios.FirstOrDefault(u => u.Id == usuario.Id);

            return usuarioPesquisa;
        }
        public void adicionarAmbiente(Ambiente ambiente)
        {
            Ambientes.Add(ambiente);
        }
        public bool removerAmbiente(Ambiente ambiente)
        {
            var ambientePesquisado = pesquisarAmbiente(ambiente);

            if (ambientePesquisado == null) return false;

            Ambientes.Remove(ambientePesquisado);
            return true;
        }
        public Ambiente pesquisarAmbiente(Ambiente ambiente)
        {
            var ambientePesquisado = Ambientes.FirstOrDefault(a => a.Id == ambiente.Id);

            return ambientePesquisado;
        }
        public void upload() {
            usuarioRepository.salvar(Usuarios.cloneShalow());
            ambienteRepository.salvar(Ambientes.cloneShalow());
        }
        public void download() {
            Usuarios = usuarioRepository.listar().ToList();
            Ambientes = ambienteRepository.listar().ToList();
        }
    }
}
