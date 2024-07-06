
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
        public QrCodeUI(string url)
        {
            
            InitializeComponent();
            pbQrCode.Image = GenerateImageQrCode(url); 
            


        }

        private Bitmap GenerateImageQrCode(string url)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            var qrCodeData = qr.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(5);
            return qrCodeImage;

        }


        private void QrCodeUI_Load(object sender, EventArgs e)
        {

        }
    }
}
