using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    internal class Users
    {
        private int id;
        private string nome;
        private string senha;
        private int codigo;


        public int Id
        {
            get { return this.id; }
            set
            {
                id = value;
                if (id < 0)
                {
                    Console.WriteLine("O id do Usuário, não pode ser menor que zero");
                }
                else
                {
                    Console.WriteLine("O id digitada corretamente");
                }
            }

        }

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
    }
}
