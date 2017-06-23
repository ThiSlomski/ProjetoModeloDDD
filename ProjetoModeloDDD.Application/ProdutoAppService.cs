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
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {

        private readonly IProdutoService _ProdutoAppService;


        public ProdutoAppService(IProdutoService ProdutoAppService)
            : base(ProdutoAppService)
        {
            _ProdutoAppService = ProdutoAppService;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _ProdutoAppService.BuscarPorNome(nome);
        }

    }
}