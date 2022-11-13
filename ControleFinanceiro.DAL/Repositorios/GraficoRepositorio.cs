using ControleFinanceiro.DAL.Interfaces;
using System;
using System.Linq;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class GraficoRepositorio : IGraficoRepositorio
    {
        private readonly Contexto _contexto;
        public GraficoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public object PegarDesepesasAnuaisPeloUsuarioId(string usuarioId, int ano)
        {
            try
            {
                return _contexto.Despesas.Where(x => x.UsuarioId == usuarioId && x.Ano == ano)
                    .OrderBy(x => x.Mes.MesId)
                    .GroupBy(x => x.Mes.MesId)
                    .Select(x => new 
                    {
                        MesId = x.Key,
                        Valores = x.Sum(y => y.Valor)
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }

        public object PegarGanhosAnuaisPeloUsuarioId(string usuarioId, int ano)
        {
            try
            {
                return _contexto.Ganhos.Where(x => x.UsuarioId == usuarioId && x.Ano == ano)
                    .OrderBy(x => x.Mes.MesId)
                    .GroupBy(x => x.Mes.MesId)
                    .Select(x => new
                    {
                        MesId = x.Key,
                        Valores = x.Sum(y => y.Valor)
                    });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
