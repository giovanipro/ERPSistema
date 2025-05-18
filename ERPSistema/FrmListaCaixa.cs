using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // Adicione esta linha

namespace ERPSistema
{
    public partial class FrmListaCaixa : Form
    {
        // Connection string para conectar ao MySQL (ajuste conforme necessário)
        private string connectionString = "Server=localhost;Port=3306;Database=database;Uid=root";

        public FrmListaCaixa()
        {
            InitializeComponent();
        }

        // Evento que ocorre quando o formulário é carregado
        private void FrmListaCaixa_Load(object sender, EventArgs e)
        {
            CarregarCaixa();
        }

        // Evento que ocorre quando o texto no campo de consulta é alterado
        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtConsulta.Text.ToLower(); // Obtém o texto da consulta e converte para minúsculo

            // Se o campo de consulta estiver vazio, limpa o filtro
            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Limpa o filtro
                (dgvListaCaixa.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                return;
            }

            // Cria a expressão de filtro para as colunas do DataGridView
            string filterExpression = string.Empty;

            foreach (DataGridViewColumn column in dgvListaCaixa.Columns)
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
                (dgvListaCaixa.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
            else
            {
                // Limpa o filtro
                (dgvListaCaixa.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        // Evento que ocorre quando um item do DataGridView é duplamente clicado
        private void dgvListaCaixa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se a linha selecionada é válida
            if (e.RowIndex >= 0)
            {
                // Obter o código da linha clicada
                int codigoCaixa = Convert.ToInt32(dgvListaCaixa.Rows[e.RowIndex].Cells["Codigo"].Value);

                // Abrir o formulário FrmConsultaCaixa e passar o código do caixa
                FrmConsultaCaixa frmConsultaCaixa = new FrmConsultaCaixa(codigoCaixa);
                frmConsultaCaixa.Show();
            }
        }

        // Função para carregar os dados no DataGridView
        public void CarregarCaixa()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))  // Alterado para MySqlConnection
            {
                try
                {
                    // Consulta SQL para carregar os dados da tabela abrircaixa
                    string query = "SELECT Codigo, CodigoUsuario, Status, Observacao, HoraAbertura, DataAbertura, HoraFechamento, DataFechamento FROM abrircaixa";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);  // Alterado para MySqlDataAdapter
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Definir a fonte de dados para o DataGridView
                    dgvListaCaixa.DataSource = dt;

                    // Organizar e renomear as colunas conforme solicitado
                    dgvListaCaixa.Columns["Codigo"].HeaderText = "Código";
                    dgvListaCaixa.Columns["HoraAbertura"].HeaderText = "Hora Abertura";
                    dgvListaCaixa.Columns["DataAbertura"].HeaderText = "Data Abertura";
                    dgvListaCaixa.Columns["DataFechamento"].HeaderText = "Data Fechamento";
                    dgvListaCaixa.Columns["HoraFechamento"].HeaderText = "Hora Fechamento";
                    dgvListaCaixa.Columns["Status"].HeaderText = "Status";
                    dgvListaCaixa.Columns["Observacao"].HeaderText = "Observação";
                    dgvListaCaixa.Columns["CodigoUsuario"].HeaderText = "Código Usuário";  // Renomeado corretamente

                    // Organizar as colunas conforme a sequência desejada
                    dgvListaCaixa.Columns["Codigo"].DisplayIndex = 0; // Código na primeira posição
                    dgvListaCaixa.Columns["CodigoUsuario"].DisplayIndex = 1; // CodigoUsuario na segunda posição
                    dgvListaCaixa.Columns["HoraAbertura"].DisplayIndex = 2;
                    dgvListaCaixa.Columns["DataAbertura"].DisplayIndex = 3;
                    dgvListaCaixa.Columns["DataFechamento"].DisplayIndex = 4;
                    dgvListaCaixa.Columns["HoraFechamento"].DisplayIndex = 5;
                    dgvListaCaixa.Columns["Status"].DisplayIndex = 6;
                    dgvListaCaixa.Columns["Observacao"].DisplayIndex = 7;

                    // Aumentar o tamanho da coluna "Observação"
                    dgvListaCaixa.Columns["Observacao"].Width = 250;  // Ajuste conforme necessário

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }
    }
}
