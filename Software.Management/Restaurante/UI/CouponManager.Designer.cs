namespace Restaurante.UI
{
    partial class CouponManager
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
            dtgCoupon = new DataGridView();
            panel1 = new Panel();
            cbActive = new CheckBox();
            txtCode = new TextBox();
            label1 = new Label();
            lblIdDiscount = new Label();
            txtPercentual = new TextBox();
            lblId = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgCoupon).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(713, 483);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(187, 54);
            BtnDelete.TabIndex = 33;
            BtnDelete.Text = "Apagar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(496, 483);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(187, 54);
            BtnUpdate.TabIndex = 32;
            BtnUpdate.Text = "Editar";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BntInsert
            // 
            BntInsert.Location = new Point(279, 483);
            BntInsert.Name = "BntInsert";
            BntInsert.Size = new Size(187, 54);
            BntInsert.TabIndex = 31;
            BntInsert.Text = "Adicionar";
            BntInsert.UseVisualStyleBackColor = true;
            BntInsert.Click += BntInsert_Click;
            // 
            // dtgCoupon
            // 
            dtgCoupon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCoupon.Location = new Point(264, 12);
            dtgCoupon.Name = "dtgCoupon";
            dtgCoupon.Size = new Size(644, 449);
            dtgCoupon.TabIndex = 30;
            dtgCoupon.CellClick += dtgCoupon_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbActive);
            panel1.Controls.Add(txtCode);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblIdDiscount);
            panel1.Controls.Add(txtPercentual);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(17, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 296);
            panel1.TabIndex = 29;
            // 
            // cbActive
            // 
            cbActive.AutoSize = true;
            cbActive.Checked = true;
            cbActive.CheckState = CheckState.Checked;
            cbActive.Location = new Point(13, 13);
            cbActive.Name = "cbActive";
            cbActive.Size = new Size(95, 19);
            cbActive.TabIndex = 26;
            cbActive.Text = "Cupom ativo";
            cbActive.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(72, 48);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(123, 23);
            txtCode.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 51);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 24;
            label1.Text = "Código:";
            // 
            // lblIdDiscount
            // 
            lblIdDiscount.AutoSize = true;
            lblIdDiscount.Location = new Point(13, 95);
            lblIdDiscount.Name = "lblIdDiscount";
            lblIdDiscount.Size = new Size(0, 15);
            lblIdDiscount.TabIndex = 23;
            lblIdDiscount.Visible = false;
            // 
            // txtPercentual
            // 
            txtPercentual.Location = new Point(153, 77);
            txtPercentual.Name = "txtPercentual";
            txtPercentual.Size = new Size(42, 23);
            txtPercentual.TabIndex = 22;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(129, 48);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 15);
            lblId.TabIndex = 8;
            lblId.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 80);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 5;
            label2.Text = "Percentual de desconto:";
            // 
            // CouponManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 593);
            Controls.Add(BtnDelete);
            Controls.Add(BtnUpdate);
            Controls.Add(BntInsert);
            Controls.Add(dtgCoupon);
            Controls.Add(panel1);
            Name = "CouponManager";
            Text = "Gerenciar Cupons";
            ((System.ComponentModel.ISupportInitialize)dtgCoupon).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button BtnDelete;
        private Button BtnUpdate;
        private Button BntInsert;
        private DataGridView dtgCoupon;
        private Panel panel1;
        private Label lblIdDiscount;
        private TextBox txtPercentual;
        private Label lblId;
        private Label label2;
        private TextBox txtCode;
        private Label label1;
        private CheckBox cbActive;
    }
}