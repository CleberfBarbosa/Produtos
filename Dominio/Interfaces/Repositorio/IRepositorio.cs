using System.Linq.Expressions;

namespace Dominio.Interfaces.Repositorio
{
    public interface IRepositorio<T> where T : class, IEntidade
    {
        List<T> Inserir(params T[] itensInserir);
        List<T> Atualizar(params T[] itensAtualizar);
        void Remover(params T[] itensRemover);
        IEnumerable<T>Filtrar(Expression<Func<T, bool>> filtro);
        void Persistir();
        IEnumerable<T> All();
    }
}
