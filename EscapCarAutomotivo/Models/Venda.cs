using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Models.Enums;
using EscapCarAutomotivo.Models;
using System.ComponentModel.DataAnnotations;

namespace EscapCarAutomotivo.Models
{
    public class Venda
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        public VendasStatus Status { get; set; }

        public Cliente Cliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amortecedor { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double KitAmortecedor { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Bandeja { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Resultado { get; set; }

        public Venda()
        {

        }

        public Venda(int id, DateTime data, VendasStatus status, Cliente cliente, double amortecedor, double kitAmortecedor,double bandeja)
        {
            Id = id;
            Data = data;
            Status = status;
            Cliente = cliente;
            Amortecedor = amortecedor;
            KitAmortecedor = kitAmortecedor;
            Bandeja = bandeja;
        }
    }

}
