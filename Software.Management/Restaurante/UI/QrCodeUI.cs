
using System.Drawing.Printing;
using QRCoder;
using Restaurante.Models;

namespace Restaurante.UI
{
    public partial class QrCodeUI : BaseForm
    {
        string url = "";
        Store store = new Store();
        public QrCodeUI(string url)
        {
            InitializeComponent();
            this.url = url;

        }


        public QrCodeUI(string url,bool haveName,  Store store)
        {
            InitializeComponent();
            this.url = url;
            this.store = store;

        }
        private void QrCodeUI_Load(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            var qrCodeData = qr.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            qrCodeImage = qrCode.GetGraphic(5);

            pbQrCode.Image = qrCodeImage;
            pbQrCode.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        private Image qrCodeImage;
        private int qrcodeCount = 1;

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (qrCodeImage != null)
                {
                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += PrintDocument_PrintPage;

                    using (PrintDialog printDialog = new PrintDialog())
                    {
                        printDialog.Document = printDocument;

                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            printDocument.Print();
                  
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

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (qrCodeImage != null)
            {
                float x = (e.PageBounds.Width - qrCodeImage.Width) / 2;
                float y = (e.PageBounds.Height - qrCodeImage.Height) / 2;

                e.Graphics.DrawImage(qrCodeImage, x, y, qrCodeImage.Width, qrCodeImage.Height);
            }
        }
    }
}
