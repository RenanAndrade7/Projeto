using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Data;
using EscapCarAutomotivo.Models;
using EscapCarAutomotivo.Services;
using EscapCarAutomotivo.Models.ViewModels;

namespace EscapCarAutomotivo.Controllers
{
    public class ClienteController : Controller
    {
        // private readonly EscapCarAutomotivoContext _context;
        private readonly ClienteServices _clienteServices;

        public ClienteController(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _clienteServices.FindAllAsync();

            return View(list);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _clienteServices.InsertAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
           var obj = await _clienteServices.FindById(id.Value);

            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteServices.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {

            var obj = await _clienteServices.FindById(id.Value);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            await _clienteServices.UpdateAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

    }
}
