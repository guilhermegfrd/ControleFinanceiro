
namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IGraficoRepositorio
    {
      object PegarGanhosAnuaisPeloUsuarioId(string usuarioId, int ano);
      object PegarDesepesasAnuaisPeloUsuarioId(string usuarioId, int ano);
    }
}
