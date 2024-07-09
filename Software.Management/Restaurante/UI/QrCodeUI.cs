
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace Restaurante.UI
{
    public partial class QrCodeUI : Form
    {
        string url = "";
        public QrCodeUI(string url)
        {
            InitializeComponent();
            this.url = url;

        }
        private void QrCodeUI_Load(object sender, EventArgs e)
        {

        }
        private Image qrCodeImage;
        private int qrcodeCount = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            var qrCodeData = qr.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            qrCodeImage = qrCode.GetGraphic(5);

            pbQrCode.Image = qrCodeImage;
            pbQrCode.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (qrCodeImage != null)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PNG Image|*.png";
                        saveFileDialog.Title = "Salvar QR Code";
                        saveFileDialog.FileName = $"qrcode_{qrcodeCount}.png";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            qrCodeImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            qrcodeCount++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, gere um QR code primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
