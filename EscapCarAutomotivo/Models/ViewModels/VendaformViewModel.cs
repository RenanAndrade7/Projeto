using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Services;

namespace EscapCarAutomotivo.Models.ViewModels
{
    public class VendaformViewModel
    {
        public ICollection<Cliente> Clientes { get; set; }
        public int Cliente { get; set; }
        public DateTime DataVenda { get; set; }
        public int Status { get; set; }
        public double Amortecedor { get; set; }
        public double KitAmortecedor { get; set; }
        public double Bandeja { get; set; }
        public ICollection<ItemEnumStatus> VendaStatus { get; set; }
    }

    public class ItemEnumStatus
    {
        public int Indice { get; set; }
        public string Texto { get; set; }
    }
}
