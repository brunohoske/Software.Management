using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.DTO
{
    public class Produto
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public float Preco { get; set; }
        public string Descricao { get; set; }
        public int Qntd { get; set; }
        public bool IsActive { get; set; }

        public Produto() { }

        public Produto(string nome, float preco, string desc)
        {
            Nome = nome;
            Preco = preco;
            Descricao = desc;
        }
        public Produto(int id,string nome, float preco, string desc)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = desc;
        }

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
