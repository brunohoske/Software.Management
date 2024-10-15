using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.UI
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            // Definindo propriedades padrão
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.MaximizeBox = false; 
            this.MinimizeBox = true;
            this.BackColor = ColorTranslator.FromHtml("#E74C4C");



            if (!this.DesignMode)
            {
                // Caminho do ícone baseado no diretório do aplicativo
                string iconPath = Path.Combine(Application.StartupPath, "Images", "logo_simplificado_multi.ico");

                // Verificando se o ícone existe
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
                else
                {

                }
            }
        }
    }
}
