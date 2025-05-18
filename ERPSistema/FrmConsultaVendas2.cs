using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmConsultaVendas2 : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;"; // Substitua pela sua string de conexão
        private int codigoMovEstoque; // Variável para armazenar o CodigoMovEstoque passado

        public FrmConsultaVendas2(int codigoMovEstoque)
        {
            InitializeComponent();
            this.codigoMovEstoque = codigoMovEstoque; // Armazena o valor recebido
        }

        // Certifique-se de chamar esse método quando o formulário for carregado
        private void FrmConsultaVendas2_Load(object sender, EventArgs e)
        {
            // Carregar os dados na dgvConsultaVendas2 ao carregar o formulário
            CarregarMovEstoqueItem();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para carregar os dados no dgvConsultaVendas2 com base no CodigoMovEstoque
        public void CarregarMovEstoqueItem()
        {
            try
            {
                // Cria uma conexão com o banco de dados MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // Abre a conexão
                    conn.Open();

                    // Consulta SQL para buscar os dados da tabela mov_estoque_item com base no CodigoMovEstoque
                    string query = "SELECT * FROM mov_estoque_item WHERE CodigoMovEstoque = @CodigoMovEstoque";

                    // Cria um DataAdapter para executar a consulta e preencher um DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@CodigoMovEstoque", codigoMovEstoque);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    dataAdapter.Fill(dataTable);

                    // Adicionar a nova coluna "Nome do Produto"
                    dataTable.Columns.Add("Nome do Produto", typeof(string));

                    // Preencher a nova coluna "Nome do Produto" com os dados da tabela produto1
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int codItem = Convert.ToInt32(row["CodItem"]);

                        // Consultar o nome do produto na tabela produto1
                        string produtoQuery = "SELECT NomeCompleto FROM produto1 WHERE Codigo = @CodItem";
                        MySqlCommand cmdProduto = new MySqlCommand(produtoQuery, conn);
                        cmdProduto.Parameters.AddWithValue("@CodItem", codItem);

                        // Obter o nome do produto
                        object nomeProdutoResult = cmdProduto.ExecuteScalar();
                        string nomeProduto = nomeProdutoResult != DBNull.Value ? nomeProdutoResult.ToString() : string.Empty;

                        // Atribuir o nome do produto à nova coluna "Nome do Produto"
                        row["Nome do Produto"] = nomeProduto;
                    }

                    // Definir o DataSource do DataGridView com o DataTable
                    dgvConsultaVendas2.DataSource = dataTable;

                    // Reorganizar a ordem das colunas
                    dgvConsultaVendas2.Columns["Codigo"].DisplayIndex = 0;
                    dgvConsultaVendas2.Columns["CodigoMovEstoque"].DisplayIndex = 1;
                    dgvConsultaVendas2.Columns["Nome do Produto"].DisplayIndex = 2;
                    dgvConsultaVendas2.Columns["Quantidade"].DisplayIndex = 3;
                    dgvConsultaVendas2.Columns["VlrUnitario"].DisplayIndex = 4;
                    dgvConsultaVendas2.Columns["VlrDesconto"].DisplayIndex = 5;
                    dgvConsultaVendas2.Columns["VlrTotal"].DisplayIndex = 6;
                    dgvConsultaVendas2.Columns["Vendedor"].DisplayIndex = 7;
                    dgvConsultaVendas2.Columns["Cliente"].DisplayIndex = 8;
                    dgvConsultaVendas2.Columns["CodItem"].Visible = false;

                    // Ajuste automático de todas as colunas, exceto a "CodigoMovEstoque"
                    dgvConsultaVendas2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Ajustar a largura da coluna "Nome do Produto" para que ocupe o espaço disponível
                    dgvConsultaVendas2.Columns["Nome do Produto"].Width = 200;

                    // Ajustar a largura da coluna "Codigo"
                    dgvConsultaVendas2.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Para a coluna "CodigoMovEstoque", não aplicar AutoSize. Configurar a largura fixa.
                    dgvConsultaVendas2.Columns["CodigoMovEstoque"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvConsultaVendas2.Columns["CodigoMovEstoque"].Width = 100; // Defina um valor fixo de largura, por exemplo, 100px

                    // Alterar os nomes das colunas
                    dgvConsultaVendas2.Columns["VlrUnitario"].HeaderText = "Valor Unitário";
                    dgvConsultaVendas2.Columns["VlrDesconto"].HeaderText = "Desconto";
                    dgvConsultaVendas2.Columns["VlrTotal"].HeaderText = "Total";
                }
            }
            catch (Exception ex)
            {
                // Exibe um erro caso a conexão falhe ou ocorra algum problema
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }
    }
}