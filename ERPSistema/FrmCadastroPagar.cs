using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmCadastroPagar : Form
    {
        // Defina a string de conexão com o seu banco de dados
        string connectionString = "Server=localhost;Database=database;Uid=root;";
        private int codigoPagar1; // Agora é do tipo int

        public FrmCadastroPagar(int codigoPagar1)
        {
            InitializeComponent();
            this.codigoPagar1 = codigoPagar1; // Armazena o valor inteiro passado
            // Associar o evento SelectionChanged
            dgvPagar2.SelectionChanged += dgvPagar2_SelectionChanged;
            // Carregar as opções de status nos ComboBoxes
            CarregarStatus();
        }

        private void FrmCadastroPagar_Load(object sender, EventArgs e)
        {
            // Carregar os dados de pagar2 com base no Código (int)
            CarregarPagar2(this.codigoPagar1);

            // Carregar as opções de parcelas no cmbParcela
            CarregarParcela(); // Agora carrega a lista de parcelas a partir da tabela "parcela"

            // Associar o evento CellFormatting para formatar a coluna Status
            dgvPagar2.CellFormatting += dgvPagar2_CellFormatting;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Verifica se está editando um registro existente ou se é um novo
                    if (codigoPagar1 == 0) // Se for um novo registro (código igual a 0)
                    {
                        // Inserir um novo registro no pagar1
                        string queryPagar1 = "INSERT INTO pagar1 (Descricao, Valor, Status) VALUES (@Descricao, @Valor, @Status)";
                        MySqlCommand cmdPagar1 = new MySqlCommand(queryPagar1, conn);
                        cmdPagar1.Parameters.AddWithValue("@Descricao", txtDesc.Text);
                        cmdPagar1.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                        cmdPagar1.Parameters.AddWithValue("@Status", cmbStatus1.Text); // Status será o valor de cmbStatus1
                        cmdPagar1.ExecuteNonQuery();

                        // Obter o Código gerado automaticamente (auto-increment)
                        MySqlCommand cmdGetCodigo = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                        var result = cmdGetCodigo.ExecuteScalar();
                        if (result != null)
                        {
                            codigoPagar1 = Convert.ToInt32(result); // Atribui o código gerado
                        }
                    }
                    else
                    {
                        // Se o registro já existe, atualiza os dados na tabela pagar1
                        string queryUpdatePagar1 = "UPDATE pagar1 SET Descricao = @Descricao, Valor = @Valor, Status = @Status WHERE Codigo = @Codigo";
                        MySqlCommand cmdUpdatePagar1 = new MySqlCommand(queryUpdatePagar1, conn);
                        cmdUpdatePagar1.Parameters.AddWithValue("@Descricao", txtDesc.Text);
                        cmdUpdatePagar1.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                        cmdUpdatePagar1.Parameters.AddWithValue("@Status", cmbStatus1.Text);
                        cmdUpdatePagar1.Parameters.AddWithValue("@Codigo", codigoPagar1); // Usando o código existente para atualizar
                        cmdUpdatePagar1.ExecuteNonQuery();
                    }

                    // Agora, definindo o valor da parcela
                    int numeroParcelas = Convert.ToInt32(cmbParcela.SelectedItem); // Número de parcelas selecionadas
                    decimal valorParcela = Convert.ToDecimal(txtValor.Text) / numeroParcelas; // Calcula o valor de cada parcela

                    DateTime dataVencimento = DateTime.Now.AddDays(30); // A primeira parcela terá 30 dias a partir de hoje

                    // Verificar se uma linha foi selecionada no DataGridView (dgvPagar2)
                    if (dgvPagar2.SelectedRows.Count > 0)
                    {
                        // Para cada linha selecionada, atualiza o registro
                        foreach (DataGridViewRow selectedRow in dgvPagar2.SelectedRows)
                        {
                            int pagar2Id = Convert.ToInt32(selectedRow.Cells["Codigo"].Value); // Supondo que você tenha uma coluna "Id" no dgvPagar2
                            string statusAtual = selectedRow.Cells["Status"].Value.ToString();

                            // Atualizar o registro da parcela na tabela pagar2
                            string queryUpdate = "UPDATE pagar2 SET Status = @Status WHERE Codigo = @Codigo";
                            MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn);
                            cmdUpdate.Parameters.AddWithValue("@Status", cmbStatus2.Text);
                            cmdUpdate.Parameters.AddWithValue("@Codigo", pagar2Id); // Atualizar com base no ID da linha selecionada
                            cmdUpdate.ExecuteNonQuery();

                            // Se o status for "Pago", inserir na tabela caixacardex
                            if (cmbStatus2.Text == "Pago")
                            {
                                // Obter o último saldo da tabela caixacardex
                                string querySaldo = "SELECT SaldoAtual FROM caixacardex ORDER BY Codigo DESC LIMIT 1";
                                MySqlCommand cmdSaldo = new MySqlCommand(querySaldo, conn);
                                decimal saldoAnterior = Convert.ToDecimal(cmdSaldo.ExecuteScalar());

                                // Inserir na tabela caixacardex
                                string queryCaixaCardex = "INSERT INTO caixacardex (Data, Hora, Tipo, Valor, Descricao, NumCaixa, SaldoAnterior, ValorEntrada, ValorSaida, SaldoAtual, IdFormaPgto) " +
                                    "VALUES (@Data, @Hora, @Tipo, @Valor, @Descricao, @NumCaixa, @SaldoAnterior, @ValorEntrada, @ValorSaida, @SaldoAtual, @IdFormaPgto)";

                                MySqlCommand cmdCaixaCardex = new MySqlCommand(queryCaixaCardex, conn);
                                cmdCaixaCardex.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd"));
                                cmdCaixaCardex.Parameters.AddWithValue("@Hora", DateTime.Now.ToString("HH:mm:ss"));
                                cmdCaixaCardex.Parameters.AddWithValue("@Tipo", "Saída");
                                cmdCaixaCardex.Parameters.AddWithValue("@Valor", valorParcela);
                                cmdCaixaCardex.Parameters.AddWithValue("@Descricao", "Contas á Pagar");
                                cmdCaixaCardex.Parameters.AddWithValue("@NumCaixa", 1); // Assumindo que o NumCaixa é 1
                                cmdCaixaCardex.Parameters.AddWithValue("@SaldoAnterior", saldoAnterior);
                                cmdCaixaCardex.Parameters.AddWithValue("@ValorEntrada", 0);
                                cmdCaixaCardex.Parameters.AddWithValue("@ValorSaida", valorParcela);
                                cmdCaixaCardex.Parameters.AddWithValue("@SaldoAtual", saldoAnterior - valorParcela);
                                cmdCaixaCardex.Parameters.AddWithValue("@IdFormaPgto", 7); // Assumindo que a forma de pagamento é 7
                                cmdCaixaCardex.ExecuteNonQuery();
                            }

                            // Adiciona 30 dias para o vencimento da próxima parcela
                            dataVencimento = dataVencimento.AddDays(30);
                        }
                    }
                    else
                    {
                        // Caso não tenha nenhuma linha selecionada, insere um novo registro para cada parcela
                        for (int i = 0; i < numeroParcelas; i++)
                        {
                            // Inserir um novo registro para a parcela na tabela pagar2
                            string queryPagar2 = "INSERT INTO pagar2 (Data, ValorParcela, Vencimento, Status, NumDocto) VALUES (@Data, @ValorParcela, @Vencimento, @Status, @NumDocto)";
                            MySqlCommand cmdPagar2 = new MySqlCommand(queryPagar2, conn);
                            cmdPagar2.Parameters.AddWithValue("@Data", dtpData.Value.ToString("yyyy-MM-dd"));
                            cmdPagar2.Parameters.AddWithValue("@ValorParcela", valorParcela);
                            cmdPagar2.Parameters.AddWithValue("@Vencimento", dataVencimento.ToString("yyyy-MM-dd"));
                            cmdPagar2.Parameters.AddWithValue("@Status", cmbStatus2.Text); // Status inicial
                            cmdPagar2.Parameters.AddWithValue("@NumDocto", codigoPagar1);
                            cmdPagar2.ExecuteNonQuery();

                            // Se o status da parcela for "Pago", inserir na tabela caixacardex
                            if (cmbStatus2.Text == "Pago")
                            {
                                // Obter o último saldo da tabela caixacardex
                                string querySaldo = "SELECT SaldoAtual FROM caixacardex ORDER BY Codigo DESC LIMIT 1";
                                MySqlCommand cmdSaldo = new MySqlCommand(querySaldo, conn);
                                decimal saldoAnterior = Convert.ToDecimal(cmdSaldo.ExecuteScalar());

                                // Inserir na tabela caixacardex
                                string queryCaixaCardex = "INSERT INTO caixacardex (Data, Hora, Tipo, Valor, Descricao, NumCaixa, SaldoAnterior, ValorEntrada, ValorSaida, SaldoAtual, IdFormaPgto) " +
                                    "VALUES (@Data, @Hora, @Tipo, @Valor, @Descricao, @NumCaixa, @SaldoAnterior, @ValorEntrada, @ValorSaida, @SaldoAtual, @IdFormaPgto)";

                                MySqlCommand cmdCaixaCardex = new MySqlCommand(queryCaixaCardex, conn);
                                cmdCaixaCardex.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd"));
                                cmdCaixaCardex.Parameters.AddWithValue("@Hora", DateTime.Now.ToString("HH:mm:ss"));
                                cmdCaixaCardex.Parameters.AddWithValue("@Tipo", "Saída");
                                cmdCaixaCardex.Parameters.AddWithValue("@Valor", valorParcela);
                                cmdCaixaCardex.Parameters.AddWithValue("@Descricao", "Contas á Pagar");
                                cmdCaixaCardex.Parameters.AddWithValue("@NumCaixa", 1); // Assumindo que o NumCaixa é 1
                                cmdCaixaCardex.Parameters.AddWithValue("@SaldoAnterior", saldoAnterior);
                                cmdCaixaCardex.Parameters.AddWithValue("@ValorEntrada", 0);
                                cmdCaixaCardex.Parameters.AddWithValue("@ValorSaida", valorParcela);
                                cmdCaixaCardex.Parameters.AddWithValue("@SaldoAtual", saldoAnterior - valorParcela);
                                cmdCaixaCardex.Parameters.AddWithValue("@IdFormaPgto", 7); // Assumindo que a forma de pagamento é 7
                                cmdCaixaCardex.ExecuteNonQuery();
                            }

                            // Adiciona 30 dias para o vencimento da próxima parcela
                            dataVencimento = dataVencimento.AddDays(30);
                        }
                    }

                    MessageBox.Show("Dados salvos com sucesso!");

                    // Carregar novamente os dados de pagar2 após salvar
                    CarregarPagar2(codigoPagar1);

                    FrmConsultaPagar frmConsultaPagar = (FrmConsultaPagar)Application.OpenForms["FrmConsultaPagar"];
                    if (frmConsultaPagar != null)
                    {
                        frmConsultaPagar.CarregarPagar(); // Chama o método para carregar os dados novamente
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            // Verificar se há uma linha selecionada
            if (dgvPagar2.SelectedRows.Count > 0)
            {
                try
                {
                    // Obter o código de 'pagar1' da linha selecionada (NumDocto que está relacionado ao pagar1)
                    int codigoPagar2 = Convert.ToInt32(dgvPagar2.SelectedRows[0].Cells["Codigo"].Value);

                    // Obter o 'NumDocto' (código do pagamento principal) que relaciona as parcelas
                    int codigoPagar1 = Convert.ToInt32(dgvPagar2.SelectedRows[0].Cells["NumDocto"].Value);

                    // Confirmar a exclusão
                    var confirmResult = MessageBox.Show("Tem certeza que deseja excluir todas as parcelas deste pagamento?", "Confirmar Exclusão", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // Conectar ao banco de dados e executar o comando DELETE
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();

                            // Query para deletar todas as parcelas relacionadas ao pagamento principal (pagar1)
                            string query = "DELETE FROM pagar2 WHERE NumDocto = @NumDocto";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@NumDocto", codigoPagar1); // Deletar todas as parcelas para o pagar1 relacionado

                            // Executar o comando de exclusão
                            cmd.ExecuteNonQuery();
                        }

                        // Mensagem de sucesso
                        MessageBox.Show("Todas as parcelas foram excluídas com sucesso!");

                        // Recarregar os dados na DataGridView
                        CarregarPagar2(codigoPagar1); // Recarrega os dados usando o código de pagar1 para filtrar as parcelas
                        dgvPagar2.Refresh();

                        // Atualizar a consulta principal (pagar1)
                        FrmConsultaPagar frmConsultaPagar = (FrmConsultaPagar)Application.OpenForms["FrmConsultaPagar"];
                        if (frmConsultaPagar != null)
                        {
                            frmConsultaPagar.CarregarPagar(); // Chama o método para carregar os dados novamente
                            frmConsultaPagar.dgvPagar1.Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Caso haja algum erro, exibir mensagem
                    MessageBox.Show("Erro ao excluir as parcelas: " + ex.Message);
                }
            }
            else
            {
                // Mensagem caso nenhuma linha seja selecionada
                MessageBox.Show("Por favor, selecione uma parcela para excluir.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento SelectedIndexChanged do cmbStatus2
        private void cmbStatus2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se a opção selecionada no cmbStatus2 é "Em Andamento" (índice 0)
            if (cmbStatus2.SelectedIndex == 0)  // Índice 0 é "Em Andamento"
            {
                // Define o índice 0 ("Em Andamento") no cmbStatus1
                cmbStatus1.SelectedIndex = 0;  // Assume que "Em Andamento" está no índice 0 de cmbStatus1 também
            }
        }

        private void dgvPagar2_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagar2.SelectedRows.Count > 0)
            {
                // Pega a linha selecionada
                DataGridViewRow selectedRow = dgvPagar2.SelectedRows[0];

                // Preenche os campos com os dados da linha selecionada
                dtpData.Value = Convert.ToDateTime(selectedRow.Cells["Data"].Value); // Data
                cmbParcela.Text = selectedRow.Cells["ValorParcela"].Value.ToString(); // ValorParcela
                cmbStatus2.SelectedItem = selectedRow.Cells["Status"].Value.ToString(); // Status
            }
        }

        private void CarregarPagar2(int codigoPagar1)
        {
            // Consulta SQL para pegar os dados da tabela pagar2 onde NumDocto é igual ao Codigo de pagar1
            string queryPagar2 = "SELECT Codigo, Data, ValorParcela, Vencimento, Status, NumDocto FROM pagar2 WHERE NumDocto = @Codigo";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Inicializando o DataAdapter com a query e conexão
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(queryPagar2, conn);

                    // Adiciona o parâmetro de código na consulta SQL
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Codigo", codigoPagar1);

                    // Cria um DataTable para armazenar os dados
                    DataTable dtPagar2 = new DataTable();

                    // Preenche o DataTable com os dados da consulta SQL
                    dataAdapter.Fill(dtPagar2);

                    // Verifica cada linha e atualiza o Status de acordo com as condições
                    foreach (DataRow row in dtPagar2.Rows)
                    {
                        DateTime vencimento = Convert.ToDateTime(row["Vencimento"]);
                        string statusPagar2 = row["Status"].ToString().ToLower(); // Pega o status de pagar2

                        // Se o status for "Pago", não faz nenhuma alteração
                        if (statusPagar2 == "pago")
                        {
                            continue; // Skip para o próximo loop, sem fazer nada
                        }

                        // Se a data de vencimento está ultrapassada e não for hoje, define como "Atrasado"
                        if (vencimento < DateTime.Now.Date)
                        {
                            int codigoPagar2 = Convert.ToInt32(row["Codigo"]);
                            string updateStatusQuery = "UPDATE pagar2 SET Status = 'Atrasado' WHERE Codigo = @Codigo";

                            MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                            cmdUpdateStatus.Parameters.AddWithValue("@Codigo", codigoPagar2);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                        // Se a data de vencimento for hoje, define como "Em Andamento"
                        else if (vencimento.Date == DateTime.Now.Date)
                        {
                            int codigoPagar2 = Convert.ToInt32(row["Codigo"]);
                            string updateStatusQuery = "UPDATE pagar2 SET Status = 'Em Andamento' WHERE Codigo = @Codigo";

                            MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                            cmdUpdateStatus.Parameters.AddWithValue("@Codigo", codigoPagar2);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                        else
                        {
                            // Se a data de vencimento não está ultrapassada e não é hoje, define como "Em Andamento"
                            int codigoPagar2 = Convert.ToInt32(row["Codigo"]);
                            string updateStatusQuery = "UPDATE pagar2 SET Status = 'Em Andamento' WHERE Codigo = @Codigo";

                            MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                            cmdUpdateStatus.Parameters.AddWithValue("@Codigo", codigoPagar2);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                    }

                    // Atribui os dados ao DataGridView dgvPagar2
                    dgvPagar2.DataSource = dtPagar2;
                }
                catch (Exception ex)
                {
                    // Caso ocorra algum erro, mostra a mensagem
                    MessageBox.Show("Erro ao carregar os dados de pagar2: " + ex.Message);
                }
            }
        }

        private void CarregarStatus()
        {
            // Adiciona os valores "Em Andamento", "Pago" e "Atrasado" aos ComboBoxes
            cmbStatus1.Items.Clear();
            cmbStatus2.Items.Clear();

            cmbStatus1.Items.Add("Em Andamento");
            cmbStatus1.Items.Add("Pago");
            cmbStatus1.Items.Add("Atrasado");

            cmbStatus2.Items.Add("Em Andamento");
            cmbStatus2.Items.Add("Pago");
            cmbStatus2.Items.Add("Atrasado");

            // Definir um valor padrão se necessário (opcional)
            cmbStatus1.SelectedIndex = 0; // Padrão como "Em Andamento"
            cmbStatus2.SelectedIndex = 0; // Padrão como "Em Andamento"
        }

        private void CarregarParcela()
        {
            // Consulta para carregar as opções de parcelas da tabela "parcela" no cmbParcela
            string query = "SELECT Vezes FROM parcela";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Inicializando o DataAdapter com a consulta e a conexão
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);

                    // Criar um DataTable para armazenar os dados
                    DataTable dtParcela = new DataTable();

                    // Preencher o DataTable com os dados da consulta
                    dataAdapter.Fill(dtParcela);

                    // Preencher o cmbParcela com os valores da coluna Vezes
                    cmbParcela.Items.Clear();
                    foreach (DataRow row in dtParcela.Rows)
                    {
                        cmbParcela.Items.Add(row["Vezes"]);
                    }

                    // Definir um valor padrão, por exemplo, o primeiro item da lista
                    if (cmbParcela.Items.Count > 0)
                    {
                        cmbParcela.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar as opções de parcelas: " + ex.Message);
                }
            }
        }

        private void dgvPagar2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a coluna sendo formatada é a coluna "Status"
            if (dgvPagar2.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString().ToLower(); // Obtém o valor da célula e converte para minúsculo

                    // Define a cor de fundo da célula dependendo do valor do Status
                    if (status == "em andamento")
                    {
                        e.CellStyle.BackColor = Color.Yellow; // Amarelo para "Em Andamento"
                    }
                    else if (status == "pago")
                    {
                        e.CellStyle.BackColor = Color.Green; // Verde para "Pago"
                    }
                    else if (status == "atrasado")
                    {
                        e.CellStyle.BackColor = Color.Red; // Vermelho para "Atrasado"
                    }
                }
            }
        }
    }
}