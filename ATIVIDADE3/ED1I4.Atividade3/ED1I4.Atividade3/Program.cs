using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade3
{
    internal class Program    {

        static void Main(string[] args)
        {
            int opcao = 1;
            Contatos contatos = new Contatos();


            Contato palinkas = new Contato("palinkas", "palinkas", new Data(31, 8, 2001));

            palinkas.adicionarTelefone(new Telefone("Celular", "9999999", true));
            palinkas.adicionarTelefone(new Telefone("Residencial", "88888888", false));

            contatos.adicionar(palinkas);


            while (opcao != 0)
            {
                Console.WriteLine("0. Sair\n1. Adicionar contato\n2. Pesquisar contato\n3. Alterar contato\n4. Remover contato\n5. Listar contatos\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                switch (opcao)
                {
                    case (int)OpcoesEnum.Sair:
                        sair();
                        break;
                    case (int)OpcoesEnum.Adicionar:
                        adicionar(contatos);
                        break;
                    case (int)OpcoesEnum.Pesquisar:
                        pesquisar(contatos);
                        break;
                    case (int)OpcoesEnum.Alterar:
                        alterar(contatos);
                        break;
                    case (int)OpcoesEnum.Remover:
                        remover(contatos);
                        break;
                    case (int)OpcoesEnum.Listar:
                        listar(contatos);
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 9\n\n");
                        break;
                }

                separador();
            }
        }

        private static void sair()
        {
            Console.WriteLine("Obrigado por usar o programa...");
            Console.WriteLine("Até a proxima :)");
            Console.ReadKey();
        }
        private static void adicionar(Contatos contatos)
        {
            Contato contato = new Contato();
            Data dataNascimento = new Data();
            Telefone telefone = new Telefone();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            Console.Write("Digite o nome do contato: ");
            contato.Nome = Console.ReadLine();

            Console.Write("Digite o dia que o contato nasceu: ");
            dataNascimento.Dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes que o contato nasceu: ");
            dataNascimento.Mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano que o contato nasceu: ");
            dataNascimento.Ano = int.Parse(Console.ReadLine());

            contato.DtNasc = dataNascimento;

            Console.Write("Digite o tipo do telefone: ");
            telefone.Tipo = Console.ReadLine();

            Console.Write("Digite o numero do telefone: ");
            telefone.numero = Console.ReadLine();

            telefone.principal = true;

            contato.adicionarTelefone(telefone);

            bool cadastradoComSucesso = contatos.adicionar(contato);

            if (cadastradoComSucesso)
            {
                Console.WriteLine("\nContato adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel adicionar o contato");
            }
        }
        private static void pesquisar(Contatos contatos)
        {
            Contato contato = new Contato();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            contato = contatos.pesquisar(contato);

            if(contato == null)
            {
                Console.WriteLine("\nContato não encontrado");
            }
            else
            {
                Console.WriteLine(contato.ToString());
            }
        }
        private static void alterar(Contatos contatos)
        {
            Contato contato = new Contato();
            Data dataNascimento = new Data();
            Telefone telefone = new Telefone();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            contato = contatos.pesquisar(contato);

            if(contato == null)
            {
                Console.WriteLine("\nContato não encontrato");
            }



            Console.Write("Digite o nome do contato: ");
            contato.Nome = Console.ReadLine();

            Console.Write("Digite o dia que o contato nasceu: ");
            dataNascimento.Dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes que o contato nasceu: ");
            dataNascimento.Mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano que o contato nasceu: ");
            dataNascimento.Ano = int.Parse(Console.ReadLine());

            contato.DtNasc = dataNascimento;

            Console.Write("Digite o tipo do telefone: ");
            telefone.Tipo = Console.ReadLine();

            Console.Write("Digite o numero do telefone: ");
            telefone.numero = Console.ReadLine();
            telefone.principal = true;
            contato.adicionarTelefone(telefone);


            bool atualizadoComSucesso = contatos.alterar(contato);

            if (atualizadoComSucesso)
            {
                Console.WriteLine("\nContato atualizado com sucesso");
            }
            else
            {
                Console.WriteLine("\nContato não foi atualizado");
            }
        }
        private static void remover(Contatos contatos)
        {
            Contato contato = new Contato();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            bool contatoRemovido = contatos.remover(contato);

            if (contatoRemovido)
            {
                Console.WriteLine("\nContato removido com sucesso");
            }
            else
            {
                Console.WriteLine("\nContato não foi removido");
            }
        }
        private static void listar(Contatos contatos)
        {
            foreach(Contato contato in contatos.Agenda)
            {
                Console.WriteLine(contato.ToString());
            }
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
