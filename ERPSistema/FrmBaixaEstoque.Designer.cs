namespace ERPSistema
{
    partial class FrmBaixaEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaixaEstoque));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbOperacao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.txtQTD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVlrUnit = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBaixaEstoque = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaixaEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 52);
            this.panel1.TabIndex = 7;
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
            this.btnFechar.Location = new System.Drawing.Point(1042, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(104, 52);
            this.btnFechar.TabIndex = 25;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(3, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(211, 37);
            this.label34.TabIndex = 2;
            this.label34.Text = "[ Baixa Estoque ]";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.cmbOperacao);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtNome);
            this.panel2.Controls.Add(this.txtDesconto);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCodBarra);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAddProd);
            this.panel2.Controls.Add(this.txtQTD);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtVlrUnit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 116);
            this.panel2.TabIndex = 8;
            // 
            // cmbOperacao
            // 
            this.cmbOperacao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperacao.FormattingEnabled = true;
            this.cmbOperacao.Location = new System.Drawing.Point(894, 56);
            this.cmbOperacao.Name = "cmbOperacao";
            this.cmbOperacao.Size = new System.Drawing.Size(139, 29);
            this.cmbOperacao.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(889, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 70;
            this.label4.Text = "Operação:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(241, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 68;
            this.label8.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNome.Location = new System.Drawing.Point(246, 56);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(311, 29);
            this.txtNome.TabIndex = 1;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDesconto.Location = new System.Drawing.Point(766, 56);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(122, 29);
            this.txtDesconto.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(761, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 67;
            this.label7.Text = "Vlr Desconto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 64;
            this.label1.Text = "Código de Barras:";
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCodBarra.Location = new System.Drawing.Point(19, 56);
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(221, 29);
            this.txtCodBarra.TabIndex = 0;
            this.txtCodBarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodBarra_KeyDown);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Green;
            this.btnSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.BackgroundImage")));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(1039, 43);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(104, 52);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(620, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 65;
            this.label2.Text = "QTD:";
            // 
            // btnAddProd
            // 
            this.btnAddProd.BackColor = System.Drawing.Color.Gray;
            this.btnAddProd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddProd.BackgroundImage")));
            this.btnAddProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProd.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnAddProd.ForeColor = System.Drawing.Color.White;
            this.btnAddProd.Location = new System.Drawing.Point(563, 41);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(56, 56);
            this.btnAddProd.TabIndex = 2;
            this.btnAddProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddProd.UseVisualStyleBackColor = false;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // txtQTD
            // 
            this.txtQTD.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQTD.Location = new System.Drawing.Point(625, 56);
            this.txtQTD.Name = "txtQTD";
            this.txtQTD.Size = new System.Drawing.Size(49, 29);
            this.txtQTD.TabIndex = 3;
            this.txtQTD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQTD_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(675, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 66;
            this.label3.Text = "Vlr. Unit:";
            // 
            // txtVlrUnit
            // 
            this.txtVlrUnit.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVlrUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVlrUnit.Location = new System.Drawing.Point(680, 56);
            this.txtVlrUnit.Name = "txtVlrUnit";
            this.txtVlrUnit.Size = new System.Drawing.Size(80, 29);
            this.txtVlrUnit.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.lblSubTotal);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 517);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1146, 84);
            this.panel3.TabIndex = 9;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.White;
            this.lblSubTotal.Location = new System.Drawing.Point(956, 43);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(113, 37);
            this.lblSubTotal.TabIndex = 8;
            this.lblSubTotal.Text = "R$ 0,00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(956, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 37);
            this.label6.TabIndex = 7;
            this.label6.Text = "[ Sub. Total ]";
            // 
            // dgvBaixaEstoque
            // 
            this.dgvBaixaEstoque.AllowUserToAddRows = false;
            this.dgvBaixaEstoque.AllowUserToDeleteRows = false;
            this.dgvBaixaEstoque.AllowUserToOrderColumns = true;
            this.dgvBaixaEstoque.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaixaEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaixaEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaixaEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaixaEstoque.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaixaEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaixaEstoque.Location = new System.Drawing.Point(0, 168);
            this.dgvBaixaEstoque.Name = "dgvBaixaEstoque";
            this.dgvBaixaEstoque.ReadOnly = true;
            this.dgvBaixaEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaixaEstoque.Size = new System.Drawing.Size(1146, 349);
            this.dgvBaixaEstoque.TabIndex = 8;
            // 
            // FrmBaixaEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 601);
            this.Controls.Add(this.dgvBaixaEstoque);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBaixaEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixa Estoque";
            this.Load += new System.EventHandler(this.FrmBaixaEstoque_Load);
            this.Shown += new System.EventHandler(this.FrmBaixaEstoque_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaixaEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtNome;
        public System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProd;
        public System.Windows.Forms.TextBox txtQTD;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtVlrUnit;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBaixaEstoque;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ComboBox cmbOperacao;
        private System.Windows.Forms.Label label4;
    }
}