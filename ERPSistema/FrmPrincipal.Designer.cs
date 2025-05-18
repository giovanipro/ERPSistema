using System.Windows.Forms;

namespace ERPSistema
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlUsuarios = new System.Windows.Forms.Panel();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnlEmpresa = new System.Windows.Forms.Panel();
            this.lblSlogamEmpresa = new System.Windows.Forms.Label();
            this.lblTituloEmpresa = new System.Windows.Forms.Label();
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.picSistema = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnPessoas = new System.Windows.Forms.Button();
            this.btnCaixa = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlUsuarios.SuspendLayout();
            this.pnlEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSistema)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.pnlUsuarios);
            this.panel1.Controls.Add(this.pnlEmpresa);
            this.panel1.Controls.Add(this.picUsuario);
            this.panel1.Controls.Add(this.picSistema);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 52);
            this.panel1.TabIndex = 0;
            // 
            // pnlUsuarios
            // 
            this.pnlUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUsuarios.Controls.Add(this.lblNivel);
            this.pnlUsuarios.Controls.Add(this.lblUsuario);
            this.pnlUsuarios.Location = new System.Drawing.Point(1772, 0);
            this.pnlUsuarios.Name = "pnlUsuarios";
            this.pnlUsuarios.Size = new System.Drawing.Size(97, 52);
            this.pnlUsuarios.TabIndex = 3;
            // 
            // lblNivel
            // 
            this.lblNivel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.ForeColor = System.Drawing.Color.White;
            this.lblNivel.Location = new System.Drawing.Point(1, 25);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(36, 17);
            this.lblNivel.TabIndex = 2;
            this.lblNivel.Text = "Nível";
            this.lblNivel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(0, 0);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(77, 25);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            // 
            // pnlEmpresa
            // 
            this.pnlEmpresa.Controls.Add(this.lblSlogamEmpresa);
            this.pnlEmpresa.Controls.Add(this.lblTituloEmpresa);
            this.pnlEmpresa.Location = new System.Drawing.Point(56, 0);
            this.pnlEmpresa.Name = "pnlEmpresa";
            this.pnlEmpresa.Size = new System.Drawing.Size(111, 52);
            this.pnlEmpresa.TabIndex = 2;
            // 
            // lblSlogamEmpresa
            // 
            this.lblSlogamEmpresa.AutoSize = true;
            this.lblSlogamEmpresa.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogamEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblSlogamEmpresa.Location = new System.Drawing.Point(3, 25);
            this.lblSlogamEmpresa.Name = "lblSlogamEmpresa";
            this.lblSlogamEmpresa.Size = new System.Drawing.Size(56, 17);
            this.lblSlogamEmpresa.TabIndex = 1;
            this.lblSlogamEmpresa.Text = "Soluções";
            // 
            // lblTituloEmpresa
            // 
            this.lblTituloEmpresa.AutoSize = true;
            this.lblTituloEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloEmpresa.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblTituloEmpresa.Location = new System.Drawing.Point(0, 0);
            this.lblTituloEmpresa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTituloEmpresa.Name = "lblTituloEmpresa";
            this.lblTituloEmpresa.Size = new System.Drawing.Size(112, 25);
            this.lblTituloEmpresa.TabIndex = 0;
            this.lblTituloEmpresa.Text = "ERPSistema";
            // 
            // picUsuario
            // 
            this.picUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picUsuario.Image = ((System.Drawing.Image)(resources.GetObject("picUsuario.Image")));
            this.picUsuario.Location = new System.Drawing.Point(1866, 0);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(48, 52);
            this.picUsuario.TabIndex = 1;
            this.picUsuario.TabStop = false;
            this.picUsuario.Click += new System.EventHandler(this.picUsuario_Click);
            this.picUsuario.MouseEnter += new System.EventHandler(this.picUsuario_MouseEnter);
            this.picUsuario.MouseLeave += new System.EventHandler(this.picUsuario_MouseLeave);
            // 
            // picSistema
            // 
            this.picSistema.Image = ((System.Drawing.Image)(resources.GetObject("picSistema.Image")));
            this.picSistema.Location = new System.Drawing.Point(0, 0);
            this.picSistema.Name = "picSistema";
            this.picSistema.Size = new System.Drawing.Size(59, 52);
            this.picSistema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSistema.TabIndex = 0;
            this.picSistema.TabStop = false;
            this.picSistema.Click += new System.EventHandler(this.picSistema_Click);
            this.picSistema.MouseEnter += new System.EventHandler(this.picSistema_MouseEnter);
            this.picSistema.MouseLeave += new System.EventHandler(this.picSistema_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.btnPagar);
            this.panel2.Controls.Add(this.btnVendas);
            this.panel2.Controls.Add(this.btnReceber);
            this.panel2.Controls.Add(this.btnPessoas);
            this.panel2.Controls.Add(this.btnCaixa);
            this.panel2.Controls.Add(this.btnVender);
            this.panel2.Controls.Add(this.btnProdutos);
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 1028);
            this.panel2.TabIndex = 1;
            // 
            // btnPagar
            // 
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Image")));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(0, 454);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(212, 51);
            this.btnPagar.TabIndex = 6;
            this.btnPagar.Text = " Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVendas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVendas.FlatAppearance.BorderSize = 0;
            this.btnVendas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVendas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendas.ForeColor = System.Drawing.Color.White;
            this.btnVendas.Image = ((System.Drawing.Image)(resources.GetObject("btnVendas.Image")));
            this.btnVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendas.Location = new System.Drawing.Point(0, 297);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(212, 55);
            this.btnVendas.TabIndex = 4;
            this.btnVendas.Text = " Vendas";
            this.btnVendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            // 
            // btnReceber
            // 
            this.btnReceber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceber.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReceber.FlatAppearance.BorderSize = 0;
            this.btnReceber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnReceber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceber.ForeColor = System.Drawing.Color.White;
            this.btnReceber.Image = ((System.Drawing.Image)(resources.GetObject("btnReceber.Image")));
            this.btnReceber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceber.Location = new System.Drawing.Point(0, 397);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(212, 51);
            this.btnReceber.TabIndex = 5;
            this.btnReceber.Text = " Receber";
            this.btnReceber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // btnPessoas
            // 
            this.btnPessoas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPessoas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPessoas.FlatAppearance.BorderSize = 0;
            this.btnPessoas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnPessoas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPessoas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPessoas.ForeColor = System.Drawing.Color.White;
            this.btnPessoas.Image = ((System.Drawing.Image)(resources.GetObject("btnPessoas.Image")));
            this.btnPessoas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPessoas.Location = new System.Drawing.Point(0, 122);
            this.btnPessoas.Name = "btnPessoas";
            this.btnPessoas.Size = new System.Drawing.Size(212, 53);
            this.btnPessoas.TabIndex = 1;
            this.btnPessoas.Text = " Pessoas";
            this.btnPessoas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPessoas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPessoas.UseVisualStyleBackColor = true;
            this.btnPessoas.Click += new System.EventHandler(this.btnPessoas_Click);
            // 
            // btnCaixa
            // 
            this.btnCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaixa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCaixa.FlatAppearance.BorderSize = 0;
            this.btnCaixa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnCaixa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaixa.ForeColor = System.Drawing.Color.White;
            this.btnCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnCaixa.Image")));
            this.btnCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaixa.Location = new System.Drawing.Point(0, 240);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(212, 51);
            this.btnCaixa.TabIndex = 3;
            this.btnCaixa.Text = " Caixa";
            this.btnCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // btnVender
            // 
            this.btnVender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVender.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVender.FlatAppearance.BorderSize = 0;
            this.btnVender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnVender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.ForeColor = System.Drawing.Color.White;
            this.btnVender.Image = ((System.Drawing.Image)(resources.GetObject("btnVender.Image")));
            this.btnVender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVender.Location = new System.Drawing.Point(0, 61);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(212, 55);
            this.btnVender.TabIndex = 0;
            this.btnVender.Text = " Vender";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdutos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProdutos.FlatAppearance.BorderSize = 0;
            this.btnProdutos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnProdutos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdutos.ForeColor = System.Drawing.Color.White;
            this.btnProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnProdutos.Image")));
            this.btnProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutos.Location = new System.Drawing.Point(0, 181);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(212, 53);
            this.btnProdutos.TabIndex = 2;
            this.btnProdutos.Text = " Produtos";
            this.btnProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(0, 968);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(212, 60);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = " Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlForm
            // 
            this.pnlForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlForm.BackgroundImage")));
            this.pnlForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(212, 52);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1708, 1028);
            this.pnlForm.TabIndex = 2;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.pnlUsuarios.ResumeLayout(false);
            this.pnlUsuarios.PerformLayout();
            this.pnlEmpresa.ResumeLayout(false);
            this.pnlEmpresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSistema)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.PictureBox picSistema;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.Panel pnlEmpresa;
        private System.Windows.Forms.Label lblTituloEmpresa;
        private System.Windows.Forms.Label lblSlogamEmpresa;
        private System.Windows.Forms.Panel pnlUsuarios;
        public System.Windows.Forms.Button btnSair;
        public System.Windows.Forms.Button btnVender;
        public System.Windows.Forms.Button btnProdutos;
        public System.Windows.Forms.Button btnCaixa;
        public System.Windows.Forms.Label lblNivel;
        public System.Windows.Forms.Label lblUsuario;
        private ContextMenuStrip contextMenuStrip1;
        public Button btnPessoas;
        public Button btnReceber;
        public Button btnVendas;
        public Button btnPagar;
    }
}

