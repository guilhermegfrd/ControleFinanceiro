﻿using ControleFinanceiro.BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IDespesaRepositorio : IRepositorioGenerico<Despesa>
    {
        IQueryable<Despesa> PegarDespesasPeloUsuarioId(string usuarioId);
        void ExcluirDespesas(IEnumerable<Despesa> despesas);
        Task<IEnumerable<Despesa>> PegarDespesasPeloCartaoId(int cartaoId);
    }
}