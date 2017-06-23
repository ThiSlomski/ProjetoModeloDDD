using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {

        private readonly IClienteRepository _clienteRepository;


        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;

        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> cliente)
        {
            return cliente.Where(c => c.ClienteEspecial(c));
        }
    }
}
