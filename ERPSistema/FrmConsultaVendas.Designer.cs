namespace ERPSistema
{
    partial class FrmConsultaVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaVendas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.dgvConsultaVendas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtConsulta.Location = new System.Drawing.Point(8, 41);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(988, 26);
            this.txtConsulta.TabIndex = 0;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "[ Consulta ]";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtConsulta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 78);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btnExibir);
            this.panel2.Controls.Add(this.btnDeletar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 548);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 53);
            this.panel2.TabIndex = 8;
            // 
            // btnExibir
            // 
            this.btnExibir.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.btnExibir.BackColor = System.Drawing.Color.Green;
            this.btnExibir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExibir.BackgroundImage")));
            this.btnExibir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExibir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExibir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExibir.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnExibir.ForeColor = System.Drawing.Color.White;
            this.btnExibir.Location = new System.Drawing.Point(799, 0);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(99, 53);
            this.btnExibir.TabIndex = 1;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExibir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExibir.UseVisualStyleBackColor = false;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Maroon;
            this.btnDeletar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletar.BackgroundImage")));
            this.btnDeletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(898, 0);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(110, 53);
            this.btnDeletar.TabIndex = 2;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // dgvConsultaVendas
            // 
            this.dgvConsultaVendas.AllowUserToAddRows = false;
            this.dgvConsultaVendas.AllowUserToDeleteRows = false;
            this.dgvConsultaVendas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsultaVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsultaVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsultaVendas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsultaVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultaVendas.Location = new System.Drawing.Point(0, 78);
            this.dgvConsultaVendas.Name = "dgvConsultaVendas";
            this.dgvConsultaVendas.ReadOnly = true;
            this.dgvConsultaVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaVendas.Size = new System.Drawing.Size(1008, 470);
            this.dgvConsultaVendas.TabIndex = 3;
            this.dgvConsultaVendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaVendas_CellDoubleClick);
            // 
            // FrmConsultaVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.dgvConsultaVendas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmConsultaVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmConsultaVendas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeletar;
        public System.Windows.Forms.DataGridView dgvConsultaVendas;
        private System.Windows.Forms.Button btnExibir;
    }
}