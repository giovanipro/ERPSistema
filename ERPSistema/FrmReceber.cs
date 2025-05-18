using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmReceber : Form
    {
        private string connectionString = "server=localhost;user=root;database=database;port=3306;";
        private BindingSource bindingSourceReceber1 = new BindingSource();

        public FrmReceber()
        {
            InitializeComponent();
            dgvReceber1.CellClick += dgvReceber1_CellClick;
            dgvReceber1.CellFormatting += dgvReceber1_CellFormatting; // Associar o evento para dgvReceber1
            dgvReceber2.CellFormatting += dgvReceber2_CellFormatting; // Associar o evento para dgvReceber2
        }

        private void FrmReceber_Load(object sender, EventArgs e)
        {
            CarregarDadosReceber1();
        }

        private void btnDefinir_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada na DataGridView de receber2
            if (dgvReceber2.SelectedRows.Count > 0)
            {
                // Obtém o NumDocto da linha selecionada
                string numDocto = dgvReceber2.SelectedRows[0].Cells["NumDocto"].Value.ToString();
                int codigoReceber2 = Convert.ToInt32(dgvReceber2.SelectedRows[0].Cells["Codigo"].Value);  // Código da parcela selecionada
                decimal valorParcela = Convert.ToDecimal(dgvReceber2.SelectedRows[0].Cells["ValorParcela"].Value);  // Valor da parcela
                string statusParcela = dgvReceber2.SelectedRows[0].Cells["Status"].Value.ToString();  // Status da parcela

                // Verifica se a parcela já está marcada como "Pago"
                if (statusParcela == "Pago")
                {
                    MessageBox.Show("Esta parcela já foi paga. Não é possível marcar como paga novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Impede a execução do restante do código
                }

                // Confirmação antes de alterar o status
                DialogResult result = MessageBox.Show("Tem certeza que deseja definir o status da parcela selecionada como 'Pago'?", "Confirmar Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            // Atualiza o status da parcela selecionada de receber2 para "Pago"
                            string updateStatusReceber2Query = "UPDATE receber2 SET Status = @Status WHERE Codigo = @Codigo";

                            // Cria um comando SQL para atualizar o status da parcela
                            MySqlCommand cmdReceber2 = new MySqlCommand(updateStatusReceber2Query, conn);
                            cmdReceber2.Parameters.AddWithValue("@Codigo", codigoReceber2);
                            cmdReceber2.Parameters.AddWithValue("@Status", "Pago");

                            // Executa a atualização
                            cmdReceber2.ExecuteNonQuery();

                            // Verifica se todas as parcelas de receber2 associadas ao mesmo NumDocto estão como "Pago"
                            string checkAllPagoQuery = "SELECT COUNT(*) FROM receber2 WHERE NumDocto = @NumDocto AND Status <> 'Pago'";

                            MySqlCommand cmdCheckPago = new MySqlCommand(checkAllPagoQuery, conn);
                            cmdCheckPago.Parameters.AddWithValue("@NumDocto", numDocto);

                            int countNotPago = Convert.ToInt32(cmdCheckPago.ExecuteScalar());

                            // Se não houver parcelas não pagas, atualiza o status de receber1 para "Pago"
                            if (countNotPago == 0)
                            {
                                // Atualiza o status de receber1 para "Pago"
                                string updateStatusReceber1Query = "UPDATE receber1 SET Status = @Status WHERE NumDocto = @NumDocto";

                                MySqlCommand cmdReceber1 = new MySqlCommand(updateStatusReceber1Query, conn);
                                cmdReceber1.Parameters.AddWithValue("@NumDocto", numDocto);
                                cmdReceber1.Parameters.AddWithValue("@Status", "Pago");

                                cmdReceber1.ExecuteNonQuery();
                            }

                            // Inserir no caixacardex
                            // Buscar o último SaldoAtual da tabela caixacardex
                            string getLastSaldoQuery = "SELECT SaldoAtual FROM caixacardex ORDER BY Codigo DESC LIMIT 1";
                            MySqlCommand cmdGetLastSaldo = new MySqlCommand(getLastSaldoQuery, conn);
                            object lastSaldoObj = cmdGetLastSaldo.ExecuteScalar();
                            decimal lastSaldo = (lastSaldoObj != DBNull.Value) ? Convert.ToDecimal(lastSaldoObj) : 0;

                            // Obter a data e hora atuais
                            DateTime currentDate = DateTime.Now;
                            string dataAtual = currentDate.ToString("yyyy-MM-dd");
                            string horaAtual = currentDate.ToString("HH:mm:ss");

                            // Inserir o movimento no caixacardex
                            string insertCaixaQuery = @"INSERT INTO caixacardex (Data, Hora, Tipo, Valor, Descricao, NumCaixa, 
                                                SaldoAnterior, ValorEntrada, ValorSaida, SaldoAtual, IdFormaPgto, IdVenda) 
                                                VALUES (@Data, @Hora, @Tipo, @Valor, @Descricao, @NumCaixa, @SaldoAnterior, 
                                                @ValorEntrada, @ValorSaida, @SaldoAtual, @IdFormaPgto, @IdVenda)";

                            MySqlCommand cmdInsertCaixa = new MySqlCommand(insertCaixaQuery, conn);
                            cmdInsertCaixa.Parameters.AddWithValue("@Data", dataAtual);
                            cmdInsertCaixa.Parameters.AddWithValue("@Hora", horaAtual);
                            cmdInsertCaixa.Parameters.AddWithValue("@Tipo", "Entrada");
                            cmdInsertCaixa.Parameters.AddWithValue("@Valor", valorParcela);
                            cmdInsertCaixa.Parameters.AddWithValue("@Descricao", "Pagamento à Receber");
                            cmdInsertCaixa.Parameters.AddWithValue("@NumCaixa", 1); // Número do caixa fixo
                            cmdInsertCaixa.Parameters.AddWithValue("@SaldoAnterior", lastSaldo);
                            cmdInsertCaixa.Parameters.AddWithValue("@ValorEntrada", valorParcela); // Não há entrada
                            cmdInsertCaixa.Parameters.AddWithValue("@ValorSaida", 0);
                            cmdInsertCaixa.Parameters.AddWithValue("@SaldoAtual", lastSaldo + valorParcela); // Saldo Atual = Saldo Anterior + Valor da Parcela
                            cmdInsertCaixa.Parameters.AddWithValue("@IdFormaPgto", 7); // Forma de pagamento fixada como 0
                            cmdInsertCaixa.Parameters.AddWithValue("@IdVenda", 0); // ID da venda fixado como 0

                            // Executar o comando de inserção no caixa
                            cmdInsertCaixa.ExecuteNonQuery();

                            MessageBox.Show("Status da parcela alterado para 'Pago' com sucesso e registro inserido no caixa.");

                            // Recarregar os dados após a atualização
                            CarregarDadosReceber2PorNumDocto(numDocto);
                            CarregarDadosReceber1();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao atualizar o status ou inserir no caixa: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para alterar o status.");
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada
            if (dgvReceber1.SelectedRows.Count > 0)
            {
                // Obtém o código (ID) do registro selecionado
                int codigo = Convert.ToInt32(dgvReceber1.SelectedRows[0].Cells["Codigo"].Value);

                // Confirmação antes de excluir
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este registro?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            // Consulta SQL para deletar o registro com base no código
                            string query = "DELETE FROM receber1 WHERE Codigo = @Codigo";

                            // Cria um comando SQL para excluir o registro
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@Codigo", codigo);

                            // Executa a exclusão
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro excluído com sucesso.");
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível excluir o registro.");
                            }

                            // Recarregar os dados após a exclusão
                            CarregarDadosReceber1();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao excluir o registro: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para excluir.");
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtConsulta.Text.ToLower(); // Obtém o texto da consulta e converte para minúsculo

            // Se o campo de consulta estiver vazio, limpa o filtro
            if (string.IsNullOrWhiteSpace(filtro))
            {
                bindingSourceReceber1.Filter = string.Empty;
                return;
            }

            // Lista para armazenar as expressões de filtro
            List<string> filterExpressions = new List<string>();

            // Itera sobre as colunas do DataGridView
            foreach (DataGridViewColumn column in dgvReceber1.Columns)
            {
                if (column.Visible) // Verifica se a coluna está visível
                {
                    string columnName = column.Name; // Usa o nome técnico da coluna no DataGridView

                    // Aplica o filtro para colunas do tipo string
                    if (column.ValueType == typeof(string))
                    {
                        filterExpressions.Add($"{columnName} LIKE '%{filtro}%'");
                    }
                    // Aplica o filtro para colunas numéricas
                    else if (column.ValueType == typeof(int) || column.ValueType == typeof(decimal) || column.ValueType == typeof(double))
                    {
                        // Para números, converta o filtro para valor numérico (caso seja numérico)
                        if (int.TryParse(filtro, out int numericValue))
                        {
                            filterExpressions.Add($"{columnName} = {numericValue}");
                        }
                        else
                        {
                            // Se não for um número válido, não filtra as colunas numéricas
                            continue;
                        }
                    }
                }
            }

            // Se houver expressões válidas, construa o filtro final
            if (filterExpressions.Count > 0)
            {
                // Junta as expressões de filtro usando "OR"
                string filterExpression = string.Join(" OR ", filterExpressions);
                bindingSourceReceber1.Filter = filterExpression; // Aplica o filtro no BindingSource
            }
            else
            {
                // Se não houver filtros válidos, limpa o filtro
                bindingSourceReceber1.Filter = string.Empty;
            }
        }

        private void dgvReceber1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada não é a linha de cabeçalho
            if (e.RowIndex >= 0)
            {
                // Obtém o NumDocto da linha selecionada
                string numDocto = dgvReceber1.Rows[e.RowIndex].Cells["NumDocto"].Value.ToString();

                // Carrega os dados de receber2 com base no NumDocto
                CarregarDadosReceber2PorNumDocto(numDocto);
            }
        }

        private void dgvReceber1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula está na coluna 'Status' e na linha correta
            if (dgvReceber1.Columns[e.ColumnIndex].Name == "Status")
            {
                // Verifica o valor da célula e define a cor correspondente
                string status = e.Value.ToString();

                if (status == "Em Andamento")
                {
                    e.CellStyle.BackColor = Color.Yellow; // Cor para "Em Andamento"
                }
                else if (status == "Atrasado")
                {
                    e.CellStyle.BackColor = Color.Red; // Cor para "Atrasado"
                }
                else if (status == "Pago")
                {
                    e.CellStyle.BackColor = Color.Green; // Cor para "Pago"
                }
            }
        }

        private void dgvReceber2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula está na coluna 'Status' e na linha correta para dgvReceber2
            if (dgvReceber2.Columns[e.ColumnIndex].Name == "Status")
            {
                // Verifica o valor da célula e define a cor correspondente
                string status = e.Value.ToString();

                if (status == "Em Andamento")
                {
                    e.CellStyle.BackColor = Color.Yellow; // Cor para "Em Andamento"
                }
                else if (status == "Atrasado")
                {
                    e.CellStyle.BackColor = Color.Red; // Cor para "Atrasado"
                }
                else if (status == "Pago")
                {
                    e.CellStyle.BackColor = Color.Green; // Cor para "Pago"
                }
            }
        }

        private void CarregarDadosReceber2PorNumDocto(string numDocto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Atualize a consulta SQL para buscar a coluna Status também
                    string query = "SELECT Codigo, NumDocto, Data, ValorParcela, Vencimento, Status " +
                                   "FROM receber2 WHERE NumDocto = @NumDocto";

                    // Cria um DataAdapter para executar a consulta e preencher um DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);

                    // Adiciona o parâmetro para a pesquisa
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@NumDocto", numDocto);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define o DataSource do DataGridView com o DataTable filtrado
                    dgvReceber2.DataSource = dataTable;

                    // Modifica os cabeçalhos das colunas
                    dgvReceber2.Columns["NumDocto"].HeaderText = "Núm. Docto.";
                    dgvReceber2.Columns["ValorParcela"].HeaderText = "Valor da Parcela";
                    dgvReceber2.Columns["Status"].HeaderText = "Status"; // Agora também carregamos o Status

                    // Ajustar o tamanho das colunas
                    dgvReceber2.Columns["NumDocto"].Width = 120; // Ajuste o tamanho conforme necessário
                    dgvReceber2.Columns["Data"].Width = 100;     // Ajuste o tamanho conforme necessário
                    dgvReceber2.Columns["ValorParcela"].Width = 150;  // Ajuste o tamanho conforme necessário
                    dgvReceber2.Columns["Vencimento"].Width = 120;    // Ajuste o tamanho conforme necessário
                    dgvReceber2.Columns["Status"].Width = 100;   // Ajuste o tamanho para a coluna Status

                    // Opcional: Auto ajustar as colunas restantes
                    dgvReceber2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados de receber2: " + ex.Message);
                }
            }
        }


        private void CarregarDadosReceber1()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para buscar os dados da tabela receber1, ordenados pela data (ou coluna relevante)
                    string query = "SELECT Codigo, NumDocto, Cliente, Valor, Status FROM receber1 ORDER BY NumDocto DESC";

                    // Cria um DataAdapter para executar a consulta e preencher um DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados da consulta
                    dataAdapter.Fill(dataTable);

                    // Verifica se algum vencimento de receber2 está ultrapassado e atualiza o status de receber1
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string numDocto = row["NumDocto"].ToString();

                        // Consulta SQL para verificar os vencimentos de receber2
                        string vencimentoQuery = "SELECT Vencimento FROM receber2 WHERE NumDocto = @NumDocto";
                        MySqlCommand cmdVencimento = new MySqlCommand(vencimentoQuery, conn);
                        cmdVencimento.Parameters.AddWithValue("@NumDocto", numDocto);

                        // Executa a consulta para buscar o vencimento mais recente
                        object vencimentoObj = cmdVencimento.ExecuteScalar();

                        if (vencimentoObj != DBNull.Value && vencimentoObj != null)
                        {
                            DateTime vencimento = Convert.ToDateTime(vencimentoObj);
                            if (vencimento < DateTime.Now) // Se o vencimento estiver ultrapassado
                            {
                                // Atualiza o status de receber1 para "Atrasado"
                                string updateStatusQuery = "UPDATE receber1 SET Status = 'Atrasado' WHERE NumDocto = @NumDocto";
                                MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                                cmdUpdateStatus.Parameters.AddWithValue("@NumDocto", numDocto);
                                cmdUpdateStatus.ExecuteNonQuery();
                            }
                        }
                    }

                    // Vincula o DataTable ao BindingSource
                    bindingSourceReceber1.DataSource = dataTable;

                    // Vincula o BindingSource ao DataGridView
                    dgvReceber1.DataSource = bindingSourceReceber1;

                    // Modifica os cabeçalhos das colunas
                    dgvReceber1.Columns["NumDocto"].HeaderText = "Núm. Docto.";
                    dgvReceber1.Columns["Valor"].HeaderText = "Valor";

                    // Ajustar o tamanho das colunas
                    dgvReceber1.Columns["NumDocto"].Width = 120; // Ajuste o tamanho conforme necessário
                    dgvReceber1.Columns["Cliente"].Width = 200;  // Ajuste o tamanho conforme necessário
                    dgvReceber1.Columns["Valor"].Width = 150;    // Ajuste o tamanho conforme necessário

                    // Opcional: Auto ajustar as colunas restantes
                    dgvReceber1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados de receber1: " + ex.Message);
                }
            }
        }
    }
}