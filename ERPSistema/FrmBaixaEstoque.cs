using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmBaixaEstoque : Form
    {
        private FrmConsultaProdutos frmConsulta;
        public FrmBaixaEstoque(FrmConsultaProdutos consultaForm)
        {
            InitializeComponent();
            this.frmConsulta = consultaForm;
        }

        private void FrmBaixaEstoque_Load(object sender, EventArgs e)
        {
            // Definindo as colunas do DataGridView programaticamente, caso ainda não tenha sido feito
            if (dgvBaixaEstoque.Columns.Count == 0)
            {
                dgvBaixaEstoque.Columns.Add("CodBarras", "Código de Barras");
                dgvBaixaEstoque.Columns.Add("Nome", "Nome do Produto");
                dgvBaixaEstoque.Columns.Add("Quantidade", "Quantidade");
                dgvBaixaEstoque.Columns.Add("VlrUnit", "Valor Unitário");
                dgvBaixaEstoque.Columns.Add("VlrDesconto", "Valor Desconto");
                dgvBaixaEstoque.Columns.Add("VlrSubTotal", "Sub Total");
                dgvBaixaEstoque.Columns.Add("Operacao", "Operação"); // Nova coluna para registrar a operação

                // Se necessário, você pode também configurar o tipo de coluna
                dgvBaixaEstoque.Columns["VlrUnit"].DefaultCellStyle.Format = "C2";  // Formatar como moeda
                dgvBaixaEstoque.Columns["VlrDesconto"].DefaultCellStyle.Format = "C2";  // Formatar como moeda
                dgvBaixaEstoque.Columns["VlrSubTotal"].DefaultCellStyle.Format = "C2";  // Formatar como moeda

                dgvBaixaEstoque.Columns["CodBarras"].Width = 250;
                dgvBaixaEstoque.Columns["Nome"].Width = 250;
            }

            // Carregar opções no ComboBox
            cmbOperacao.Items.Add("Adicionar");
            cmbOperacao.Items.Add("Remover");
            cmbOperacao.SelectedIndex = 0; // Set default to "Adicionar"

            txtCodBarra.Focus();
        }

        private void FrmBaixaEstoque_Shown(object sender, EventArgs e)
        {
            txtCodBarra.Focus();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            FrmAddProd frmAddProd = new FrmAddProd();
            frmAddProd.ShowDialog();
            txtQTD.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Definir os valores das variáveis
            string codBarras = txtCodBarra.Text;
            string nome = txtNome.Text;

            int quantidade;
            if (!int.TryParse(txtQTD.Text, out quantidade)) // Verificar se a quantidade é um número válido
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            decimal vlrUnit;
            if (!decimal.TryParse(txtVlrUnit.Text, out vlrUnit)) // Verificar se o valor unitário é válido
            {
                MessageBox.Show("Valor unitário inválido.");
                return;
            }

            decimal vlrDesconto;
            if (!decimal.TryParse(txtDesconto.Text, out vlrDesconto)) // Verificar se o valor de desconto é válido
            {
                MessageBox.Show("Valor de desconto inválido.");
                return;
            }

            // Cálculo do valor subtotal
            decimal vlrSubTotal = (vlrUnit * quantidade) - (vlrDesconto * quantidade); // Subtotal considerando o desconto

            string operacao = cmbOperacao.SelectedItem.ToString(); // Captura a operação selecionada no ComboBox

            // Conectar ao banco de dados
            string connectionString = "server=localhost;database=database;uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Atualizar o estoque na tabela produto2
                    string updateQuery = @"
UPDATE produto2
SET Estoque = Estoque ";

                    // Se a operação for "Adicionar", somar, se for "Remover", subtrair
                    if (operacao == "Adicionar")
                    {
                        updateQuery += "+ @Quantidade ";
                    }
                    else
                    {
                        updateQuery += "- @Quantidade ";
                    }

                    updateQuery += "WHERE CodProduto1 = (SELECT Codigo FROM produto1 WHERE CodBarras = @CodBarras)";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    updateCmd.Parameters.AddWithValue("@CodBarras", codBarras);
                    updateCmd.ExecuteNonQuery(); // Executa a atualização no banco de dados

                    bool produtoExistente = false;
                    bool operacaoRemoverExistente = false; // Variável para verificar se já existe a operação Remover
                    bool operacaoAdicionarExistente = false; // Variável para verificar se já existe a operação Adicionar

                    foreach (DataGridViewRow row in dgvBaixaEstoque.Rows)
                    {
                        if (row.Cells["CodBarras"].Value != null && row.Cells["CodBarras"].Value.ToString() == codBarras)
                        {
                            if (operacao == "Remover")
                            {
                                // Verifica se já existe a operação Remover
                                if (row.Cells["Operacao"].Value.ToString() == "Remover")
                                {
                                    // Se já existe a operação Remover, atualize a linha
                                    int qtdExistente = Convert.ToInt32(row.Cells["Quantidade"].Value);
                                    decimal novoSubTotal = (vlrUnit * (qtdExistente + quantidade)) - (vlrDesconto * (qtdExistente + quantidade));
                                    row.Cells["VlrSubTotal"].Value = novoSubTotal.ToString("C");

                                    decimal novoDescontoTotal = vlrDesconto * (qtdExistente + quantidade);
                                    row.Cells["VlrDesconto"].Value = novoDescontoTotal.ToString("C");

                                    row.Cells["Quantidade"].Value = qtdExistente + quantidade;
                                    row.Cells["Operacao"].Value = operacao;

                                    operacaoRemoverExistente = true; // Marca que a operação Remover já existe
                                    break; // Saímos do loop
                                }
                            }
                            else if (operacao == "Adicionar")
                            {
                                // Se a operação for Adicionar, verifique se já existe uma linha com a operação Adicionar
                                if (row.Cells["Operacao"].Value.ToString() == "Adicionar")
                                {
                                    // Se já existe a operação Adicionar, atualize a linha
                                    int qtdExistente = Convert.ToInt32(row.Cells["Quantidade"].Value);
                                    decimal novoSubTotal = (vlrUnit * (qtdExistente + quantidade)) - (vlrDesconto * (qtdExistente + quantidade));
                                    row.Cells["VlrSubTotal"].Value = novoSubTotal.ToString("C");

                                    decimal novoDescontoTotal = vlrDesconto * (qtdExistente + quantidade);
                                    row.Cells["VlrDesconto"].Value = novoDescontoTotal.ToString("C");

                                    row.Cells["Quantidade"].Value = qtdExistente + quantidade;
                                    row.Cells["Operacao"].Value = operacao;

                                    operacaoAdicionarExistente = true; // Marca que a operação Adicionar já existe
                                    break; // Saímos do loop
                                }
                            }
                        }
                    }

                    // Se a operação for "Remover" e não existir, adiciona uma nova linha
                    if (operacao == "Remover" && !operacaoRemoverExistente)
                    {
                        dgvBaixaEstoque.Rows.Add(
                            codBarras,
                            nome,
                            quantidade,
                            vlrUnit.ToString("C"),  // Formata como moeda
                            vlrDesconto.ToString("C"),  // Formata como moeda
                            vlrSubTotal.ToString("C"),  // Formata como moeda para o novo subtotal
                            operacao // Adiciona a operação à nova linha
                        );
                    }

                    // Se a operação for "Adicionar" e o produto não existir, adiciona uma nova linha
                    if (!operacaoAdicionarExistente && operacao == "Adicionar")
                    {
                        dgvBaixaEstoque.Rows.Add(
                            codBarras,
                            nome,
                            quantidade,
                            vlrUnit.ToString("C"),  // Formata como moeda
                            vlrDesconto.ToString("C"),  // Formata como moeda
                            vlrSubTotal.ToString("C"),  // Formata como moeda para o novo subtotal
                            operacao // Adiciona a operação à nova linha
                        );
                    }

                    // Atualizar o lblSubTotal com a soma de todos os VlrSubTotal
                    decimal totalSubTotal = 0;

                    foreach (DataGridViewRow row in dgvBaixaEstoque.Rows)
                    {
                        if (row.Cells["VlrSubTotal"].Value != null)
                        {
                            // Pegar o valor da célula como string
                            string cellValue = row.Cells["VlrSubTotal"].Value.ToString();

                            // Remover qualquer símbolo de moeda e espaços em branco usando uma expressão regular
                            string numericValue = System.Text.RegularExpressions.Regex.Replace(cellValue, @"[^\d,.-]", "");

                            // Tentar converter a string limpa para decimal
                            decimal subTotal;
                            if (decimal.TryParse(numericValue, out subTotal))
                            {
                                totalSubTotal += subTotal;
                            }
                            else
                            {
                                MessageBox.Show("Valor inválido encontrado em VlrSubTotal.");
                            }
                        }
                    }

                    lblSubTotal.Text = totalSubTotal.ToString("C");

                    frmConsulta.CarregarProdutos();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar: " + ex.Message);
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodBarra_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifique se a tecla pressionada é ENTER
            if (e.KeyCode == Keys.Enter)
            {
                // Conecte-se ao banco de dados
                string connectionString = "server=localhost;database=database;uid=root;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Defina a query SQL para pegar os dados
                        string query = @"
                            SELECT p1.NomeCompleto, p2.VlrVenda, p2.VlrDesconto
                            FROM produto1 p1
                            JOIN produto2 p2 ON p1.Codigo = p2.CodProduto1
                            WHERE p1.CodBarras = @CodBarras
                        ";

                        // Crie o comando e adicione o parâmetro do código de barras
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CodBarras", txtCodBarra.Text);

                        // Execute a consulta e obtenha os dados
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Se houver algum resultado
                            {
                                // Preencha os campos com os dados
                                txtNome.Text = reader["NomeCompleto"].ToString();
                                txtQTD.Text = "1";
                                txtVlrUnit.Text = reader["VlrVenda"].ToString();
                                txtDesconto.Text = reader["VlrDesconto"].ToString();  // Preenchendo o campo de desconto

                                txtQTD.Focus();
                            }
                            else
                            {
                                // Caso o código de barras não seja encontrado
                                MessageBox.Show("Produto não encontrado.");
                                txtNome.Clear();
                                txtQTD.Clear();
                                txtVlrUnit.Clear();
                                txtDesconto.Clear();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar dados: " + ex.Message);
                    }
                }
            }
        }

        private void txtQTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chama o evento do botão btnSalvar
                btnSalvar_Click(sender, e);
            }
        }

        // Método para limpar os campos de texto
        private void LimparCampos()
        {
            txtCodBarra.Clear();
            txtNome.Clear();
            txtQTD.Clear();
            txtVlrUnit.Clear();
            txtDesconto.Clear();
        }
    }
}