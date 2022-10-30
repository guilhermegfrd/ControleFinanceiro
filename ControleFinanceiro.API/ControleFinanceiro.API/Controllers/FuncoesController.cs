using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using ControleFinanceiro.DAL.Interfaces;
using ControleFinanceiro.API.ViewModels;
using System.Xml.Linq;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoRepositorio _funcaoRepositorio;

        public FuncoesController(
            IFuncaoRepositorio funcaoRepositorio
            )
        {
            _funcaoRepositorio = funcaoRepositorio;
        }

        // GET: api/Funcoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncoes()
        {
            return await _funcaoRepositorio.PegarTodos().ToListAsync();
        }

        // GET: api/Funcoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetCategoria(string id)
        {
            var funcao = await _funcaoRepositorio.PegarPeloId(id);

            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(string id, FuncoesViewModel funcoes)
        {
            if (id != funcoes.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var funcao = await _funcaoRepositorio.PegarPeloId(id);
                if (funcao != null)
                {
                    funcao.Name = funcoes.Name;
                    funcao.NormalizedName = funcoes.Name.ToUpper();
                    funcao.Descricao = funcoes.Descricao;
                }             

                await _funcaoRepositorio.Atualizar(funcao);

                return Ok(new
                {
                    mensagem = $"Função {funcao.Name} atualizada com sucesso!"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<ActionResult<Funcao>> PostCategoria(FuncoesViewModel funcoes)
        {
            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };

                await _funcaoRepositorio.Inserir(funcao);

                return Ok(new
                {
                    mensagem = $"Função {funcao.Name} cadastrada com sucesso!"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcao>> DeleteFuncao(string id)
        {
            var funcao = await _funcaoRepositorio.PegarPeloId(id);
            if (funcao == null)
            {
                return NotFound();
            }

            await _funcaoRepositorio.Excluir(funcao);

            return Ok(new
            {
                mensagem = $"Função {funcao.Name} excluída com sucesso!"
            });
        }

        [HttpGet("FiltrarFuncoes/{nomeFuncao}")]
        public async Task<ActionResult<IEnumerable<Funcao>>> FiltrarFuncoes(string nomeFuncao)
        {
            return await _funcaoRepositorio.FiltrarFuncoes(nomeFuncao).ToListAsync();
        }
    }
}
