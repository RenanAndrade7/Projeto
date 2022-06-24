using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Data;
using EscapCarAutomotivo.Models;
using Microsoft.EntityFrameworkCore;


namespace EscapCarAutomotivo.Services
{
    public class VendaServices
    {
        private readonly EscapCarAutomotivoContext _context; 

        public VendaServices(EscapCarAutomotivoContext context)
        {
            _context = context;
        }

        /* public async Task<List<Venda>> FindAllAsync()
        {
            return await _context.Venda.ToListAsync();
        }*/

        public async Task InsertAsync(Venda obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        /* public List<Venda> FindAll()
        {
            return _context.Venda.ToList();
        }*/

        public async Task<List<Venda>> FindByDataAsync(DateTime? minData, DateTime? maxData)
        {
            var result = from obj in _context.Venda select obj;
            if (minData.HasValue)
            {
                result = result.Where(x => x.Data >= minData.Value);
            }

            if (minData.HasValue)
            {
                result = result.Where(x => x.Data <= maxData.Value);
            }

            return await result.Include(x => x.Cliente).OrderByDescending(x => x.Data).ToListAsync();
        }

        public async Task<List<Venda>> FindByDateGroupingAsync(DateTime? minData, DateTime? maxData)
        {
            var result = from obj in _context.Venda select obj;
            if (minData.HasValue)
            {
                result = result.Where(x => x.Data >= minData.Value);
            }

            if (minData.HasValue)
            {
                result = result.Where(x => x.Data <= maxData.Value);
            }

            return await result.Include(x => x.Cliente).OrderByDescending(x => x.Data).ToListAsync();
        }
        public  double Soma (double obj1, double obj2, double obj3)
        {
            double resultado = obj1 + obj2 + obj3;
            return (resultado);
        }

        public async Task<Venda> FindById(int Id)
        {
            return await _context.Venda.FindAsync(Id);
        }

        public async Task RemoveAsync(int Id)
        {
            var obj = _context.Venda.Find(Id);
            _context.Venda.Remove(obj);
            await _context.SaveChangesAsync();
        }

    }
}
