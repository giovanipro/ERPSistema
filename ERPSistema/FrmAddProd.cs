using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmAddProd : Form
    {
        // Defina a string de conexão com o banco de dados MySQL
        private string connectionString = "Server=localhost;Database=database;Uid=root;";
        public class Produto2Info
        {
            public decimal VlrVenda { get; set; }
            public decimal VlrDesconto { get; set; }
        }

        public FrmAddProd()
        {
            InitializeComponent();
        }

        private void FrmAddProd_Load(object sender, EventArgs e)
        {
            // Carregar os dados da tabela produto1 no DataGridView ao abrir o formulário
            CarregarDadosProdutos();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada no DataGridView
            if (dgvAddProd.SelectedRows.Count > 0)
            {
                // Obtém o Codigo do produto da linha selecionada
                int codigoProduto1 = Convert.ToInt32(dgvAddProd.SelectedRows[0].Cells["Codigo"].Value);

                // Obtém o Código de Barras da linha selecionada (assumindo que a coluna se chama "CodBarras")
                string codBarras = dgvAddProd.SelectedRows[0].Cells["CodBarras"].Value.ToString();

                // Busca as informações de produto2 relacionadas ao produto selecionado
                var produto2Info = BuscarProduto2Info(codigoProduto1);

                // Verifica se encontrou as informações do produto2
                if (produto2Info != null)
                {
                    // Verifica se o formulário FrmBaixaEstoque está aberto
                    FrmBaixaEstoque frmBaixaEstoque = Application.OpenForms.OfType<FrmBaixaEstoque>().FirstOrDefault();

                    if (frmBaixaEstoque != null)
                    {
                        // Preenche os campos do FrmBaixaEstoque com os dados buscados
                        frmBaixaEstoque.txtCodBarra.Text = codBarras;
                        frmBaixaEstoque.txtNome.Text = dgvAddProd.SelectedRows[0].Cells["NomeCompleto"].Value.ToString();
                        frmBaixaEstoque.txtQTD.Text = "1";
                        frmBaixaEstoque.txtVlrUnit.Text = produto2Info.VlrVenda.ToString("F2");  // Preenche com o VlrVenda formatado
                        frmBaixaEstoque.txtDesconto.Text = produto2Info.VlrDesconto.ToString("F2");  // Preenche com o VlrDesconto formatado
                        frmBaixaEstoque.txtQTD.Focus();
                    }

                    // Verifica se o formulário FrmCadastroVendas está aberto
                    FrmCadastroVendas frmCadastroVendas = Application.OpenForms.OfType<FrmCadastroVendas>().FirstOrDefault();

                    if (frmCadastroVendas != null)
                    {
                        // Preenche os campos do FrmCadastroVendas com os dados buscados
                        frmCadastroVendas.txtCodBarra.Text = codBarras;
                        frmCadastroVendas.txtNome.Text = dgvAddProd.SelectedRows[0].Cells["NomeCompleto"].Value.ToString();
                        frmCadastroVendas.txtQTD.Text = "1";
                        frmCadastroVendas.txtVlrUnit.Text = produto2Info.VlrVenda.ToString("F2");  // Preenche com o VlrVenda formatado
                        frmCadastroVendas.txtDesconto.Text = produto2Info.VlrDesconto.ToString("F2");  // Preenche com o VlrDesconto formatado
                        frmCadastroVendas.txtQTD.Focus();
                    }

                    // Fecha o formulário FrmAddProd após a seleção
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar as informações do produto na tabela produto2.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para adicionar.");
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
            DataTable originalDataTable = dgvAddProd.Tag as DataTable; // Recupera o DataTable original

            if (originalDataTable != null)
            {
                // Filtra as linhas da DataGridView com base no texto da consulta
                var filteredRows = originalDataTable.AsEnumerable()
                    .Where(row =>
                        row["Codigo"].ToString().ToLower().Contains(filtro) || // Filtra pelo Codigo
                        row["NomeCompleto"].ToString().ToLower().Contains(filtro) || // Filtra pelo NomeCompleto
                        row["CodBarras"].ToString().ToLower().Contains(filtro) ||  // Filtra pelo CodBarras
                        row["NomePopular"].ToString().ToLower().Contains(filtro) || // Filtra pelo NomePopular
                        row["Estoque"].ToString().ToLower().Contains(filtro) || // Filtra pelo Estoque
                        row["VlrVenda"].ToString().ToLower().Contains(filtro) || // Filtra pelo Codigo
                        row["NCM"].ToString().ToLower().Contains(filtro))
                    .ToList(); // Converte para uma lista

                if (filteredRows.Any()) // Verifica se há resultados filtrados
                {
                    // Copia os dados filtrados para um novo DataTable
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    dgvAddProd.DataSource = filteredDataTable; // Atualiza o DataSource do DataGridView
                }
                else
                {
                    // Se não houver resultados, limpa o DataGridView
                    dgvAddProd.DataSource = null;
                }
            }
        }

        private void dgvAddProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma linha válida (ignorando a linha de cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Chama a função associada ao botão btnSelecionar
                btnSelecionar_Click(sender, e);
            }
        }

        private void CarregarDadosProdutos()
        {
            // Cria uma conexão com o banco de dados MySQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    conn.Open();

                    // Consulta SQL com JOIN para buscar os dados das duas tabelas
                    string query = @"
                SELECT p1.Codigo, p1.CodBarras, p1.NomeCompleto, p1.NomePopular, p1.NCM, 
                       p2.Estoque, p2.VlrVenda
                FROM produto1 p1
                LEFT JOIN produto2 p2 ON p1.Codigo = p2.CodProduto1";

                    // Cria um DataAdapter para executar a consulta e preencher um DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define o DataSource do DataGridView com o DataTable
                    dgvAddProd.DataSource = dataTable;

                    // Altera o nome do cabeçalho da coluna 'VlrVenda' para 'Valor Venda'
                    dgvAddProd.Columns["VlrVenda"].HeaderText = "Valor Venda";

                    // Armazena o DataTable como um campo para fácil acesso durante a filtragem
                    dgvAddProd.Tag = dataTable;
                }
                catch (Exception ex)
                {
                    // Exibe um erro caso a conexão falhe ou ocorra algum problema
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }

        // Método para buscar as informações do produto na tabela produto2
        private Produto2Info BuscarProduto2Info(int codigoProduto1)
        {
            Produto2Info produtoInfo = new Produto2Info();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT VlrVenda, VlrDesconto FROM produto2 WHERE CodProduto1 = @CodProduto1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CodProduto1", codigoProduto1);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produtoInfo.VlrVenda = reader.GetDecimal("VlrVenda");
                            produtoInfo.VlrDesconto = reader.GetDecimal("VlrDesconto");
                        }
                        else
                        {
                            // Se não encontrar nenhum dado, retorna o objeto com valores padrão
                            produtoInfo = null;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return produtoInfo;
        }
    }
}