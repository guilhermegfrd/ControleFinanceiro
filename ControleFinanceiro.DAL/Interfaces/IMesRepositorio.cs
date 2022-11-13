using ControleFinanceiro.BLL.Models;
using System.Linq;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IMesRepositorio : IRepositorioGenerico<Mes>
    {
        new IQueryable<Mes> PegarTodos();
    }
}
