using Restaurante.BLL;
using Restaurante.DTO;
using Restaurante.UI;

namespace Restaurante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Logar()
        {
            if (TxtNome.Text != "Nome" && TxtNome.Text != "" && TxtSenha.Text != "" && TxtSenha.Text != "Senha")
            {
                string nomeLogin = TxtNome.Text;
                string senhaLogin = TxtSenha.Text;


                DALUsers d = new DALUsers();
                Users user = d.SearchUser(TxtNome.Text);


                if (user != null)
                {
                    if (d.ValidatePass(user, TxtSenha.Text))
                    {
                        MainMenu m = new MainMenu(user);
                        m.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Nome ou senha inv�lido");
                    }
                }
                else
                {
                    MessageBox.Show("Nome ou senha inv�lido");
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome e a senha.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Logar();
        }

        #region placeholders
        private void Form1_Load(object sender, EventArgs e)
        {
            TxtNome.Text = "Nome";
            TxtSenha.Text = "Senha";
        }

        private void TxtNome_Enter(object sender, EventArgs e)
        {
            if (TxtNome.Text == "Nome")
            {
                TxtNome.Text = "";
            }
        }

        private void TxtNome_Leave(object sender, EventArgs e)
        {
            if (TxtNome.Text == "")
            {
                TxtNome.Text = "Nome";

            }
        }

        private void TxtSenha_Enter(object sender, EventArgs e)
        {
            if (TxtSenha.Text == "Senha")
            {
                TxtSenha.Text = "";
            }
        }

        private void TxtSenha_Leave(object sender, EventArgs e)
        {
            if (TxtSenha.Text == "")
            {
                TxtSenha.Text = "Senha";

            }
        }
        #endregion



        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                Logar(); // Chama o m�todo Logar
            }
        }
    }
}