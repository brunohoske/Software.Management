namespace Restaurante.UI
{
    partial class QrCodeUI
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
            pbQrCode = new PictureBox();
            BtnGerar = new Button();
            BtnSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbQrCode).BeginInit();
            SuspendLayout();
            // 
            // pbQrCode
            // 
            pbQrCode.Location = new Point(202, 32);
            pbQrCode.Margin = new Padding(3, 2, 3, 2);
            pbQrCode.Name = "pbQrCode";
            pbQrCode.Size = new Size(286, 236);
            pbQrCode.TabIndex = 0;
            pbQrCode.TabStop = false;
            // 
            // BtnGerar
            // 
            BtnGerar.Location = new Point(202, 288);
            BtnGerar.Name = "BtnGerar";
            BtnGerar.Size = new Size(153, 23);
            BtnGerar.TabIndex = 1;
            BtnGerar.Text = "Gerar QRCODE";
            BtnGerar.UseVisualStyleBackColor = true;
            BtnGerar.Click += button1_Click;
            // 
            // BtnSalvar
            // 
            BtnSalvar.Location = new Point(361, 288);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(127, 23);
            BtnSalvar.TabIndex = 2;
            BtnSalvar.Text = "Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // QrCodeUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(BtnSalvar);
            Controls.Add(BtnGerar);
            Controls.Add(pbQrCode);
            Margin = new Padding(3, 2, 3, 2);
            Name = "QrCodeUI";
            Text = "QrCodeUI";
            Load += QrCodeUI_Load;
            ((System.ComponentModel.ISupportInitialize)pbQrCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbQrCode;
        private Button BtnGerar;
        private Button BtnSalvar;
    }
}