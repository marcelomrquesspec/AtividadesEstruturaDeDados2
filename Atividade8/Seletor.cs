using Atividade8.Models;
using Atividade8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade8
{
    public class Seletor
    {
        private Cadastro cadastro;

        public Seletor(Cadastro cadastro)
        {
            this.cadastro = cadastro;
        }


        public int EscolherOpcao()
        {
            int opcao = 1;

            do
            {
                Console.WriteLine("0\tSair\r\n1\tCadastrar ambiente\r\n2\tConsultar ambiente\r\n3\tExcluir ambiente\r\n4\tCadastrar usuario\r\n5\tConsultar usuario\r\n6\tExcluir usuario\r\n7\tConceder permissão de acesso ao usuario (informar ambiente e usuário - vincular ambiente ao usuário)\r\n8\tRevogar permissão de acesso ao usuario (informar ambiente e usuário - desvincular ambiente do usuário)\r\n9\tRegistrar acesso (informar o ambiente e o usuário - registrar o log respectivo)\r\n10\tConsultar logs de acesso (informar o ambiente e listar os logs - filtrar por logs autorizados/negados/todos)\r\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                switch (opcao)
                {
                    case (int)OpcoesEnum.Sair:
                        sair();
                        break;
                    case (int)OpcoesEnum.CadastrarAmbiente:
                        cadastrarAmbiente();
                        break;
                    case (int)OpcoesEnum.ConsultarAmbiente:
                        consultarAmbiente();
                        break;
                    case (int)OpcoesEnum.ExcluirAmbiente:
                        excluirAmbiente();
                        break;
                    case (int)OpcoesEnum.CadastrarUsuario:
                        cadastrarUsuario();
                        break;
                    case (int)OpcoesEnum.ConsultarUsuario:
                        consultarUsuario();
                        break;
                    case (int)OpcoesEnum.ExcluirUsuario:
                        excluirUsuario();
                        break;
                    case (int)OpcoesEnum.ConcederPermissao:
                        concederPermissao();
                        break;
                    case (int)OpcoesEnum.RegovarPermissao:
                        regovarPermissao();
                        break;
                    case (int)OpcoesEnum.RegistrarAcesso:
                        registrarAcesso();
                        break;
                    case (int)OpcoesEnum.ConsultarLogs:
                        consultarLogs();
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 10\n\n");
                        break;
                }

                cadastro.upload();
                separador();
            } while (opcao < 0 || opcao > 10);

            return opcao;
        }

        private void consultarLogs()
        {
            Ambiente ambiente = consularAmbientePeloId();

            if (ambiente == null)
            {
                Console.WriteLine("\n\nAmbiente não encontrado.\n");
                return;
            }

            Console.WriteLine("\n");
            foreach (var log in ambiente.Logs)
            {
                Console.WriteLine($"{log.ToString()}");
            }
        }

        private void registrarAcesso()
        {
            Usuario usuario = consultarUsuarioPeloId();

            if (usuario == null)
            {
                Console.WriteLine("\n\nUsuario não encontrado.\n");
                return;
            }

            Ambiente ambiente = consularAmbientePeloId();

            if (ambiente == null)
            {
                Console.WriteLine("\n\nAmbiente não encontrado.\n");
                return;
            }

            var log = new Log(usuario, usuario.hasPermissaoCadastrada(ambiente));
            ambiente.registrarLog(log);

            Console.WriteLine("\n\nTentativa de acesso registrada\n");
        }

        private void regovarPermissao()
        {
            Usuario usuario = consultarUsuarioPeloId();

            if (usuario == null)
            {
                Console.WriteLine("\n\nUsuario não encontrado.\n");
                return;
            }

            Ambiente ambiente = consularAmbientePeloId();

            if (ambiente == null)
            {
                Console.WriteLine("\n\nAmbiente não encontrado.\n");
                return;
            }

            var revogadoAcessoSucesso = usuario.revogarPermissao(ambiente);

            if (revogadoAcessoSucesso)
            {
                Console.WriteLine("\n\nAcesso revogado!\n");
            }
            else
            {
                Console.WriteLine("\n\nAcesso não revogado\n");
            }
        }

        private void concederPermissao()
        {
            Usuario usuario = consultarUsuarioPeloId();

            if (usuario == null)
            {
                Console.WriteLine("\n\nUsuario não encontrado.\n");
                return;
            }

            Ambiente ambiente = consularAmbientePeloId();

            if (ambiente == null)
            {
                Console.WriteLine("\n\nAmbiente não encontrado.\n");
                return;
            }

            var concederAcessoSucesso = usuario.concederPermissao(ambiente);

            if (concederAcessoSucesso)
            {
                Console.WriteLine("\n\nAcesso concedido!\n");
            }
            else
            {
                Console.WriteLine("\n\nAcesso não concedido\n");
            }
        }

        private void excluirUsuario()
        {
            Usuario usuario = new Usuario();

            Console.Write("Digite id do usuario: ");
            usuario.Id = int.Parse(Console.ReadLine());

            var removidoComSucesso = cadastro.removerUsuario(usuario);

            if (removidoComSucesso)
            {
                Console.WriteLine("\n\nUsuario excluido com sucesso!\n");
            }
            else
            {

                Console.WriteLine("\n\nNão foi possivel remover o usuario\n");
            }
        }

        private void consultarUsuario()
        {
            Usuario usuario = consultarUsuarioPeloId();

            if (usuario == null)
            {
                Console.WriteLine("\n\nUsuario não encontrado.\n");
            }
            else
            {
                Console.WriteLine($"\n\n{usuario.ToString()}\n");
            }
        }

        private void cadastrarUsuario()
        {
            Usuario usuario = new Usuario();

            Console.Write("Digite id do usuario: ");
            usuario.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do usuario: ");
            usuario.Nome = Console.ReadLine();

            cadastro.adicionarUsuario(usuario);

            Console.WriteLine("\n\nUsuario cadastrado com sucesso!\n");
        }

        private void excluirAmbiente()
        {
            Ambiente ambiente = new Ambiente();

            Console.Write("Digite id do ambiente: ");
            ambiente.Id = int.Parse(Console.ReadLine());

            var removidoComSucesso = cadastro.removerAmbiente(ambiente);

            if (removidoComSucesso)
            {
                Console.WriteLine("\n\nAmbiente excluido com sucesso!\n");
            }
            else
            {
                Console.WriteLine("\n\nAmbiente não encontrado\n");
            }
        }

        private void consultarAmbiente()
        {
            Ambiente ambiente = consularAmbientePeloId();

            if (ambiente == null)
            {
                Console.WriteLine("\n\nAmbiente não encontrado.\n");
                return;
            }
            else
            {
                Console.WriteLine($"\n\n{ambiente.ToString()}\n");
            }

        }

        private void cadastrarAmbiente()
        {
            Ambiente ambiente = new Ambiente();

            Console.Write("Digite id do ambiente: ");
            ambiente.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do ambiente: ");
            ambiente.Nome = Console.ReadLine();

            cadastro.adicionarAmbiente(ambiente);

            Console.WriteLine("\n\nAmbiente cadastrado com sucesso!\n");
        }

        private void sair()
        {
            Console.WriteLine("Obrigado por usar o programa...");
            Console.WriteLine("Até a proxima :)");
            Console.ReadKey();
        }

        private Usuario consultarUsuarioPeloId()
        {
            Usuario usuario = new Usuario();

            Console.Write("Digite id do usuario: ");
            usuario.Id = int.Parse(Console.ReadLine());

            return cadastro.pesquisarUsuario(usuario);
        }
        private Ambiente consularAmbientePeloId()
        {
            Ambiente ambiente = new Ambiente();

            Console.Write("Digite id do ambiente: ");
            ambiente.Id = int.Parse(Console.ReadLine());

            return cadastro.pesquisarAmbiente(ambiente);
        }

        private void separador()
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
