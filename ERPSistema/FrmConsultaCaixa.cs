using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmConsultaCaixa : Form
    {
        // String de conexão com o banco de dados
        private string connectionString = "server=localhost;user=root;database=database;port=3306;";
        private int numCaixa;

        public FrmConsultaCaixa(int numCaixa)
        {
            this.numCaixa = numCaixa;
            InitializeComponent();
        }

        private void FrmCaixa_Load(object sender, EventArgs e)
        {
            // Carregar os dados no DataGridView e atualizar o saldo
            CarregarCaixa();
            pnlTroco.Visible = false;
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir conexão
                    connection.Open();

                    // Comando SQL para excluir todos os dados da tabela caixacardex
                    string queryDelete = "DELETE FROM caixacardex WHERE NumCaixa = @numCaixa";
                    MySqlCommand command = new MySqlCommand(queryDelete, connection);
                    command.Parameters.AddWithValue("@numCaixa", numCaixa);

                    // Executar o comando de exclusão
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Todos os dados foram excluídos com sucesso.");
                    }
                    else
                    {
                        MessageBox.Show("Não há dados para excluir.");
                    }

                    // Após deletar os dados, recarregar a tabela
                    CarregarCaixa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao resetar os dados do caixa: " + ex.Message);
                }
            }
        }

        private void btnTroco_Click(object sender, EventArgs e)
        {
            pnlTroco.Visible = true;
            txtValor.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se o valor do troco (txtValor) foi preenchido
                decimal valorEntrada;
                if (decimal.TryParse(txtValor.Text, out valorEntrada) && valorEntrada > 0)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        // Abrir a conexão
                        connection.Open();

                        // Obter o último saldo da tabela caixacardex para o numCaixa
                        string querySaldo = @"
                SELECT SaldoAtual 
                FROM caixacardex 
                WHERE NumCaixa = @NumCaixa 
                ORDER BY Codigo DESC LIMIT 1";

                        MySqlCommand cmdSaldo = new MySqlCommand(querySaldo, connection);
                        cmdSaldo.Parameters.AddWithValue("@NumCaixa", numCaixa);
                        object result = cmdSaldo.ExecuteScalar();

                        // Se existir um saldo anterior, utilize ele, senão, inicialize o saldo como 0
                        decimal saldoAnterior = result != null ? Convert.ToDecimal(result) : 0;

                        // Calcular o novo saldo atual
                        decimal saldoAtual = saldoAnterior + valorEntrada;

                        // Inserir o novo registro na tabela caixacardex
                        string queryInsert = @"
                INSERT INTO caixacardex (Data, Hora, Tipo, Valor, Descricao, NumCaixa, SaldoAnterior, ValorEntrada, ValorSaida, SaldoAtual, IdFormaPgto)
                VALUES (@Data, @Hora, @Tipo, @Valor, @Descricao, @NumCaixa, @SaldoAnterior, @ValorEntrada, @ValorSaida, @SaldoAtual, @IdFormaPgto)";

                        MySqlCommand cmdInsert = new MySqlCommand(queryInsert, connection);
                        cmdInsert.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmdInsert.Parameters.AddWithValue("@Hora", DateTime.Now.ToString("HH:mm:ss"));
                        cmdInsert.Parameters.AddWithValue("@Tipo", "Entrada");  // Tipo "Entrada"
                        cmdInsert.Parameters.AddWithValue("@Valor", valorEntrada); // O valor que está sendo inserido
                        cmdInsert.Parameters.AddWithValue("@Descricao", "Entrada de Troco"); // Descrição
                        cmdInsert.Parameters.AddWithValue("@NumCaixa", numCaixa);  // Número do caixa
                        cmdInsert.Parameters.AddWithValue("@SaldoAnterior", saldoAnterior); // Saldo anterior
                        cmdInsert.Parameters.AddWithValue("@ValorEntrada", valorEntrada); // O valor da entrada
                        cmdInsert.Parameters.AddWithValue("@ValorSaida", 0); // Não há saída nesse caso
                        cmdInsert.Parameters.AddWithValue("@SaldoAtual", saldoAtual); // Novo saldo atual
                        cmdInsert.Parameters.AddWithValue("@IdFormaPgto", 7); // Forma de pagamento (assumindo que é 7)

                        // Executar o comando de inserção
                        cmdInsert.ExecuteNonQuery();

                        // Mostrar mensagem de sucesso
                        MessageBox.Show("Entrada de troco registrada com sucesso!");
                        pnlTroco.Visible = false;
                        // Após inserir, recarregar os dados do caixa para atualizar o saldo
                        CarregarCaixa();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o troco.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar a entrada de troco: " + ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar2_Click(object sender, EventArgs e)
        {
            pnlTroco.Visible = false;
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtConsulta.Text.ToLower(); // Obtém o texto no campo de consulta e converte para minúsculo

            // Filtra as linhas da DataGridView com base no texto da consulta
            foreach (DataGridViewRow row in dgvCaixa.Rows)
            {
                // Verifica se alguma coluna contém o texto digitado
                bool isVisible = false;

                // Verifique se qualquer uma das colunas contém o texto pesquisado
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(filtro))
                    {
                        isVisible = true;
                        break; // Se encontrar, não precisa continuar verificando outras colunas
                    }
                }

                // Atualiza a visibilidade da linha
                row.Visible = isVisible;
            }
        }

        private void CarregarCaixa()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Consulta SQL para pegar o saldo mais recente
                    string query = @"
