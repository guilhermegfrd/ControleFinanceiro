using ControleFinanceiro.BLL.Models;
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
    public class DespesasController : ControllerBase
    {
        private readonly IDespesaRepositorio _despesaRepositorio;

        public DespesasController(IDespesaRepositorio despesaRepositorio)
        {
            _despesaRepositorio = despesaRepositorio;
        }

        [HttpGet("PegarDespesasPeloUsuarioId/{usuarioId}")]
        public async Task<IEnumerable<Despesa>> PegarDespesasPeloUsuarioId(string usuarioId)
        {
            return await _despesaRepositorio.PegarDespesasPeloUsuarioId(usuarioId).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            Despesa despesa = await _despesaRepositorio.PegarPeloId(id);
            if (despesa == null)
                return NotFound();

            return despesa;
        }

        [HttpPost]
        public async Task<ActionResult<Despesa>> PostDespesa(Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                await _despesaRepositorio.Inserir(despesa);

                return Ok(new
                {
                    mensagem = $"Despesa no valor de R$ {despesa.Valor} criada com sucesso"
                });
            }

            return BadRequest(despesa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Despesa>> PutDespesa(int id, Despesa despesa)
        {
            if (id != despesa.DespesaId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _despesaRepositorio.Atualizar(despesa);

                return Ok(new
                {
                    mensagem = $"Despesa no valor de R$ {despesa.Valor} atualizada com sucesso"
                });
            }

            return BadRequest(despesa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDespesa(int id)
        {
            Despesa despesa = await _despesaRepositorio.PegarPeloId(id);

            if (despesa == null)
                return NotFound();           

            await _despesaRepositorio.Excluir(despesa);

            return Ok(new
            {
                mensagem = $"Despesa no valor de R$ {despesa.Valor} excluída com sucesso"
            });
        }

        [HttpGet("FiltrarDespesas/{nomeCategoria}")]
        public async Task<ActionResult<IEnumerable<Despesa>>> FiltrarDespesas(string nomeCategoria)
        {
            return await _despesaRepositorio.FiltrarDespesas(nomeCategoria).ToListAsync();
        }
    }
}
