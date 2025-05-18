using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmConsultaPagar : Form
    {
        // Defina a string de conexão com o seu banco de dados
        string connectionString = "Server=localhost;Database=database;Uid=root;";

        public FrmConsultaPagar()
        {
            InitializeComponent();
            dgvPagar1.CellDoubleClick += dgvPagar1_CellDoubleClick;
        }

        private void FrmConsultaPagar_Load(object sender, EventArgs e)
        {
            // Carregar os dados no DataGridView ao carregar o formulário
            CarregarPagar();
            dgvPagar1.CellFormatting += dgvPagar1_CellFormatting;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPagar1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowPagar1 = dgvPagar1.SelectedRows[0];
                string descricao = selectedRowPagar1.Cells["Descricao"].Value.ToString();
                decimal valor = Convert.ToDecimal(selectedRowPagar1.Cells["Valor"].Value);
                string status = selectedRowPagar1.Cells["Status"].Value.ToString();
                int codigoPagar1 = Convert.ToInt32(selectedRowPagar1.Cells["Codigo"].Value);

                FrmCadastroPagar frmCadastroPagar = new FrmCadastroPagar(codigoPagar1);
                frmCadastroPagar.txtDesc.Text = descricao;
                frmCadastroPagar.txtValor.Text = valor.ToString("F2");
                frmCadastroPagar.cmbStatus1.Text = status;
                frmCadastroPagar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha na tabela Pagar.");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            dgvPagar1.ClearSelection();
            FrmCadastroPagar frmCadastroPagar = new FrmCadastroPagar(0);
            frmCadastroPagar.ShowDialog();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvPagar1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRowPagar1 = dgvPagar1.SelectedRows[0];
                int codigoPagar1 = Convert.ToInt32(selectedRowPagar1.Cells["Codigo"].Value);

                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir este registro?", "Confirmar Exclusão", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            string queryDelete = "DELETE FROM pagar1 WHERE Codigo = @Codigo";
                            MySqlCommand cmdDelete = new MySqlCommand(queryDelete, conn);
                            cmdDelete.Parameters.AddWithValue("@Codigo", codigoPagar1);
                            cmdDelete.ExecuteNonQuery();
                        }

                        MessageBox.Show("Registro excluído com sucesso!");
                        CarregarPagar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir o registro: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para excluir.");
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtConsulta.Text.ToLower(); // Obtém o texto da consulta e converte para minúsculo

            // Se o campo de consulta estiver vazio, limpa o filtro
            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Limpa o filtro
                (dgvPagar1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                return;
            }

            // Cria a expressão de filtro para as colunas do DataGridView
            string filterExpression = string.Empty;

            foreach (DataGridViewColumn column in dgvPagar1.Columns)
            {
                if (column.Visible) // Verifica se a coluna está visível
                {
                    string columnName = column.Name; // Usa o nome técnico da coluna no DataGridView

                    // Aplica o filtro nas colunas do tipo string
                    if (column.ValueType == typeof(string))
                    {
                        filterExpression += $"{columnName} LIKE '%{filtro}%' OR ";
                    }
                    // Aplica o filtro nas colunas numéricas, se for necessário
                    else if (column.ValueType == typeof(int) || column.ValueType == typeof(decimal) || column.ValueType == typeof(double))
                    {
                        if (int.TryParse(filtro, out int numericValue))
                        {
                            filterExpression += $"{columnName} = {numericValue} OR ";
                        }
                        else
                        {
                            // Ignora filtros numéricos caso o valor inserido não seja um número válido
                            continue;
                        }
                    }
                }
            }

            // Remove o último "OR" se houver
            if (filterExpression.EndsWith(" OR "))
            {
                filterExpression = filterExpression.Substring(0, filterExpression.Length - 4);
            }

            // Aplica o filtro ao DataTable associado ao DataGridView
            if (!string.IsNullOrEmpty(filterExpression))
            {
                (dgvPagar1.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
            else
            {
                // Limpa o filtro
                (dgvPagar1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }


        private void dgvPagar1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se uma linha foi selecionada (não deve ser uma célula de cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Chama a função de editar, simulando o clique no botão
                btnEditar_Click(sender, e);
            }
        }

        // Evento para formatar as células da DataGridView
        private void dgvPagar1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar se estamos na coluna 'Status' (supondo que a coluna "Status" seja a 3ª coluna)
            if (dgvPagar1.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString().ToLower(); // Pega o valor da célula e converte para minúsculo

                    // Verificar o valor e aplicar a cor correspondente
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

        public void CarregarPagar()
        {
            // Consulta SQL para pegar os dados da tabela pagar1
            string queryPagar1 = "SELECT Codigo, Descricao, Valor, Status FROM pagar1";

            // Cria a conexão com o banco de dados
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(queryPagar1, conn);

                    // Cria um DataTable para armazenar os dados
                    DataTable dtPagar1 = new DataTable();

                    // Preenche o DataTable com os dados
                    dataAdapter.Fill(dtPagar1);

                    // Atribui os dados ao DataGridView
                    dgvPagar1.DataSource = dtPagar1;

                    // Após carregar os dados de pagar1, verificar se é necessário atualizar o status de pagar1
                    foreach (DataRow rowPagar1 in dtPagar1.Rows)
                    {
                        int codigoPagar1 = Convert.ToInt32(rowPagar1["Codigo"]);
                        string statusPagar1 = rowPagar1["Status"].ToString().ToLower();

                        // Verificar se o status de pagar1 já é "Pago", se sim, não atualiza
                        if (statusPagar1 == "pago")
                        {
                            continue;
                        }

                        // Variáveis para controle de status
                        bool todosPago = true;  // Variável para verificar se todos os Status de pagar2 são "Pago"
                        bool temEmAndamento = false; // Variável para verificar se existe algum "Em Andamento"
                        bool temAtrasado = false; // Variável para verificar se existe algum "Atrasado"

                        // Consulta para verificar se há algum registro relacionado em pagar2
                        string queryPagar2 = "SELECT Status, Vencimento FROM pagar2 WHERE NumDocto = @Codigo";
                        MySqlCommand cmdPagar2 = new MySqlCommand(queryPagar2, conn);
                        cmdPagar2.Parameters.AddWithValue("@Codigo", codigoPagar1);

                        MySqlDataReader readerPagar2 = cmdPagar2.ExecuteReader();

                        while (readerPagar2.Read())
                        {
                            string statusPagar2 = readerPagar2["Status"].ToString().ToLower();
                            DateTime vencimento = Convert.ToDateTime(readerPagar2["Vencimento"]);

                            // Se encontrar algum Status diferente de "Pago", marca como não "Todos Pago"
                            if (statusPagar2 != "pago")
                            {
                                todosPago = false;
                            }

                            // Verificar se existe algum status "Em Andamento" em pagar2 para o pagar1
                            if (statusPagar2 == "em andamento")
                            {
                                temEmAndamento = true;
                            }

                            // Verificar se existe algum status "Atrasado" em pagar2 para o pagar1
                            if (statusPagar2 == "atrasado")
                            {
                                temAtrasado = true;
                            }
                        }
                        readerPagar2.Close(); // Fechar o DataReader

                        // Atualizar o status de pagar1 com a lógica de prioridade

                        // Se todos os Status de pagar2 forem "Pago", atualizar o Status de pagar1 para "Pago"
                        if (todosPago)
                        {
                            string updateStatusQuery = "UPDATE pagar1 SET Status = 'Pago' WHERE Codigo = @Codigo";
                            MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                            cmdUpdateStatus.Parameters.AddWithValue("@Codigo", codigoPagar1);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                        else if (temEmAndamento)
                        {
                            // Se houver ao menos um "Em Andamento", atualizar o Status de pagar1 para "Em Andamento"
                            string updateStatusQuery = "UPDATE pagar1 SET Status = 'Em Andamento' WHERE Codigo = @Codigo";
                            MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                            cmdUpdateStatus.Parameters.AddWithValue("@Codigo", codigoPagar1);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                        else if (temAtrasado)
                        {
                            // Se houver ao menos um "Atrasado", atualizar o Status de pagar1 para "Atrasado"
                            string updateStatusQuery = "UPDATE pagar1 SET Status = 'Atrasado' WHERE Codigo = @Codigo";
                            MySqlCommand cmdUpdateStatus = new MySqlCommand(updateStatusQuery, conn);
                            cmdUpdateStatus.Parameters.AddWithValue("@Codigo", codigoPagar1);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                    }

                    // Após a atualização, forçar o DataGridView a atualizar
                    dgvPagar1.Refresh(); // Forçar o DataGridView a atualizar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados de pagar1: " + ex.Message);
                }
            }
        }
    }
}