using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    internal class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public float Preco {  get; private set; }

        public int Qntd { get; private set; }

        public Produto(int id, string nome, float preco,int qntd ) 
        {

            Id = id;
            Nome = nome;
            Preco = preco;
            Qntd = qntd;

        }

        public Produto(string nome, float preco, int qntd)
        {
            Nome = nome;
            Preco = preco;
            Qntd = qntd;

        }

    }
}
