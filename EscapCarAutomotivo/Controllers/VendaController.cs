using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Services;
using EscapCarAutomotivo.Models.Enums;
using EscapCarAutomotivo.Models;
using EscapCarAutomotivo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EscapCarAutomotivo.Controllers
{
    public class VendaController : Controller
    {
        private readonly VendaServices _vendaServices;
        private readonly ClienteServices _clienteServices;

        public VendaController(VendaServices vendaServices, ClienteServices clienteServices)
        {
            _vendaServices = vendaServices;
            _clienteServices = clienteServices;
        }
        public IActionResult Index()
        {
            // var list = await _vendaServices.FindAllAsync();

            return View(/*list*/);
        }

        public async Task<IActionResult> Create()
        {
            var list = await _clienteServices.FindAllAsync();
            // var listp = await _produtoServices.FindAllAsync();
            var obj = new VendaformViewModel
            {
                Clientes = list,
                VendaStatus = Enum.GetValues(typeof(VendasStatus)).Cast<VendasStatus>().Select(en => new ItemEnumStatus
                {
                    Indice = (int)en,
                    Texto = en.ToString()
                }).ToList()
            };
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendaformViewModel venda)
        {
            var objVenda = new Venda
            {
                Status = (VendasStatus)venda.Status,
                Data = venda.DataVenda,
                Cliente = _clienteServices.FindById(venda.Cliente).Result,
                Amortecedor = venda.Amortecedor,
                KitAmortecedor = venda.KitAmortecedor,
                Bandeja = venda.Bandeja,
                Resultado = _vendaServices.Soma(venda.Amortecedor, venda.KitAmortecedor, venda.Bandeja),
            };

            await _vendaServices.InsertAsync(objVenda);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _vendaServices.FindByDataAsync(minDate, maxDate);
            return View(result);
        }
            public async Task<IActionResult> Delete(int? id)
            {
                var obj = await _vendaServices.FindById(id.Value);

                return View(obj);
            }
       
            [HttpPost]
            [AutoValidateAntiforgeryToken]
            public async Task<IActionResult> Delete(int id)
            {
                await _vendaServices.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            
        
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _vendaServices.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }


    }
}
