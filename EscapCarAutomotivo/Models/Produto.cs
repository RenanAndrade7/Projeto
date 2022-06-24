using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Models;

namespace EscapCarAutomotivo.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public  double Valor { get; set; }
        // public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Produto()
        {

        }
        public Produto(int id, string nome, double valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }
}
