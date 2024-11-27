namespace Restaurante.UI
{
    partial class CheckRegister
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
            BtnDelete = new Button();
            BtnUpdate = new Button();
            panel1 = new Panel();
            lblnumMesa = new Label();
            txtNumMesa = new TextBox();
            lblnum = new Label();
            label2 = new Label();
            BntInsert = new Button();
            dataGridView1 = new DataGridView();
            btnGerarQR = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(366, 378);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(115, 42);
            BtnDelete.TabIndex = 17;
            BtnDelete.Text = "Deletar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(207, 378);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(115, 42);
            BtnUpdate.TabIndex = 16;
            BtnUpdate.Text = "Atualizar";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblnumMesa);
            panel1.Controls.Add(txtNumMesa);
            panel1.Controls.Add(lblnum);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 296);
            panel1.TabIndex = 15;
            panel1.Paint += panel1_Paint;
            // 
            // lblnumMesa
            // 
            lblnumMesa.AutoSize = true;
            lblnumMesa.Location = new Point(124, 14);
            lblnumMesa.Name = "lblnumMesa";
            lblnumMesa.Size = new Size(0, 15);
            lblnumMesa.TabIndex = 8;
            lblnumMesa.Visible = false;
            // 
            // txtNumMesa
            // 
            txtNumMesa.Location = new Point(26, 74);
            txtNumMesa.Name = "txtNumMesa";
            txtNumMesa.Size = new Size(131, 23);
            txtNumMesa.TabIndex = 1;
            // 
            // lblnum
            // 
            lblnum.AutoSize = true;
            lblnum.Location = new Point(26, 14);
            lblnum.Name = "lblnum";
            lblnum.Size = new Size(85, 15);
            lblnum.TabIndex = 7;
            lblnum.Text = "Número Mesa:";
            lblnum.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 56);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 5;
            label2.Text = "Número da Mesa";
            // 
            // BntInsert
            // 
            BntInsert.Location = new Point(54, 378);
            BntInsert.Name = "BntInsert";
            BntInsert.Size = new Size(115, 42);
            BntInsert.TabIndex = 14;
            BntInsert.Text = "Cadastrar";
            BntInsert.UseVisualStyleBackColor = true;
            BntInsert.Click += BntInsert_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(266, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(522, 294);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnGerarQR
            // 
            btnGerarQR.Location = new Point(675, 332);
            btnGerarQR.Margin = new Padding(3, 2, 3, 2);
            btnGerarQR.Name = "btnGerarQR";
            btnGerarQR.Size = new Size(115, 42);
            btnGerarQR.TabIndex = 9;
            btnGerarQR.Text = "Gerar QR Code";
            btnGerarQR.UseVisualStyleBackColor = true;
            btnGerarQR.Click += btnGerarQR_Click;
            // 
            // CheckRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGerarQR);
            Controls.Add(BtnDelete);
            Controls.Add(BtnUpdate);
            Controls.Add(panel1);
            Controls.Add(BntInsert);
            Controls.Add(dataGridView1);
            Name = "CheckRegister";
            Text = "Gerenciar Mesas";
            Load += CheckRegister_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnDelete;
        private Button BtnUpdate;
        private Panel panel1;
        private Label lblnumMesa;
        private Label lblnum;
        private Label label2;
        private Button BntInsert;
        private DataGridView dataGridView1;
        private TextBox txtNumMesa;
        private Button btnGerarQR;
    }
}