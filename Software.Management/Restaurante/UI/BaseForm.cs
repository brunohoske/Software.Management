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
            //this.BackColor = ColorTranslator.FromHtml("#E74C4C");
           



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

        public void EstilizarGrid(DataGridView dtg)
        {
            dtg.RowHeadersVisible = false;
            dtg.AllowUserToAddRows = false;

            // Configuração para ocultar a barra lateral de linhas
            dtg.RowHeadersVisible = false;

            // Configuração para desativar a linha vazia no final
            dtg.AllowUserToAddRows = false;

            // Configurações extras para melhorar a aparência
            dtg.EnableHeadersVisualStyles = false;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dtg.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtg.DefaultCellStyle.ForeColor = Color.Black;
            dtg.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dtg.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            dtg.DefaultCellStyle.SelectionForeColor = Color.White;
            dtg.BorderStyle = BorderStyle.None;
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg.GridColor = Color.LightGray;
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // Configurações para estilizar o DataGridView
            dtg.EnableHeadersVisualStyles = false;

            // Cabeçalho
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dtg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Linhas
            dtg.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtg.DefaultCellStyle.ForeColor = Color.Black;
            dtg.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dtg.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            dtg.DefaultCellStyle.SelectionForeColor = Color.White;

            // Estilo de linhas alternadas
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Bordas
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg.GridColor = Color.LightGray;

            // Estilo geral
            dtg.BackgroundColor = Color.FromArgb(255, 240, 240, 240) ;
            dtg.BorderStyle = BorderStyle.None;

            // Margens e padding
            dtg.RowTemplate.Height = 40;
            dtg.ColumnHeadersHeight = 50;
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
