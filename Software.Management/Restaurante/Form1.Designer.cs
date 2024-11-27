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
            label4 = new Label();
            label3 = new Label();
            BtnAcesso = new Button();
            TxtSenha = new TextBox();
            TxtNome = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(BtnAcesso);
            panel1.Controls.Add(TxtSenha);
            panel1.Controls.Add(TxtNome);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(160, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(461, 281);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(150, 134);
            label4.Name = "label4";
            label4.Size = new Size(41, 13);
            label4.TabIndex = 14;
            label4.Text = "Senha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(150, 88);
            label3.Name = "label3";
            label3.Size = new Size(36, 13);
            label3.TabIndex = 13;
            label3.Text = "Login:";
            // 
            // BtnAcesso
            // 
            BtnAcesso.Location = new Point(168, 209);
            BtnAcesso.Name = "BtnAcesso";
            BtnAcesso.Size = new Size(128, 23);
            BtnAcesso.TabIndex = 12;
            BtnAcesso.Text = "Logar";
            BtnAcesso.UseVisualStyleBackColor = true;
            BtnAcesso.Click += button1_Click;
            // 
            // TxtSenha
            // 
            TxtSenha.ForeColor = SystemColors.ControlDark;
            TxtSenha.Location = new Point(150, 150);
            TxtSenha.Name = "TxtSenha";
            TxtSenha.Size = new Size(162, 23);
            TxtSenha.TabIndex = 4;
            TxtSenha.Text = "Senha";
            TxtSenha.Enter += TxtSenha_Enter;
            TxtSenha.KeyPress += TxtSenha_KeyPress;
            TxtSenha.Leave += TxtSenha_Leave;
            // 
            // TxtNome
            // 
            TxtNome.ForeColor = SystemColors.ControlDark;
            TxtNome.Location = new Point(150, 104);
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
            label2.Location = new Point(150, 51);
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
            label1.Location = new Point(190, 25);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 0;
            label1.Text = "Bem-Vindo (a)";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(351, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(86, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Click&Eat";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}
