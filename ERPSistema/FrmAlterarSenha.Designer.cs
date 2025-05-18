namespace ERPSistema
{
    partial class FrmAlterarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlterarSenha));
            this.txtSenhaNova = new System.Windows.Forms.TextBox();
            this.txtSenhaAntiga = new System.Windows.Forms.TextBox();
            this.txtSenhaNovaConfirmar = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSenhaNova
            // 
            this.txtSenhaNova.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaNova.Location = new System.Drawing.Point(209, 182);
            this.txtSenhaNova.Name = "txtSenhaNova";
            this.txtSenhaNova.PasswordChar = '*';
            this.txtSenhaNova.Size = new System.Drawing.Size(177, 22);
            this.txtSenhaNova.TabIndex = 1;
            // 
            // txtSenhaAntiga
            // 
            this.txtSenhaAntiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaAntiga.Location = new System.Drawing.Point(209, 129);
            this.txtSenhaAntiga.Name = "txtSenhaAntiga";
            this.txtSenhaAntiga.PasswordChar = '*';
            this.txtSenhaAntiga.Size = new System.Drawing.Size(177, 22);
            this.txtSenhaAntiga.TabIndex = 0;
            // 
            // txtSenhaNovaConfirmar
            // 
            this.txtSenhaNovaConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaNovaConfirmar.Location = new System.Drawing.Point(209, 233);
            this.txtSenhaNovaConfirmar.Name = "txtSenhaNovaConfirmar";
            this.txtSenhaNovaConfirmar.PasswordChar = '*';
            this.txtSenhaNovaConfirmar.Size = new System.Drawing.Size(177, 22);
            this.txtSenhaNovaConfirmar.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(204, 154);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(117, 25);
            this.label28.TabIndex = 47;
            this.label28.Text = "Nova Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "Senha Antiga:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "Confirmar Senha:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.label34);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(640, 48);
            this.panel6.TabIndex = 50;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Gray;
            this.label34.Location = new System.Drawing.Point(3, 5);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(205, 37);
            this.label34.TabIndex = 0;
            this.label34.Text = "[ Alterar Senha ]";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 52);
            this.panel1.TabIndex = 51;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Green;
            this.btnConfirmar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.BackgroundImage")));
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(151, 0);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 52);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Maroon;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(346, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 52);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAlterarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtSenhaNovaConfirmar);
            this.Controls.Add(this.txtSenhaNova);
            this.Controls.Add(this.txtSenhaAntiga);
            this.Name = "FrmAlterarSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Senha";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSenhaNova;
        private System.Windows.Forms.TextBox txtSenhaAntiga;
        private System.Windows.Forms.TextBox txtSenhaNovaConfirmar;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}