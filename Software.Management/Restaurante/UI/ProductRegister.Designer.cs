
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
            lblId = new Label();
            dataGridView1 = new DataGridView();
            Insert = new Button();
            cbAtivo = new CheckBox();
            Update = new Button();
            btnEstatisticas = new Button();
            Delete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(161, 48);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(131, 23);
            txtNome.TabIndex = 0;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(471, 47);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(131, 23);
            txtPreco.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(316, 47);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(131, 23);
            txtDescription.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 29);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 4;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(471, 29);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Preço:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(316, 29);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 6;
            label3.Text = "Descrição:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(161, 9);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 15);
            lblId.TabIndex = 7;
            lblId.Text = "ID:";
            lblId.Visible = false;
            lblId.Click += L_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 292);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Insert
            // 
            Insert.Location = new Point(161, 105);
            Insert.Name = "Insert";
            Insert.Size = new Size(115, 42);
            Insert.TabIndex = 9;
            Insert.Text = "Inserir";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_Click;
            // 
            // cbAtivo
            // 
            cbAtivo.AutoSize = true;
            cbAtivo.Location = new Point(618, 69);
            cbAtivo.Margin = new Padding(3, 2, 3, 2);
            cbAtivo.Name = "cbAtivo";
            cbAtivo.Size = new Size(98, 19);
            cbAtivo.TabIndex = 9;
            cbAtivo.Text = "Produto ativo";
            cbAtivo.UseVisualStyleBackColor = true;
            cbAtivo.CheckedChanged += cbAtivo_CheckedChanged;
            // 
            // Update
            // 
            Update.Location = new Point(316, 105);
            Update.Name = "Update";
            Update.Size = new Size(115, 42);
            Update.TabIndex = 11;
            Update.Text = "Atualizar";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // btnEstatisticas
            // 
            btnEstatisticas.Location = new Point(713, 124);
            btnEstatisticas.Name = "btnEstatisticas";
            btnEstatisticas.Size = new Size(75, 23);
            btnEstatisticas.TabIndex = 13;
            btnEstatisticas.Text = "Estatísticas";
            btnEstatisticas.UseVisualStyleBackColor = true;
            btnEstatisticas.Click += button1_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(471, 105);
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
            Controls.Add(cbAtivo);
            Controls.Add(Delete);
            Controls.Add(btnEstatisticas);
            Controls.Add(lblId);
            Controls.Add(txtPreco);
            Controls.Add(txtDescription);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(Update);
            Controls.Add(Insert);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "ProductRegister";
            Text = "Gerenciar Produtos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblId;
        private DataGridView dataGridView1;
        private Button Insert;
        private Button Update;
        private CheckBox cbAtivo;
        private Button btnEstatisticas;
        private Button Delete;
    }
}
