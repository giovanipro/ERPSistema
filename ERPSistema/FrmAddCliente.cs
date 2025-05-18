using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmAddCliente : Form
    {
        // Defina a string de conexão com o banco de dados MySQL
        private string connectionString = "Server=localhost;Database=database;Uid=root;";

        public FrmAddCliente()
        {
            InitializeComponent();
        }

        private void FrmAddCliente_Load(object sender, EventArgs e)
        {
            // Carregar os dados da tabela pessoas no DataGridView ao abrir o formulário
            CarregarDadosPessoas();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada no DataGridView
            if (dgvAddClientes.SelectedRows.Count > 0)
            {
                // Obtém o Codigo da linha selecionada
                int codigoCliente = Convert.ToInt32(dgvAddClientes.SelectedRows[0].Cells["Codigo"].Value);

                // Verifica se o formulário FrmCadastroVendas está aberto
                FrmCadastroVendas frmCadastroVendas = Application.OpenForms.OfType<FrmCadastroVendas>().FirstOrDefault();

                if (frmCadastroVendas != null)
                {
                    // Se o formulário FrmCadastroVendas estiver aberto, preenche o txtCliente com o Codigo
                    frmCadastroVendas.txtCliente.Text = codigoCliente.ToString();
                }
                else
                {
                    MessageBox.Show("Nenhum formulário de vendas está aberto.");
                }

                // Fecha o formulário FrmAddCliente após a seleção
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione uma linha para adicionar o Cliente.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento de mudança de texto no txtConsulta
        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtConsulta.Text.ToLower(); // Obtém o texto no campo de consulta e converte para minúsculo
            DataTable originalDataTable = dgvAddClientes.Tag as DataTable; // Recupera o DataTable original

            if (originalDataTable != null)
            {
                // Filtra as linhas da DataGridView com base no texto da consulta
                var filteredRows = originalDataTable.AsEnumerable()
                    .Where(row =>
                        row["Codigo"].ToString().ToLower().Contains(filtro) || // Filtra pelo Codigo
                        row["Fantasia"].ToString().ToLower().Contains(filtro) || // Filtra pela Fantasia
                        row["Destinatario"].ToString().ToLower().Contains(filtro) || // Filtra pelo Destinatario
                        row["CNPJ_CPF"].ToString().ToLower().Contains(filtro) || // Filtra pelo CNPJ_CPF
                        row["Razao"].ToString().ToLower().Contains(filtro) || // Filtra pela Razao
                        row["tipo_pessoa"].ToString().ToLower().Contains(filtro)) // Filtra pelo tipo_pessoa
                    .ToList(); // Converte para uma lista

                if (filteredRows.Any()) // Verifica se há resultados filtrados
                {
                    // Copia os dados filtrados para um novo DataTable
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    dgvAddClientes.DataSource = filteredDataTable; // Atualiza o DataSource do DataGridView
                }
                else
                {
                    // Se não houver resultados, limpa o DataGridView
                    dgvAddClientes.DataSource = null;
                }
            }
        }

        private void dgvAddClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma linha válida (ignorando a linha de cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Chama a função associada ao botão btnSelecionar
                btnSelecionar_Click(sender, e);
            }
        }

        private void CarregarDadosPessoas()
        {
            // Cria uma conexão com o banco de dados MySQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    conn.Open();

                    // Consulta SQL para buscar os dados da tabela pessoas
                    string query = "SELECT Codigo, Fantasia, Destinatario, CNPJ_CPF, idEstrangeiroRG, Razao, tipo_pessoa FROM pessoas";

                    // Cria um DataAdapter para executar a consulta e preencher um DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define o DataSource do DataGridView com o DataTable
                    dgvAddClientes.DataSource = dataTable;

                    // Armazenar o DataTable original para usar durante a filtragem
                    dgvAddClientes.Tag = dataTable;
                }
                catch (Exception ex)
                {
                    // Exibe um erro caso a conexão falhe ou ocorra algum problema
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }
    }
}