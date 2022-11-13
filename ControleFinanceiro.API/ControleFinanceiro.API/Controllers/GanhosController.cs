﻿ using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GanhosController : ControllerBase
    {
        private readonly IGanhoRepositorio _ganhoRepositorio;

        public GanhosController(IGanhoRepositorio ganhoRepositorio)
        {
            _ganhoRepositorio = ganhoRepositorio;
        }

        [HttpGet("PegarGanhosPeloUsuarioId/{usuarioId}")]
        public async Task<IEnumerable<Ganho>> PegarGanhosPeloUsuarioId(string usuarioId)
        {
            return await _ganhoRepositorio.PegarGanhosPeloUsuarioId(usuarioId).ToListAsync();
        }

        [HttpGet("{ganhoId}")]
        public async Task<ActionResult<Ganho>> GetGanho(int ganhoId)
        {
            Ganho ganho = await _ganhoRepositorio.PegarPeloId(ganhoId);
            if (ganho == null)
                return NotFound();

            return ganho;
        }

        [HttpPut("{ganhoId}")]
        public async Task<ActionResult<Ganho>> PutGanho(int ganhoId, Ganho ganho)
        {
            if (ganhoId != ganho.GanhoId)            
                return NotFound();            

            if (ModelState.IsValid)
            {
                await _ganhoRepositorio.Atualizar(ganho);

                return Ok(new
                {
                    mensagem = $"Ganho no valor de R$ {ganho.Valor} atualizado com sucesso"
                });
            }

            return BadRequest(ganho);
        }

        [HttpPost]
        public async Task<ActionResult<Ganho>> PostGanho(Ganho ganho)
        {
            if (ModelState.IsValid)
            {
                await _ganhoRepositorio.Inserir(ganho);

                return Ok(new
                {
                    mensagem = $"Ganho no valor de R$ {ganho.Valor} criado com sucesso"
                });
            }

            return BadRequest(ganho);
        }       

        [HttpDelete("{ganhoId}")]
        public async Task<ActionResult> DeleteGanho(int ganhoId)
        {
            Ganho ganho = await _ganhoRepositorio.PegarPeloId(ganhoId);

            if (ganho == null)
                return NotFound();           

            await _ganhoRepositorio.Excluir(ganho);

            return Ok(new
            {
                mensagem = $"Ganho no valor de R$ {ganho.Valor} excluído com sucesso"
            });
        }

        [HttpGet("FiltrarGanhos/{nomeCategoria}")]
        public async Task<ActionResult<IEnumerable<Ganho>>> FiltrarGanhos(string nomeCategoria)
        {
            return await _ganhoRepositorio.FiltrarGanhos(nomeCategoria).ToListAsync();
        }
    }
}
