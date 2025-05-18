namespace ERPSistema
{
    partial class FrmReceber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceber));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDefinir = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.dgvReceber2 = new System.Windows.Forms.DataGridView();
            this.dgvReceber1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceber1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1008, 71);
            this.panel1.TabIndex = 0;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtConsulta.Location = new System.Drawing.Point(19, 42);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(978, 26);
            this.txtConsulta.TabIndex = 0;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "[ Pesquisa ]";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btnDefinir);
            this.panel2.Controls.Add(this.btnDeletar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 547);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 54);
            this.panel2.TabIndex = 1;
            // 
            // btnDefinir
            // 
            this.btnDefinir.BackColor = System.Drawing.Color.Green;
            this.btnDefinir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDefinir.BackgroundImage")));
            this.btnDefinir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDefinir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefinir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDefinir.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnDefinir.ForeColor = System.Drawing.Color.White;
            this.btnDefinir.Location = new System.Drawing.Point(709, 0);
            this.btnDefinir.Name = "btnDefinir";
            this.btnDefinir.Size = new System.Drawing.Size(189, 54);
            this.btnDefinir.TabIndex = 1;
            this.btnDefinir.Text = "Definir Como Pago";
            this.btnDefinir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefinir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDefinir.UseVisualStyleBackColor = false;
            this.btnDefinir.Click += new System.EventHandler(this.btnDefinir_Click);
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
            this.btnDeletar.Size = new System.Drawing.Size(110, 54);
            this.btnDeletar.TabIndex = 2;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // dgvReceber2
            // 
            this.dgvReceber2.AllowUserToAddRows = false;
            this.dgvReceber2.AllowUserToDeleteRows = false;
            this.dgvReceber2.AllowUserToOrderColumns = true;
            this.dgvReceber2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceber2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceber2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceber2.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceber2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceber2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReceber2.Location = new System.Drawing.Point(0, 133);
            this.dgvReceber2.Name = "dgvReceber2";
            this.dgvReceber2.ReadOnly = true;
            this.dgvReceber2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceber2.Size = new System.Drawing.Size(1008, 414);
            this.dgvReceber2.TabIndex = 4;
            // 
            // dgvReceber1
            // 
            this.dgvReceber1.AllowUserToAddRows = false;
            this.dgvReceber1.AllowUserToDeleteRows = false;
            this.dgvReceber1.AllowUserToOrderColumns = true;
            this.dgvReceber1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceber1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceber1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceber1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceber1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReceber1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceber1.Location = new System.Drawing.Point(0, 71);
            this.dgvReceber1.Name = "dgvReceber1";
            this.dgvReceber1.ReadOnly = true;
            this.dgvReceber1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceber1.Size = new System.Drawing.Size(1008, 62);
            this.dgvReceber1.TabIndex = 3;
            this.dgvReceber1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceber1_CellClick);
            // 
            // FrmReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.dgvReceber1);
            this.Controls.Add(this.dgvReceber2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReceber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a Receber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReceber_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceber1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvReceber2;
        private System.Windows.Forms.DataGridView dgvReceber1;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnDefinir;
    }
}