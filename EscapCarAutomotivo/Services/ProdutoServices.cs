using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Models;
using EscapCarAutomotivo.Data;
using Microsoft.EntityFrameworkCore;

namespace EscapCarAutomotivo.Services
{
    public class ProductServices
    {
        private readonly EscapCarAutomotivoContext _context;

        public ProductServices(EscapCarAutomotivoContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task InsertAsync(Produto obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindById(int id)
        {
            return await _context.Produto.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = _context.Produto.Find(id);
            _context.Produto.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto obj)
        {
            bool hasAny = await _context.Produto.AnyAsync(x => x.Id == obj.Id);
            _context.Produto.Update(obj);
            await _context.SaveChangesAsync();
        }

    }
}


