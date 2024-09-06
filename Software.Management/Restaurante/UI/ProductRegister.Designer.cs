
namespace ProjetoDeSoftware
{
    partial class ProductRegister
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
            txtNome = new TextBox();
            txtPreco = new TextBox();
            txtDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            L = new Label();
            dataGridView1 = new DataGridView();
            Insert = new Button();
            panel1 = new Panel();
            cbAtivo = new CheckBox();
            lblId = new Label();
            Update = new Button();
            Dalete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(30, 147);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(149, 27);
            txtNome.TabIndex = 0;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(30, 211);
            txtPreco.Margin = new Padding(3, 4, 3, 4);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(149, 27);
            txtPreco.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(30, 281);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(149, 27);
            txtDescription.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 123);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 4;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 187);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 5;
            label2.Text = "Preço:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 257);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 6;
            label3.Text = "Descrição:";
            // 
            // L
            // 
            L.AutoSize = true;
            L.Location = new Point(16, 17);
            L.Name = "L";
            L.Size = new Size(27, 20);
            L.TabIndex = 7;
            L.Text = "ID:";
            L.Visible = false;
            L.Click += L_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(304, 16);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(597, 392);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Insert
            // 
            Insert.Location = new Point(62, 476);
            Insert.Margin = new Padding(3, 4, 3, 4);
            Insert.Name = "Insert";
            Insert.Size = new Size(131, 56);
            Insert.TabIndex = 9;
            Insert.Text = "Insert";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbAtivo);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(txtNome);
            panel1.Controls.Add(txtPreco);
            panel1.Controls.Add(L);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(14, 13);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 395);
            panel1.TabIndex = 10;
            // 
            // cbAtivo
            // 
            cbAtivo.AutoSize = true;
            cbAtivo.Location = new Point(35, 329);
            cbAtivo.Name = "cbAtivo";
            cbAtivo.Size = new Size(121, 24);
            cbAtivo.TabIndex = 9;
            cbAtivo.Text = "Produto ativo";
            cbAtivo.UseVisualStyleBackColor = true;
            cbAtivo.CheckedChanged += cbAtivo_CheckedChanged;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(47, 17);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 20);
            lblId.TabIndex = 8;
            lblId.Visible = false;
            // 
            // Update
            // 
            Update.Location = new Point(237, 476);
            Update.Margin = new Padding(3, 4, 3, 4);
            Update.Name = "Update";
            Update.Size = new Size(131, 56);
            Update.TabIndex = 11;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Dalete
            // 
            Dalete.Location = new Point(418, 476);
            Dalete.Margin = new Padding(3, 4, 3, 4);
            Dalete.Name = "Dalete";
            Dalete.Size = new Size(131, 56);
            Dalete.TabIndex = 12;
            Dalete.Text = "Delete";
            Dalete.UseVisualStyleBackColor = true;
            Dalete.Click += Dalete_Click;
            // 
            // ProductRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(Dalete);
            Controls.Add(Update);
            Controls.Add(panel1);
            Controls.Add(Insert);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductRegister";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void L_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtDescription;
        private TextBox txtId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label L;
        private DataGridView dataGridView1;
        private Button Insert;
        private Panel panel1;
        private Button Update;
        private Button Dalete;
        private Label lblId;
        private CheckBox cbAtivo;
    }
}
