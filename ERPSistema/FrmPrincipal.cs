using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPSistema
{
    public partial class FrmPrincipal : Form
    {
        // Definição do ContextMenuStrip
        private ContextMenuStrip contextMenuUsuario;
        private ToolStripMenuItem menuCadUsuario;
        private ToolStripMenuItem menuAlterarSenha;
        private ToolStripMenuItem menuLogOff;

        // String de conexão com o MySQL
        string connectionString = "Server=localhost;Port=3306;Database=database;User=root;";

        // Propriedade para tornar o label de usuário acessível em outros formulários
        public string Usuario
        {
            get { return lblUsuario.Text; }
            set { lblUsuario.Text = value; }
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            InitializeContextMenuUsuario();
        }

        // Evento ao carregar o formulário
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario;  // Exibe o nome do usuário logado

            // Exibe o nível de acesso (chama o método GetNivelAcesso passando o nome do usuário)
            string nivelAcesso = GetNivelAcesso(Usuario);
            lblNivel.Text = nivelAcesso;  // Atualiza a label com o nível de acesso
        }

        // Inicializa o ContextMenuStrip para picUsuario
        private void InitializeContextMenuUsuario()
        {
            this.contextMenuUsuario = new ContextMenuStrip();
            this.menuCadUsuario = new ToolStripMenuItem("Cad. Usuário");
            this.menuAlterarSenha = new ToolStripMenuItem("Alterar Senha");
            this.menuLogOff = new ToolStripMenuItem("LogOff");

            this.contextMenuUsuario.Items.Add(this.menuCadUsuario);
            this.contextMenuUsuario.Items.Add(this.menuAlterarSenha);
            this.contextMenuUsuario.Items.Add(this.menuLogOff);

            // Associando os eventos aos itens do menu
            this.menuCadUsuario.Click += new EventHandler(this.menuCadUsuario_Click);
            this.menuAlterarSenha.Click += new EventHandler(this.menuAlterarSenha_Click);
            this.menuLogOff.Click += new EventHandler(this.menuLogOff_Click);
        }

        #region Eventos de Botões e Ações do Menu

        // Evento do clique em "Cadastro de Usuário"
        private void menuCadUsuario_Click(object sender, EventArgs e)
        {
            string nivelAcessoUsuario = lblNivel.Text.ToLower(); // Obter o nível de acesso do usuário logado

            if (nivelAcessoUsuario == "admin")
            {
                FrmCadastroUsuarios frmCadastro = new FrmCadastroUsuarios();
                frmCadastro.FormClosed += (s, args) => {
                };
                frmCadastro.ShowDialog(); // Exibe o formulário de cadastro de usuário
            }
            else
            {
                MessageBox.Show("Você não tem permissão para cadastrar usuários. Somente um Administrador pode realizar essa ação.", "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento do clique em "Alterar Senha"
        private void menuAlterarSenha_Click(object sender, EventArgs e)
        {
            FrmAlterarSenha frmAlterarSenha = new FrmAlterarSenha();
            frmAlterarSenha.FormClosed += (s, args) => {
            };
            frmAlterarSenha.ShowDialog(); // Exibe o formulário para alteração de senha
        }

        // Evento de clique em "LogOff"
        private void menuLogOff_Click(object sender, EventArgs e)
        {
            // Fecha o FrmPrincipal existente e exibe a tela de login novamente
            FrmPrincipal frmPrincipal = Application.OpenForms["FrmPrincipal"] as FrmPrincipal;
            if (frmPrincipal != null)
            {
                frmPrincipal.Close();
            }

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();  // Exibe a tela de login
        }

        // Eventos de interação com a imagem do usuário (efeito hover)
        private void picUsuario_MouseEnter(object sender, EventArgs e)
        {
            picUsuario.Image = Properties.Resources.account_icon_rose;
        }

        private void picUsuario_MouseLeave(object sender, EventArgs e)
        {
            picUsuario.Image = Properties.Resources.account_icon_white;
        }

        // Eventos de interação com a imagem do sistema (efeito hover)
        private void picSistema_MouseEnter(object sender, EventArgs e)
        {
            picSistema.Image = Properties.Resources.ballot_rose;
        }

        private void picSistema_MouseLeave(object sender, EventArgs e)
        {
            picSistema.Image = Properties.Resources.ballot_white;
        }

        // Evento de clique no picUsuario para exibir o menu
        private void picUsuario_Click(object sender, EventArgs e)
        {
            // Exibe o menu no local do clique
            contextMenuUsuario.Show(picUsuario, new Point(0, picUsuario.Height));
        }

        // Evento de clique no picSistema para fechar todos os formulários, exceto o principal e login
        private void picSistema_Click(object sender, EventArgs e)
        {
            List<Form> formsToClose = new List<Form>();

            // Itera sobre todos os formulários abertos
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmPrincipal) && form.GetType() != typeof(FrmLogin))
                {
                    formsToClose.Add(form);
                }
            }

            // Fecha os formulários selecionados
            foreach (Form form in formsToClose)
            {
                form.Close();
            }
        }

        // Eventos de clique nos botões de navegação
        private void btnFilial_Click(object sender, EventArgs e)
        {
            // Implementar a navegação para o formulário de filial
        }

        private void btnPessoas_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário FrmConsultaPessoas já está aberto
            FrmConsultaPessoas frmConsulta = Application.OpenForms.OfType<FrmConsultaPessoas>().FirstOrDefault();

            if (frmConsulta != null)
            {
                // Fecha a instância anterior, caso esteja aberta
                frmConsulta.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmConsulta = new FrmConsultaPessoas();
            FormShow(frmConsulta);  // Exibe o formulário de consulta de pessoas
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário FrmListaCaixa já está aberto
            FrmListaCaixa frmListaCaixa = Application.OpenForms.OfType<FrmListaCaixa>().FirstOrDefault();

            if (frmListaCaixa != null)
            {
                // Fecha a instância anterior, caso esteja aberta
                frmListaCaixa.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmListaCaixa = new FrmListaCaixa();
            FormShow(frmListaCaixa);  // Exibe o formulário de lista de caixa
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário FrmConsultaProdutos já está aberto
            FrmConsultaProdutos frmProdutos = Application.OpenForms.OfType<FrmConsultaProdutos>().FirstOrDefault();

            if (frmProdutos != null)
            {
                // Fecha a instância anterior, caso esteja aberta
                frmProdutos.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmProdutos = new FrmConsultaProdutos();
            FormShow(frmProdutos);  // Exibe o formulário de consulta de produtos
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            int codigoMovEstoque = 0;

            // Verifica se o formulário FrmCadastroVendas já está aberto
            FrmCadastroVendas frmCadastroVendas = Application.OpenForms.OfType<FrmCadastroVendas>().FirstOrDefault();

            if (frmCadastroVendas != null)
            {
                // Se o formulário já estiver aberto, fecha a instância anterior
                frmCadastroVendas.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmCadastroVendas = new FrmCadastroVendas(codigoMovEstoque);
            FormShow(frmCadastroVendas);
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            int codigoMovEstoque = 0;

            // Verifica se o formulário FrmConsultaVendas já está aberto
            FrmConsultaVendas frmConsultaVendas = Application.OpenForms.OfType<FrmConsultaVendas>().FirstOrDefault();

            if (frmConsultaVendas != null)
            {
                // Fecha a instância anterior, caso esteja aberta
                frmConsultaVendas.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmConsultaVendas = new FrmConsultaVendas(codigoMovEstoque);
            FormShow(frmConsultaVendas);
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário FrmReceber já está aberto
            FrmReceber frmReceber = Application.OpenForms.OfType<FrmReceber>().FirstOrDefault();

            if (frmReceber != null)
            {
                // Fecha a instância anterior, caso esteja aberta
                frmReceber.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmReceber = new FrmReceber();
            FormShow(frmReceber);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário FrmReceber já está aberto
            FrmConsultaPagar frmConsultaPagar = Application.OpenForms.OfType<FrmConsultaPagar>().FirstOrDefault();

            if (frmConsultaPagar != null)
            {
                // Fecha a instância anterior, caso esteja aberta
                frmConsultaPagar.Close();
            }

            // Cria e exibe uma nova instância do formulário
            frmConsultaPagar = new FrmConsultaPagar();
            FormShow(frmConsultaPagar);
        }

        // Evento de clique no botão "Sair"
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Encerra a aplicação
        }

        #endregion

        #region Métodos Auxiliares

        // Método para exibir um formulário dentro de um painel
        public void FormShow(Form frm)
        {
            frm.TopLevel = false;  // Definindo o formulário como não top-level para integrá-lo ao painel
            pnlForm.Controls.Clear();  // Limpa controles anteriores

            pnlForm.Controls.Add(frm);  // Adiciona o formulário ao painel
            frm.Dock = DockStyle.Fill;  // Faz o formulário ocupar todo o espaço do painel
            frm.BringToFront();  // Coloca o formulário na frente de outros controles
            frm.Show();  // Exibe o formulário
        }

        // Método para obter o nível de acesso do usuário no banco de dados
        private string GetNivelAcesso(string usuario)
        {
            string query = "SELECT Nivel_Acesso FROM usuarios WHERE Usuario = @Usuario";
            string nivelAcesso = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // Abre a conexão com o banco de dados

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();  // Lê a primeira linha de resultado
                            nivelAcesso = reader["Nivel_Acesso"].ToString();  // Obtém o nível de acesso do banco de dados
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar nível de acesso: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Exibe erro caso haja falha na conexão
                }
            }

            return nivelAcesso;  // Retorna o nível de acesso
        }

        #endregion
    }
}
