using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscapCarAutomotivo.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        // public Venda Venda { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Cliente()
        {

        }

        public Cliente(int id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }

       /* public void AddVenda(Venda sr)
        {
            Vendas.Add(sr);
        }

        public void RemoveVenda(Venda sr)
        {
            Vendas.Remove(sr);
        } */
    }
}
