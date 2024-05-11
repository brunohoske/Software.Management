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
        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text != "Nome" && TxtNome.Text != "" && TxtSenha.Text != "" && TxtSenha.Text != "Senha")
            {
                string nomeLogin = TxtNome.Text;
                string senhaLogin = TxtSenha.Text;
                int codigoLogin;
                if (TxtCodigo.Text != "")
                {
                    codigoLogin = int.Parse(TxtCodigo.Text);
                }


                DALUsers d = new DALUsers();
                Users user = d.SearchUser(TxtNome.Text);


                if (user != null)
                {
                    if (d.ValidatePass(user, TxtSenha.Text))
                    {
                        MainMenu m = new MainMenu();
                        m.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nome ou senha inválido");
                    }
                }
                else
                {
                    MessageBox.Show("Nome ou senha inválido");
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome e a senha.");
            }

        }

        #region placeholders
        private void Form1_Load(object sender, EventArgs e)
        {
            TxtNome.Text = "Nome";
            TxtSenha.Text = "Senha";
            TxtCodigo.Text = "";
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

    }
}