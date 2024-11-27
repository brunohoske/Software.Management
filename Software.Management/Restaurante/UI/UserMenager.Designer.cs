namespace Restaurante.UI
{
    partial class UserMenager
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            txtNome = new TextBox();
            txtSenha = new TextBox();
            Loguin = new Label();
            label2 = new Label();
            label3 = new Label();
            lblId = new Label();
            checkBox1 = new CheckBox();
            label1 = new Label();
            cbAtivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(268, 15);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(520, 423);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(39, 210);
            button1.Name = "button1";
            button1.Size = new Size(125, 45);
            button1.TabIndex = 1;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(39, 261);
            button2.Name = "button2";
            button2.Size = new Size(125, 45);
            button2.TabIndex = 2;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(39, 312);
            button3.Name = "button3";
            button3.Size = new Size(125, 45);
            button3.TabIndex = 3;
            button3.Text = "Deletar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 70);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(185, 23);
            txtNome.TabIndex = 4;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(12, 124);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(185, 23);
            txtSenha.TabIndex = 5;
            // 
            // Loguin
            // 
            Loguin.AutoSize = true;
            Loguin.Location = new Point(12, 52);
            Loguin.Name = "Loguin";
            Loguin.Size = new Size(40, 15);
            Loguin.TabIndex = 6;
            Loguin.Text = "Login:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 106);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "Senha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 8;
            label3.Text = "ID:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(39, 9);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 15);
            lblId.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(22, 168);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(62, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Admin";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 150);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 11;
            label1.Text = "Nivel de Permissão:";
            // 
            // cbAtivo
            // 
            cbAtivo.AutoSize = true;
            cbAtivo.Location = new Point(148, 9);
            cbAtivo.Margin = new Padding(3, 2, 3, 2);
            cbAtivo.Name = "cbAtivo";
            cbAtivo.Size = new Size(94, 19);
            cbAtivo.TabIndex = 12;
            cbAtivo.Text = "Cliente Ativo";
            cbAtivo.UseVisualStyleBackColor = true;
            cbAtivo.CheckedChanged += cbAtivo_CheckedChanged;
            // 
            // UserMenager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(cbAtivo);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(lblId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Loguin);
            Controls.Add(txtSenha);
            Controls.Add(txtNome);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "UserMenager";
            Text = "Gerenciar Usuários";
            Load += UserMenager_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox txtNome;
        private TextBox txtSenha;
        private Label Loguin;
        private Label label2;
        private Label label3;
        private Label lblId;
        private CheckBox checkBox1;
        private Label label1;
        private CheckBox cbAtivo;
    }
}