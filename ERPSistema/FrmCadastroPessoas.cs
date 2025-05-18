using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ERPSistema
{
    public partial class FrmCadastroPessoas : Form
    {
        // Propriedades
        public string Codigo { get; set; }
        public string Destinatario { get; set; }
        public string CNPJCPF { get; set; }
        public string idEstrangeiroRG { get; set; }
        public string Fantasia { get; set; }
        public string Razao { get; set; }
        public string TipoPessoa { get; set; }
        public string CodigoPessoa { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public int CodigoCidade { get; set; }

        // Conexão e outros componentes
        private MySqlConnection connection;
        private FrmConsultaPessoas frmConsulta;
        private string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        public FrmCadastroPessoas(FrmConsultaPessoas consulta)
        {
            InitializeComponent();
            this.Shown += FrmCadastroPessoas_Shown; // Evento para foco
            this.frmConsulta = consulta;
            connection = new MySqlConnection(connectionString);
        }


        #region Eventos de Tela

        // Evento ao carregar o formulário
        private void FrmCadastroPessoas_Load(object sender, EventArgs e)
        {
            // Preenche os campos com dados existentes, se aplicável
            txtDestinatario.Text = Destinatario;
            txtCNPJCPF.Text = CNPJCPF;
            txtIERG.Text = idEstrangeiroRG;
            txtFantasia.Text = Fantasia;

            // Restante da lógica de carregamento dos dados
            CarregarEnderecos();
            CarregarPessoas();
            CarregarTipoPessoa();
            txtDestinatario.Focus();
        }

        // Evento ao exibir o formulário
        private void FrmCadastroPessoas_Shown(object sender, EventArgs e)
        {
            // Garantir que o foco vá para o txtDestinatario após o formulário ser exibido
            txtDestinatario.Focus();
        }

        #region Métodos de Botões
        
        // Evento do botão que abrirá o FrmCidades
        private void btnCidade_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do FrmCidades
            FrmCidades frmCidades = new FrmCidades();
            frmCidades.Show(); // Exibe o formulário de cidades
        }

        // Botão Novo Cadastro
        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Codigo = "0";  // Código inicial, que será gerado automaticamente no banco
            SetFieldsReadOnly(false);
            txtDestinatario.Focus();
            CarregarEnderecos();
        }

        // Botão Novo Endereço
        private void btnNovoEndereco_Click(object sender, EventArgs e)
        {
            ClearAddressFields();
            dgvEndereco.ClearSelection();
            txtLogradouro.Focus();
        }

        // Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarDados();
        }

        // Botão Deletar
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DeletarEndereco();
        }

        // Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento de mudança de seleção no DataGridView de Endereços
        private void dgvEndereco_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica se há uma linha selecionada no DataGridView
            if (dgvEndereco.SelectedRows.Count > 0)
            {
                // Recupera a primeira linha selecionada
                DataGridViewRow selectedRow = dgvEndereco.SelectedRows[0];

                // Preenche os TextBoxes com os valores das células da linha selecionada
                txtLogradouro.Text = selectedRow.Cells["Logradouro"].Value.ToString();
                txtNumero.Text = selectedRow.Cells["Numero"].Value.ToString();
                txtComplemento.Text = selectedRow.Cells["Complemento"].Value.ToString();
                txtBairro.Text = selectedRow.Cells["Bairro"].Value.ToString();
                txtCidade.Text = selectedRow.Cells["Municipio"].Value.ToString();
                txtUF.Text = selectedRow.Cells["UF"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtCEP.Text = selectedRow.Cells["CEP"].Value.ToString();
                txtPais.Text = selectedRow.Cells["Pais"].Value.ToString();
                txtTelefone.Text = selectedRow.Cells["Telefone"].Value.ToString();
            }
            else
            {
                // Caso não haja linha selecionada, limpa os campos
                ClearAddressFields();
            }
        }

        #endregion

        #region Métodos de Funções (Organizados no final)

        // Função de Carregar Endereços
        private void CarregarEnderecos(int codigoEnderecoSelecionado = -1)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT Codigo, Logradouro, Numero, Complemento, Bairro, Municipio, UF, Email, CEP, Pais, Telefone, end_idPessoa " +
                               "FROM Endereco WHERE end_idPessoa = @Codigo";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Codigo", Codigo);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvEndereco.DataSource = dt;
                        dgvEndereco.Refresh();
                        AlterarNomesColunasEndereco(); // Alterar os nomes das colunas, se necessário
                    }
                    else
                    {
                        dgvEndereco.DataSource = null; // Caso não haja dados
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar endereço: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // Função de Carregar Pessoas
        private void CarregarPessoas()
        {
            try
            {
                string query = "SELECT * FROM Pessoas WHERE Codigo = @Codigo";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtDestinatario.Text = dt.Rows[0]["Destinatario"].ToString();
                    txtFantasia.Text = dt.Rows[0]["Fantasia"].ToString();
                    txtCNPJCPF.Text = dt.Rows[0]["CNPJ_CPF"].ToString();
                    txtIERG.Text = dt.Rows[0]["idEstrangeiroRG"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar pessoas: " + ex.Message);
            }
        }

        // Função para Salvar Dados
        private void SalvarDados()
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja salvar as alterações?", "Confirmar Salvamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Captura o código do endereço selecionado antes de qualquer operação
                    int codigoEnderecoSelecionado = -1;
                    if (dgvEndereco.SelectedRows.Count > 0)
                    {
                        codigoEnderecoSelecionado = Convert.ToInt32(dgvEndereco.SelectedRows[0].Cells["Codigo"].Value);
                    }

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Verificar se o CNPJ/CPF já existe na tabela Pessoas, EXCLUINDO o próprio registro se estiver atualizando
                        string queryVerificarCNPJCPF = "SELECT COUNT(*) FROM Pessoas WHERE CNPJ_CPF = @CNPJ_CPF AND (Codigo != @Codigo OR @Codigo IS NULL)";
                        using (MySqlCommand cmdVerificarCNPJCPF = new MySqlCommand(queryVerificarCNPJCPF, connection))
                        {
                            cmdVerificarCNPJCPF.Parameters.AddWithValue("@CNPJ_CPF", txtCNPJCPF.Text);
                            cmdVerificarCNPJCPF.Parameters.AddWithValue("@Codigo", string.IsNullOrEmpty(Codigo) ? (object)DBNull.Value : Codigo);  // Caso seja um novo registro, o código será nulo

                            int countCNPJCPF = Convert.ToInt32(cmdVerificarCNPJCPF.ExecuteScalar());

                            if (countCNPJCPF > 0)
                            {
                                MessageBox.Show("Já existe um registro com este CNPJ/CPF. Não é possível salvar.");
                                return;  // Se o CNPJ/CPF já existir, impede o salvamento
                            }
                        }

                        // Inserir ou atualizar pessoa
                        string queryVerificarPessoa = "SELECT COUNT(*) FROM Pessoas WHERE Codigo=@Codigo";
                        using (MySqlCommand cmdVerificarPessoa = new MySqlCommand(queryVerificarPessoa, connection))
                        {
                            cmdVerificarPessoa.Parameters.AddWithValue("@Codigo", Codigo);
                            int countPessoa = Convert.ToInt32(cmdVerificarPessoa.ExecuteScalar());

                            if (countPessoa > 0) // Se a pessoa já existir, realiza a atualização
                            {
                                string updatePessoas = "UPDATE Pessoas SET Fantasia=@Fantasia, Destinatario=@Destinatario, CNPJ_CPF=@CNPJ_CPF, idEstrangeiroRG=@idEstrangeiroRG, tipo_pessoa=@tipo_pessoa, Razao=@Razao WHERE Codigo=@Codigo";
                                using (MySqlCommand cmdUpdatePessoas = new MySqlCommand(updatePessoas, connection))
                                {
                                    cmdUpdatePessoas.Parameters.AddWithValue("@Codigo", Codigo);
                                    cmdUpdatePessoas.Parameters.AddWithValue("@Fantasia", txtFantasia.Text);
                                    cmdUpdatePessoas.Parameters.AddWithValue("@Destinatario", txtDestinatario.Text);
                                    cmdUpdatePessoas.Parameters.AddWithValue("@CNPJ_CPF", txtCNPJCPF.Text);
                                    cmdUpdatePessoas.Parameters.AddWithValue("@idEstrangeiroRG", txtIERG.Text);
                                    cmdUpdatePessoas.Parameters.AddWithValue("@tipo_pessoa", cmbTipoPessoa.SelectedValue); // Tipo de pessoa selecionado
                                    cmdUpdatePessoas.Parameters.AddWithValue("@Razao", txtRazao.Text);
                                    cmdUpdatePessoas.ExecuteNonQuery();
                                }

                                MessageBox.Show("Dados da pessoa atualizados com sucesso!");
                            }
                            else
                            {
                                string insertPessoas = "INSERT INTO Pessoas (Fantasia, Destinatario, CNPJ_CPF, idEstrangeiroRG, tipo_pessoa, Razao) " +
                                                       "VALUES (@Fantasia, @Destinatario, @CNPJ_CPF, @idEstrangeiroRG, @tipo_pessoa, @Razao)";
                                using (MySqlCommand cmdInsertPessoas = new MySqlCommand(insertPessoas, connection))
                                {
                                    cmdInsertPessoas.Parameters.AddWithValue("@Fantasia", txtFantasia.Text);
                                    cmdInsertPessoas.Parameters.AddWithValue("@Destinatario", txtDestinatario.Text);
                                    cmdInsertPessoas.Parameters.AddWithValue("@CNPJ_CPF", txtCNPJCPF.Text);
                                    cmdInsertPessoas.Parameters.AddWithValue("@idEstrangeiroRG", txtIERG.Text);
                                    cmdInsertPessoas.Parameters.AddWithValue("@tipo_pessoa", cmbTipoPessoa.SelectedValue); // Tipo de pessoa selecionado
                                    cmdInsertPessoas.Parameters.AddWithValue("@Razao", txtRazao.Text);
                                    cmdInsertPessoas.ExecuteNonQuery();

                                    Codigo = cmdInsertPessoas.LastInsertedId.ToString();  // Recupere o ID da pessoa inserida
                                    MessageBox.Show("Novo registro de pessoa adicionado com sucesso!");
                                }
                            }
                        }

                        // Inserir ou atualizar o endereço
                        if (codigoEnderecoSelecionado == -1) // Caso não tenha endereço selecionado, insira um novo
                        {
                            string insertEndereco = "INSERT INTO Endereco (Logradouro, Numero, Complemento, Bairro, Municipio, UF, Email, CEP, Pais, Telefone, end_idPessoa) " +
                                                    "VALUES (@Logradouro, @Numero, @Complemento, @Bairro, @Municipio, @UF, @Email, @CEP, @Pais, @Telefone, @end_idPessoa)";
                            using (MySqlCommand cmdInsertEndereco = new MySqlCommand(insertEndereco, connection))
                            {
                                cmdInsertEndereco.Parameters.AddWithValue("@Logradouro", txtLogradouro.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Numero", txtNumero.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Complemento", txtComplemento.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Bairro", txtBairro.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Municipio", txtCidade.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@UF", txtUF.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Email", txtEmail.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@CEP", txtCEP.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Pais", txtPais.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                                cmdInsertEndereco.Parameters.AddWithValue("@end_idPessoa", Codigo);  // Relaciona o endereço com a pessoa inserida

                                // Executa o comando e obtém o código do endereço inserido
                                cmdInsertEndereco.ExecuteNonQuery();
                                int codigoNovoEndereco = Convert.ToInt32(cmdInsertEndereco.LastInsertedId);  // Recupera o ID do novo endereço inserido

                                MessageBox.Show("Novo endereço adicionado com sucesso!");

                                // Atualiza a tela e seleciona o novo endereço
                                CarregarEnderecos();
                                SelecionarEndereco(codigoNovoEndereco);
                            }
                        }
                        else // Caso haja um endereço selecionado, realiza a atualização desse endereço
                        {
                            string updateEndereco = "UPDATE Endereco SET Logradouro=@Logradouro, Numero=@Numero, Complemento=@Complemento, Bairro=@Bairro, Municipio=@Municipio, " +
                                                    "UF=@UF, Email=@Email, CEP=@CEP, Pais=@Pais, Telefone=@Telefone WHERE Codigo=@CodigoEndereco";
                            using (MySqlCommand cmdUpdateEndereco = new MySqlCommand(updateEndereco, connection))
                            {
                                cmdUpdateEndereco.Parameters.AddWithValue("@CodigoEndereco", codigoEnderecoSelecionado);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Logradouro", txtLogradouro.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Numero", txtNumero.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Complemento", txtComplemento.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Bairro", txtBairro.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Municipio", txtCidade.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@UF", txtUF.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Email", txtEmail.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@CEP", txtCEP.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Pais", txtPais.Text);
                                cmdUpdateEndereco.Parameters.AddWithValue("@Telefone", txtTelefone.Text);

                                cmdUpdateEndereco.ExecuteNonQuery();

                                MessageBox.Show("Endereço atualizado com sucesso!");

                                // Atualiza a tela e seleciona o endereço atualizado
                                CarregarEnderecos();
                                SelecionarEndereco(codigoEnderecoSelecionado);
                            }
                        }

                        // Atualiza a tela após a operação
                        AtualizarTelaConsulta();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar ou atualizar pessoa e endereço: " + ex.Message);
            }
        }

        // Função para preencher o ComboBox com os tipos de pessoa
        private void CarregarTipoPessoa()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string queryTipoPessoa = "SELECT Nome, Id FROM TipoPessoa"; // Aqui recuperamos o Nome e o Codigo de TipoPessoa
                    using (MySqlCommand cmd = new MySqlCommand(queryTipoPessoa, connection))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbTipoPessoa.DataSource = dt;
                        cmbTipoPessoa.DisplayMember = "Nome"; // Exibe o nome no ComboBox
                        cmbTipoPessoa.ValueMember = "Id"; // Usa o Código internamente
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os tipos de pessoa: " + ex.Message);
            }
        }

        // Função de Deletar Endereço
        private void DeletarEndereco()
        {
            try
            {
                if (dgvEndereco.SelectedRows.Count > 0)
                {
                    int codigoEndereco = Convert.ToInt32(dgvEndereco.SelectedRows[0].Cells["Codigo"].Value);
                    DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir este endereço?", "Confirmar Exclusão", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string deleteEnderecoQuery = "DELETE FROM Endereco WHERE Codigo = @Codigo";
                            using (MySqlCommand cmdDeleteEndereco = new MySqlCommand(deleteEnderecoQuery, connection))
                            {
                                cmdDeleteEndereco.Parameters.AddWithValue("@Codigo", codigoEndereco);
                                cmdDeleteEndereco.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Endereço excluído com sucesso!");
                        CarregarEnderecos();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um endereço para excluir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o endereço: " + ex.Message);
            }
        }

        private void SelecionarEndereco(int codigoEnderecoSelecionado = -1)
        {
            dgvEndereco.ClearSelection();  // Limpa qualquer seleção anterior

            if (codigoEnderecoSelecionado == -1)
            {
                // Caso nenhum código tenha sido passado, seleciona a primeira linha
                if (dgvEndereco.Rows.Count > 0)
                {
                    dgvEndereco.Rows[0].Selected = true;
                    dgvEndereco.CurrentCell = dgvEndereco.Rows[0].Cells[0];  // Foca na célula da primeira linha
                }
            }
            else
            {
                // Caso um código tenha sido passado, procuramos pela linha com esse código
                foreach (DataGridViewRow row in dgvEndereco.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Codigo"].Value) == codigoEnderecoSelecionado)
                    {
                        row.Selected = true;
                        dgvEndereco.CurrentCell = row.Cells[0];  // Foca na célula da linha selecionada
                        break;
                    }
                }
            }
        }

        // Função para Alterar Nomes das Colunas na Grid
        private void AlterarNomesColunasEndereco()
        {
            dgvEndereco.Columns["Codigo"].HeaderText = "Código";
            dgvEndereco.Columns["Logradouro"].HeaderText = "Endereço";
            dgvEndereco.Columns["Numero"].HeaderText = "Número";
            dgvEndereco.Columns["Complemento"].HeaderText = "Complemento";
            dgvEndereco.Columns["Bairro"].HeaderText = "Bairro";
            dgvEndereco.Columns["Municipio"].HeaderText = "Cidade";
            dgvEndereco.Columns["UF"].HeaderText = "Estado";
            dgvEndereco.Columns["Email"].HeaderText = "E-mail";
            dgvEndereco.Columns["CEP"].HeaderText = "CEP";
            dgvEndereco.Columns["Pais"].HeaderText = "País";
            dgvEndereco.Columns["Telefone"].HeaderText = "Telefone";
            dgvEndereco.Columns["end_idPessoa"].HeaderText = "Código da Pessoa";
        }

        // Função para Limpar os Campos de Endereço
        private void ClearAddressFields()
        {
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtUF.Clear();
            txtEmail.Clear();
            txtCEP.Clear();
            txtPais.Clear();
            txtTelefone.Clear();
        }

        // Função para Limpar os Campos
        private void LimparCampos()
        {
            txtDestinatario.Clear();
            txtCNPJCPF.Clear();
            txtIERG.Clear();
            txtFantasia.Clear();
            Codigo = "0";
            SetFieldsReadOnly(false);
        }

        // Função para Configurar os Campos como Somente Leitura
        private void SetFieldsReadOnly(bool readOnly)
        {
            txtDestinatario.ReadOnly = readOnly;
            txtCNPJCPF.ReadOnly = readOnly;
            txtIERG.ReadOnly = readOnly;
            txtFantasia.ReadOnly = readOnly;
        }

        // Atualizar a Tela de Consulta
        private void AtualizarTelaConsulta()
        {
            if (frmConsulta != null)
            {
                frmConsulta.AtualizarConsulta();
            }
        }

        // Evento Leave para o campo txtCEP (quando o foco sai do campo)
        private void txtCEP_Leave(object sender, EventArgs e)
        {
            string cepDigitado = txtCEP.Text.Trim(); // Obtém o CEP digitado no campo txtCEP
            if (string.IsNullOrEmpty(cepDigitado))
            {
                MessageBox.Show("Por favor, digite um CEP.");
                return;
            }

            // Defina a consulta SQL
            string query = "SELECT descricao, descricao_bairro, complemento, descricao_cidade, UF " +
                           "FROM logradouro WHERE CEP = @CEP";

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
                        // Adiciona o parâmetro de CEP para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@CEP", cepDigitado);

                        // Executa a consulta e obtém os dados
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Se encontrar algum resultado
                            {
                                // Preenche os campos com os dados retornados
                                txtLogradouro.Text = reader["descricao"].ToString();
                                txtBairro.Text = reader["descricao_bairro"].ToString();
                                txtComplemento.Text = reader["complemento"].ToString();
                                txtCidade.Text = reader["descricao_cidade"].ToString();
                                txtUF.Text = reader["UF"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("CEP não encontrado.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o CEP: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
#endregion