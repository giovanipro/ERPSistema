using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // Adicione esta referência

namespace ERPSistema
{
    public partial class FrmConsultaProdutos : Form
    {
        // String de conexão com o banco de dados (substitua pelos seus detalhes reais)
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        public FrmConsultaProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void btnBaixaEstoque_Click(object sender, EventArgs e)
        {
            FrmBaixaEstoque frmBaixaEstoque = new FrmBaixaEstoque(this);
            frmBaixaEstoque.ShowDialog();
        }

        // Exemplo de como abrir o FrmCadastroProdutos a partir de FrmConsultaProdutos
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells["Codigo"].Value);
                string produto = dgvProdutos.SelectedRows[0].Cells["NomeCompleto"].Value.ToString();
                string popular = dgvProdutos.SelectedRows[0].Cells["NomePopular"].Value.ToString();
                string ncm = dgvProdutos.SelectedRows[0].Cells["NCM"].Value.ToString();
                string codBarra = dgvProdutos.SelectedRows[0].Cells["CodBarras"].Value.ToString();

                // Criar o formulário de cadastro e preencher os campos
                FrmCadastroProdutos frmCadastroProdutos = new FrmCadastroProdutos(this);
                frmCadastroProdutos.PreencherCampos(codigo, produto, popular, ncm, codBarra);

                // Exibir o formulário de edição
                frmCadastroProdutos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto para editar.");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos frmCadastroProdutos = new FrmCadastroProdutos(this);
            frmCadastroProdutos.ShowDialog();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                int codigo = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells["Codigo"].Value);

                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir o produto?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            string deleteProduto2Query = "DELETE FROM produto2 WHERE CodProduto1 = @Codigo";
                            MySqlCommand deleteProduto2Cmd = new MySqlCommand(deleteProduto2Query, conn);
                            deleteProduto2Cmd.Parameters.AddWithValue("@Codigo", codigo);

                            deleteProduto2Cmd.ExecuteNonQuery();

                            string deleteProduto1Query = "DELETE FROM produto1 WHERE Codigo = @Codigo";
                            MySqlCommand deleteProduto1Cmd = new MySqlCommand(deleteProduto1Query, conn);
                            deleteProduto1Cmd.Parameters.AddWithValue("@Codigo", codigo);

                            deleteProduto1Cmd.ExecuteNonQuery();

                            MessageBox.Show("Produto excluído com sucesso!");

                            CarregarProdutos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao excluir o produto: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto para excluir.");
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtConsulta.Text.ToLower(); // Converte a consulta para minúscula

            // Percorrer todas as linhas do DataGridView
            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                try
                {
                    // Verifica se a linha não é a linha de novo item
                    if (!row.IsNewRow)
                    {
                        bool isMatch = row.Cells["Codigo"].Value.ToString().ToLower().Contains(searchValue) ||
                                       row.Cells["CodBarras"].Value.ToString().ToLower().Contains(searchValue) ||
                                       row.Cells["NomeCompleto"].Value.ToString().ToLower().Contains(searchValue) ||
                                       row.Cells["NomePopular"].Value.ToString().ToLower().Contains(searchValue) ||
                                       row.Cells["Estoque"].Value.ToString().ToLower().Contains(searchValue) ||
                                       row.Cells["NCM"].Value.ToString().ToLower().Contains(searchValue);

                        // Se encontrar correspondência, exibe a linha; caso contrário, oculta a linha
                        row.Visible = isMatch;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    // Você pode registrar o erro ou apenas ignorá-lo se a linha não puder ser ocultada
                    Console.WriteLine($"Erro ao alterar visibilidade da linha: {ex.Message}");
                }
            }
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma linha válida (ignora a primeira linha que é a de cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Aqui você chama a função associada ao botão btnEditar
                btnEditar_Click(sender, e);
            }
        }

        public void CarregarProdutos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Codigo, CodBarras, NomeCompleto, NomePopular, NCM, " +
                                   "(SELECT Estoque FROM produto2 WHERE CodProduto1 = produto1.Codigo LIMIT 1) AS Estoque " +
                                   "FROM produto1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    dgvProdutos.DataSource = dataTable;

                    dgvProdutos.Columns["CodBarras"].HeaderText = "Cod. Barra";
                    dgvProdutos.Columns["NomeCompleto"].HeaderText = "Produto";
                    dgvProdutos.Columns["NomePopular"].HeaderText = "Nome Popular";
                    dgvProdutos.Columns["Estoque"].HeaderText = "Estoque";

                    // Ajustando largura das colunas
                    dgvProdutos.Columns["NomeCompleto"].Width = 300;
                    dgvProdutos.Columns["NomePopular"].Width = 300;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }
    }
}
