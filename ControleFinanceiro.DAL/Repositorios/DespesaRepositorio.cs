using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class DespesaRepositorio : RepositorioGenerico<Despesa>, IDespesaRepositorio
    {
        private readonly Contexto _contexto;

        public DespesaRepositorio(Contexto contexto): base(contexto)
        {
            _contexto = contexto;
        }

        public void ExcluirDespesas(IEnumerable<Despesa> despesas)
        {
            try
            {
                _contexto.Despesas.RemoveRange(despesas);                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Despesa>> PegarDespesasPeloCartaoId(int cartaoId)
        {
            try
            {
                return await _contexto.Despesas.Where(x => x.CartaoId == cartaoId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }

        public IQueryable<Despesa> PegarDespesasPeloUsuarioId(string usuarioId)
        {
            try
            {
                return _contexto.Despesas.Include(x => x.Cartao).Include(x => x.Categoria).Where(x => x.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
