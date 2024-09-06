
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
            btnEstatisticas = new Button();
            Delete = new Button();
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
            // txtDescription
            // 
            txtDescription.Location = new Point(26, 211);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(131, 23);
            txtDescription.TabIndex = 2;
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
            label3.Size = new Size(61, 15);
            label3.TabIndex = 6;
            label3.Text = "Descrição:";
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
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(522, 294);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Insert
            // 
            Insert.Location = new Point(54, 357);
            Insert.Name = "Insert";
            Insert.Size = new Size(115, 42);
            Insert.TabIndex = 9;
            Insert.Text = "Inserir";
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
            panel1.Location = new Point(12, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 296);
            panel1.TabIndex = 10;
            // 
            // cbAtivo
            // 
            cbAtivo.AutoSize = true;
            cbAtivo.Location = new Point(31, 247);
            cbAtivo.Margin = new Padding(3, 2, 3, 2);
            cbAtivo.Name = "cbAtivo";
            cbAtivo.Size = new Size(98, 19);
            cbAtivo.TabIndex = 9;
            cbAtivo.Text = "Produto ativo";
            cbAtivo.UseVisualStyleBackColor = true;
            cbAtivo.CheckedChanged += cbAtivo_CheckedChanged;
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
            Update.Text = "Atualizar";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // btnEstatisticas
            // 
            btnEstatisticas.Location = new Point(713, 415);
            btnEstatisticas.Name = "btnEstatisticas";
            btnEstatisticas.Size = new Size(75, 23);
            btnEstatisticas.TabIndex = 13;
            btnEstatisticas.Text = "Estatísticas";
            btnEstatisticas.UseVisualStyleBackColor = true;
            btnEstatisticas.Click += button1_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(369, 357);
            Delete.Name = "Delete";
            Delete.Size = new Size(115, 42);
            Delete.TabIndex = 14;
            Delete.Text = "Apagar";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ProductRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Delete);
            Controls.Add(btnEstatisticas);
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
        private Label lblId;
        private CheckBox cbAtivo;
        private Button btnEstatisticas;
        private Button Delete;
    }
}
