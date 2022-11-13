using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using System;
using System.Linq;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class MesRepositorio : RepositorioGenerico<Mes>, IMesRepositorio
    {
        private readonly Contexto _contexto;
        public MesRepositorio(Contexto contexto): base(contexto)
        {
            _contexto = contexto;
        }

        public new IQueryable<Mes> PegarTodos()
        {
            try
            {
                return _contexto.Meses.OrderBy(x => x.MesId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
