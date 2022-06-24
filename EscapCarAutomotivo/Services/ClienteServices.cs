using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Data;
using EscapCarAutomotivo.Models;
using Microsoft.EntityFrameworkCore;


namespace EscapCarAutomotivo.Services
{
    public class ClienteServices
    {

        private readonly EscapCarAutomotivoContext _context;

        public ClienteServices(EscapCarAutomotivoContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task InsertAsync(Cliente obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> FindById(int Id)
        {
            return await _context.Cliente.FindAsync(Id);
        } 

        public async Task RemoveAsync(int Id)
        {
            var obj = _context.Cliente.Find(Id);
            _context.Cliente.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente obj)
        {
            bool hasAny = await _context.Cliente.AnyAsync(x => x.Id == obj.Id);
            _context.Cliente.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
