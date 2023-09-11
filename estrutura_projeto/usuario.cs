using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
namespace estrutura_projeto
{
    class usuario : conexao
    {
        private int codigo;
        private string usuarioL;
        private string senhaL;

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }
        public int getCodigo()
        {
            return this.codigo;
        }
        public void setUsuarioL(string usuarioL)
        {
            this.usuarioL = usuarioL;
        }
        public string getUsuarioL()
        {
            return this.usuarioL;
        }
        public void setSenhaL(string senhaL)
        {
            this.senhaL = senhaL;
        }
        public string getSenhaL()
        {
            return this.senhaL;
        }
        public void inserir()
        {
            //Os campos em vermelhos devem estar escrito da mesma forma que está no banco de dados
            string query = "insert into usuario(usuario,senha)values ('" +
                          getUsuarioL() + "','" + getSenhaL() + "')";

            //Abrir conexão
            if (this.abrirconexao() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                //Fechar conexão
                this.fecharconexao();
            }
        }
        public DataTable consultar()
        {
            //importar a biblioteca using System.Data;
            this.abrirconexao();
            string mSQL = "Select * from usuario";
            //MySqlCommand e MySqlDataAdapter executa a query
            MySqlCommand cmd = new MySqlCommand(mSQL, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            this.fecharconexao();
            //demonstração do resultado em formato de tabela no datagridview
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void excluir()
        {
            string query = "delete from usuario where codigo = '" + getCodigo() + "'";
            //Abrir conexão
            if (this.abrirconexao() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                //Fechar conexão
                this.fecharconexao();
            }
        }
        public void alterar()
        {
            string query = "update usuario set usuario= '" + getUsuarioL() 
                + "', senha = '" + getSenhaL() + "' where codigo = '" + getCodigo() + "'";
            if (this.abrirconexao() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, conectar);
                cmd.ExecuteNonQuery();
                //Fechar conexão
                this.fecharconexao();
            }
        }
        //metodo int pq o metodo retorna um valor no final da execução
        public int consultar_login()
        {
            this.abrirconexao();
            //count necessário contar quantos usuarios existem dentro do banco
            //de dados
            string query = "select count(usuario) from usuario where usuario = '" +
                getUsuarioL() + "' and senha = '" + getSenhaL() + "'";
            
            //execução da query digitada na linha acima
            MySqlCommand cmd = new MySqlCommand(query, conectar);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            //Int32 e o tipo da variavel para armazenar  o valor do resultado da query
            //resultado_query é o nome da variavel que armazena o valor.

            Int32 resultado_query = Convert.ToInt32(cmd.ExecuteScalar());
            //finaliza a consulta
            cmd.Dispose();

            int valor_login;
            valor_login = resultado_query;
            this.fecharconexao();
            return valor_login;
        }

    }
}
