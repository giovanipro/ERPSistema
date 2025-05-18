namespace ERPSistema
{
    partial class FrmCadastroVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroVendas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFaturar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQTD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVlrUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNomeVendedor = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddCliente = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.dgvCadastroVendas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadastroVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label34);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 40);
            this.panel1.TabIndex = 0;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(1, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(132, 37);
            this.label34.TabIndex = 1;
            this.label34.Text = "[ Vendas ]";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btnFaturar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 548);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 53);
            this.panel2.TabIndex = 1;
            // 
            // btnFaturar
            // 
            this.btnFaturar.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.btnFaturar.BackColor = System.Drawing.Color.Green;
            this.btnFaturar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFaturar.BackgroundImage")));
            this.btnFaturar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFaturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFaturar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFaturar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnFaturar.ForeColor = System.Drawing.Color.White;
            this.btnFaturar.Location = new System.Drawing.Point(843, 0);
            this.btnFaturar.Name = "btnFaturar";
            this.btnFaturar.Size = new System.Drawing.Size(107, 53);
            this.btnFaturar.TabIndex = 12;
            this.btnFaturar.Text = "Faturar";
            this.btnFaturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFaturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFaturar.UseVisualStyleBackColor = false;
            this.btnFaturar.Click += new System.EventHandler(this.btnFaturar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Maroon;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(950, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(168, 53);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar Venda";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.lblSubTotal);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 464);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 84);
            this.panel3.TabIndex = 2;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.White;
            this.lblSubTotal.Location = new System.Drawing.Point(928, 43);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(113, 37);
            this.lblSubTotal.TabIndex = 8;
            this.lblSubTotal.Text = "R$ 0,00";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(928, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 37);
            this.label6.TabIndex = 7;
            this.label6.Text = "[ Sub. Total ]";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendedor.Location = new System.Drawing.Point(17, 34);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(139, 29);
            this.txtVendedor.TabIndex = 0;
            this.txtVendedor.TextChanged += new System.EventHandler(this.txtVendedor_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label33.Location = new System.Drawing.Point(3, 6);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(144, 25);
            this.label33.TabIndex = 38;
            this.label33.Text = "Cód. Vendedor:";
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCodBarra.Location = new System.Drawing.Point(17, 176);
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(221, 29);
            this.txtCodBarra.TabIndex = 3;
            this.txtCodBarra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodBarra_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 40;
            this.label1.Text = "Código de Barras:";
            // 
            // txtQTD
            // 
            this.txtQTD.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQTD.Location = new System.Drawing.Point(522, 178);
            this.txtQTD.Name = "txtQTD";
            this.txtQTD.Size = new System.Drawing.Size(49, 29);
            this.txtQTD.TabIndex = 6;
            this.txtQTD.TextChanged += new System.EventHandler(this.txtQTD_TextChanged);
            this.txtQTD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQTD_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(517, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "QTD:";
            // 
            // txtVlrUnit
            // 
            this.txtVlrUnit.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVlrUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVlrUnit.Location = new System.Drawing.Point(577, 178);
            this.txtVlrUnit.Name = "txtVlrUnit";
            this.txtVlrUnit.Size = new System.Drawing.Size(80, 29);
            this.txtVlrUnit.TabIndex = 7;
            this.txtVlrUnit.TextChanged += new System.EventHandler(this.txtVlrUnit_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(572, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "Vlr. Unit:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSubTotal.Location = new System.Drawing.Point(791, 178);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(95, 29);
            this.txtSubTotal.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(786, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 46;
            this.label4.Text = "Sub. Total:";
            // 
            // lblNomeVendedor
            // 
            this.lblNomeVendedor.AutoSize = true;
            this.lblNomeVendedor.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeVendedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNomeVendedor.Location = new System.Drawing.Point(162, 34);
            this.lblNomeVendedor.Name = "lblNomeVendedor";
            this.lblNomeVendedor.Size = new System.Drawing.Size(0, 25);
            this.lblNomeVendedor.TabIndex = 49;
            this.lblNomeVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCliente.Location = new System.Drawing.Point(17, 94);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(139, 29);
            this.txtCliente.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 25);
            this.label5.TabIndex = 51;
            this.label5.Text = "Cód. Cliente:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDeletar);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtNome);
            this.panel4.Controls.Add(this.txtDesconto);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btnAddCliente);
            this.panel4.Controls.Add(this.label33);
            this.panel4.Controls.Add(this.txtCliente);
            this.panel4.Controls.Add(this.txtVendedor);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblNomeVendedor);
            this.panel4.Controls.Add(this.txtCodBarra);
            this.panel4.Controls.Add(this.btnSalvar);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnAddProd);
            this.panel4.Controls.Add(this.txtQTD);
            this.panel4.Controls.Add(this.txtSubTotal);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtVlrUnit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1118, 223);
            this.panel4.TabIndex = 4;
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Maroon;
            this.btnDeletar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletar.BackgroundImage")));
            this.btnDeletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(1002, 162);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(111, 53);
            this.btnDeletar.TabIndex = 11;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(239, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 56;
            this.label8.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNome.Location = new System.Drawing.Point(244, 176);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(210, 29);
            this.txtNome.TabIndex = 4;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDesconto.Location = new System.Drawing.Point(663, 178);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(122, 29);
            this.txtDesconto.TabIndex = 8;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(658, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 54;
            this.label7.Text = "Vlr Desconto:";
            // 
            // btnAddCliente
            // 
            this.btnAddCliente.BackColor = System.Drawing.Color.Gray;
            this.btnAddCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCliente.BackgroundImage")));
            this.btnAddCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCliente.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnAddCliente.ForeColor = System.Drawing.Color.White;
            this.btnAddCliente.Location = new System.Drawing.Point(162, 79);
            this.btnAddCliente.Name = "btnAddCliente";
            this.btnAddCliente.Size = new System.Drawing.Size(56, 56);
            this.btnAddCliente.TabIndex = 2;
            this.btnAddCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCliente.UseVisualStyleBackColor = false;
            this.btnAddCliente.Click += new System.EventHandler(this.btnAddCliente_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Green;
            this.btnSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.BackgroundImage")));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(892, 163);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(104, 52);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.BackColor = System.Drawing.Color.Gray;
            this.btnAddProd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddProd.BackgroundImage")));
            this.btnAddProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProd.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnAddProd.ForeColor = System.Drawing.Color.White;
            this.btnAddProd.Location = new System.Drawing.Point(460, 163);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(56, 56);
            this.btnAddProd.TabIndex = 5;
            this.btnAddProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddProd.UseVisualStyleBackColor = false;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // dgvCadastroVendas
            // 
            this.dgvCadastroVendas.AllowUserToAddRows = false;
            this.dgvCadastroVendas.AllowUserToDeleteRows = false;
            this.dgvCadastroVendas.AllowUserToOrderColumns = true;
            this.dgvCadastroVendas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCadastroVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCadastroVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCadastroVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCadastroVendas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCadastroVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCadastroVendas.Location = new System.Drawing.Point(0, 263);
            this.dgvCadastroVendas.Name = "dgvCadastroVendas";
            this.dgvCadastroVendas.ReadOnly = true;
            this.dgvCadastroVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCadastroVendas.Size = new System.Drawing.Size(1118, 201);
            this.dgvCadastroVendas.TabIndex = 15;
            // 
            // FrmCadastroVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 601);
            this.Controls.Add(this.dgvCadastroVendas);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCadastroVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCadastroVendas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadastroVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Label label33;
        public System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtVlrUnit;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtQTD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblNomeVendedor;
        private System.Windows.Forms.Button btnAddCliente;
        public System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label34;
        public System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFaturar;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtNome;
        public System.Windows.Forms.DataGridView dgvCadastroVendas;
        private System.Windows.Forms.Button btnDeletar;
    }
}