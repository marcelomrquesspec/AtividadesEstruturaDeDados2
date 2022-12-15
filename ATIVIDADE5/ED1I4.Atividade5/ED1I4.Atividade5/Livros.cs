using System.Collections.Generic;
using System.Linq;

namespace ED1I4.Atividade5
{
    public class Livros
    {
        public List<Livro> Acervo { get; }

        public Livros()
        {
            Acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }
        public Livro pesquisar(Livro livro)
        {
            return Acervo.FirstOrDefault(l => l.Equals(livro));
        }
    }
}
