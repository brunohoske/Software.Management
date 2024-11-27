namespace Restaurante.UI
{
    partial class DiscountManager
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
            BntInsert = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            lblIdDiscount = new Label();
            txtPercentual = new TextBox();
            lblId = new Label();
            lblnum = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(930, 506);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(187, 54);
            BtnDelete.TabIndex = 26;
            BtnDelete.Text = "Apagar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(713, 506);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(187, 54);
            BtnUpdate.TabIndex = 25;
            BtnUpdate.Text = "Editar";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BntInsert
            // 
            BntInsert.Location = new Point(496, 506);
            BntInsert.Name = "BntInsert";
            BntInsert.Size = new Size(187, 54);
            BntInsert.TabIndex = 24;
            BntInsert.Text = "Adicionar";
            BntInsert.UseVisualStyleBackColor = true;
            BntInsert.Click += BntInsert_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(335, 261);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(764, 238);
            dataGridView1.TabIndex = 23;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblIdDiscount);
            panel1.Controls.Add(txtPercentual);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(lblnum);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(22, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 296);
            panel1.TabIndex = 22;
            panel1.Paint += panel1_Paint;
            // 
            // lblIdDiscount
            // 
            lblIdDiscount.AutoSize = true;
            lblIdDiscount.Location = new Point(108, 141);
            lblIdDiscount.Name = "lblIdDiscount";
            lblIdDiscount.Size = new Size(0, 15);
            lblIdDiscount.TabIndex = 23;
            lblIdDiscount.Visible = false;
            // 
            // txtPercentual
            // 
            txtPercentual.Location = new Point(147, 53);
            txtPercentual.Name = "txtPercentual";
            txtPercentual.Size = new Size(42, 23);
            txtPercentual.TabIndex = 22;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(124, 14);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 15);
            lblId.TabIndex = 8;
            lblId.Visible = false;
            // 
            // lblnum
            // 
            lblnum.AutoSize = true;
            lblnum.Location = new Point(13, 14);
            lblnum.Name = "lblnum";
            lblnum.Size = new Size(78, 15);
            lblnum.TabIndex = 7;
            lblnum.Text = "ID PRODUTO:";
            lblnum.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 56);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 5;
            label2.Text = "Percentual de desconto:";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(335, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(764, 243);
            dataGridView2.TabIndex = 27;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(35, 355);
            button1.Name = "button1";
            button1.Size = new Size(187, 54);
            button1.TabIndex = 28;
            button1.Text = "Gerenciar Cupons";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DiscountManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 584);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(BtnDelete);
            Controls.Add(BtnUpdate);
            Controls.Add(BntInsert);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "DiscountManager";
            Text = "Gerenciar Descontos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnDelete;
        private Button BtnUpdate;
        private Button BntInsert;
        private DataGridView dataGridView1;
        private Panel panel1;
        private TextBox txtPercentual;
        private Label lblId;
        private Label lblnum;
        private Label label2;
        private DataGridView dataGridView2;
        private Label lblIdDiscount;
        private Button button1;
    }
}