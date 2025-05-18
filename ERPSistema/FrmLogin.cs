using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmLogin : Form
    {
        // String de conexão com o MySQL
        private readonly string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        public FrmLogin()
        {
            InitializeComponent();
        }

        // Método de clique do botão de login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Captura os valores do formulário
            string usuario = txtUsuario.Text.Trim();  // Usuário digitado no login
            string senha = txtSenha.Text.Trim();  // Senha digitada no login

            // Valida o login do usuário
            if (ValidarLogin(usuario, senha))
            {
                // Após a validação, obtém o nível de acesso do usuário
                string nivelAcesso = GetNivelAcesso(usuario);  // Método que retorna o nível de acesso (Gerente, Admin, Vendedor)

                // Abre o formulário principal com as informações do usuário
                AbrirFormularioPrincipal(usuario, nivelAcesso);
            }
            else
            {
                // Exibe uma mensagem de erro caso o login falhe
                MessageBox.Show("Usuário ou senha inválidos", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para sair da aplicação
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Encerra a aplicação
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        #region Métodos Auxiliares

        // Método para validar as credenciais do login no banco de dados
        private bool ValidarLogin(string usuario, string senha)
        {
            string query = "SELECT * FROM usuarios WHERE Usuario = @Usuario AND Password = @Password";

            // Usando 'using' para garantir que a conexão seja fechada corretamente
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // Abre a conexão com o banco de dados
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros da consulta (usuário e senha)
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Password", senha);  // Aqui, você deveria usar um método de hashing para validar a senha real, e não a senha em texto claro

                        MySqlDataReader reader = command.ExecuteReader();

                        // Se houverem registros, significa que o login é válido
                        return reader.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar com o banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;  // Retorna falso em caso de erro
                }
            }
        }

        // Método para obter o nível de acesso do usuário
        private string GetNivelAcesso(string usuario)
        {
            string query = "SELECT Nivel_Acesso FROM usuarios WHERE Usuario = @Usuario";

            // Usando 'using' para garantir que a conexão seja fechada corretamente
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // Abre a conexão com o banco de dados
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adiciona o parâmetro da consulta (usuário)
                        command.Parameters.AddWithValue("@Usuario", usuario);

                        MySqlDataReader reader = command.ExecuteReader();

                        // Se o usuário for encontrado, retorna o nível de acesso
                        if (reader.HasRows)
                        {
                            reader.Read();  // Lê a primeira linha (não deveria haver mais de uma)
                            return reader["Nivel_Acesso"].ToString();  // Retorna o nível de acesso (Gerente, Admin, Vendedor)
                        }
                        else
                        {
                            return "Nível não encontrado";  // Se o usuário não for encontrado, retorna uma string padrão
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar com o banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;  // Retorna nulo em caso de erro
                }
            }
        }

        // Método para abrir o formulário principal após o login
        private void AbrirFormularioPrincipal(string usuario, string nivelAcesso)
        {
            // Fecha o FrmPrincipal anterior, caso esteja aberto
            FrmPrincipal frmPrincipalAntigo = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;
            if (frmPrincipalAntigo != null)
            {
                frmPrincipalAntigo.Close();  // Fecha o FrmPrincipal anterior
            }

            // Cria uma nova instância do FrmPrincipal com as informações do usuário
            FrmPrincipal frmPrincipalNovo = new FrmPrincipal
            {
                Usuario = usuario,  // Passa o nome do usuário
                lblUsuario = { Text = usuario },  // Atualiza a label de usuário
                lblNivel = { Text = nivelAcesso }  // Atualiza a label de nível de acesso (Gerente, Admin, Vendedor)
            };

            // Exibe a nova instância do FrmPrincipal
            frmPrincipalNovo.Show();

            // Fecha o formulário de login após o login bem-sucedido
            this.Hide();  // Esconde o FrmLogin
        }

        #endregion
    }
}
