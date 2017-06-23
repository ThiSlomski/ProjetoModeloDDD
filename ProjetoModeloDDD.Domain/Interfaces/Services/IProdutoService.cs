using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{

    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;


        public ProdutoService(IProdutoRepository ProdutoRepository)
            : base(ProdutoRepository)
        {
            _produtoRepository = ProdutoRepository;

        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

    }

}
