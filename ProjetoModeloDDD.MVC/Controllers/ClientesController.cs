using AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }


        // GET: Clientes
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.GetAll());

            return View(model);
        }

        // GET: Clientes
        public ActionResult Especiais()
        {
            var model = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.ObterClientesEspeciais());

            return View(model);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var model = Mapper.Map<Cliente, ClienteViewModel>(_clienteAppService.GetById(id));

            return View(model);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(model);
                _clienteAppService.Add(clienteDomain);
                return RedirectToAction("index");
            }

            return View(model);

        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<Cliente, ClienteViewModel>(_clienteAppService.GetById(id));

            return View(model);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(model);
                _clienteAppService.Update(clienteDomain);
                return RedirectToAction("index");
            }

            return View(model);

        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Mapper.Map<Cliente, ClienteViewModel>(_clienteAppService.GetById(id));
            return View(model);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var cliente = _clienteAppService.GetById(id);
            _clienteAppService.Remove(cliente);

            return RedirectToAction("index");



        }
    }
}
