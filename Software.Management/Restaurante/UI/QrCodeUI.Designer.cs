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
            ((System.ComponentModel.ISupportInitialize)pbQrCode).BeginInit();
            SuspendLayout();
            // 
            // pbQrCode
            // 
            pbQrCode.Location = new Point(231, 43);
            pbQrCode.Name = "pbQrCode";
            pbQrCode.Size = new Size(327, 314);
            pbQrCode.TabIndex = 0;
            pbQrCode.TabStop = false;
            // 
            // QrCodeUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbQrCode);
            Name = "QrCodeUI";
            Text = "QrCodeUI";
            Load += QrCodeUI_Load;
            ((System.ComponentModel.ISupportInitialize)pbQrCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbQrCode;
    }
}