namespace Restaurante.UI
{
    partial class FeedbackUI
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
            dtgOrders = new DataGridView();
            dtgFeedback = new DataGridView();
            lblIdOrder = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgFeedback).BeginInit();
            SuspendLayout();
            // 
            // dtgOrders
            // 
            dtgOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgOrders.Location = new Point(12, 284);
            dtgOrders.Name = "dtgOrders";
            dtgOrders.Size = new Size(755, 154);
            dtgOrders.TabIndex = 29;
            // 
            // dtgFeedback
            // 
            dtgFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgFeedback.Location = new Point(12, 37);
            dtgFeedback.Name = "dtgFeedback";
            dtgFeedback.Size = new Size(755, 200);
            dtgFeedback.TabIndex = 28;
            dtgFeedback.CellClick += dtgFeedback_CellClick;
            // 
            // lblIdOrder
            // 
            lblIdOrder.AutoSize = true;
            lblIdOrder.Location = new Point(135, 19);
            lblIdOrder.Name = "lblIdOrder";
            lblIdOrder.Size = new Size(0, 15);
            lblIdOrder.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(331, 6);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 31;
            label1.Text = "FEEDBACKS:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(226, 253);
            label2.Name = "label2";
            label2.Size = new Size(294, 28);
            label2.TabIndex = 31;
            label2.Text = "ITENS REALIZADOS NO PEDIDO:";
            // 
            // FeedbackUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblIdOrder);
            Controls.Add(dtgOrders);
            Controls.Add(dtgFeedback);
            Name = "FeedbackUI";
            Text = "Visualizar Feedbacks";
            Load += FeedbackUI_Load;
            ((System.ComponentModel.ISupportInitialize)dtgOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgFeedback).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgOrders;
        private DataGridView dtgFeedback;
        private Label lblIdOrder;
        private Label label1;
        private Label label2;
    }
}