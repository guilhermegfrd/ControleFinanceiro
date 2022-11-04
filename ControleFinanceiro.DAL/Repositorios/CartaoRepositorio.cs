using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class CartaoRepositorio : RepositorioGenerico<Cartao>, ICartaoRepositorio
    {
        private readonly Contexto _contexto;

        public CartaoRepositorio(Contexto contexto): base(contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Cartao> FiltrarCartoes(string numeroCartao)
        {
            try
            {
                var entity = _contexto.Cartoes.Where(x => x.Numero.Contains(numeroCartao));
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Cartao> PegarCartoesPeloUsuarioId(string usuarioId)
        {
            try
            {
                return _contexto.Cartoes.Where(x => x.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
