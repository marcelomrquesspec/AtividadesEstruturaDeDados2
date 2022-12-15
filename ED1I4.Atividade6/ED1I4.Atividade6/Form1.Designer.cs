namespace ED1I4.Atividade6
{
    partial class Form1
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
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnListarSenhas = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnChamar = new System.Windows.Forms.Button();
            this.btnListarAtendimentos = new System.Windows.Forms.Button();
            this.listSenhas = new System.Windows.Forms.ListView();
            this.label = new System.Windows.Forms.Label();
            this.lblQtdeGuiches = new System.Windows.Forms.Label();
            this.listGuiches = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGuiche = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(59, 21);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnListarSenhas
            // 
            this.btnListarSenhas.Location = new System.Drawing.Point(12, 280);
            this.btnListarSenhas.Name = "btnListarSenhas";
            this.btnListarSenhas.Size = new System.Drawing.Size(167, 23);
            this.btnListarSenhas.TabIndex = 1;
            this.btnListarSenhas.Text = "Listar Senhas";
            this.btnListarSenhas.UseVisualStyleBackColor = true;
            this.btnListarSenhas.Click += new System.EventHandler(this.btnListarSenhas_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(233, 184);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnChamar
            // 
            this.btnChamar.Location = new System.Drawing.Point(701, 21);
            this.btnChamar.Name = "btnChamar";
            this.btnChamar.Size = new System.Drawing.Size(75, 23);
            this.btnChamar.TabIndex = 3;
            this.btnChamar.Text = "Chamar";
            this.btnChamar.UseVisualStyleBackColor = true;
            this.btnChamar.Click += new System.EventHandler(this.btnChamar_Click);
            // 
            // btnListarAtendimentos
            // 
            this.btnListarAtendimentos.Location = new System.Drawing.Point(625, 280);
            this.btnListarAtendimentos.Name = "btnListarAtendimentos";
            this.btnListarAtendimentos.Size = new System.Drawing.Size(151, 23);
            this.btnListarAtendimentos.TabIndex = 4;
            this.btnListarAtendimentos.Text = "Listar Atendimentos";
            this.btnListarAtendimentos.UseVisualStyleBackColor = true;
            this.btnListarAtendimentos.Click += new System.EventHandler(this.btnListarAtendimentos_Click);
            // 
            // listSenhas
            // 
            this.listSenhas.HideSelection = false;
            this.listSenhas.Location = new System.Drawing.Point(12, 55);
            this.listSenhas.Name = "listSenhas";
            this.listSenhas.Size = new System.Drawing.Size(167, 195);
            this.listSenhas.TabIndex = 5;
            this.listSenhas.UseCompatibleStateImageBehavior = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(221, 90);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 20);
            this.label.TabIndex = 6;
            this.label.Text = "Qtde guichês:";
            // 
            // lblQtdeGuiches
            // 
            this.lblQtdeGuiches.AutoSize = true;
            this.lblQtdeGuiches.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdeGuiches.Location = new System.Drawing.Point(249, 123);
            this.lblQtdeGuiches.Name = "lblQtdeGuiches";
            this.lblQtdeGuiches.Size = new System.Drawing.Size(42, 46);
            this.lblQtdeGuiches.TabIndex = 7;
            this.lblQtdeGuiches.Text = "0";
            // 
            // listGuiches
            // 
            this.listGuiches.HideSelection = false;
            this.listGuiches.Location = new System.Drawing.Point(355, 55);
            this.listGuiches.Name = "listGuiches";
            this.listGuiches.Size = new System.Drawing.Size(421, 195);
            this.listGuiches.TabIndex = 8;
            this.listGuiches.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Guichê:";
            // 
            // txtGuiche
            // 
            this.txtGuiche.Location = new System.Drawing.Point(595, 23);
            this.txtGuiche.Name = "txtGuiche";
            this.txtGuiche.Size = new System.Drawing.Size(100, 20);
            this.txtGuiche.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 325);
            this.Controls.Add(this.txtGuiche);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listGuiches);
            this.Controls.Add(this.lblQtdeGuiches);
            this.Controls.Add(this.label);
            this.Controls.Add(this.listSenhas);
            this.Controls.Add(this.btnListarAtendimentos);
            this.Controls.Add(this.btnChamar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnListarSenhas);
            this.Controls.Add(this.btnGerar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnListarSenhas;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnChamar;
        private System.Windows.Forms.Button btnListarAtendimentos;
        private System.Windows.Forms.ListView listSenhas;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblQtdeGuiches;
        private System.Windows.Forms.ListView listGuiches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGuiche;
    }
}

