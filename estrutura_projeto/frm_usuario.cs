using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estrutura_projeto
{
    public partial class frm_usuario : Form
    {
        public frm_usuario()
        {
            InitializeComponent();
        }
        //Ligação do formulário com a classe
        usuario u = new usuario();
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                u.setUsuarioL(txt_usuario.Text);
                u.setSenhaL(txt_senha.Text);
                u.inserir();
                //Consulta apos a inserção dos dados.
                dataGridView1.DataSource = u.consultar();
            }
            finally
            {
                MessageBox.Show("Usuário e senha cadastrado");
            }
           
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = u.consultar();
            //Formatação das conlunas do datagrid.
            dataGridView1.Columns["codigo"].HeaderText = "Código";
            dataGridView1.Columns["usuario"].HeaderText = "Usuario";
            dataGridView1.Columns["senha"].HeaderText = "Senha";
        }

        public void exibiregistro(int i)
        {
            txt_codigo.Text = "" + dataGridView1[0, i].Value;
            txt_usuario.Text = "" + dataGridView1[1, i].Value;
            txt_senha.Text = "" + dataGridView1[2, i].Value;
        }






        private void frm_usuario_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            /*Exibiregistro método criado dentro do proprio
            formulário (metodo não disponivel para os
            formularios) 
            CurrentRow.Index - posicionamento do ponteiro
            (mouse) na linha atual do datagrid
            */
            exibiregistro(dataGridView1.CurrentRow.Index);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                u.setCodigo(int.Parse(txt_codigo.Text));
                u.excluir();
                dataGridView1.DataSource = u.consultar();
            }
            finally
            {
                MessageBox.Show("Excluida com sucesso");
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            try
            {
                u.setCodigo(int.Parse(txt_codigo.Text));
                u.setUsuarioL(txt_usuario.Text);
                u.setSenhaL(txt_senha.Text);
                u.alterar();
                dataGridView1.DataSource = u.consultar();
            }
            finally
            {
                MessageBox.Show("Alterado com sucesso");
            }

        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_codigo.Text = "";
            txt_usuario.Text = "";
            txt_senha.Text = "";
        }
    }
}
