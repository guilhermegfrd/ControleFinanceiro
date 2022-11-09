using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MesesController : ControllerBase
    {
        private readonly IMesRepositorio _mesRepositorio;

        public MesesController(IMesRepositorio mesRepositorio)
        {
            _mesRepositorio = mesRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mes>>> GetMeses()
        {
            return await _mesRepositorio.PegarTodos().ToListAsync();
        }
    }
}
