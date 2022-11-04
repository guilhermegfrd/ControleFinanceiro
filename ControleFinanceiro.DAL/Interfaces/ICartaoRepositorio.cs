using ControleFinanceiro.BLL.Models;
using System.Linq;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICartaoRepositorio : IRepositorioGenerico<Cartao>
    {
        IQueryable<Cartao> PegarCartoesPeloUsuarioId(string usuarioId);
        IQueryable<Cartao> FiltrarCartoes(string numeroCartao);

    }
}
