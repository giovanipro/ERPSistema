using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmConsultaVendas : Form
    {
        // Defina a string de conexão com o banco de dados MySQL
        private string connectionString = "Server=localhost;Database=database;Uid=root;";
        private int codigoMovEstoque;

        public FrmConsultaVendas(int codigoMovEstoque)
        {
            InitializeComponent();
            this.codigoMovEstoque = codigoMovEstoque;
        }

        private void FrmConsultaVendas_Load(object sender, EventArgs e)
        {
            // Chama o método para carregar os dados
            CarregarDadosMovEstoque();
            txtConsulta.Focus();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            // Verifica se há uma linha selecionada
            if (dgvConsultaVendas.SelectedRows.Count > 0)
            {
                // Pega o valor do Código da linha selecionada
                int codigoMovEstoque = Convert.ToInt32(dgvConsultaVendas.SelectedRows[0].Cells["Codigo"].Value);

                // Cria e exibe o FrmConsultaVendas2, passando o valor do CodigoMovEstoque
                FrmConsultaVendas2 frmConsultaVendas2 = new FrmConsultaVendas2(codigoMovEstoque);
                frmConsultaVendas2.Show();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há alguma linha selecionada no DataGridView
                if (dgvConsultaVendas.SelectedRows.Count > 0)
                {
                    // Obtém o Codigo da linha selecionada
                    int codigoMovEstoque = Convert.ToInt32(dgvConsultaVendas.SelectedRows[0].Cells["Codigo"].Value);

                    // Cria a consulta SQL para deletar o registro
                    string deleteQuery = "DELETE FROM mov_estoque WHERE Codigo = @Codigo";

                    // Conecta ao banco de dados
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@Codigo", codigoMovEstoque);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    // Atualiza o DataGridView após a exclusão
                    CarregarDadosMovEstoque();

                    MessageBox.Show("Registro deletado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para deletar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar o registro: " + ex.Message);
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o campo txtConsulta não está vazio
            string searchText = txtConsulta.Text.Trim();

            // Cria um filtro baseado no texto da consulta
            if (!string.IsNullOrEmpty(searchText))
            {
                // Cria uma expressão de filtro para procurar nas colunas, "Data", "Hora", "VlrDesconto" ou "VlrTotal"
                // Convertendo Data, Hora, VlrDesconto e VlrTotal para string para poder aplicar o LIKE
                string filterExpression = "CONVERT(Data, 'System.String') LIKE '%" + searchText + "%' OR " +
                                          "CONVERT(Hora, 'System.String') LIKE '%" + searchText + "%' OR " +
                                          "CONVERT(Desconto, 'System.String') LIKE '%" + searchText + "%' OR " +
                                          "CONVERT(Total, 'System.String') LIKE '%" + searchText + "%'";

                // Filtra os dados da tabela com base na expressão
                DataTable dataTable = (DataTable)dgvConsultaVendas.DataSource;
                DataRow[] filteredRows = dataTable.Select(filterExpression);

                // Cria um novo DataTable com os resultados filtrados
                DataTable filteredDataTable = dataTable.Clone(); // Cria uma cópia da estrutura original da tabela
                foreach (DataRow row in filteredRows)
                {
                    filteredDataTable.ImportRow(row); // Adiciona as linhas filtradas ao novo DataTable
                }

                // Define o novo DataTable como o DataSource do DataGridView
                dgvConsultaVendas.DataSource = filteredDataTable;
            }
            else
            {
                // Caso o campo de pesquisa esteja vazio, recarrega todos os dados
                CarregarDadosMovEstoque();
            }
        }

        private void dgvConsultaVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma linha válida
            if (e.RowIndex >= 0)
            {
                // A lógica do botão btnExibir será chamada aqui
                btnExibir_Click(sender, e);
            }
        }

        // Função para carregar os dados da tabela mov_estoque no DataGridView
        public void CarregarDadosMovEstoque()
        {
            // Cria uma conexão com o banco de dados MySQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    conn.Open();

                    // Consulta SQL para buscar os dados da tabela mov_estoque, ordenando pela Data e Hora de forma decrescente
                    string query = "SELECT Codigo, Data, Hora, VlrDesconto, VlrTotal, VlrSubTotal FROM mov_estoque ORDER BY Data DESC, Hora DESC";

                    // Cria um DataAdapter para executar a consulta e preencher um DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    dataAdapter.Fill(dataTable);

                    // Renomeia as colunas
                    dataTable.Columns["VlrTotal"].ColumnName = "Total";
                    dataTable.Columns["VlrDesconto"].ColumnName = "Desconto";
                    dataTable.Columns["VlrSubTotal"].ColumnName = "SubTotal";

                    // Define o DataSource do DataGridView com o DataTable
                    dgvConsultaVendas.DataSource = dataTable;

                    // Organiza as colunas na sequência desejada: Codigo, Data, Hora, Total, Desconto, SubTotal
                    dgvConsultaVendas.Columns["Codigo"].DisplayIndex = 0;
                    dgvConsultaVendas.Columns["Data"].DisplayIndex = 1;
                    dgvConsultaVendas.Columns["Hora"].DisplayIndex = 2;
                    dgvConsultaVendas.Columns["Total"].DisplayIndex = 3;
                    dgvConsultaVendas.Columns["Desconto"].DisplayIndex = 4;
                    dgvConsultaVendas.Columns["SubTotal"].DisplayIndex = 5;
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