using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmCadastroProdutos : Form
    {
        private int lastSavedProductId = 0; // Para armazenar o ID do último produto salvo
        private bool isNewProduct = false;  // Flag para verificar se é um novo produto
        private FrmConsultaProdutos frmConsulta;
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        public FrmCadastroProdutos(FrmConsultaProdutos consultaForm)
        {
            InitializeComponent();
            this.frmConsulta = consultaForm;
        }

        private void FrmCadastroProdutos_Load(object sender, EventArgs e)
        {
            // Torna o campo txtID não editável
            txtID.ReadOnly = true;
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                int codigoProduto1 = Convert.ToInt32(txtID.Text);  // Ou use o código passado ao formulário
                CarregarProduto2(codigoProduto1);
            }
        }

        private void FrmCadastroProdutos_Shown(object sender, EventArgs e)
        {
            // Dá o foco ao campo txtProduto depois que o formulário foi totalmente exibido
            txtProduto.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Verificar se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrEmpty(txtProduto.Text) || string.IsNullOrEmpty(txtCodBarra.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            // Obter os dados dos campos
            string produto = txtProduto.Text;
            string popular = txtPopular.Text;
            string ncm = txtNCM.Text;
            string codBarra = txtCodBarra.Text;
            int codigo = string.IsNullOrEmpty(txtID.Text) ? 0 : int.Parse(txtID.Text);  // Se o ID estiver vazio, será considerado 0 (novo produto)

            // Dados para a tabela produto2
            decimal vlrCustoIni = string.IsNullOrEmpty(txtInicial.Text) ? 0 : decimal.Parse(txtInicial.Text);
            decimal vlrCustoEnt = string.IsNullOrEmpty(txtEntrada.Text) ? 0 : decimal.Parse(txtEntrada.Text);
            decimal vlrVenda = string.IsNullOrEmpty(txtVenda.Text) ? 0 : decimal.Parse(txtVenda.Text);

            // Verificação para garantir que txtEstoque contém um valor válido
            int estoque = 0;
            if (string.IsNullOrEmpty(txtEstoque.Text) || !int.TryParse(txtEstoque.Text, out estoque))
            {
                MessageBox.Show("Por favor, informe um valor válido para o estoque.");
                return;
            }

            decimal vlrDesconto = string.IsNullOrEmpty(txtDesconto.Text) ? 0 : decimal.Parse(txtDesconto.Text);  // VlrDesconto

            int filial = 1; // Vamos assumir que a filial é 1, mas pode ser alterado conforme sua lógica

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Verificar se o produto com o mesmo CodBarras já existe, **ignorando o produto atual** (somente para novo produto)
                    string checkQuery = "SELECT COUNT(*) FROM produto1 WHERE CodBarras = @CodBarras AND Codigo != @Codigo";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@CodBarras", codBarra);
                    checkCmd.Parameters.AddWithValue("@Codigo", codigo); // Ignorar o produto atual (caso de edição)

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Produto com este código de barras já existe.");
                        return;
                    }

                    if (codigo == 0) // Caso seja um novo produto (sem ID)
                    {
                        // Salvar um novo produto na tabela produto1
                        string insertQuery = "INSERT INTO produto1 (NomeCompleto, NomePopular, NCM, CodBarras) VALUES (@NomeCompleto, @NomePopular, @NCM, @CodBarras)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@NomeCompleto", produto);
                        insertCmd.Parameters.AddWithValue("@NomePopular", popular);
                        insertCmd.Parameters.AddWithValue("@NCM", ncm);
                        insertCmd.Parameters.AddWithValue("@CodBarras", codBarra);

                        insertCmd.ExecuteNonQuery();

                        // Obter o ID do último produto inserido
                        int newProductId = (int)insertCmd.LastInsertedId;

                        // Atualizar o txtID com o novo ID do produto
                        txtID.Text = newProductId.ToString();

                        // Verificar se o produto já existe na tabela produto2
                        string checkProduto2Query = "SELECT COUNT(*) FROM produto2 WHERE CodProduto1 = @CodProduto1 AND Filial = @Filial";
                        MySqlCommand checkProduto2Cmd = new MySqlCommand(checkProduto2Query, conn);
                        checkProduto2Cmd.Parameters.AddWithValue("@CodProduto1", newProductId);
                        checkProduto2Cmd.Parameters.AddWithValue("@Filial", filial);

                        int produto2Count = Convert.ToInt32(checkProduto2Cmd.ExecuteScalar());

                        if (produto2Count == 0) // Se não houver, insere na tabela produto2
                        {
                            string insertProduto2Query = "INSERT INTO produto2 (CodProduto1, VlrCustoIni, VlrCustoEnt, VlrVenda, Filial, Estoque, VlrDesconto) " +
                                                         "VALUES (@CodProduto1, @VlrCustoIni, @VlrCustoEnt, @VlrVenda, @Filial, @Estoque, @VlrDesconto)";
                            MySqlCommand insertProduto2Cmd = new MySqlCommand(insertProduto2Query, conn);
                            insertProduto2Cmd.Parameters.AddWithValue("@CodProduto1", newProductId);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrCustoIni", vlrCustoIni);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrCustoEnt", vlrCustoEnt);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrVenda", vlrVenda);
                            insertProduto2Cmd.Parameters.AddWithValue("@Filial", filial);
                            insertProduto2Cmd.Parameters.AddWithValue("@Estoque", estoque);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrDesconto", vlrDesconto);

                            insertProduto2Cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Produto cadastrado com sucesso!");
                    }
                    else
                    {
                        // Caso seja um produto já existente, vamos atualizar a tabela produto1
                        string updateQuery = "UPDATE produto1 SET NomeCompleto = @NomeCompleto, NomePopular = @NomePopular, NCM = @NCM, CodBarras = @CodBarras WHERE Codigo = @Codigo";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@Codigo", codigo);
                        updateCmd.Parameters.AddWithValue("@NomeCompleto", produto);
                        updateCmd.Parameters.AddWithValue("@NomePopular", popular);
                        updateCmd.Parameters.AddWithValue("@NCM", ncm);
                        updateCmd.Parameters.AddWithValue("@CodBarras", codBarra);

                        updateCmd.ExecuteNonQuery();

                        // Verificar se o produto já existe na tabela produto2
                        string checkProduto2Query = "SELECT COUNT(*) FROM produto2 WHERE CodProduto1 = @CodProduto1 AND Filial = @Filial";
                        MySqlCommand checkProduto2Cmd = new MySqlCommand(checkProduto2Query, conn);
                        checkProduto2Cmd.Parameters.AddWithValue("@CodProduto1", codigo);
                        checkProduto2Cmd.Parameters.AddWithValue("@Filial", filial);

                        int produto2Count = Convert.ToInt32(checkProduto2Cmd.ExecuteScalar());

                        if (produto2Count == 0) // Se não houver, insere na tabela produto2
                        {
                            string insertProduto2Query = "INSERT INTO produto2 (CodProduto1, VlrCustoIni, VlrCustoEnt, VlrVenda, Filial, Estoque, VlrDesconto) " +
                                                         "VALUES (@CodProduto1, @VlrCustoIni, @VlrCustoEnt, @VlrVenda, @Filial, @Estoque, @VlrDesconto)";
                            MySqlCommand insertProduto2Cmd = new MySqlCommand(insertProduto2Query, conn);
                            insertProduto2Cmd.Parameters.AddWithValue("@CodProduto1", codigo);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrCustoIni", vlrCustoIni);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrCustoEnt", vlrCustoEnt);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrVenda", vlrVenda);
                            insertProduto2Cmd.Parameters.AddWithValue("@Filial", filial);
                            insertProduto2Cmd.Parameters.AddWithValue("@Estoque", estoque);
                            insertProduto2Cmd.Parameters.AddWithValue("@VlrDesconto", vlrDesconto);

                            insertProduto2Cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Caso o produto já exista na tabela produto2, faz a atualização
                            string updateProduto2Query = "UPDATE produto2 SET VlrCustoIni = @VlrCustoIni, VlrCustoEnt = @VlrCustoEnt, VlrVenda = @VlrVenda, Estoque = @Estoque, VlrDesconto = @VlrDesconto WHERE CodProduto1 = @CodProduto1 AND Filial = @Filial";
                            MySqlCommand updateProduto2Cmd = new MySqlCommand(updateProduto2Query, conn);
                            updateProduto2Cmd.Parameters.AddWithValue("@CodProduto1", codigo);
                            updateProduto2Cmd.Parameters.AddWithValue("@VlrCustoIni", vlrCustoIni);
                            updateProduto2Cmd.Parameters.AddWithValue("@VlrCustoEnt", vlrCustoEnt);
                            updateProduto2Cmd.Parameters.AddWithValue("@VlrVenda", vlrVenda);
                            updateProduto2Cmd.Parameters.AddWithValue("@Filial", filial);
                            updateProduto2Cmd.Parameters.AddWithValue("@Estoque", estoque);
                            updateProduto2Cmd.Parameters.AddWithValue("@VlrDesconto", vlrDesconto);

                            updateProduto2Cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Produto atualizado com sucesso!");
                    }

                    // Recarregar os produtos na DataGridView
                    frmConsulta.CarregarProdutos();
                    txtProduto.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar os dados: " + ex.Message);
                }
            }
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            // Limpar todos os campos
            txtID.Clear();
            txtProduto.Clear();
            txtPopular.Clear();
            txtNCM.Clear();
            txtCodBarra.Clear();
            txtInicial.Clear();
            txtEntrada.Clear();
            txtVenda.Clear();
            txtEstoque.Clear();

            // Dar foco no campo txtProduto
            txtProduto.Focus();

            // Setar a flag para indicar que o cadastro é novo
            isNewProduct = true;
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha o formulário
        }

        // Método para preencher os campos do formulário
        public void PreencherCampos(int codigo, string produto, string popular, string ncm, string codBarra)
        {
            txtID.Text = codigo.ToString();  // Preenche o campo txtID (Codigo)
            txtProduto.Text = produto;
            txtPopular.Text = popular;
            txtNCM.Text = ncm;
            txtCodBarra.Text = codBarra;
        }

        private void CarregarUltimoProduto()
        {
            if (!isNewProduct) return; // Não carregar se não for um novo produto

            // Carregar o último produto salvo do banco e preencher os campos
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL para pegar o último produto inserido
                    string query = "SELECT Codigo, NomeCompleto, NomePopular, NCM, CodBarras FROM produto1 ORDER BY Codigo DESC LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Preencher os campos com os dados do último produto
                        txtID.Text = reader["Codigo"].ToString();
                        txtProduto.Text = reader["NomeCompleto"].ToString();
                        txtPopular.Text = reader["NomePopular"].ToString();
                        txtNCM.Text = reader["NCM"].ToString();
                        txtCodBarra.Text = reader["CodBarras"].ToString();

                        // Atualizar o ID do último produto salvo
                        lastSavedProductId = Convert.ToInt32(reader["Codigo"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar o último produto: " + ex.Message);
                }
            }
        }
        public void PreencherCamposAdicionais(decimal vlrCustoIni, decimal vlrCustoEnt, decimal vlrVenda, int estoque)
        {
            // Preencher os valores de custo e venda
            txtInicial.Text = vlrCustoIni.ToString("F2");
            txtEntrada.Text = vlrCustoEnt.ToString("F2");
            txtVenda.Text = vlrVenda.ToString("F2");

            // Preencher o campo de estoque
            txtEstoque.Text = estoque.ToString();
        }

        private void CarregarProduto2(int codigoProduto1)
        {
            decimal vlrCustoIni = 0, vlrCustoEnt = 0, vlrVenda = 0;
            int estoque = 0;
            decimal vlrDesconto = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta para buscar os dados de custo, venda, estoque e desconto na tabela produto2
                    string query = "SELECT VlrCustoIni, VlrCustoEnt, VlrVenda, Estoque, VlrDesconto " +
                                   "FROM produto2 WHERE CodProduto1 = @Codigo LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Codigo", codigoProduto1);  // Utilizando o Codigo do produto1

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Carregar os valores de custo, venda e estoque
                            vlrCustoIni = reader.GetDecimal("VlrCustoIni");
                            vlrCustoEnt = reader.GetDecimal("VlrCustoEnt");
                            vlrVenda = reader.GetDecimal("VlrVenda");

                            // Carregar as informações de estoque
                            estoque = reader.GetInt32("Estoque");

                            vlrDesconto = reader.IsDBNull(reader.GetOrdinal("VlrDesconto")) ? 0 : reader.GetDecimal("VlrDesconto");
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado na tabela produto2.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar dados adicionais do produto: " + ex.Message);
                    return;
                }
            }

            // Passar os valores de custo, venda, estoque e desconto para os campos do formulário
            PreencherCamposAdicionais(vlrCustoIni, vlrCustoEnt, vlrVenda, estoque);

            // Preencher o campo txtDesconto
            txtDesconto.Text = vlrDesconto.ToString("F2");
        }
    }
}
