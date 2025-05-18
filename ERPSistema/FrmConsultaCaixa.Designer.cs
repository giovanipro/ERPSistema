namespace ERPSistema
{
    partial class FrmConsultaCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaCaixa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTroco = new System.Windows.Forms.Button();
            this.btnResetar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRetiradas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCaixa = new System.Windows.Forms.DataGridView();
            this.pnlTroco = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFechar2 = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaixa)).BeginInit();
            this.pnlTroco.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtConsulta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 80);
            this.panel1.TabIndex = 0;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtConsulta.Location = new System.Drawing.Point(9, 46);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(1259, 26);
            this.txtConsulta.TabIndex = 0;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "[ Consulta ]";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btnTroco);
            this.panel2.Controls.Add(this.btnResetar);
            this.panel2.Controls.Add(this.btnFechar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 667);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 53);
            this.panel2.TabIndex = 1;
            // 
            // btnTroco
            // 
            this.btnTroco.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.btnTroco.BackColor = System.Drawing.Color.Green;
            this.btnTroco.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTroco.BackgroundImage")));
            this.btnTroco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTroco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTroco.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTroco.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnTroco.ForeColor = System.Drawing.Color.White;
            this.btnTroco.Location = new System.Drawing.Point(897, 0);
            this.btnTroco.Name = "btnTroco";
            this.btnTroco.Size = new System.Drawing.Size(168, 53);
            this.btnTroco.TabIndex = 1;
            this.btnTroco.Text = "Adicionar Troco";
            this.btnTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTroco.UseVisualStyleBackColor = false;
            this.btnTroco.Click += new System.EventHandler(this.btnTroco_Click);
            // 
            // btnResetar
            // 
            this.btnResetar.BackColor = System.Drawing.Color.Maroon;
            this.btnResetar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResetar.BackgroundImage")));
            this.btnResetar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnResetar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResetar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnResetar.ForeColor = System.Drawing.Color.White;
            this.btnResetar.Location = new System.Drawing.Point(1065, 0);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(112, 53);
            this.btnResetar.TabIndex = 2;
            this.btnResetar.Text = "Resetar";
            this.btnResetar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetar.UseVisualStyleBackColor = false;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Maroon;
            this.btnFechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFechar.BackgroundImage")));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1177, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 53);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblEntradas);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblRetiradas);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblSaldo);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 589);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1280, 78);
            this.panel3.TabIndex = 3;
            // 
            // lblEntradas
            // 
            this.lblEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntradas.AutoSize = true;
            this.lblEntradas.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradas.ForeColor = System.Drawing.Color.Blue;
            this.lblEntradas.Location = new System.Drawing.Point(794, 37);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(108, 37);
            this.lblEntradas.TabIndex = 9;
            this.lblEntradas.Text = "R$ 0,00";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(794, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 37);
            this.label6.TabIndex = 8;
            this.label6.Text = "Entradas:";
            // 
            // lblRetiradas
            // 
            this.lblRetiradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRetiradas.AutoSize = true;
            this.lblRetiradas.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetiradas.ForeColor = System.Drawing.Color.Red;
            this.lblRetiradas.Location = new System.Drawing.Point(930, 37);
            this.lblRetiradas.Name = "lblRetiradas";
            this.lblRetiradas.Size = new System.Drawing.Size(108, 37);
            this.lblRetiradas.TabIndex = 7;
            this.lblRetiradas.Text = "R$ 0,00";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(930, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Retiradas:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(1073, 37);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(108, 37);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "R$ 0,00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1073, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saldo do Caixa:";
            // 
            // dgvCaixa
            // 
            this.dgvCaixa.AllowUserToAddRows = false;
            this.dgvCaixa.AllowUserToDeleteRows = false;
            this.dgvCaixa.AllowUserToOrderColumns = true;
            this.dgvCaixa.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaixa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaixa.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaixa.Location = new System.Drawing.Point(0, 80);
            this.dgvCaixa.Name = "dgvCaixa";
            this.dgvCaixa.ReadOnly = true;
            this.dgvCaixa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaixa.Size = new System.Drawing.Size(1280, 509);
            this.dgvCaixa.TabIndex = 4;
            // 
            // pnlTroco
            // 
            this.pnlTroco.BackColor = System.Drawing.Color.Gray;
            this.pnlTroco.Controls.Add(this.label3);
            this.pnlTroco.Controls.Add(this.btnFechar2);
            this.pnlTroco.Controls.Add(this.txtValor);
            this.pnlTroco.Controls.Add(this.btnOK);
            this.pnlTroco.Controls.Add(this.panel8);
            this.pnlTroco.Location = new System.Drawing.Point(479, 276);
            this.pnlTroco.Name = "pnlTroco";
            this.pnlTroco.Size = new System.Drawing.Size(322, 132);
            this.pnlTroco.TabIndex = 7;
            this.pnlTroco.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(100, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Valor:";
            // 
            // btnFechar2
            // 
            this.btnFechar2.BackColor = System.Drawing.Color.Maroon;
            this.btnFechar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFechar2.BackgroundImage")));
            this.btnFechar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFechar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnFechar2.ForeColor = System.Drawing.Color.White;
            this.btnFechar2.Location = new System.Drawing.Point(219, 80);
            this.btnFechar2.Name = "btnFechar2";
            this.btnFechar2.Size = new System.Drawing.Size(103, 52);
            this.btnFechar2.TabIndex = 32;
            this.btnFechar2.Text = "Fechar";
            this.btnFechar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar2.UseVisualStyleBackColor = false;
            this.btnFechar2.Click += new System.EventHandler(this.btnFechar2_Click);
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.Gray;
            this.txtValor.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.ForeColor = System.Drawing.Color.White;
            this.txtValor.Location = new System.Drawing.Point(168, 45);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(151, 29);
            this.txtValor.TabIndex = 30;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(133, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 53);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(322, 28);
            this.panel8.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(89, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "[ VALOR TROCO ]";
            // 
            // FrmConsultaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlTroco);
            this.Controls.Add(this.dgvCaixa);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Caixa";
            this.Load += new System.EventHandler(this.FrmCaixa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaixa)).EndInit();
            this.pnlTroco.ResumeLayout(false);
            this.pnlTroco.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dgvCaixa;
        private System.Windows.Forms.Button btnResetar;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRetiradas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTroco;
        private System.Windows.Forms.Panel pnlTroco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFechar2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label5;
    }
}