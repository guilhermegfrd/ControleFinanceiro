using ControleFinanceiro.API.ViewModels;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICartaoRepositorio _cartaoRepositorio;
        private readonly IGanhoRepositorio _ganhoRepositorio;
        private readonly IDespesaRepositorio _despesaRepositorio;
        private readonly IMesRepositorio _mesRepositorio;
        private readonly IGraficoRepositorio _graficoRepositorio;

        public DashboardController(
            ICartaoRepositorio cartaoRepositorio,
            IGanhoRepositorio ganhoRepositorio,
            IDespesaRepositorio despesaRepositorio,
            IMesRepositorio mesRepositorio,
            IGraficoRepositorio graficoRepositorio
            )
        {
            _cartaoRepositorio = cartaoRepositorio;
            _ganhoRepositorio = ganhoRepositorio;
            _despesaRepositorio = despesaRepositorio;
            _mesRepositorio = mesRepositorio;
            _graficoRepositorio = graficoRepositorio;
        }

        [HttpGet("PegarDadosCardsDashboard/{usuarioId}")]
        public async Task<ActionResult<DadosCardsDashboardViewModel>> PegarDadosCardsDashboard(string usuarioId)
        {
            int qtdCartos = await _cartaoRepositorio.PegarQuantidadeCartoesPeloUsuarioId(usuarioId);
            double ganhoTotal = Math.Round(await _ganhoRepositorio.PegarGanhoTotalPeloUsuarioId(usuarioId), 2);
            double despesaTotal = Math.Round(await _despesaRepositorio.PegarDespesaTotalPeloUsuarioId(usuarioId), 2);
            double saldo = Math.Round(ganhoTotal - despesaTotal, 2);

            DadosCardsDashboardViewModel model = new DadosCardsDashboardViewModel
            {
                QtdCartoes = qtdCartos,
                GanhoTotal = ganhoTotal,
                DespesaTotal = despesaTotal,
                Saldo = saldo,
            };

            return model;
        }

        [HttpGet("PegarDadosAnuaisPeloUsuarioId/{usuarioId}/{ano}")]
        public object PegarDadosAnuaisPeloUsuarioId(string usuarioId, int ano)
        {

            return new
            {
                ganhos = _graficoRepositorio.PegarGanhosAnuaisPeloUsuarioId(usuarioId, ano),
                despesas = _graficoRepositorio.PegarDesepesasAnuaisPeloUsuarioId(usuarioId, ano),
                meses = _mesRepositorio.PegarTodos()
            };
        }
    }
}
