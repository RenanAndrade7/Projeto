using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscapCarAutomotivo.Services;
using EscapCarAutomotivo.Models;
using EscapCarAutomotivo.Data;
using EscapCarAutomotivo.Models.Enums;
using EscapCarAutomotivo.Models.ViewModels;


namespace EscapCarAutomotivo.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProductServices _produtoServices;
        private readonly ClienteServices _clienteServices;

        public ProdutoController(ProductServices produtoServices, ClienteServices clienteServices)
        {
            _produtoServices = produtoServices;
            _clienteServices = clienteServices;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _produtoServices.FindAllAsync();
            return View(list);
        }

        public IActionResult Create() // Controlador Create que irá chamar a View Create
        {
            return View();
        }


        [HttpPost] // Mesmo controlador Create anterior mas esse é para atualizar,
                   // gravar informação no Banco de Dados
        [ValidateAntiForgeryToken] // Proteção para não invadirem a página
        public async Task<IActionResult> Create(Produto produto)
        {
            await _produtoServices.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
           
            var obj = await _produtoServices.FindById(id.Value);  

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoServices.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {

            var obj = await _produtoServices.FindById(id.Value);
            ClientProductformViewModel viewModel = new ClientProductformViewModel { Produto = obj };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            await _produtoServices.UpdateAsync(produto);
            return RedirectToAction(nameof(Index));
        }


    }
}


    

