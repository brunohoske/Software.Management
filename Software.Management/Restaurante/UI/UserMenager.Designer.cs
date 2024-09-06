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
            panel1 = new Panel();
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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(296, 4);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(605, 580);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 8);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(594, 564);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(45, 280);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(143, 60);
            button1.TabIndex = 1;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(45, 348);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(143, 60);
            button2.TabIndex = 2;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(45, 416);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(143, 60);
            button3.TabIndex = 3;
            button3.Text = "Deletar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(14, 93);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(211, 27);
            txtNome.TabIndex = 4;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(14, 165);
            txtSenha.Margin = new Padding(3, 4, 3, 4);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(211, 27);
            txtSenha.TabIndex = 5;
            // 
            // Loguin
            // 
            Loguin.AutoSize = true;
            Loguin.Location = new Point(14, 69);
            Loguin.Name = "Loguin";
            Loguin.Size = new Size(49, 20);
            Loguin.TabIndex = 6;
            Loguin.Text = "Login:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 141);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 7;
            label2.Text = "Senha:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 12);
            label3.Name = "label3";
            label3.Size = new Size(27, 20);
            label3.TabIndex = 8;
            label3.Text = "ID:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(45, 12);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 20);
            lblId.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(25, 224);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(75, 24);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Admin";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 200);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 11;
            label1.Text = "Nivel de Permição:";
            // 
            // cbAtivo
            // 
            cbAtivo.AutoSize = true;
            cbAtivo.Location = new Point(169, 12);
            cbAtivo.Name = "cbAtivo";
            cbAtivo.Size = new Size(116, 24);
            cbAtivo.TabIndex = 12;
            cbAtivo.Text = "Cliente Ativo";
            cbAtivo.UseVisualStyleBackColor = true;
            cbAtivo.CheckedChanged += cbAtivo_CheckedChanged;
            // 
            // UserMenager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
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
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserMenager";
            Text = "UserMenager";
            Load += UserMenager_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
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