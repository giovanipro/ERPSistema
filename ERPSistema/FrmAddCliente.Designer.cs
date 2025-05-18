namespace ERPSistema
{
    partial class FrmAddCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dgvAddClientes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtConsulta);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 73);
            this.panel1.TabIndex = 0;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtConsulta.Location = new System.Drawing.Point(12, 40);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(776, 26);
            this.txtConsulta.TabIndex = 3;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label34.Location = new System.Drawing.Point(3, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 37);
            this.label34.TabIndex = 1;
            this.label34.Text = "[ Clientes ]";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btnSelecionar);
            this.panel2.Controls.Add(this.btnFechar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 52);
            this.panel2.TabIndex = 1;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.Green;
            this.btnSelecionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.BackgroundImage")));
            this.btnSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelecionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelecionar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnSelecionar.ForeColor = System.Drawing.Color.White;
            this.btnSelecionar.Location = new System.Drawing.Point(566, 0);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(130, 52);
            this.btnSelecionar.TabIndex = 23;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
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
            this.btnFechar.Location = new System.Drawing.Point(696, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(104, 52);
            this.btnFechar.TabIndex = 24;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // dgvAddClientes
            // 
            this.dgvAddClientes.AllowUserToAddRows = false;
            this.dgvAddClientes.AllowUserToDeleteRows = false;
            this.dgvAddClientes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAddClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAddClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddClientes.Location = new System.Drawing.Point(0, 73);
            this.dgvAddClientes.Name = "dgvAddClientes";
            this.dgvAddClientes.ReadOnly = true;
            this.dgvAddClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddClientes.Size = new System.Drawing.Size(800, 325);
            this.dgvAddClientes.TabIndex = 2;
            this.dgvAddClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddClientes_CellDoubleClick);
            // 
            // FrmAddCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAddClientes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmAddCliente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAddClientes;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtConsulta;
    }
}