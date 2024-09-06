namespace Restaurante.UI
{
    partial class StatisticsProduct
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
            dtProduct = new DataGridView();
            panel1 = new Panel();
            lblTotalV = new Label();
            label5 = new Label();
            lblTotalR = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtProduct).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtProduct
            // 
            dtProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtProduct.Location = new Point(10, 6);
            dtProduct.Name = "dtProduct";
            dtProduct.Size = new Size(577, 333);
            dtProduct.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalV);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblTotalR);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(593, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(185, 334);
            panel1.TabIndex = 1;
            // 
            // lblTotalV
            // 
            lblTotalV.AutoSize = true;
            lblTotalV.Location = new Point(3, 89);
            lblTotalV.Name = "lblTotalV";
            lblTotalV.Size = new Size(0, 15);
            lblTotalV.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 65);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 4;
            label5.Text = "Valor Total Vendas";
            // 
            // lblTotalR
            // 
            lblTotalR.AutoSize = true;
            lblTotalR.Location = new Point(3, 40);
            lblTotalR.Name = "lblTotalR";
            lblTotalR.Size = new Size(0, 15);
            lblTotalR.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 13);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Total Receita Produto";
            // 
            // StatisticsProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 443);
            Controls.Add(panel1);
            Controls.Add(dtProduct);
            Name = "StatisticsProduct";
            Text = "StatisticsProduct";
            Load += StatisticsProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dtProduct).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtProduct;
        private Panel panel1;
        private Label lblTotalV;
        private Label label5;
        private Label lblTotalR;
        private Label label1;
    }
}