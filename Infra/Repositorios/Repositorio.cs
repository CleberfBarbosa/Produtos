using Dominio.Interfaces;
using Dominio.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class, IEntidade
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;

        public Repositorio(DbContext context)
        {
            _context  = context;
            _dbSet = context.Set<T>();
        }

        public virtual List<T> Atualizar(params T[] itensAtualizar)
        {
            if (itensAtualizar == null)
                throw new Exception("Dados inválidos para atualização!");

            _dbSet.UpdateRange(itensAtualizar);
            Persistir();
            return itensAtualizar.ToList();
        }

        public virtual List<T> Inserir(params T[] itensInserir)
        {
            if (itensInserir == null)
                throw new Exception("Dados inválidos para inserção!");

            _dbSet.AddRange(itensInserir);
            Persistir();
            return itensInserir.ToList();
        }

        public virtual void Remover(params T[] itensRemover)
        {
            if (itensRemover == null)
                throw new Exception("Dados inválidos para remoção!");

            _dbSet.RemoveRange(itensRemover);
            Persistir();
        }

        public virtual IEnumerable<T> Filtrar(Expression<Func<T, bool>> filtro)
        {
            var elementos = _dbSet.Where(filtro);
            return elementos.AsEnumerable();
        }

        public virtual IEnumerable<T> All()
        {
            var elementos = _dbSet.AsEnumerable();
            return elementos.AsEnumerable();
        }

        public virtual void Persistir()
        {
            _context.SaveChanges();
        }
    }
}
