using ControleFinanceiro.BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IGanhoRepositorio : IRepositorioGenerico<Ganho>
    {
        IQueryable<Ganho> PegarGanhosPeloUsuarioId(string usuarioId);
        IQueryable<Ganho> FiltrarGanhos(string nomeCategoria);
        Task<double> PegarGanhoTotalPeloUsuarioId(string usuarioId);
    }
}
