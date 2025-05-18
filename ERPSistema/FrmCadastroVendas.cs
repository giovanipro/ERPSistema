using System;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmCadastroVendas : Form
    {
        // Defina a string de conexão com o banco de dados MySQL
        private string connectionString = "Server=localhost;Database=database;Uid=root;";
        private int codigoMovEstoque;

        public FrmCadastroVendas(int codigoMovEstoque)
        {
            InitializeComponent();
            this.codigoMovEstoque = codigoMovEstoque; // Armazene o código para usar nas consultas
        }

        private void FrmCadastroVendas_Load(object sender, EventArgs e)
        {
            txtVendedor.Focus();
        }

        // Abrir o FrmAddCliente ao clicar no btnAddCliente
        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            FrmAddCliente frmAddCliente = new FrmAddCliente();
            frmAddCliente.ShowDialog();
            txtCodBarra.Focus();
        }

        // Abrir o FrmAddProd ao clicar no btnAddProd
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            FrmAddProd frmAddProd = new FrmAddProd();
            frmAddProd.ShowDialog();
            txtQTD.Focus();
        }

        // Salvar dados no banco de dados ao clicar no btnSalvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrEmpty(txtCodBarra.Text) || string.IsNullOrEmpty(txtQTD.Text) || string.IsNullOrEmpty(txtVlrUnit.Text) ||
                string.IsNullOrEmpty(txtSubTotal.Text) || string.IsNullOrEmpty(txtDesconto.Text) || string.IsNullOrEmpty(txtVendedor.Text) ||
                string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de salvar.");
                return;
            }

            // Obter os dados dos campos
            string codBarra = txtCodBarra.Text.Trim();
            int codItem = 0;
            string nomeProduto = string.Empty;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Buscar CodItem a partir do CodBarra
                    string queryCodItem = "SELECT Codigo, NomeCompleto FROM produto1 WHERE CodBarras = @CodBarras";
                    MySqlCommand cmdCodItem = new MySqlCommand(queryCodItem, conn);
                    cmdCodItem.Parameters.AddWithValue("@CodBarras", codBarra);

                    MySqlDataReader reader = cmdCodItem.ExecuteReader();
                    if (reader.Read())
                    {
                        codItem = reader.GetInt32("Codigo");
                        nomeProduto = reader.GetString("NomeCompleto");
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar CodItem: " + ex.Message);
                    return;
                }
            }

            int quantidade = Convert.ToInt32(txtQTD.Text);
            decimal vlrUnitario = Convert.ToDecimal(txtVlrUnit.Text);
            decimal vlrDesconto = Convert.ToDecimal(txtDesconto.Text) * quantidade;

            decimal vlrTotal = quantidade * vlrUnitario;

            string vendedor = txtVendedor.Text;
            string cliente = txtCliente.Text;

            // Trabalhando diretamente com o DataTable
            DataTable dt = (DataTable)dgvCadastroVendas.DataSource;

            // Verificar se o DataTable já foi criado, caso contrário, inicialize
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("CodigoMovEstoque");
                dt.Columns.Add("CodItem");
                dt.Columns.Add("NomeProduto"); // Adicionando a coluna NomeProduto
                dt.Columns.Add("Quantidade");
                dt.Columns.Add("VlrUnitario");
                dt.Columns.Add("VlrTotal");
                dt.Columns.Add("VlrDesconto");
                dt.Columns.Add("Vendedor");
                dt.Columns.Add("Cliente");

                dgvCadastroVendas.DataSource = dt;
            }

            // Verificar se o item já existe no DataTable
            bool itemExistente = false;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["CodItem"]) == codItem)
                {
                    itemExistente = true;
                    break;
                }
            }

            if (itemExistente)
            {
                // Atualizar a linha existente
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["CodItem"]) == codItem)
                    {
                        int quantidadeExistente = Convert.ToInt32(row["Quantidade"]);
                        decimal vlrUnitarioExistente = Convert.ToDecimal(row["VlrUnitario"]);
                        decimal vlrDescontoExistente = Convert.ToDecimal(row["VlrDesconto"]);

                        int novaQuantidade = quantidadeExistente + quantidade;
                        row["Quantidade"] = novaQuantidade;
                        row["VlrTotal"] = novaQuantidade * vlrUnitarioExistente;
                        row["VlrDesconto"] = vlrDescontoExistente + vlrDesconto;
                    }
                }
            }
            else
            {
                // Adicionar nova linha
                DataRow newRow = dt.NewRow();
                newRow["CodigoMovEstoque"] = codigoMovEstoque;
                newRow["CodItem"] = codItem;
                newRow["NomeProduto"] = nomeProduto; // Coloca o Nome do Produto na nova linha
                newRow["Quantidade"] = quantidade;
                newRow["VlrUnitario"] = vlrUnitario;
                newRow["VlrTotal"] = vlrTotal;
                newRow["VlrDesconto"] = vlrDesconto;
                newRow["Vendedor"] = vendedor;
                newRow["Cliente"] = cliente;

                dt.Rows.Add(newRow);
            }

            // Calcular o valor de VlrSubTotal (somar VlrTotal - VlrDesconto de todas as linhas)
            decimal subTotal = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal vlrTotalLinha = Convert.ToDecimal(row["VlrTotal"]);
                decimal vlrDescontoLinha = Convert.ToDecimal(row["VlrDesconto"]);
                subTotal += vlrTotalLinha - vlrDescontoLinha;
            }

            // Atualizar o lblSubTotal com o valor calculado
            lblSubTotal.Text = "R$ " + subTotal.ToString("F2");

            // Limpar os campos de entrada
            txtCodBarra.Clear();
            txtNome.Clear();
            txtQTD.Clear();
            txtVlrUnit.Clear();
            txtDesconto.Clear();
            txtSubTotal.Clear();
            txtCodBarra.Focus();

            // Ocultar a coluna CodItem
            dgvCadastroVendas.Columns["CodItem"].Visible = false;

            // Ajustar a coluna "NomeProduto"
            dgvCadastroVendas.Columns["NomeProduto"].Width = 300;

            // Renomear as colunas de acordo com o solicitado
            dgvCadastroVendas.Columns["CodigoMovEstoque"].HeaderText = "Codigo Mov Estoque";
            dgvCadastroVendas.Columns["CodItem"].HeaderText = "Cod. Item";
            dgvCadastroVendas.Columns["NomeProduto"].HeaderText = "Nome do Produto";
            dgvCadastroVendas.Columns["Quantidade"].HeaderText = "Quantidade";
            dgvCadastroVendas.Columns["VlrUnitario"].HeaderText = "Valor Unitário";
            dgvCadastroVendas.Columns["VlrTotal"].HeaderText = "Valor Total";
            dgvCadastroVendas.Columns["VlrDesconto"].HeaderText = "Valor Desconto";
            dgvCadastroVendas.Columns["Vendedor"].HeaderText = "Vendedor";
            dgvCadastroVendas.Columns["Cliente"].HeaderText = "Cliente";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            // Verificar se uma linha está selecionada
            if (dgvCadastroVendas.SelectedRows.Count > 0)
            {
                // Confirmar se o usuário deseja realmente excluir a linha
                var result = MessageBox.Show("Você tem certeza que deseja excluir esta linha?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Obter o valor total e o valor do desconto da linha selecionada
                        DataGridViewRow selectedRow = dgvCadastroVendas.SelectedRows[0];
                        decimal vlrTotalItem = Convert.ToDecimal(selectedRow.Cells["VlrTotal"].Value);
                        decimal vlrDescontoItem = Convert.ToDecimal(selectedRow.Cells["VlrDesconto"].Value);

                        // Calcular o valor do item (VlrTotal - VlrDesconto)
                        decimal valorItem = vlrTotalItem - vlrDescontoItem;

                        // Remover a linha selecionada do DataGridView
                        dgvCadastroVendas.Rows.RemoveAt(selectedRow.Index);

                        // Atualizar o lblSubTotal subtraindo o valor do item excluído
                        decimal subTotal = 0;
                        foreach (DataGridViewRow row in dgvCadastroVendas.Rows)
                        {
                            decimal vlrTotalLinha = Convert.ToDecimal(row.Cells["VlrTotal"].Value);
                            decimal vlrDescontoLinha = Convert.ToDecimal(row.Cells["VlrDesconto"].Value);
                            subTotal += vlrTotalLinha - vlrDescontoLinha;
                        }

                        // Atualizar o lblSubTotal com o novo valor
                        lblSubTotal.Text = "R$ " + subTotal.ToString("F2");

                        MessageBox.Show("Linha excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Exibe um erro caso ocorra algum problema
                        MessageBox.Show("Erro ao excluir a linha: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFaturar_Click(object sender, EventArgs e)
        {
            // Tente remover qualquer formatação de moeda, como o símbolo "R$" e espaços extras
            string valorSubTotalTexto = lblSubTotal.Text.Replace("R$", "").Trim(); // Remove "R$" (ou outro símbolo de moeda, se for o caso)

            // Verifica se o valor pode ser convertido para decimal
            if (decimal.TryParse(valorSubTotalTexto, out decimal valorSubTotal))
            {
                // Passa a instância de FrmConsultaVendas (que foi passada para FrmCadastroVendas) para FrmFaturamentoVendas
                FrmFaturamentoVendas frmFaturamentoVendas = new FrmFaturamentoVendas(valorSubTotal, this, codigoMovEstoque);
                frmFaturamentoVendas.ShowDialog();
            }
            else
            {
                // Caso a conversão falhe, exibe uma mensagem de erro
                MessageBox.Show("O Subtotal está vazio ou inválido. Verifique os campos de quantidade, valor unitário e desconto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpar os dados da DataGridView
            DataTable dt = (DataTable)dgvCadastroVendas.DataSource;
            if (dt != null)
            {
                dt.Clear(); // Limpa todas as linhas da DataGridView
            }

            // Limpar os campos de entrada
            txtCodBarra.Clear();
            txtNome.Clear();
            txtQTD.Clear();
            txtVlrUnit.Clear();
            txtDesconto.Clear();
            txtSubTotal.Clear();
            txtCliente.Clear();  // Se desejar também limpar o campo Cliente
            txtVendedor.Clear(); // Se desejar limpar o campo Vendedor também

            // Definir o foco para o campo txtVendedor
            txtVendedor.Focus();

            // Atualizar o rótulo do SubTotal para "R$ 0,00" (caso queira)
            lblSubTotal.Text = "R$ 0,00";
        }

        // Evento para buscar o nome do vendedor ao digitar no txtVendedor
        private void txtVendedor_TextChanged(object sender, EventArgs e)
        {
            string idVendedor = txtVendedor.Text.Trim();

            if (!string.IsNullOrEmpty(idVendedor))
            {
                // Busca o nome do vendedor com base no ID inserido no txtVendedor
                string nomeVendedor = BuscarNomeVendedor(idVendedor);

                if (!string.IsNullOrEmpty(nomeVendedor))
                {
                    // Exibe o nome do vendedor na lblNomeVendedor
                    lblNomeVendedor.Text = nomeVendedor;
                }
                else
                {
                    lblNomeVendedor.Text = "Vendedor não encontrado!";
                }
            }
            else
            {
                lblNomeVendedor.Text = string.Empty; // Limpa o label caso o campo esteja vazio
            }
        }

        // Evento KeyDown para o campo txtCodBarra

        private void txtCodBarra_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi o "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                string codBarra = txtCodBarra.Text.Trim();

                if (!string.IsNullOrEmpty(codBarra))
                {
                    // Conectar ao banco de dados e buscar os dados
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            // 1. Buscar o Código do Produto (Produto1) com base no Código de Barras
                            string queryProduto1 = "SELECT Codigo, NomePopular FROM produto1 WHERE CodBarras = @CodBarras";
                            MySqlCommand cmdProduto1 = new MySqlCommand(queryProduto1, conn);
                            cmdProduto1.Parameters.AddWithValue("@CodBarras", codBarra);

                            MySqlDataReader readerProduto1 = cmdProduto1.ExecuteReader();

                            if (readerProduto1.Read())
                            {
                                // Preencher o nome do produto (NomePopular)
                                txtNome.Text = readerProduto1["NomePopular"].ToString();

                                int codProduto1 = Convert.ToInt32(readerProduto1["Codigo"]);

                                // 2. Buscar o VlrVenda e VlrDesconto na tabela produto2 com base no CodProduto1
                                readerProduto1.Close(); // Fechar o reader do produto1 antes de abrir outro

                                string queryProduto2 = "SELECT VlrVenda, VlrDesconto FROM produto2 WHERE CodProduto1 = @CodProduto1";
                                MySqlCommand cmdProduto2 = new MySqlCommand(queryProduto2, conn);
                                cmdProduto2.Parameters.AddWithValue("@CodProduto1", codProduto1);

                                MySqlDataReader readerProduto2 = cmdProduto2.ExecuteReader();

                                if (readerProduto2.Read())
                                {
                                    // Preencher os valores dos campos
                                    txtQTD.Text = "1";
                                    txtVlrUnit.Text = Convert.ToDecimal(readerProduto2["VlrVenda"]).ToString("F2"); // Preencher com o valor de venda
                                    txtDesconto.Text = Convert.ToDecimal(readerProduto2["VlrDesconto"]).ToString("F2"); // Preencher com o valor de VlrDesconto

                                    // Calcular o SubTotal
                                    CalcularSubTotal();
                                    txtQTD.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Não foi encontrado o preço de venda ou outros dados para o produto.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Produto não encontrado com o código de barras fornecido.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao buscar os dados do produto: " + ex.Message);
                        }
                    }
                }
                else
                {
                    // Limpar os campos caso o código de barras seja apagado
                    txtNome.Clear();
                    txtQTD.Clear();
                    txtVlrUnit.Clear();
                    txtDesconto.Clear();
                    txtSubTotal.Clear();
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

        // Evento TextChanged para o campo txtQTD
        private void txtQTD_TextChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();
        }

        // Evento TextChanged para o campo txtVlrUnit
        private void txtVlrUnit_TextChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();
        }

        // Evento TextChanged para o campo txtDesconto
        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();
        }

        // Função para buscar o nome do vendedor pelo ID
        private string BuscarNomeVendedor(string idVendedor)
        {
            string nomeVendedor = string.Empty;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para buscar o campo Usuario (nome) na tabela usuarios com base no ID
                    string query = "SELECT Usuario FROM usuarios WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", idVendedor);

                    // Executa a consulta e obtém o nome do vendedor
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        nomeVendedor = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o nome do vendedor: " + ex.Message);
                }
            }

            return nomeVendedor;
        }

        // Função para calcular o SubTotal
        private void CalcularSubTotal()
        {
            // Verifica se os campos não estão vazios e contém valores válidos
            if (decimal.TryParse(txtQTD.Text, out decimal quantidade) &&
                decimal.TryParse(txtVlrUnit.Text, out decimal vlrUnitario) &&
                decimal.TryParse(txtDesconto.Text, out decimal vlrDesconto))
            {
                // Calcula o subtotal: (Quantidade * VlrUnitario) - Desconto
                decimal subTotal = (quantidade * vlrUnitario) - (quantidade * vlrDesconto);

                // Atualiza o campo txtSubTotal com o valor calculado
                txtSubTotal.Text = subTotal.ToString("F2"); // Formato com 2 casas decimais
            }
            else
            {
                // Caso algum campo esteja vazio ou com valor inválido, limpa o txtSubTotal
                txtSubTotal.Clear();
            }
        }
    }
}