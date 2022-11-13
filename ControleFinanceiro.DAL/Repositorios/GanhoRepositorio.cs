using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class GanhoRepositorio : RepositorioGenerico<Ganho>, IGanhoRepositorio
    {
        private readonly Contexto _contexto;

        public GanhoRepositorio(Contexto contexto): base(contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Ganho> PegarGanhosPeloUsuarioId(string usuarioId)
        {
            try
            {
                return _contexto.Ganhos.Include(x => x.Categoria).Include(x => x.Mes).Where(x => x.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }    

        public IQueryable<Ganho> FiltrarGanhos(string nomeCategoria)
        {
            try
            {
                return _contexto.Ganhos.Include(x => x.Mes)
                    .Include(x => x.Categoria).ThenInclude(x => x.Tipo)
                    .Where(x => x.Categoria.Nome.Contains(nomeCategoria) && x.Categoria.Tipo.Nome.Contains("Ganho"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<double> PegarGanhoTotalPeloUsuarioId(string usuarioId)
        {
            try
            {
                return _contexto.Ganhos.Where(x => x.UsuarioId == usuarioId).SumAsync(x => x.Valor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
