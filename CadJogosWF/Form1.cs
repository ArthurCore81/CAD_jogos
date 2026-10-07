using CadJogosWF.DAO;
using CadJogosWF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadJogosWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                JogosViewModel a = new JogosViewModel();
                a.ID = Convert.ToInt32(txtIDJogo.Text);
                a.Name = txtNomeJogo.Text;
                a.Valor = Convert.ToSingle(txtValor.Text);
                a.Data = Convert.ToDateTime(masktxtDataCompra.Text);
                a.IDCategoria = Convert.ToInt32(txtIDCategoria.Text);

                JogosDAO dao = new JogosDAO();
                dao.Inserir(a);
                MessageBox.Show("Cadastro Realizado com Sucesso");
            }

            catch (Exception erro) 
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                JogosDAO dao = new JogosDAO();
                dao.Deletar(Convert.ToInt32(txtIDJogo.Text));
                MessageBox.Show("Cadastro Removido Com Sucesso");
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                JogosViewModel a = new JogosViewModel();
                a.ID = Convert.ToInt32(txtIDJogo.Text);
                a.Name = txtNomeJogo.Text;
                a.Valor = Convert.ToSingle(txtValor.Text);
                a.Data = Convert.ToDateTime(masktxtDataCompra.Text);
                a.IDCategoria = Convert.ToInt32(txtIDCategoria.Text);

                JogosDAO dao = new JogosDAO();
                dao.Alterar(a);
                MessageBox.Show("Cadastro Alterado Com Sucesso");
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                JogosDAO dao = new JogosDAO();
                JogosViewModel a = dao.Consulta(Convert.ToInt32(txtIDJogo.Text));
                if (a != null)
                    PreencheTela(a);
                else
                    MessageBox.Show("Registro não encontrado!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void PreencheTela(JogosViewModel a)
        {
            if (a != null)
            {
                txtIDJogo.Text = a.ID.ToString();
                txtNomeJogo.Text = a.Name;
                txtValor.Text = a.Valor.ToString();
                masktxtDataCompra.Text = a.Data.ToShortDateString();
                txtIDCategoria.Text = a.IDCategoria.ToString();
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                JogosDAO dao = new JogosDAO();
                var lista = dao.Listagem();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

    }
}
