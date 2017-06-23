using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {

        private readonly IClienteService _clienteAppService;


        public ClienteAppService(IClienteService clienteAppService)
            : base(clienteAppService)
        {
            _clienteAppService = clienteAppService;

        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteAppService.ObterClientesEspeciais(_clienteAppService.GetAll());
        }


    }
}