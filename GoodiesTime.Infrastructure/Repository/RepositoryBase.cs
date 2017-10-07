using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using GoodiesTime.Library;
using GoodiesTime.Library.Specifications;
using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.Interfaces.Repository;

namespace GoodiesTime.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        internal IDataContext Db;
        internal DbSet<TEntity> dbSet;

        public RepositoryBase(IDataContext Db)
        {
            this.Db = Db;
            dbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            dbSet.Add(obj);
        }

        public virtual TEntity GetById(int Id)
        {
            return dbSet.Find(Id);
        }


        /// <summary>
        /// Obter a primeira Entidade do Repositório
        /// </summary>
        /// <returns></returns>
        public TEntity First()
        {
            return dbSet.FirstOrDefault();
        }

        /// <summary>
        /// Obter a última Entidade do Repositório que atenda ao critério estabelecido
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity First(
            ISpecification<TEntity> predicate)
        {

            return dbSet
                    .Where(predicate.SpecExpression)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Obter todas as Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.AsEnumerable();
        }


        /// <summary>
        /// Obter todas as Entidades do Repositório sob determina(s) ordem(ns)
        /// </summary>
        /// <param name="sorts"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            SortField[] sorts)
        {
            return dbSet.ApplyMultipleOrders(sorts);
        }

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado, sob determina(s) ordem(ns)
        /// </summary>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            SortField[] sorts,
            ISpecification<TEntity> predicate)
        {
            if (predicate == null)
            {
                return Get(sorts);
            }
            return dbSet
                    .Where(predicate.SpecExpression)
                    .ApplyMultipleOrders(sorts);
        }

        /// <summary>
        /// Obter todas as Entidades do Repositório sob determina(s) ordem(ns), com limitação de paginação
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="sorts"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            out int recordCount,
            SortField[] sorts,
            int limit = 10,
            int start = 1)
        {
            recordCount = dbSet.Count();

            return dbSet
                    .ApplyMultipleOrders(sorts)
                    .Skip(start - 1)
                    .Take(limit);
        }

        /// <summary>
        /// Obter todas as Entidades do Repositório que atendam ao critério especificado, sob determina(s) ordem(ns), com limitação de paginação
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="sorts"></param>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            out int recordCount,
            SortField[] sorts,
            ISpecification<TEntity> predicate,
            int limit = 10,
            int start = 1)
        {
            recordCount = dbSet.Count(predicate.SpecExpression);

            return dbSet
                    .Where(predicate.SpecExpression)
                    .ApplyMultipleOrders(sorts)
                    .Skip(start - 1)
                    .Take(limit);
        }

        public virtual IEnumerable<TEntity> Get(ISpecification<TEntity> predicate)
        {
            return dbSet.Where(predicate.SpecExpression);
        }


        /// <summary>
        /// Obter quantidade total de Entidades do Repositório
        /// </summary>
        /// <returns></returns>
        public virtual int Count()
        {
            return dbSet.Count();
        }

        /// <summary>
        /// Obter quantidade de Entidades do Repositório que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int Count(
            ISpecification<TEntity> predicate)
        {
            return dbSet.Count(predicate.SpecExpression);
        }

        /// <summary>
        /// Verificar se existe ou não Entidades que atendam ao critério especificado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool Exists(
            ISpecification<TEntity> predicate)
        {
            return dbSet.Count(predicate.SpecExpression) > 0;
        }


        public TEntity GetById(params object[] keys)
        {
            return dbSet.Find(keys);
        }

        IEnumerable<TEntity> IRepositoryBase<TEntity>.Get(ISpecification<TEntity> predicate)
        {
            return dbSet.Where(predicate.SpecExpression).AsNoTracking();
        }

        public virtual void Update(TEntity obj)
        {
            var entry = this.Db.Entry(obj);

            IEnumerable<object> key = Db.GetPropertyKeyValues<TEntity>(obj);

            if (entry.State == EntityState.Detached)
            {

                var currentEntry = this.dbSet.Find(key.ToArray());
                if (currentEntry != null)
                {
                    var attachedEntry = this.Db.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(obj);
                }
                else
                {
                    this.dbSet.Attach(obj);
                    entry.State = EntityState.Modified;
                }
            }

        }

        public virtual void Remove(TEntity obj)
        {
            dbSet.Remove(obj);
        }

        public virtual void Dispose()
        {

        }

        private int GetPrimaryKey(DbEntityEntry entry)
        {
            var myObject = entry.Entity;
            var property =
                myObject.GetType()
                    .GetProperties()
                    .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));
            return (int)property.GetValue(myObject, null);
        }
    }
}
