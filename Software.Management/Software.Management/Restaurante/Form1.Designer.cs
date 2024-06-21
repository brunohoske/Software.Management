namespace Restaurante
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            TxtSenha = new TextBox();
            TxtNome = new TextBox();
            label2 = new Label();
            label1 = new Label();
            BtnAcesso = new Button();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Indigo;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(BtnAcesso);
            panel1.Controls.Add(TxtSenha);
            panel1.Controls.Add(TxtNome);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(166, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(461, 281);
            panel1.TabIndex = 0;
            // 
            // TxtSenha
            // 
            TxtSenha.ForeColor = SystemColors.ControlDark;
            TxtSenha.Location = new Point(140, 142);
            TxtSenha.Name = "TxtSenha";
            TxtSenha.Size = new Size(162, 23);
            TxtSenha.TabIndex = 4;
            TxtSenha.Text = "Senha";
            TxtSenha.Enter += TxtSenha_Enter;
            TxtSenha.Leave += TxtSenha_Leave;
            // 
            // TxtNome
            // 
            TxtNome.ForeColor = SystemColors.ControlDark;
            TxtNome.Location = new Point(140, 96);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(162, 23);
            TxtNome.TabIndex = 2;
            TxtNome.Enter += TxtNome_Enter;
            TxtNome.Leave += TxtNome_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(140, 43);
            label2.Name = "label2";
            label2.Size = new Size(158, 13);
            label2.TabIndex = 1;
            label2.Text = "Acesse sua conta agora mesmo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(180, 17);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 0;
            label1.Text = "Bem-Vindo (a)";
            // 
            // BtnAcesso
            // 
            BtnAcesso.Location = new Point(146, 237);
            BtnAcesso.Name = "BtnAcesso";
            BtnAcesso.Size = new Size(156, 23);
            BtnAcesso.TabIndex = 12;
            BtnAcesso.Text = "Logar";
            BtnAcesso.UseVisualStyleBackColor = true;
            BtnAcesso.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(140, 80);
            label3.Name = "label3";
            label3.Size = new Size(36, 13);
            label3.TabIndex = 13;
            label3.Text = "Login:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(140, 126);
            label4.Name = "label4";
            label4.Size = new Size(41, 13);
            label4.TabIndex = 14;
            label4.Text = "Senha:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Tela Login";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox TxtSenha;
        private TextBox TxtNome;
        private Label label4;
        private Label label3;
        private Button BtnAcesso;
    }
}
