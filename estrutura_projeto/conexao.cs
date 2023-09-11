using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
//Biblioteca para comunicação
//com o MYSQL 

namespace estrutura_projeto
{
    class conexao
    {
        public MySqlConnection conectar;
        //Declaração das variaveis para conexao
        public string servidor;
        //Variavel servidor - identifica onde está localizado
        //o servidor do banco de dados. (
        //Exemplo Padrão de conexão local - 127.0.0.1 ou localhost
        public string database;
        //data-base nome local onde estara todas as tabelas
        //do banco de dados.
        public string usuario;
        //usuario de acesso ao banco de dados, que utilizaremos
        //o usuario padrão - root
        public string senha;
        //senha de acesso ao banco de dados, que utilizaremos
        //a senha padrão - ""

        //Criação do Construtor
        public conexao()
        {
            //Função Inicializar 
            inicializar();
        }

        //Criação da função inicializar
        //A palavra public permite que a função inicializar 
        //seja utilizada em todo o projeto ou seja em 
        //diversos formulários
        //Void quando a função não retonar nenhum valor
        //ou seja existem funções que retornam valor e outras não 
        //quando não retorna a função executa somente o que é
        //determinada.
        public void inicializar()
        {
            //Configurar as variaves dentro da função inicializar
            servidor = "127.0.0.1"; //"proprio computador"
            database = "estrutura_projeto";//data base a ser criada
                                     //futuramente
            usuario = "root";
            senha = "";
            //Juntar todas as informações em uma unica
            //variavel conexaostring
            string conexaostring;
            conexaostring = "SERVER=" + servidor + ";" + "DATABASE=" +
                        database + ";" + "UID=" + usuario + ";" +
                        "PASSWORD= " + senha + ";";
            //palavras em vermelho são comandos padrões a ser usados
            //para conexão. Os comandos em vermelhos serão preenchidos
            //com valor das variaveis.
            conectar = new MySqlConnection(conexaostring);
            //MySqlConnection e o componente que realiza a conexão
            //entre o C# e o banco de dados.
        }
        //Criação de função de abertura de banco de dados
        //Bool - Booleano - Aberto ou Fechado
        public bool abrirconexao()
        {
            //try catch e um tratamento de erros  //tudo que estiver dentro do try será executado
            //caso não seja possivel executar o catch e reponsavel
            //por mostrar uma mensagem de erro ao usuário.
            try
            {       //Try executa a abertura do banco de dados.
                conectar.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox
                            .Show("Não foi possível conectar");
                        break;
                    case 1045:
                        System.Windows.Forms.MessageBox
                         .Show("Usuário e senha inválidos! Verifique");
                        break;
                }
                return false;
            }
        }

        //função para fechar conexão
        public bool fecharconexao()
        {
            try
            {
                conectar.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
