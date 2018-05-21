using System;
using System.Linq;
using System.Linq.Expressions;

namespace XGame.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId>
        where TEntidade : class
        where TId : struct
    {
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarEOrdenarPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, Tkey>>);

        TEntidade ObeterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[]);

        bool Existe(Func<TEntidade, bool> where);

        
    }
}
