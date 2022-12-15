using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade7
{
    public class Seletor
    {
        private Medicamentos medicamentos;

        public Seletor(Medicamentos medicamentos)
        {
            this.medicamentos = medicamentos;
        }


        public int EscolherOpcao()
        {
            int opcao = 1;

            do
            {
                Console.WriteLine("0\tFinalizar\r\n1\tCadastrar Medicamento\r\n2\tConsultar Medicamento (sintético)¹\r\n3\tConsultar Medicamento (analítico)²\r\n4\tComprar medicamento\r\n5\tVender medicamento\r\n6\tListar medicamentos\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                switch (opcao)
                {
                    case (int)OpcoesEnum.Finalizar:
                        finalizar();
                        break;
                    case (int)OpcoesEnum.CadastrarMedicamento:
                        cadastrarMedicamentos();
                        break;
                    case (int)OpcoesEnum.ConsultarMedicamentoSintetico:
                        consultarMedicamentoSintetico();
                        break;
                    case (int)OpcoesEnum.ConsultarMedicamentoAnalitico:
                        consultarMedicamentoAnalitico();
                        break;
                    case (int)OpcoesEnum.ComprarMedicamento:
                        comprarMedicamento();
                        break;
                    case (int)OpcoesEnum.VenderMedicamento:
                        venderMedicamento();
                        break;
                    case (int)OpcoesEnum.ListarMedicamentos:
                        listarMedicamentos();
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 6\n\n");
                        break;
                }

                separador();
            } while (opcao < 0 || opcao > 6);

            return opcao;
        }

        private void listarMedicamentos()
        {
            if (medicamentos.listaMedicamentos.Count() <= 0)
            {
                Console.WriteLine("\nNão há medicamentos a serem listados!");
            }
            else
            {
                Console.WriteLine("ID - NOME - LABORATORIO - QTDE DISPONÍVEL");
                foreach (var medicamento in medicamentos.listaMedicamentos)
                {
                    Console.WriteLine("\n" + medicamento.ToString());
                }
            }
        }

        private void venderMedicamento()
        {
            Medicamento medicamento = consultarMedicamentoPeloId();
            int qtdeVenda = 0;

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }

            Console.Write("Digite a qtde da venda: ");
            qtdeVenda = int.Parse(Console.ReadLine());

            bool vendaSucesso = medicamento.vender(qtdeVenda);

            if (vendaSucesso)
            {
                Console.WriteLine("\nVenda realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nQtde da venda maior que a quantidade disponivel!");
            }
        }

        private void comprarMedicamento()
        {
            Medicamento medicamento = consultarMedicamentoPeloId();
            Lote lote = new Lote();

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }

            Console.Write("Digite id do lote: ");
            lote.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade do lote: ");
            lote.Qtde = int.Parse(Console.ReadLine());

            Console.Write("Digite o dia do vencimento do lote: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes do vencimento do lote: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano do vencimento do lote: ");
            int ano = int.Parse(Console.ReadLine());

            lote.Vencimento = new DateTime(ano, mes, dia);

            medicamento.comprar(lote);

            Console.WriteLine("\nLote adicionada com sucesso!");
        }

        private void consultarMedicamentoAnalitico()
        {
            Medicamento medicamento = consultarMedicamentoPeloId();

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }
            else
            {
                Console.WriteLine("\n" + medicamento.ToString());
                Console.WriteLine("Lotes:");

                if (medicamento.Lotes.Count() <= 0)
                {
                    Console.WriteLine("\tMedicamento não possui lotes!");
                }
                else
                {
                    foreach (var lote in medicamento.Lotes)
                    {
                        Console.WriteLine("\t" + lote.ToString());
                    }
                }
            }
        }

        private void consultarMedicamentoSintetico()
        {
            Medicamento medicamento = consultarMedicamentoPeloId();

            if (medicamento == null)
            {
                Console.WriteLine("\nMedicamento não encontrado!");
            }
            else
            {
                Console.WriteLine("\n" + medicamento.ToString());
            }
        }

        private Medicamento consultarMedicamentoPeloId()
        {
            Medicamento medicamento = new Medicamento();

            Console.Write("Digite id do medicamento: ");
            medicamento.Id = int.Parse(Console.ReadLine());

            return medicamentos.pesquisar(medicamento);
        }

        private void cadastrarMedicamentos()
        {
            Medicamento medicamento = new Medicamento();

            Console.Write("Digite id do medicamento: ");
            medicamento.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do medicamento: ");
            medicamento.Nome = Console.ReadLine();

            Console.Write("Digite o nome do laboratorio: ");
            medicamento.Laboratorio = Console.ReadLine();

            medicamentos.adicionar(medicamento);

            Console.WriteLine("\nMedicamento adicionada com sucesso!");
        }

        private void finalizar()
        {
            Console.WriteLine("Obrigado por usar o programa...");
            Console.WriteLine("Até a proxima :)");
            Console.ReadKey();
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
