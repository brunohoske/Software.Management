namespace Restaurante.Models
{
    public class Users
    {
        private int id;
        private string nome;
        private string senha;
        private int codigo;
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Cnpj { get; set; }

        public string Nome
        {
            get { return nome; }
            set
            {
                this.nome = value;
                if (nome.Length > 0)
                {
                    this.nome = nome.ToUpper();
                }
                else
                {
                    Console.WriteLine("Não é valido vazio para nome");
                }
            }

        }


        public string Senha
        {
            get { return senha; }
            set
            {
                this.senha = value;
                if (senha.Length > 0)
                {
                    Console.WriteLine("Senha não pode ser vazia");
                }
                else
                {
                    Console.WriteLine("Senha digitada corretamente");
                }
            }
        }


        public int Codigo
        {
            get { return this.codigo; }
            set
            {
                codigo = value;
                if (codigo < 0)
                {
                    Console.WriteLine("O Codigo do Admin não pode ser vazio");
                }
                else
                {
                    Console.WriteLine("O Código digitada corretamente");
                }
            }

        }

        public Users(int id, string nome, string senha, bool adm)
        {
            Id = id;
            Nome = nome;
            Senha = senha;

            if (adm == true)
            {
                Codigo = 1;
            }
            else
            {
                Codigo = 0;
            }
        }

        public Users(string nome, string senha, bool adm)
        {
            Nome = nome;
            Senha = senha;

            if (adm == true)
            {
                Codigo = 1;
            }
            else
            {
                Codigo = 0;
            }
        }

        public Users() { }

        


    }
}