SELECT Codigo AS 'Num. Lanc.', 
       IdVenda AS 'Num. Venda', 
       Data, 
       Hora, 
       Tipo, 
       ValorEntrada AS 'Valor Entrada', 
       ValorSaida AS 'Valor Saída', 
       SaldoAtual AS 'Saldo Atual',
       Descricao AS 'Descrição'
FROM caixacardex 
WHERE NumCaixa = @numCaixa
ORDER BY Codigo DESC"; // Ordena do mais recente para o mais antigo

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@numCaixa", numCaixa);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Definir a fonte de dados para o DataGridView (dgvCaixa)
                    dgvCaixa.DataSource = dt;

                    // Ocultar todas as colunas primeiro
                    foreach (DataGridViewColumn coluna in dgvCaixa.Columns)
                    {
                        coluna.Visible = false;
                    }

                    // Verifique se a coluna "Descrição" existe antes de torná-la visível
                    if (dgvCaixa.Columns.Contains("Descrição"))
                    {
                        dgvCaixa.Columns["Descrição"].Visible = true;  // Mostrar a coluna Descrição
                    }

                    // Exibir as outras colunas
                    dgvCaixa.Columns["Num. Lanc."].Visible = true;
                    dgvCaixa.Columns["Num. Venda"].Visible = true;
                    dgvCaixa.Columns["Data"].Visible = true;
                    dgvCaixa.Columns["Hora"].Visible = true;
                    dgvCaixa.Columns["Tipo"].Visible = true;
                    dgvCaixa.Columns["Valor Entrada"].Visible = true;
                    dgvCaixa.Columns["Valor Saída"].Visible = true;
                    dgvCaixa.Columns["Saldo Atual"].Visible = true;

                    // Ajustar a ordem das colunas
                    dgvCaixa.Columns["Descrição"].DisplayIndex = 0;  // Mover a coluna "Descrição" para a primeira posição
                    dgvCaixa.Columns["Num. Lanc."].DisplayIndex = 1;
                    dgvCaixa.Columns["Num. Venda"].DisplayIndex = 2;
                    dgvCaixa.Columns["Data"].DisplayIndex = 3;
                    dgvCaixa.Columns["Hora"].DisplayIndex = 4;
                    dgvCaixa.Columns["Tipo"].DisplayIndex = 5;
                    dgvCaixa.Columns["Valor Entrada"].DisplayIndex = 6;
                    dgvCaixa.Columns["Valor Saída"].DisplayIndex = 7;
                    dgvCaixa.Columns["Saldo Atual"].DisplayIndex = 8;

                    // Ajustar largura das colunas
                    dgvCaixa.Columns["Descrição"].Width = 200;

                    // Variáveis para acumular os valores de entradas e retiradas
                    decimal totalEntradas = 0;
                    decimal totalRetiradas = 0;
                    decimal saldoAtual = 0;

                    // Percorrer todas as linhas e somar os valores de Entrada e Saída
                    foreach (DataRow row in dt.Rows)
                    {
                        totalEntradas += Convert.ToDecimal(row["Valor Entrada"]);
                        totalRetiradas += Convert.ToDecimal(row["Valor Saída"]);
                    }

                    // Obter o saldo mais recente da última linha carregada
                    if (dt.Rows.Count > 0)
                    {
                        saldoAtual = Convert.ToDecimal(dt.Rows[0]["Saldo Atual"]);
                    }

                    // Atualizar os labels
                    lblEntradas.Text = totalEntradas.ToString("C");
                    lblRetiradas.Text = totalRetiradas.ToString("C");
                    lblSaldo.Text = saldoAtual.ToString("C");

                    // Alterar a cor de lblSaldo dependendo do valor
                    if (saldoAtual >= 0)
                    {
                        lblSaldo.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblSaldo.ForeColor = System.Drawing.Color.Red;
                    }

                    // Agora, ocultar a coluna "Saldo Atual"
                    dgvCaixa.Columns["Saldo Atual"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados do caixa: " + ex.Message);
                }
            }
        }
    }
}
