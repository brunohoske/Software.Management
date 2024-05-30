using ProjetoDeSoftware;
using Restaurante.BLL;
using Restaurante.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.UI
{
    public partial class MainMenu : Form
    {
        Users user;
        public MainMenu(Users u)
        {
            InitializeComponent();
            user = u;
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

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnTableManager_Click(object sender, EventArgs e)
        {
            CheckRegister cr = new CheckRegister();
            cr.Show();
        }
    }
}
