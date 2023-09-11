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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {

        }
        usuario u = new usuario();
        private void btn_acessar_Click(object sender, EventArgs e)
        {
            u.setUsuarioL(txt_usuario.Text);
            u.setSenhaL(txt_senha.Text);
            //metodo para consulta do login que deve retornar o valor 1
            //para acesso ao sistema.
            u.consultar_login();
            //variavel valor armazena o resultado do consultar
            int valor = u.consultar_login();
            if(valor == 1)
            {
                frm_principal form = new frm_principal();
                form.Show();
                this.Hide();
            }
            else if(txt_usuario.Text =="admin" && txt_senha.Text=="admin")
            {
                frm_usuario form = new frm_usuario();
                form.Show();
                this.Hide();
            } else {
                MessageBox.Show("Usuário e Senha Invalidos", "Acesso",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        }
    }
}
