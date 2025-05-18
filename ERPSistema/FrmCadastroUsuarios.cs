using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmCadastroUsuarios : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;"; // Ajuste conforme seu banco de dados

        public FrmCadastroUsuarios()
        {
            InitializeComponent();
        }

        // Função chamada quando o formulário for carregado
        private void FrmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            // Definir valores do ComboBox para Nível de Acesso
            cmbNivelAcesso.Items.Clear();  // Limpa os itens antigos (se houver)
            cmbNivelAcesso.Items.Add("Admin");
            cmbNivelAcesso.Items.Add("Gerente");
            cmbNivelAcesso.Items.Add("Vendedor");

            // Define o índice selecionado após adicionar os itens
            cmbNivelAcesso.SelectedIndex = 0; // Default para "Admin"

            // Carregar usuários na DataGridView
            CarregarUsuarios();

            // Limpar os campos ao carregar
            LimparCampos();

            // Garantir que nenhuma linha esteja selecionada ao abrir o formulário
            dgvUsuarios.ClearSelection();
        }

        // Função para salvar ou atualizar o usuário
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtPassword.Text;
            string nivelAcesso = cmbNivelAcesso.SelectedItem?.ToString(); // Usando ? para garantir que o valor não seja nulo

            // Verificação se os campos obrigatórios estão preenchidos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o ComboBox tem algum item selecionado
            if (cmbNivelAcesso.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione um nível de acesso!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se é uma edição ou um novo cadastro
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Editando um usuário existente
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                int idUsuario = Convert.ToInt32(row.Cells["Id"].Value); // Supondo que a tabela tenha uma coluna "Id"
                AtualizarUsuario(idUsuario, usuario, senha, nivelAcesso);
            }
            else
            {
                // Novo cadastro
                CadastrarUsuario(usuario, senha, nivelAcesso);
            }
        }

        // Função para limpar os campos e resetar o estado para um novo cadastro
        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            LimparCampos(); // Limpa os campos
            dgvUsuarios.ClearSelection(); // Limpa a seleção da DataGridView
            txtUsuario.Focus(); // Coloca o foco no campo txtUsuario
        }

        // Função para excluir o usuário selecionado
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Obtemos o ID do usuário selecionado
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                int idUsuario = Convert.ToInt32(row.Cells["Id"].Value);

                DialogResult dialogResult = MessageBox.Show("Você tem certeza que deseja excluir este usuário?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    ExcluirUsuario(idUsuario); // Chama a função para excluir o usuário
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para excluir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Função para fechar o formulário
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário
        }

        // Função chamada quando a seleção de usuários no DataGridView mudar
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                // Preencher os campos com os dados da linha selecionada
                DataGridViewRow row = dgvUsuarios.SelectedRows[0];
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();

                // Atualiza o ComboBox de Nível de Acesso
                string nivelAcesso = row.Cells["Nivel_Acesso"].Value.ToString();
                if (nivelAcesso == "Admin" || nivelAcesso == "Gerente" || nivelAcesso == "Vendedor")
                {
                    cmbNivelAcesso.SelectedItem = nivelAcesso;
                }
            }
        }

        // Função para cadastrar um novo usuário
        private void CadastrarUsuario(string usuario, string senha, string nivelAcesso)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Usuarios (Usuario, Password, Nivel_Acesso) VALUES (@Usuario, @Password, @Nivel_Acesso)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Password", senha); // A senha não está criptografada, idealmente, use hashing
                        cmd.Parameters.AddWithValue("@Nivel_Acesso", nivelAcesso);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos(); // Limpa os campos após salvar
                    CarregarUsuarios(); // Recarrega os usuários na DataGridView
                    dgvUsuarios.ClearSelection();
                    SelecionarUsuario(usuario); // Seleciona o novo usuário
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Função para atualizar os dados de um usuário existente
        private void AtualizarUsuario(int idUsuario, string usuario, string senha, string nivelAcesso)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Usuarios SET Usuario = @Usuario, Password = @Password, Nivel_Acesso = @Nivel_Acesso WHERE Id = @Id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Password", senha);
                        cmd.Parameters.AddWithValue("@Nivel_Acesso", nivelAcesso);
                        cmd.Parameters.AddWithValue("@Id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos(); // Limpa os campos após salvar
                    CarregarUsuarios(); // Recarrega os usuários na DataGridView
                    dgvUsuarios.ClearSelection();
                    SelecionarUsuario(usuario); // Seleciona o usuário atualizado
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Função para selecionar um usuário após o cadastro ou edição
        private void SelecionarUsuario(string usuario)
        {
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                if (row.Cells["Usuario"].Value.ToString() == usuario) // Se o nome do usuário for igual
                {
                    row.Selected = true;
                    dgvUsuarios.FirstDisplayedScrollingRowIndex = row.Index; // Faz a linha selecionada visível
                    break; // Encerra o loop após encontrar a linha
                }
            }
        }

        // Função para carregar os usuários na DataGridView
        private void CarregarUsuarios()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuarios";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dgvUsuarios.DataSource = dt; // Preencher DataGridView com os dados
                        dgvUsuarios.Columns["Password"].HeaderText = "Senha";
                        dgvUsuarios.Columns["Nivel_Acesso"].HeaderText = "Nível";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Função para excluir o usuário do banco de dados
        private void ExcluirUsuario(int idUsuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM Usuarios WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarUsuarios(); // Recarrega os usuários no DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir o usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Função para limpar os campos do formulário
        private void LimparCampos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            cmbNivelAcesso.SelectedIndex = -1; // Reseta para "Admin"
        }
    }
}
