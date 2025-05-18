using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmAlterarSenha : Form
    {
        // Conexão com o banco de dados (string de conexão)
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        public FrmAlterarSenha()
        {
            InitializeComponent();
        }

        // Manipulador de evento para o botão Confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string senhaAntiga = txtSenhaAntiga.Text;
            string senhaNova = txtSenhaNova.Text;
            string senhaNovaConfirmar = txtSenhaNovaConfirmar.Text;

            // Validar se as senhas novas são iguais
            if (!ValidarSenhas(senhaNova, senhaNovaConfirmar))
                return;

            // Obtém o nome de usuário atual (logado no sistema) chamando o método GetUsuarioAtual()
            string usuario = GetUsuarioAtual();  // Obtém o usuário atual da instância do FrmPrincipal

            // Validar se a senha antiga está correta
            if (ValidateOldPassword(usuario, senhaAntiga))
            {
                // Se a senha antiga for válida, altera a senha
                ChangePassword(usuario, senhaNova);
            }
            else
            {
                ShowMessage("Senha antiga incorreta.", "Erro", MessageBoxIcon.Error);
            }
        }

        // Manipulador de evento para o botão Cancelar (fecha o formulário)
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha o formulário de alteração de senha
        }

        // Função auxiliar para validar as senhas inseridas
        private bool ValidarSenhas(string senhaNova, string senhaNovaConfirmar)
        {
            // Verifica se a nova senha e a confirmação da senha coincidem
            if (senhaNova != senhaNovaConfirmar)
            {
                ShowMessage("As senhas novas não coincidem!", "Erro", MessageBoxIcon.Error);
                return false;
            }

            // Verifica se a nova senha tem uma complexidade mínima
            if (!IsPasswordStrong(senhaNova))
            {
                ShowMessage("A nova senha deve ter no mínimo 8 caracteres, incluindo letras e números.", "Erro", MessageBoxIcon.Error);
                return false;
            }

            return true;  // Se tudo estiver certo, retorna true
        }

        // Função para verificar se a nova senha é forte o suficiente (mínimo de 8 caracteres, letras e números)
        private bool IsPasswordStrong(string senha)
        {
            return senha.Length >= 8 && senha.Any(char.IsLetter) && senha.Any(char.IsDigit);
        }

        // Função para mostrar mensagens de erro ou sucesso
        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        // Função para obter o nome do usuário atual a partir do formulário principal
        private string GetUsuarioAtual()
        {
            // Verifica se o FrmPrincipal está aberto e obtém o nome do usuário
            FrmPrincipal frmPrincipal = (FrmPrincipal)Application.OpenForms["FrmPrincipal"];

            if (frmPrincipal != null)
            {
                return frmPrincipal.Usuario;  // Retorna o nome do usuário logado
            }
            else
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }
        }

        // Função para validar a senha antiga fornecida pelo usuário
        private bool ValidateOldPassword(string usuario, string senhaAntiga)
        {
            string query = "SELECT Password FROM usuarios WHERE Usuario = @Usuario";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // Abre a conexão com o banco de dados
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adiciona o parâmetro da consulta para o nome do usuário
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        MySqlDataReader reader = command.ExecuteReader();

                        // Se a consulta retornar resultados, compara a senha fornecida com a armazenada
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string passwordFromDb = reader["Password"].ToString();
                            return passwordFromDb == senhaAntiga;  // Verifica se a senha antiga fornecida é a mesma armazenada no banco de dados
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Erro ao conectar com o banco de dados: {ex.Message}", "Erro", MessageBoxIcon.Error);
                }
            }
            return false;  // Retorna false caso a senha antiga não seja válida
        }

        // Função para alterar a senha no banco de dados
        private void ChangePassword(string usuario, string novaSenha)
        {
            string query = "UPDATE usuarios SET Password = @Password WHERE Usuario = @Usuario";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // Abre a conexão com o banco de dados
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros da consulta (nova senha e usuário)
                        command.Parameters.AddWithValue("@Password", novaSenha);
                        command.Parameters.AddWithValue("@Usuario", usuario);

                        // Executa a consulta de atualização no banco de dados
                        int rowsAffected = command.ExecuteNonQuery();

                        // Se a atualização for bem-sucedida, exibe uma mensagem de sucesso
                        if (rowsAffected > 0)
                        {
                            ShowMessage("Senha alterada com sucesso!", "Sucesso", MessageBoxIcon.Information);
                            this.Close();  // Fecha o formulário após a alteração
                        }
                        else
                        {
                            // Se nada foi alterado (nenhuma linha afetada), exibe um erro
                            MessageBox.Show("Erro ao alterar a senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibe erro caso ocorra algum problema ao conectar com o banco de dados
                    ShowMessage($"Erro ao conectar com o banco de dados: {ex.Message}", "Erro", MessageBoxIcon.Error);
                }
            }
        }
    }
}
