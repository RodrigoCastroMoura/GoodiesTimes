using System.Collections.Generic;
using GoodiesTime.Library;
using GoodiesTime.Library.Specifications;

namespace GoodiesTime.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int Id);

        TEntity GetById(params object[] keys);

        TEntity First();

        TEntity First(ISpecification<TEntity> predicate);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        // <summary>
        /// Obter todas as Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Obter todas as Entidades do Repositório sob determina(s) ordem(ns)
        /// </summary>
        /// <param name="sorts"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            SortField[] sorts);

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado, sob determina(s) ordem(ns)
        /// </summary>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            SortField[] sorts,
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Obter todas as Entidades do Repositório sob determina(s) ordem(ns), com limitação de paginação
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="sorts"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            out int recordCount,
            SortField[] sorts,
            int pageSize = 10,
            int page = 1);

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado, sob determina(s) ordem(ns), com limitação de paginação
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            out int recordCount,
            SortField[] sorts,
            ISpecification<TEntity> predicate,
            int pageSize = 10,
            int page = 1);

        /// <summary>
        /// Obter quantidade total de Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Obter quantidade de Entidades do Repositório que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(
            ISpecification<TEntity> predicate);

        /// <summary>
        /// Verificar se existe ou não Entidades que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(
            ISpecification<TEntity> predicate);

    }
}
