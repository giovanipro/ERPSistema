using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmFaturamentoVendas : Form
    {
        private string connectionString = "Server=localhost;Database=database;Uid=root;";
        private FrmCadastroVendas frmCadastroVendas;
        private int codigoMovEstoque;
        private int quantidade = 0;
        private int codItem = 0;

        public FrmFaturamentoVendas(decimal valorSubTotal, FrmCadastroVendas frmCadastroVendas, int codigoMovEstoque)
        {
            InitializeComponent();
            lblValorRestante.Text = valorSubTotal.ToString("C");
            lblFatura.Text = valorSubTotal.ToString("C");
            this.frmCadastroVendas = frmCadastroVendas; // Armazenando a instância
            this.codigoMovEstoque = codigoMovEstoque; // Armazene o código para usar nas consultas
        }

        // Evento disparado ao carregar o formulário
        private void FrmFaturamentoVendas_Load(object sender, EventArgs e)
        {
            // Inicializa a ListBox com itens
            listBoxFormasPagamento.Items.Add("DINHEIRO");
            listBoxFormasPagamento.Items.Add("CARTÃO CRÉDITO");
            listBoxFormasPagamento.Items.Add("CARTÃO DÉBITO");
            listBoxFormasPagamento.Items.Add("PIX");
            listBoxFormasPagamento.Items.Add("TRANSFERÊNCIA");
            listBoxFormasPagamento.Items.Add("DUPLICATA");

            // Configurar o DataGridView: Adicionando colunas
            dgvFaturamento.Columns.Add("FormaPagamento", "FORMAS DE PAGAMENTO");
            dgvFaturamento.Columns.Add("Valor", "VALOR");

            // Altera a cor de fundo dos cabeçalhos para cinza
            dgvFaturamento.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            dgvFaturamento.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; // Para as letras ficarem brancas

            // Ajusta a largura da coluna "FORMAS DE PAGAMENTO"
            dgvFaturamento.Columns["FormaPagamento"].Width = 450; // Aumenta o tamanho da coluna
            dgvFaturamento.Columns["Valor"].Width = 150;

            // Certifique-se de que o painel começa invisível
            pnlFaturar.Visible = false;
            lblVezes.Visible = false;
            lblDividir.Visible = false;
            cmbVezes.Visible = false;

            // Carregar opções de parcelamento (Vezes) na ComboBox
            CarregarParcelas();
        }

        // Evento disparado ao clicar no botão OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado na ListBox
            if (listBoxFormasPagamento.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um item da lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém o nome do item selecionado na ListBox
            string nomeSelecionado = listBoxFormasPagamento.SelectedItem.ToString();

            // Obtém o valor inserido no txtValor
            decimal valorInserido;
            if (!decimal.TryParse(txtValor.Text, out valorInserido) || valorInserido <= 0)
            {
                MessageBox.Show("Por favor, insira um valor válido e maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtém o valor restante de lblValorRestante, removendo a formatação de moeda
            decimal valorRestante;
            if (!decimal.TryParse(RemoverSimboloMoeda(lblValorRestante.Text), out valorRestante))
            {
                MessageBox.Show("O valor restante é inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcula o valor excedente (troco) se o valor inserido for maior que o valor restante
            decimal valorExcedente = valorInserido > valorRestante ? valorInserido - valorRestante : 0;

            // Atualiza o valor restante após a inserção
            decimal novoValorRestante = valorRestante - valorInserido;

            // Se o novo valor restante for negativo, define como 0
            if (novoValorRestante < 0)
            {
                novoValorRestante = 0;
            }

            lblValorRestante.Text = novoValorRestante.ToString("C");

            // Adiciona o valor inserido em lblFaturado
            decimal valorFaturado;
            if (decimal.TryParse(RemoverSimboloMoeda(lblFaturado.Text), out valorFaturado))
            {
                lblFaturado.Text = (valorFaturado + valorInserido).ToString("C");
            }
            else
            {
                lblFaturado.Text = valorInserido.ToString("C");
            }

            // Se houver valor excedente (troco), exibe no lblTroco
            lblTroco.Text = valorExcedente.ToString("C");

            // Se a forma de pagamento for parcelada, divide o valor e adiciona as parcelas no DataGridView
            int numeroParcelas = 1; // Por padrão, número de parcelas é 1
            if (nomeSelecionado == "CARTÃO CRÉDITO" || nomeSelecionado == "CARTÃO DÉBITO" || nomeSelecionado == "DUPLICATA")
            {
                // Pega o número de parcelas selecionado no ComboBox
                numeroParcelas = Convert.ToInt32(cmbVezes.SelectedItem);
            }

            // Calcula o valor da parcela dividindo o valor total pela quantidade de parcelas
            decimal valorParcela = valorInserido / numeroParcelas;

            // Adiciona as parcelas no DataGridView
            for (int i = 1; i <= numeroParcelas; i++)
            {
                string formaPagamento = nomeSelecionado;
                dgvFaturamento.Rows.Add(formaPagamento, valorParcela.ToString("C"));
            }

            // Limpa o txtValor após a inserção
            txtValor.Clear();

            // Torna o painel pnlFaturar invisível novamente
            pnlFaturar.Visible = false;
        }

        // Evento disparado ao clicar no botão Faturar
        private void btnFaturar_Click(object sender, EventArgs e)
        {
            // Verificar se o valor restante é 0
            decimal valorRestante;
            if (!decimal.TryParse(RemoverSimboloMoeda(lblValorRestante.Text), out valorRestante))
            {
                MessageBox.Show("Erro ao ler o valor restante. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (valorRestante != 0)
            {
                MessageBox.Show("O valor restante não é 0. Por favor, complete o pagamento antes de faturar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Impede o faturamento caso o valor restante não seja zero
            }

            // Conectar ao banco de dados MySQL
            string connectionString = "Server=localhost;Port=3306;Database=database;User=root;"; // Substitua pela sua string de conexão MySQL

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    decimal somaValoresPagamento = 0;
                    bool pagamentoEncontrado = false;

                    foreach (DataGridViewRow row in dgvFaturamento.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Acessando o valor da célula "FormaPagamento" para cada linha
                        string formaPagamento = row.Cells["FormaPagamento"].Value.ToString();

                        // Verificando se a forma de pagamento é "CARTÃO CRÉDITO" ou "DUPLICATA"
                        if (formaPagamento == "CARTÃO CRÉDITO" || formaPagamento == "DUPLICATA")
                        {
                            pagamentoEncontrado = true;
                            break;  // Interrompe o loop ao encontrar o valor
                        }
                    }

                    // Inserir o registro de movimento de estoque
                    string insertMovEstoqueQuery = "INSERT INTO mov_estoque (TipoEstoque, Data, Hora, VlrDesconto, VlrTotal, VlrSubTotal) " +
                                               "VALUES (@TipoEstoque, @Data, @Hora, @VlrDesconto, @VlrTotal, @VlrSubTotal)";
                    MySqlCommand cmdMovEstoque = new MySqlCommand(insertMovEstoqueQuery, conn);
                    cmdMovEstoque.Parameters.AddWithValue("@TipoEstoque", "Saída");
                    cmdMovEstoque.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmdMovEstoque.Parameters.AddWithValue("@Hora", DateTime.Now.ToString("HH:mm:ss"));
                    cmdMovEstoque.Parameters.AddWithValue("@VlrDesconto", 0); // Supondo que será calculado no loop das vendas
                    cmdMovEstoque.Parameters.AddWithValue("@VlrTotal", 0);  // Supondo que será calculado no loop das vendas
                    cmdMovEstoque.Parameters.AddWithValue("@VlrSubTotal", 0); // Supondo que será calculado no loop das vendas

                    // Inserir na tabela mov_estoque e pegar o ID gerado
                    cmdMovEstoque.ExecuteNonQuery();
                    codigoMovEstoque = Convert.ToInt32(cmdMovEstoque.LastInsertedId);

                    // Declarar variáveis para somar os valores
                    decimal totalVlrTotal = 0;
                    decimal totalVlrDesconto = 0;
                    int idVenda = 0;
                    // Agora, insira os itens no movimento de estoque (mov_estoque_item)
                    foreach (DataGridViewRow selectedRow in frmCadastroVendas.dgvCadastroVendas.Rows)
                    {
                        if (selectedRow.IsNewRow) continue;

                        // Agora, atribua o codigoMovEstoque para idVenda
                        idVenda = codigoMovEstoque; // Usando o codigoMovEstoque gerado, não mais da DataGridView

                        // Obtenha os outros valores das células corretamente
                        codItem = Convert.ToInt32(selectedRow.Cells["CodItem"].Value); // Certifique-se de que o nome da coluna está correto
                        quantidade = Convert.ToInt32(selectedRow.Cells["Quantidade"].Value);
                        decimal vlrUnitario = Convert.ToDecimal(selectedRow.Cells["VlrUnitario"].Value);
                        decimal vlrTotal = Convert.ToDecimal(selectedRow.Cells["VlrTotal"].Value);
                        decimal vlrDesconto = Convert.ToDecimal(selectedRow.Cells["VlrDesconto"].Value);
                        string vendedor = selectedRow.Cells["Vendedor"].Value.ToString();
                        string cliente = selectedRow.Cells["Cliente"].Value.ToString();

                        // Somar os valores para atualizar o movimento de estoque
                        totalVlrTotal += vlrTotal;
                        totalVlrDesconto += vlrDesconto;

                        // Agora insira o item no mov_estoque_item
                        string insertMovEstoqueItemQuery = "INSERT INTO mov_estoque_item (CodigoMovEstoque, CodItem, Quantidade, VlrUnitario, VlrTotal, VlrDesconto, Vendedor, Cliente) " +
                                                           "VALUES (@CodigoMovEstoque, @CodItem, @Quantidade, @VlrUnitario, @VlrTotal, @VlrDesconto, @Vendedor, @Cliente)";
                        MySqlCommand cmdMovEstoqueItem = new MySqlCommand(insertMovEstoqueItemQuery, conn);
                        cmdMovEstoqueItem.Parameters.AddWithValue("@CodigoMovEstoque", codigoMovEstoque); // Usando o ID do movimento de estoque
                        cmdMovEstoqueItem.Parameters.AddWithValue("@CodItem", codItem);
                        cmdMovEstoqueItem.Parameters.AddWithValue("@Quantidade", quantidade);
                        cmdMovEstoqueItem.Parameters.AddWithValue("@VlrUnitario", vlrUnitario);

                        // Subtrai o valor de desconto de VlrTotal
                        decimal vlrTotalComDesconto = vlrTotal - vlrDesconto;

                        cmdMovEstoqueItem.Parameters.AddWithValue("@VlrTotal", vlrTotalComDesconto); // Inserir o valor ajustado (VlrTotal - VlrDesconto)
                        cmdMovEstoqueItem.Parameters.AddWithValue("@VlrDesconto", vlrDesconto);
                        cmdMovEstoqueItem.Parameters.AddWithValue("@Vendedor", vendedor);
                        cmdMovEstoqueItem.Parameters.AddWithValue("@Cliente", cliente);

                        cmdMovEstoqueItem.ExecuteNonQuery();
                    }

                    // Percorrer todas as linhas da dgvFaturamento
                    foreach (DataGridViewRow row in dgvFaturamento.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string formaPagamento = row.Cells["FormaPagamento"].Value.ToString();
                        string valorString = row.Cells["Valor"].Value.ToString();
                        valorString = RemoverSimboloMoeda(valorString);

                        if (!decimal.TryParse(valorString, out decimal valorFormaPagamento))
                        {
                            MessageBox.Show("Erro ao converter o valor: " + valorString, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        somaValoresPagamento += valorFormaPagamento;

                        // Obter o ID da forma de pagamento
                        string idFormaPgtoQuery = "SELECT Codigo FROM formaspgto WHERE Nome = @NomeFormaPagamento";
                        MySqlCommand cmd = new MySqlCommand(idFormaPgtoQuery, conn);
                        cmd.Parameters.AddWithValue("@NomeFormaPagamento", formaPagamento);

                        object idFormaPgtoResult = cmd.ExecuteScalar();
                        if (idFormaPgtoResult == null)
                        {
                            MessageBox.Show("Forma de pagamento não encontrada: " + formaPagamento, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        int idFormaPgto = Convert.ToInt32(idFormaPgtoResult);

                        // Obter o último saldo atual
                        decimal saldoAnterior = 0;
                        decimal saldoAtual = 0;

                        string lastSaldoQuery = "SELECT SaldoAtual FROM caixacardex ORDER BY Codigo DESC LIMIT 1";
                        MySqlCommand cmdLastSaldo = new MySqlCommand(lastSaldoQuery, conn);
                        object lastSaldoResult = cmdLastSaldo.ExecuteScalar();
                        if (lastSaldoResult != DBNull.Value && lastSaldoResult != null)
                        {
                            saldoAnterior = Convert.ToDecimal(lastSaldoResult);
                            saldoAtual = saldoAnterior + valorFormaPagamento;
                        }
                        else
                        {
                            // Se não houver registros, o saldo do primeiro registro é o valor do pagamento
                            saldoAtual = valorFormaPagamento;
                        }

                        if (formaPagamento != "CARTÃO CRÉDITO" && formaPagamento != "DUPLICATA")
                        {
                            // Verifica se o valor de lblTroco é maior que zero
                            decimal valorTroco = 0;
                            if (decimal.TryParse(RemoverSimboloMoeda(lblTroco.Text), out valorTroco) && valorTroco > 0)
                            {
                                valorFormaPagamento -= valorTroco; // Subtrai o valor do troco
                            }

                            // Agora, insira o pagamento no caixa
                            string insertQuery = "INSERT INTO caixacardex (Data, Hora, Tipo, Descricao, NumCaixa, ValorEntrada, ValorSaida, IdFormaPgto, Valor, IdVenda, SaldoAnterior, SaldoAtual) " +
                                                 "VALUES (@Data, @Hora, @Tipo, @Descricao, @NumCaixa, @ValorEntrada, @ValorSaida, @IdFormaPgto, @Valor, @IdVenda, @SaldoAnterior, @SaldoAtual)";
                            cmd = new MySqlCommand(insertQuery, conn);
                            cmd.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Hora", DateTime.Now.ToString("HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@Tipo", "Entrada");
                            cmd.Parameters.AddWithValue("@Descricao", "VENDA: " + formaPagamento);
                            cmd.Parameters.AddWithValue("@NumCaixa", 1);
                            cmd.Parameters.AddWithValue("@ValorEntrada", valorFormaPagamento);
                            cmd.Parameters.AddWithValue("@ValorSaida", 0);
                            cmd.Parameters.AddWithValue("@IdFormaPgto", idFormaPgto);
                            cmd.Parameters.AddWithValue("@Valor", valorFormaPagamento);
                            cmd.Parameters.AddWithValue("@IdVenda", idVenda);
                            cmd.Parameters.AddWithValue("@SaldoAnterior", saldoAnterior);
                            cmd.Parameters.AddWithValue("@SaldoAtual", saldoAtual);

                            cmd.ExecuteNonQuery();
                        }

                        // Agora que todos os itens foram inseridos, vamos atualizar o movimento de estoque (mov_estoque)
                        string updateMovEstoqueQuery = "UPDATE mov_estoque SET VlrTotal = @VlrTotal, VlrDesconto = @VlrDesconto, VlrSubTotal = (VlrTotal - VlrDesconto) " +
                                                      "WHERE Codigo = @CodigoMovEstoque";
                        MySqlCommand cmdUpdateMovEstoque = new MySqlCommand(updateMovEstoqueQuery, conn);
                        cmdUpdateMovEstoque.Parameters.AddWithValue("@VlrTotal", totalVlrTotal);
                        cmdUpdateMovEstoque.Parameters.AddWithValue("@VlrDesconto", totalVlrDesconto);
                        cmdUpdateMovEstoque.Parameters.AddWithValue("@CodigoMovEstoque", codigoMovEstoque);

                        // Executa a atualização na tabela mov_estoque
                        cmdUpdateMovEstoque.ExecuteNonQuery();
                    }

                    // Após o primeiro insert em 'receber1'
                    if (pagamentoEncontrado)
                    {
                        // Inserir em 'receber1' com o campo Status
                        string insertReceber1Query = "INSERT INTO receber1 (NumDocto, Cliente, Valor, Status) VALUES (@NumDocto, @Cliente, @Valor, @Status)";
                        MySqlCommand cmdReceber1 = new MySqlCommand(insertReceber1Query, conn);
                        cmdReceber1.Parameters.AddWithValue("@NumDocto", codigoMovEstoque); // Usando o ID do movimento de estoque

                        // Buscando o valor 'Fantasia' na tabela 'pessoas' com base no 'Codigo' do cliente da dgvCadastroVendas
                        string clienteFantasia = string.Empty;
                        int codigoCliente = 0;

                        foreach (DataGridViewRow selectedRow in frmCadastroVendas.dgvCadastroVendas.SelectedRows)
                        {
                            if (selectedRow.IsNewRow) continue;

                            codigoCliente = selectedRow.Cells["Cliente"].Value == DBNull.Value ? 0 : Convert.ToInt32(selectedRow.Cells["Cliente"].Value);

                            string fantasiaQuery = "SELECT Fantasia FROM pessoas WHERE Codigo = @CodigoCliente";
                            MySqlCommand cmdFantasia = new MySqlCommand(fantasiaQuery, conn);
                            cmdFantasia.Parameters.AddWithValue("@CodigoCliente", codigoCliente);

                            object resultadoFantasia = cmdFantasia.ExecuteScalar();
                            clienteFantasia = resultadoFantasia != DBNull.Value && resultadoFantasia != null ? resultadoFantasia.ToString() : string.Empty;
                            break; // Só precisa pegar o primeiro cliente selecionado
                        }

                        // Somando os valores da coluna 'Valor' na dgvFaturamento
                        decimal somaValoresFaturamento = 0;
                        foreach (DataGridViewRow row in dgvFaturamento.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string formaPagamento = row.Cells["FormaPagamento"].Value.ToString();

                            // Agora, insira em 'receber1' e 'receber2' se a forma de pagamento for "CARTÃO CRÉDITO" ou "DUPLICATA"
                            if (formaPagamento == "CARTÃO CRÉDITO" || formaPagamento == "DUPLICATA")
                            {
                                // Verifica se o valor da célula 'Valor' não é nulo
                                if (row.Cells["Valor"].Value != DBNull.Value)
                                {
                                    string valorCelula = row.Cells["Valor"].Value.ToString();

                                    // Remover o símbolo de moeda caso ele exista
                                    decimal valorNumerico = 0;

                                    // Tentar converter o valor para decimal ignorando símbolos
                                    if (decimal.TryParse(valorCelula, NumberStyles.Currency, CultureInfo.CurrentCulture, out valorNumerico))
                                    {
                                        somaValoresFaturamento += valorNumerico;
                                    }
                                    else
                                    {
                                        // Caso não consiga converter, exibe um erro ou trata a situação
                                        MessageBox.Show("Valor inválido encontrado na coluna 'Valor'.");
                                    }
                                }
                            }
                        }

                        // O valor da soma dos valores da 'dgvFaturamento' será usado
                        cmdReceber1.Parameters.AddWithValue("@Cliente", clienteFantasia); // Colocando o nome Fantasia do Cliente
                        cmdReceber1.Parameters.AddWithValue("@Valor", somaValoresFaturamento); // Colocando a soma dos valores da 'dgvFaturamento'
                        cmdReceber1.Parameters.AddWithValue("@Status", "Em Andamento"); // Definindo o Status como "Em Andamento"
                        cmdReceber1.ExecuteNonQuery();  // Executa a inserção na tabela receber1 com o Status atualizado
                    }

                    // Inserir na tabela receber2 (para cada linha de pagamento)
                    // Primeiro, obtenha o valor do troco
                    decimal valorTroco2 = 0;
                    if (decimal.TryParse(RemoverSimboloMoeda(lblTroco.Text), out valorTroco2) && valorTroco2 > 0)
                    {
                        // Calcule o número de linhas da DataGridView, excluindo a nova linha
                        int totalLinhas = dgvFaturamento.Rows.Cast<DataGridViewRow>()
                                            .Where(row => !row.IsNewRow) // Exclui a nova linha
                                            .Count();

                        // Se houver linhas para distribuir o troco
                        if (totalLinhas > 0)
                        {
                            decimal valorTrocoPorParcela = valorTroco2 / totalLinhas; // Divide o troco pelo número de parcelas

                            // Agora, para cada linha de pagamento na DataGridView
                            foreach (DataGridViewRow pagamentoRow in dgvFaturamento.Rows)
                            {
                                if (pagamentoRow.IsNewRow) continue;

                                string formaPagamento = pagamentoRow.Cells["FormaPagamento"].Value.ToString();

                                // Insira em 'receber1' e 'receber2' se a forma de pagamento for "CARTÃO CRÉDITO", "DUPLICATA" ou "CARTÃO DÉB"
                                if (formaPagamento == "CARTÃO CRÉDITO" || formaPagamento == "DUPLICATA" || formaPagamento == "CARTÃO DÉB")
                                {
                                    string valorParcelaString = pagamentoRow.Cells["Valor"].Value.ToString();
                                    decimal valorParcela = Convert.ToDecimal(RemoverSimboloMoeda(valorParcelaString));

                                    // Subtrai a parte proporcional do troco da parcela
                                    valorParcela -= valorTrocoPorParcela;

                                    // Agora, insira em 'receber2' com o valor de NumDocto da tabela receber1
                                    string insertReceber2Query = "INSERT INTO receber2 (NumDocto, Data, ValorParcela, Vencimento, Status) " +
                                                                 "VALUES (@NumDocto, @Data, @ValorParcela, @Vencimento, @Status)";

                                    MySqlCommand cmdReceber2 = new MySqlCommand(insertReceber2Query, conn);
                                    cmdReceber2.Parameters.AddWithValue("@NumDocto", codigoMovEstoque); // Usando o código do movimento de estoque ou outro identificador de recebimento
                                    cmdReceber2.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd"));
                                    cmdReceber2.Parameters.AddWithValue("@ValorParcela", valorParcela);
                                    cmdReceber2.Parameters.AddWithValue("@Vencimento", DateTime.Now.AddDays(30).ToString("yyyy-MM-dd")); // Vencimento em 30 dias
                                    cmdReceber2.Parameters.AddWithValue("@Status", "Em Andamento"); // Definindo o status como "Em Andamento"

                                    cmdReceber2.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // Se não houver linhas, você pode exibir um erro ou tomar outra ação
                            Console.WriteLine("Não há linhas para distribuir o troco.");
                        }
                    }
                    else
                    {
                        // Caso o valor do troco seja inválido ou não exista
                        Console.WriteLine("Valor do troco inválido ou não encontrado.");
                    }

                    foreach (DataGridViewRow selectedRow in frmCadastroVendas.dgvCadastroVendas.Rows)
                    {
                        if (selectedRow.IsNewRow) continue;

                        codItem = Convert.ToInt32(selectedRow.Cells["CodItem"].Value); // Certifique-se de que o nome da coluna está correto
                            quantidade = Convert.ToInt32(selectedRow.Cells["Quantidade"].Value);

                        // Subtraímos a quantidade do estoque
                        string updateEstoqueQuery = "UPDATE produto2 SET Estoque = Estoque - @Quantidade WHERE CodProduto1 = @CodItem";
                        MySqlCommand cmdUpdateEstoque = new MySqlCommand(updateEstoqueQuery, conn);
                        cmdUpdateEstoque.Parameters.AddWithValue("@Quantidade", quantidade);
                        cmdUpdateEstoque.Parameters.AddWithValue("@CodItem", codItem);

                        // Executa a atualização no estoque
                        cmdUpdateEstoque.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            pnlFaturar.Visible = false;
        }

        private void btnFechar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento disparado ao dar um duplo clique em um item da ListBox
        private void listBoxFormasPagamento_DoubleClick(object sender, EventArgs e)
        {
            // Verifica se o valor restante é igual a zero
            decimal valorRestante;
            if (!decimal.TryParse(RemoverSimboloMoeda(lblValorRestante.Text), out valorRestante) || valorRestante <= 0)
            {
                MessageBox.Show("O valor restante da fatura é zero. Não é possível realizar o pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Impede a execução do código a seguir
            }

            string nomeSelecionado = listBoxFormasPagamento.SelectedItem.ToString();

            // Verifica se o pagamento foi por "CARTÃO CRÉDITO", "CARTÃO DÉBITO" ou "DUPLICATA"
            if (nomeSelecionado == "CARTÃO CRÉDITO" || nomeSelecionado == "CARTÃO DÉBITO" || nomeSelecionado == "DUPLICATA")
            {
                lblVezes.Visible = true;
                lblDividir.Visible = true;
                cmbVezes.Visible = true;
            }
            else
            {
                lblVezes.Visible = false;
                lblDividir.Visible = false;
                cmbVezes.Visible = false;
            }

            // Torna o painel pnlFaturar visível
            pnlFaturar.Visible = true;

            // Foca no txtValor para o usuário digitar o valor
            txtValor.Focus();
        }

        private void CarregarParcelas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Vezes FROM parcela";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    cmbVezes.Items.Clear();

                    while (reader.Read())
                    {
                        cmbVezes.Items.Add(reader.GetInt32("Vezes"));
                    }

                    // Seleciona o primeiro valor da lista como padrão
                    if (cmbVezes.Items.Count > 0)
                    {
                        cmbVezes.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar parcelas: " + ex.Message);
            }
        }

        // Função para remover o símbolo de moeda e outras formatações
        private string RemoverSimboloMoeda(string valor)
        {
            // Remove o símbolo de moeda (como "R$") e outros caracteres não numéricos
            valor = valor.Replace("R$", "").Trim(); // Remove 'R$' e espaços em branco
            return valor;
        }
    }
}