using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmConsultaPessoas : Form
    {
        private MySqlConnection connection;
        private MySqlDataAdapter dataAdapter;
        private BindingSource bindingSource;
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        public FrmConsultaPessoas()
        {
            InitializeComponent();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            // Carrega os dados e faz outras configurações necessárias
            CarregarDados();
            AtualizarConsulta();
            txtConsulta.Focus();
        }

        // Função chamada quando o botão Novo é clicado
        private void btnNovo_Click(object sender, EventArgs e)
        {
            AbrirFormularioCadastro(new FrmCadastroPessoas(this));
        }

        // Função chamada quando o botão Editar é clicado
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.SelectedRows.Count > 0)
            {
                // Captura os dados da pessoa selecionada para editar
                string codigo = dgvPessoas.SelectedRows[0].Cells["Codigo"].Value.ToString();
                string fantasia = dgvPessoas.SelectedRows[0].Cells["Fantasia"].Value.ToString();
                string destinatario = dgvPessoas.SelectedRows[0].Cells["Destinatario"].Value.ToString();
                string cnpjcpf = dgvPessoas.SelectedRows[0].Cells["CNPJ_CPF"].Value.ToString();
                string ierg = dgvPessoas.SelectedRows[0].Cells["idEstrangeiroRG"].Value.ToString();
                string tipoPessoa = dgvPessoas.SelectedRows[0].Cells["TipoPessoa"].Value.ToString();
                string razao = dgvPessoas.SelectedRows[0].Cells["Razao"].Value.ToString();

                // Instancia o formulário de cadastro para edição
                FrmCadastroPessoas frmCadastro = new FrmCadastroPessoas(this);
                frmCadastro.Codigo = codigo;
                frmCadastro.Fantasia = fantasia;
                frmCadastro.Destinatario = destinatario;
                frmCadastro.CNPJCPF = cnpjcpf;
                frmCadastro.idEstrangeiroRG = ierg;
                frmCadastro.TipoPessoa = tipoPessoa;
                frmCadastro.Razao = razao;

                // Carrega o endereço da pessoa selecionada
                CarregarEndereco(codigo, frmCadastro);

                // Exibe o formulário de edição
                frmCadastro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma linha para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Função chamada quando o botão Deletar é clicado
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um registro para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigo = dgvPessoas.SelectedRows[0].Cells["Codigo"].Value.ToString();
            ConfirmarExclusao(codigo);
        }

        // Função que é chamada sempre que o texto de consulta é alterado
        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            // Atualiza a consulta com o filtro do texto digitado
            CarregarDados();
        }

        private void dgvPessoas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma linha válida (ignorando a linha de cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Chama a função associada ao botão btnEditar
                btnEditar_Click(sender, e);
            }
        }

        // Função para carregar os dados na DataGridView com base no filtro
        public void CarregarDados()
        {
            if (bindingSource == null)
            {
                bindingSource = new BindingSource();
            }

            string filtro = txtConsulta.Text.Trim().ToLower();
            string query = @"
        SELECT 
            p.Codigo, 
            p.Fantasia, 
            p.Destinatario, 
            p.CNPJ_CPF, 
            p.idEstrangeiroRG, 
            tp.Nome AS TipoPessoa,  -- Aqui estamos trazendo o nome do tipo de pessoa
            p.Razao
        FROM 
            pessoas p
        LEFT JOIN 
            tipopessoa tp ON p.tipo_pessoa = tp.Id";  // Fazemos o join com a tabela tipopessoa para pegar o nome

            if (!string.IsNullOrEmpty(filtro))
            {
                query += " WHERE p.Destinatario LIKE @filtro OR p.CNPJ_CPF LIKE @filtro OR p.idEstrangeiroRG LIKE @filtro OR p.Fantasia LIKE @filtro";
            }

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                // Prepara o adaptador de dados com a consulta SQL
                dataAdapter = new MySqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Atribui o DataTable ao BindingSource
                bindingSource.DataSource = dataTable;
                dgvPessoas.DataSource = bindingSource;

                // Configura as colunas manualmente se necessário
                dgvPessoas.Columns["Codigo"].HeaderText = "Código";
                dgvPessoas.Columns["Fantasia"].HeaderText = "Fantasia";
                dgvPessoas.Columns["Destinatario"].HeaderText = "Destinatário";
                dgvPessoas.Columns["CNPJ_CPF"].HeaderText = "CNPJ / CPF";
                dgvPessoas.Columns["TipoPessoa"].HeaderText = "Tipo de Pessoa";  // "TipoPessoa" exibe o nome do tipo de pessoa
                dgvPessoas.Columns["Razao"].HeaderText = "Razão Social";

                // Ajustando a largura da coluna "Tipo de Pessoa" para 150 pixels
                dgvPessoas.Columns["TipoPessoa"].Width = 150;

                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para atualizar a consulta e carregar todos os registros
        public void AtualizarConsulta()
        {
            try
            {

                // Conexão com o banco de dados
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Modificação da consulta SQL para incluir um JOIN e trazer o Nome do Tipo de Pessoa
                    string query = @"
                SELECT 
                    p.Codigo, 
                    p.Fantasia, 
                    p.Destinatario, 
                    p.CNPJ_CPF, 
                    p.idEstrangeiroRG, 
                    tp.Nome AS TipoPessoa,  -- Agora traz o Nome da tabela tipopessoa
                    p.Razao
                FROM 
                    Pessoas p
                LEFT JOIN 
                    tipopessoa tp ON p.tipo_pessoa = tp.Id";  // Realiza o JOIN com a tabela tipopessoa

                    // Prepara o adaptador para preencher o DataTable
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    adapter.Fill(dt);

                    // Verifica se o DataTable tem dados
                    if (dt.Rows.Count > 0)
                    {
                        // Atribui o DataTable ao DataGridView
                        dgvPessoas.DataSource = dt;

                        // Modifica os nomes das colunas
                        dgvPessoas.Columns["Codigo"].HeaderText = "Código";
                        dgvPessoas.Columns["Fantasia"].HeaderText = "Fantasia";
                        dgvPessoas.Columns["Destinatario"].HeaderText = "Destinatário";
                        dgvPessoas.Columns["CNPJ_CPF"].HeaderText = "CNPJ / CPF";
                        dgvPessoas.Columns["idEstrangeiroRG"].HeaderText = "IE / RG";
                        dgvPessoas.Columns["TipoPessoa"].HeaderText = "Tipo de Pessoa";  // Exibe o nome do tipo de pessoa
                        dgvPessoas.Columns["Razao"].HeaderText = "Razão Social";

                        // Caso você queira ocultar alguma coluna (por exemplo, "idEstrangeiroRG"), pode fazer isso:
                        // dgvPessoas.Columns["idEstrangeiroRG"].Visible = false;

                        // Ajustando a largura da coluna "Tipo de Pessoa" para 150 pixels
                        dgvPessoas.Columns["TipoPessoa"].Width = 150;
                    }
                    else
                    {
                        // Caso não tenha dados, mostra uma mensagem
                        MessageBox.Show("Não há dados para exibir.");
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe a mensagem de erro
                MessageBox.Show("Erro ao atualizar a consulta: " + ex.Message);
            }
        }

        // Função que abre o formulário de cadastro
        private void AbrirFormularioCadastro(FrmCadastroPessoas frmCadastro)
        {
            frmCadastro.ShowDialog();
        }

        // Função para carregar o endereço da pessoa selecionada
        private void CarregarEndereco(string codigo, FrmCadastroPessoas frmCadastro)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para recuperar o primeiro endereço da pessoa
                    string queryEndereco = "SELECT * FROM Endereco WHERE end_idPessoa = @Codigo LIMIT 1";
                    using (MySqlCommand cmdEndereco = new MySqlCommand(queryEndereco, connection))
                    {
                        cmdEndereco.Parameters.AddWithValue("@Codigo", codigo);
                        MySqlDataReader reader = cmdEndereco.ExecuteReader();

                        if (reader.Read())
                        {
                            // Passa os dados de endereço para o formulário de cadastro
                            frmCadastro.Logradouro = reader["Logradouro"].ToString();
                            frmCadastro.Numero = reader["Numero"].ToString();
                            frmCadastro.Complemento = reader["Complemento"].ToString();
                            frmCadastro.Bairro = reader["Bairro"].ToString();
                            frmCadastro.Cidade = reader["Municipio"].ToString();
                            frmCadastro.UF = reader["UF"].ToString();
                            frmCadastro.Email = reader["Email"].ToString();
                            frmCadastro.CEP = reader["CEP"].ToString();
                            frmCadastro.Pais = reader["Pais"].ToString();
                            frmCadastro.Telefone = reader["Telefone"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o endereço: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função que confirma a exclusão do registro
        private void ConfirmarExclusao(string codigo)
        {
            DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir este registro?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                ExcluirRegistro(codigo);
            }
        }

        // Função para excluir o registro da pessoa e seu respectivo endereço
        private void ExcluirRegistro(string codigo)
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Excluir primeiro o endereço, caso haja algum
                    string queryEndereco = "DELETE FROM Endereco WHERE end_idPessoa = @Codigo";
                    using (MySqlCommand cmdEndereco = new MySqlCommand(queryEndereco, connection))
                    {
                        cmdEndereco.Parameters.AddWithValue("@Codigo", codigo);
                        cmdEndereco.ExecuteNonQuery();
                    }

                    // Agora excluir a pessoa
                    string queryPessoas = "DELETE FROM Pessoas WHERE Codigo = @Codigo";
                    using (MySqlCommand cmdPessoas = new MySqlCommand(queryPessoas, connection))
                    {
                        cmdPessoas.Parameters.AddWithValue("@Codigo", codigo);
                        int rowsAffected = cmdPessoas.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AtualizarConsulta();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi excluído. O código pode estar incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o registro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}