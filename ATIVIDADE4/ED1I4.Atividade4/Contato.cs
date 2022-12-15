using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ED1I4.Atividade4
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; }

        public Contato()
            : this("", "", null)
        {
        }
        public Contato(string email)
            : this(email, "", null)
        {
        }
        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            Telefones = new List<Telefone>();
        }


        public int getIdate()
        {
            // TO-DO Fazer
            return 18;
        }

        public void adicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }
        public string getTelefonePrincipal()
        {
            var telefone = Telefones.Where(t => t.principal);

            return telefone.ToString();
        }

        public override string ToString()
        {
            string telefones = "\n";

            Telefones.ForEach(t =>
            {
                telefones += $"\t{t.ToString()}\n";
            });

            return $"Email: {Email}\nNome: {Nome.ToString()}\nData Nascimento: {DtNasc.ToString()}\nTelefones: {telefones}";
        }

        public override bool Equals(object obj)
        {
            return this.Email.Equals(((Contato)obj).Email);
        }
    }
}
