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
            txtQntd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            L = new Label();
            dataGridView1 = new DataGridView();
            Insert = new Button();
            panel1 = new Panel();
            lblId = new Label();
            Update = new Button();
            Dalete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(26, 110);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(131, 23);
            txtNome.TabIndex = 0;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(26, 158);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(131, 23);
            txtPreco.TabIndex = 1;
            // 
            // txtQntd
            // 
            txtQntd.Location = new Point(26, 211);
            txtQntd.Name = "txtQntd";
            txtQntd.Size = new Size(131, 23);
            txtQntd.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 92);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 4;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 140);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Preço:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 193);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Quantidade:";
            // 
            // L
            // 
            L.AutoSize = true;
            L.Location = new Point(14, 13);
            L.Name = "L";
            L.Size = new Size(21, 15);
            L.TabIndex = 7;
            L.Text = "ID:";
            L.Visible = false;
            L.Click += L_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(266, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(522, 294);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Insert
            // 
            Insert.Location = new Point(54, 357);
            Insert.Name = "Insert";
            Insert.Size = new Size(115, 42);
            Insert.TabIndex = 9;
            Insert.Text = "Insert";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(txtNome);
            panel1.Controls.Add(txtPreco);
            panel1.Controls.Add(L);
            panel1.Controls.Add(txtQntd);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 296);
            panel1.TabIndex = 10;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(41, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 15);
            lblId.TabIndex = 8;
            lblId.Visible = false;
            // 
            // Update
            // 
            Update.Location = new Point(207, 357);
            Update.Name = "Update";
            Update.Size = new Size(115, 42);
            Update.TabIndex = 11;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Dalete
            // 
            Dalete.Location = new Point(366, 357);
            Dalete.Name = "Dalete";
            Dalete.Size = new Size(115, 42);
            Dalete.TabIndex = 12;
            Dalete.Text = "Delete";
            Dalete.UseVisualStyleBackColor = true;
            Dalete.Click += Dalete_Click;
            // 
            // ProductRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Dalete);
            Controls.Add(Update);
            Controls.Add(panel1);
            Controls.Add(Insert);
            Controls.Add(dataGridView1);
            Name = "ProductRegister";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtQntd;
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
    }
}
