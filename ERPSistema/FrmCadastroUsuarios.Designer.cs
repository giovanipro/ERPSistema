namespace ERPSistema
{
    partial class FrmCadastroUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroUsuarios));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.cmbNivelAcesso = new System.Windows.Forms.ComboBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnDeletar);
            this.panel1.Controls.Add(this.btnNovoUsuario);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 52);
            this.panel1.TabIndex = 59;
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Maroon;
            this.btnDeletar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletar.BackgroundImage")));
            this.btnDeletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(434, 0);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(112, 52);
            this.btnDeletar.TabIndex = 5;
            this.btnDeletar.Text = "Deletar Usuário";
            this.btnDeletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnNovoUsuario
            // 
            this.btnNovoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNovoUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNovoUsuario.BackgroundImage")));
            this.btnNovoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovoUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoUsuario.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnNovoUsuario.ForeColor = System.Drawing.Color.White;
            this.btnNovoUsuario.Location = new System.Drawing.Point(276, 0);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(152, 52);
            this.btnNovoUsuario.TabIndex = 4;
            this.btnNovoUsuario.Text = "Criar Usuário";
            this.btnNovoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoUsuario.UseVisualStyleBackColor = false;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Green;
            this.btnSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.BackgroundImage")));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(169, 0);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(101, 52);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Maroon;
            this.btnFechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFechar.BackgroundImage")));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(552, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(107, 52);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.label34);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(800, 48);
            this.panel6.TabIndex = 58;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Gray;
            this.label34.Location = new System.Drawing.Point(3, 5);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(149, 37);
            this.label34.TabIndex = 0;
            this.label34.Text = "[ Usuários ]";
            // 
            // txtNivel
            // 
            this.txtNivel.AutoSize = true;
            this.txtNivel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNivel.Location = new System.Drawing.Point(211, 116);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(59, 25);
            this.txtNivel.TabIndex = 57;
            this.txtNivel.Text = "Nível:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 56;
            this.label1.Text = "Nome de Usuário:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(394, 63);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(68, 25);
            this.label28.TabIndex = 55;
            this.label28.Text = "Senha:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(399, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(177, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(216, 91);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(177, 22);
            this.txtUsuario.TabIndex = 0;
            // 
            // cmbNivelAcesso
            // 
            this.cmbNivelAcesso.FormattingEnabled = true;
            this.cmbNivelAcesso.Location = new System.Drawing.Point(218, 144);
            this.cmbNivelAcesso.Name = "cmbNivelAcesso";
            this.cmbNivelAcesso.Size = new System.Drawing.Size(175, 21);
            this.cmbNivelAcesso.TabIndex = 2;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 184);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(800, 214);
            this.dgvUsuarios.TabIndex = 60;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // FrmCadastroUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.cmbNivelAcesso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txtNivel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Name = "FrmCadastroUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Usuário";
            this.Load += new System.EventHandler(this.FrmCadastroUsuarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label txtNivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cmbNivelAcesso;
        private System.Windows.Forms.Button btnNovoUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnDeletar;
    }
}