using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class CategoriaRepositorio : RepositorioGenerico<Categoria>, ICategoriaRepositorio
    {
        private readonly Contexto _contexto;

        public CategoriaRepositorio(Contexto contexto): base(contexto)
        {
            _contexto = contexto;
        }

        public new IQueryable<Categoria> PegarTodos()
        {
            try
            {
                return _contexto.Categorias.Include(x => x.Tipo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public new async Task<Categoria> PegarPeloId(int id)
        {
            try
            {
                var entity = await _contexto.Categorias.Include(x => x.Tipo).FirstOrDefaultAsync(x => x.CategoriaId == id);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Categoria> FiltrarCategorias(string nome)
        {
            try
            {
                var entity = _contexto.Categorias.Include(x => x.Tipo).Where(x => x.Nome.Contains(nome));
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Categoria> PegarCategoriasPeloTipo(string tipo)
        {
            try
            {
                var entity = _contexto.Categorias.Include(x => x.Tipo).Where(x => x.Tipo.Nome.Contains(tipo));
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
