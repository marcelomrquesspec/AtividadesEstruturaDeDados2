using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade5
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; }


        public Livro() : this(0, "", "", "")
        {
        }
        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }


        public void adicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }
        public int qtdeExemplares() => Exemplares.Count;
        public int qtdeDisponiveis() => Exemplares.Count(exemplar => exemplar.disponivel());
        public int qtdeEmprestimos()
        {
            int qtdeEmprestimos = 0;

            Exemplares.ForEach(exemplar =>
            {
                qtdeEmprestimos += exemplar.Emprestimos.Count;
            });

            return qtdeEmprestimos;
        }
        public double percDisponibilidade()
        {
            return qtdeDisponiveis() / (double)qtdeExemplares();
        }

        public override bool Equals(object obj)
        {
            return Isbn.Equals(((Livro)obj).Isbn);
        }
        public override string ToString()
        {
            return $"ISBN: {Isbn}\nTitulo: {Titulo}\nAutor: {Autor}\nEditora: {Editora}\nTotal de exemplares: {qtdeExemplares()}\nTotal de exemplares disponíveis: {qtdeDisponiveis()}\nPercentual de disponibilidade: {percDisponibilidade() * 100}%";
        }
    }
}
