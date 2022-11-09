using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class MesRepositorio : RepositorioGenerico<Mes>, IMesRepositorio
    {
        public MesRepositorio(Contexto contexto): base(contexto)
        {
        }            
    }
}
