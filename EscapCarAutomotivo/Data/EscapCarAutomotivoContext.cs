using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscapCarAutomotivo.Models;

namespace EscapCarAutomotivo.Data
{
    public class EscapCarAutomotivoContext : DbContext
    {
        public EscapCarAutomotivoContext(DbContextOptions<EscapCarAutomotivoContext> options)
           : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public DbSet<Venda> Venda { get; set; }
    }
}

