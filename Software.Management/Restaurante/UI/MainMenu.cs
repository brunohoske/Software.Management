using ProjetoDeSoftware;
using Restaurante.DAO;
using Restaurante.Models;

namespace Restaurante.UI
{
    public partial class MainMenu : BaseForm
    {
        Users user;
        DAOStore daoStore = new DAOStore();
        Store store = new Store();
        public MainMenu(Users u)
        {
            InitializeComponent();
            user = u;
            this.BackColor = ColorTranslator.FromHtml("#E74C4C");
            store = daoStore.GetCompanyFromCNPJ(user.Cnpj);
            pbStoreLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStoreLogo.Visible = true;
            pbStoreLogo.ImageLocation = store.Logo;
            pbStoreLogo.Load();

            lblName.Text = store.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductRegister productRegister = new ProductRegister();
            productRegister.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (user.Codigo == 1)
            {
                UserMenager um = new UserMenager();
                um.Show();
            }
            else
            {
                MessageBox.Show("Você não tem acesso.");
            }
        }

        private void btnTableManager_Click(object sender, EventArgs e)
        {
            CheckRegister cr = new CheckRegister();
            cr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DiscountManager ds = new DiscountManager();
            ds.Show();
        }

        private void btnVendaPanel_Click(object sender, EventArgs e)
        {
            SalePanel s = new SalePanel();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FeedbackUI feedbackUI = new FeedbackUI();
            feedbackUI.Show();

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
