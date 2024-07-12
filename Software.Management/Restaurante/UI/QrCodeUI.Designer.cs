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
            BtnSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbQrCode).BeginInit();
            SuspendLayout();
            // 
            // pbQrCode
            // 
            pbQrCode.Location = new Point(231, 43);
            pbQrCode.Name = "pbQrCode";
            pbQrCode.Size = new Size(327, 315);
            pbQrCode.TabIndex = 0;
            pbQrCode.TabStop = false;
            // 
            // BtnSalvar
            // 
            BtnSalvar.Location = new Point(598, 94);
            BtnSalvar.Margin = new Padding(3, 4, 3, 4);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(145, 31);
            BtnSalvar.TabIndex = 2;
            BtnSalvar.Text = "Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // QrCodeUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(BtnSalvar);
            Controls.Add(pbQrCode);
            Name = "QrCodeUI";
            Text = "QrCodeUI";
            Load += QrCodeUI_Load;
            ((System.ComponentModel.ISupportInitialize)pbQrCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbQrCode;
        private Button BtnSalvar;
    }
}