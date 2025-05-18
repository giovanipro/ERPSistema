using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmCidades : Form
    {
        private MySqlConnection conn;
        string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";
        private Timer timer = new Timer();
        private const int DELAY = 500;  // 500 ms de atraso para realizar a pesquisa

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Quando o timer "disparar", chama o método de atualização
            AtualizarDataGridView(txtConsulta.Text);
            timer.Stop();  // Para o timer após a pesquisa
        }

        public FrmCidades()
        {
            InitializeComponent();
            // Inicializa o timer
            timer.Interval = DELAY;
            timer.Tick += Timer_Tick;
        }

        // Evento de Form Load - Conectar ao banco
        private void FrmCidades_Load(object sender, EventArgs e)
        {
            txtConsulta.Focus();
        }

        // Evento para o botão 'Selecionar'
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            // Verificar se alguma linha foi selecionada
            if (dgvCidades.SelectedRows.Count > 0)
            {
                // Obter os dados da linha selecionada
                DataGridViewRow linhaSelecionada = dgvCidades.SelectedRows[0];
                string nomeCidade = linhaSelecionada.Cells["descricao_cidade"].Value.ToString();  // Nome da cidade
                string ufCidade = linhaSelecionada.Cells["UF"].Value.ToString();  // Estado (UF)
                string cepCidade = linhaSelecionada.Cells["CEP"].Value.ToString();  // CEP

                // Remover o hífen do CEP, caso esteja presente
                cepCidade = cepCidade.Replace("-", "");

                // Definir a consulta SQL para buscar os dados de logradouro
                string query = "SELECT descricao, descricao_bairro, complemento, descricao_cidade, UF " +
                               "FROM logradouro WHERE TRIM(descricao_cidade) = @descricaoCidade AND TRIM(CEP) = @cepCidade";

                // Criar a conexão e o comando SQL para MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Abre a conexão
                        conn.Open();

                        // Cria o comando SQL
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Adiciona os parâmetros para evitar SQL Injection
                            cmd.Parameters.AddWithValue("@descricaoCidade", nomeCidade);
                            cmd.Parameters.AddWithValue("@cepCidade", cepCidade);

                            // Executa a consulta e obtém os dados
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read()) // Se encontrar algum resultado
                                {
                                    // Acessar o FrmCadastroPessoas e passar os valores
                                    FrmCadastroPessoas frmCadastro = Application.OpenForms["FrmCadastroPessoas"] as FrmCadastroPessoas;
                                    if (frmCadastro != null)
                                    {
                                        // Preencher os campos com os dados retornados da consulta
                                        frmCadastro.txtLogradouro.Text = reader["descricao"].ToString();
                                        frmCadastro.txtBairro.Text = reader["descricao_bairro"].ToString();
                                        frmCadastro.txtComplemento.Text = reader["complemento"].ToString();
                                        frmCadastro.txtCidade.Text = reader["descricao_cidade"].ToString();
                                        frmCadastro.txtUF.Text = reader["UF"].ToString();

                                        // Passa os dados da cidade para o formulário
                                        frmCadastro.txtCidade.Text = nomeCidade;
                                        frmCadastro.txtUF.Text = ufCidade;
                                        frmCadastro.CodigoCidade = Convert.ToInt32(cepCidade);  // Passa o 'CEP' como Código da cidade (se aplicável)

                                        // Preencher o campo txtCEP com o valor do CEP
                                        frmCadastro.txtCEP.Text = cepCidade;

                                        // Foca no campo numero
                                        frmCadastro.txtNumero.Focus();  // Foca no campo número
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Não foram encontrados dados de logradouro para a cidade selecionada.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao buscar os dados de logradouro: " + ex.Message);
                    }
                }

                // Fechar o formulário de Cidades
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione uma cidade da lista.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento para o TextBox (txtConsulta) - Atualizar a pesquisa ao digitar 3 ou mais caracteres
        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            if (txtConsulta.Text.Length >= 3)
            {
                // Inicia o timer sempre que o texto mudar
                timer.Stop();  // Para o timer anterior, caso o texto esteja sendo alterado rapidamente
                timer.Start();  // Inicia o timer para disparar a pesquisa após o delay
            }
        }

        private void dgvCidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o clique foi em uma linha válida (ignorando a linha de cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Chama a função associada ao botão btnSelecionar
                btnSelecionar_Click(sender, e);
            }
        }

        // Método para buscar logradouros e atualizar o DataGridView
        private void AtualizarDataGridView(string consulta)
        {
            try
            {
                // Abrir conexão com o banco
                conn.Open();

                // Consulta SQL para buscar os campos desejados na tabela logradouro
                string query = "SELECT CEP, id_logradouro, descricao, UF, complemento, descricao_cidade, descricao_bairro " +
                               "FROM logradouro WHERE  " +
                               "LOWER(CEP) LIKE LOWER(@consulta) " +
                               "OR LOWER(UF) LIKE LOWER(@consulta) " +
                               "OR LOWER(descricao_cidade) LIKE LOWER(@consulta) ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@consulta", "%" + consulta.ToLower() + "%");

                // Carregar os resultados na DataGridView
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Atribuir os dados à DataGridView
                dgvCidades.DataSource = dt;

                // Ajustar o tamanho das colunas para melhor exibição
                dgvCidades.Columns["CEP"].Width = 120;  // Ajusta a largura da coluna CEP
                dgvCidades.Columns["id_logradouro"].Width = 120; // Ajusta a largura da coluna id_logradouro
                dgvCidades.Columns["descricao"].Width = 300;  // Ajusta a largura da coluna descricao
                dgvCidades.Columns["UF"].Width = 120;  // Ajusta a largura da coluna UF
                dgvCidades.Columns["complemento"].Width = 200;  // Ajusta a largura da coluna complemento
                dgvCidades.Columns["descricao_cidade"].Width = 200; // Ajusta a largura da coluna descricao_cidade
                dgvCidades.Columns["descricao_bairro"].Width = 200; // Ajusta a largura da coluna descricao_bairro

                // Renomear as colunas para exibição
                dgvCidades.Columns["CEP"].HeaderText = "CEP";  // Renomeia a coluna CEP
                dgvCidades.Columns["id_logradouro"].HeaderText = "ID Logradouro";  // Renomeia a coluna id_logradouro
                dgvCidades.Columns["descricao"].HeaderText = "Logradouro";  // Renomeia a coluna descricao
                dgvCidades.Columns["UF"].HeaderText = "UF";  // Renomeia a coluna UF
                dgvCidades.Columns["complemento"].HeaderText = "Complemento";  // Renomeia a coluna complemento
                dgvCidades.Columns["descricao_cidade"].HeaderText = "Cidade";  // Renomeia a coluna descricao_cidade
                dgvCidades.Columns["descricao_bairro"].HeaderText = "Bairro";  // Renomeia a coluna descricao_bairro

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar logradouros: " + ex.Message);
            }
            finally
            {
                // Fechar a conexão
                conn.Close();
            }
        }
    }
}