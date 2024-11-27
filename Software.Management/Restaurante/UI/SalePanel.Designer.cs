namespace Restaurante.UI
{
    partial class SalePanel
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
            dtgSalePanel = new DataGridView();
            panel1 = new Panel();
            lblQuant = new Label();
            label4 = new Label();
            lblTotal = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgSalePanel).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtgSalePanel
            // 
            dtgSalePanel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgSalePanel.Location = new Point(4, 3);
            dtgSalePanel.Margin = new Padding(3, 2, 3, 2);
            dtgSalePanel.Name = "dtgSalePanel";
            dtgSalePanel.RowHeadersWidth = 51;
            dtgSalePanel.Size = new Size(733, 388);
            dtgSalePanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblQuant);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblTotal);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(742, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(226, 82);
            panel1.TabIndex = 1;
            // 
            // lblQuant
            // 
            lblQuant.AutoSize = true;
            lblQuant.Location = new Point(119, 49);
            lblQuant.Name = "lblQuant";
            lblQuant.Size = new Size(25, 15);
            lblQuant.TabIndex = 3;
            lblQuant.Text = "100";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 49);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 2;
            label4.Text = "Quantidade Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(81, 23);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(25, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "100";
            lblTotal.Click += lblTotal_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 23);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Total Geral:";
            // 
            // SalePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 392);
            Controls.Add(panel1);
            Controls.Add(dtgSalePanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SalePanel";
            Text = "Painel de vendas";
            Load += SalePanel_Load;
            ((System.ComponentModel.ISupportInitialize)dtgSalePanel).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgSalePanel;
        private Panel panel1;
        private Label lblTotal;
        private Label label1;
        private Label lblQuant;
        private Label label4;
    }
}