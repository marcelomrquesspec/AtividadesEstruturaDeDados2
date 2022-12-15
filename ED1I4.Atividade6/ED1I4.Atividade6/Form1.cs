using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ED1I4.Atividade6
{
    public partial class Form1 : Form
    {
        private Senhas senhas;
        private Guiches guiches;
        private int qtdGuiches;

        public Form1()
        {
            InitializeComponent();

            senhas = new Senhas();
            guiches = new Guiches();
            qtdGuiches = 0;

            listSenhas.View = View.List;
            listGuiches.View = View.List;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            carregarQtdeGuiches();
            carregarListSenhas();

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            senhas.gerar();
            carregarListSenhas();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Guiche novoGuiche = new Guiche(++qtdGuiches);
            guiches.adicionar(novoGuiche);

            carregarQtdeGuiches();
        }
        private void btnListarSenhas_Click(object sender, EventArgs e)
        {
            carregarListSenhas();
        }
        private void btnChamar_Click(object sender, EventArgs e)
        {
            try
            {
                int idGuiche = getGuicheDigitado();
                var guiche = guiches.listaCuiches.FirstOrDefault(g => g.Id == idGuiche);

                if (guiche == null)
                    throw new Exception("Guichê não encontrado");

                bool sucessoChamarSenha = guiche.chamar(senhas.FilaSenhas);

                if(!sucessoChamarSenha)
                    throw new Exception("Não há senhas a serem atendidas.");

                carregarListSenhas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnListarAtendimentos_Click(object sender, EventArgs e)
        {
            try
            {
                int idGuiche = getGuicheDigitado();
                var guiche = guiches.listaCuiches.FirstOrDefault(g => g.Id == idGuiche);

                if (guiche == null)
                    throw new Exception("Guichê não encontrado");


                carregarListAtendimentos(guiche.Atendimentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getGuicheDigitado()
        {
            int idGuiche = 0;

            if (string.IsNullOrEmpty(txtGuiche.Text))
                throw new Exception("Para chamar um atendimento é preciso preencher o campo guichê");

            if (!int.TryParse(txtGuiche.Text, out idGuiche))
                throw new Exception("O identificador do guichê deve ser um numero");

            return idGuiche;
        }
        private void carregarQtdeGuiches()
        {
            lblQtdeGuiches.Text = qtdGuiches.ToString();
        }
        private void carregarListSenhas()
        {
            listSenhas.Items.Clear();

            foreach (var senha in senhas.FilaSenhas)
            {
                listSenhas.Items.Add(new ListViewItem(new string[] { senha.dadosParciais() }));
            }
        }
        private void carregarListAtendimentos(Queue<Senha> senhasAtendidas)
        {
            listGuiches.Items.Clear();

            foreach (var senha in senhasAtendidas)
            {
                listGuiches.Items.Add(new ListViewItem(new string[] { senha.dadosCompletos() }));
            }
        }
    }
}
