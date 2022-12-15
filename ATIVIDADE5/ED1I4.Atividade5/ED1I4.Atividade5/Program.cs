using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 1;
            Livros livros = new Livros();


            while (opcao != 0)
            {
                Console.WriteLine("0\tSair\r\n1\tAdicionar livro\r\n2\tPesquisar livro (sintético)¹\r\n3\tPesquisar livro (analítico)²\r\n4\tAdicionar exemplar\r\n5\tRegistrar empréstimo\r\n6\tRegistrar devolução\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                switch (opcao)
                {
                    case (int)OpcoesEnum.Sair:
                        sair();
                        break;
                    case (int)OpcoesEnum.AdicionarLivro:
                        adicionarLivro(livros);
                        break;
                    case (int)OpcoesEnum.PesquisarSintetico:
                        pesquisarSintetico(livros);
                        break;
                    case (int)OpcoesEnum.PesquisarAnalitico:
                        pesquisarAnalitico(livros);
                        break;
                    case (int)OpcoesEnum.AdicionarExemplar:
                        adicionarExemplar(livros);
                        break;
                    case (int)OpcoesEnum.RegistrarEmprestimo:
                        registrarEmprestimo(livros);
                        break;
                    case (int)OpcoesEnum.RegistrarDevolucao:
                        registrarDevolucao(livros);
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 6\n\n");
                        break;
                }

                separador();
            }
        }

        private static void registrarDevolucao(Livros livros)
        {
            Livro livro = new Livro();
            Exemplar exemplar = new Exemplar();

            Console.Write("Digite isbn do livro: ");
            livro.Isbn = int.Parse(Console.ReadLine());

            livro = livros.pesquisar(livro);

            if (livro == null)
            {
                Console.WriteLine("\nLivro não encontrado.");
                return;
            }

            Console.Write("Digite tombo do exemplar desse livro: ");
            exemplar.Tombo = int.Parse(Console.ReadLine());

            exemplar = livro.Exemplares.FirstOrDefault(ex => ex.Equals(exemplar));

            if(exemplar == null)
            {
                Console.WriteLine("\nExemplar não encontrado.");
                return;
            }

            if (exemplar.devolver())
            {
                Console.WriteLine("\nExemplar devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel devolver o exemplar.");
            }
        }

        private static void registrarEmprestimo(Livros livros)
        {
            Livro livro = new Livro();
            Exemplar exemplar = new Exemplar();

            Console.Write("Digite isbn do livro: ");
            livro.Isbn = int.Parse(Console.ReadLine());

            livro = livros.pesquisar(livro);

            if (livro == null)
            {
                Console.WriteLine("\nLivro não encontrado.");
                return;
            }

            Console.Write("Digite tombo do exemplar desse livro: ");
            exemplar.Tombo = int.Parse(Console.ReadLine());

            exemplar = livro.Exemplares.FirstOrDefault(ex => ex.Equals(exemplar));

            if (exemplar == null)
            {
                Console.WriteLine("\nExemplar não encontrado.");
                return;
            }

            if (exemplar.emprestar())
            {
                Console.WriteLine("\nExemplar emprestado com sucesso.");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel emprestar o exemplar.");
            }
        }

        private static void adicionarExemplar(Livros livros)
        {
            Livro livro = new Livro();
            Exemplar exemplar = new Exemplar();

            Console.Write("Digite isbn do livro: ");
            livro.Isbn = int.Parse(Console.ReadLine());

            livro = livros.pesquisar(livro);

            if (livro == null)
            {
                Console.WriteLine("\nLivro não encontrado.");
                return;
            }

            Console.Write("Digite tombo do exemplar desse livro: ");
            exemplar.Tombo = int.Parse(Console.ReadLine());

            livro.adicionarExemplar(exemplar);

            Console.WriteLine("\nExemplar adicionada com sucesso!");
        }

        private static void pesquisarAnalitico(Livros livros)
        {
            Livro livro = new Livro();

            Console.Write("Digite isbn do livro: ");
            livro.Isbn = int.Parse(Console.ReadLine());

            livro = livros.pesquisar(livro);

            if (livro != null)
            {
                Console.WriteLine("\n" + livro.ToString());
                Console.WriteLine("Exemplares:");
                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine("\t" + exemplar.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado.");
            }
        }

        private static void pesquisarSintetico(Livros livros)
        {
            Livro livro = new Livro();

            Console.Write("Digite isbn do livro: ");
            livro.Isbn = int.Parse(Console.ReadLine());

            livro = livros.pesquisar(livro);

            if (livro != null)
            {
                Console.WriteLine("\n" + livro.ToString());
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado.");
            }
        }

        private static void adicionarLivro(Livros livros)
        {
            Livro livro = new Livro();
            Exemplar exemplar = new Exemplar();

            Console.Write("Digite isbn do livro: ");
            livro.Isbn = int.Parse(Console.ReadLine());

            Console.Write("Digite titulo do livro: ");
            livro.Titulo = Console.ReadLine();

            Console.Write("Digite autor do livro: ");
            livro.Autor = Console.ReadLine();

            Console.Write("Digite editora do livro: ");
            livro.Editora = Console.ReadLine();

            Console.Write("Digite tombo do exemplar desse livro: ");
            exemplar.Tombo = int.Parse(Console.ReadLine());

            livro.adicionarExemplar(exemplar);
            livros.adicionar(livro);

            Console.WriteLine("\nLivro adicionada com sucesso!");
        }

        private static void sair()
        {
            Console.WriteLine("Obrigado por usar o programa...");
            Console.WriteLine("Até a proxima :)");
            Console.ReadKey();
        }


        private static void separador()
        {
            Console.WriteLine();
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("\n");
        }
    }
}
