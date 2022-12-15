using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ED1I4.Atividade4
{
    public partial class Form1 : Form
    {
        private readonly Contatos contatos;

        public Form1()
        {
            InitializeComponent();
            contatos = new Contatos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var source = new BindingSource();
            source.DataSource = contatos.Agenda;

            dtResultados.DataSource = source;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var contato = _retornarContato();
            var sucessoAddContato = contatos.adicionar(contato);

            if (sucessoAddContato)
            {
                MessageBox.Show("Contato adicionado com sucesso");
                _limparCampos();
            }
        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            var contato = _pesquisarContatoPeloEmail();

            if (contato.Email == "")
            {
                MessageBox.Show("Email digitado não pertence a um contato cadastrado");
                return;
            }

            var sucessoRemover = contatos.remover(contato);

            if (sucessoRemover)
            {
                MessageBox.Show("Contato removido!");
                _limparCampos();
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            var contato = _pesquisarContatoPeloEmail();

            if (contato == null)
            {
                MessageBox.Show("Email digitado não pertence a um contato cadastrado");
                return;
            }

            var source = new BindingSource();
            source.DataSource = contato;

            dtResultados.DataSource = source;
            _limparCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                var contato = _retornarContato();
                var sucessoAlteracao = contatos.alterar(contato);


                if (sucessoAlteracao)
                {
                    MessageBox.Show("Contato atualizado com sucesso");
                    _limparCampos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Contato _pesquisarContatoPeloEmail()
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                throw new Exception("O campo Email é obrigatorio");

            var contato = new Contato(txtEmail.Text);

            var contatoEncontrado = contatos.pesquisar(contato);

            return contatoEncontrado;
        }
        private Contato _retornarContato()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
                throw new Exception("O campo Nome é obrigatorio");

            if (string.IsNullOrEmpty(txtEmail.Text))
                throw new Exception("O campo Email é obrigatorio");

            if (string.IsNullOrEmpty(txtDia.Text))
                throw new Exception("O campo dia da data de nascimento é obrigatorio");

            if (string.IsNullOrEmpty(txtMes.Text))
                throw new Exception("O campo mês da data de nascimento é obrigatorio");

            if (string.IsNullOrEmpty(txtAno.Text))
                throw new Exception("O campo ano da data de nascimento é obrigatorio");

            var dataNascimento = new Data(
                int.Parse(txtDia.Text),
                int.Parse(txtMes.Text),
                int.Parse(txtAno.Text)
            );

            var contato = new Contato(
                txtEmail.Text,
                txtNome.Text,
                dataNascimento
            );

            return contato;
        }
        private void _limparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtDia.Text = "";
            txtMes.Text = "";
            txtAno.Text = "";

            txtNumero.Text = "";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //int indexSelectedCell = dtResultados.Rows(DataGridViewElementStates.Selected);

            //MessageBox.Show(indexSelectedCell.ToString());
        }
    }
}
