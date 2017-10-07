using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using GoodiesTime.Domain.Context;

namespace GoodiesTime.Infrastructure.Context
{
    public class DataContext : DbContext, IDataContext
    {
      

        public DataContext() : base("Model1")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;

            Database.SetInitializer<DataContext>(null);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<string>().Configure(c => c.IsUnicode(false));

            #region Mappings

            modelBuilder.Configurations.AddFromAssembly(typeof(DataContext).Assembly);

            #endregion

        }


        public override int SaveChanges()
        {
            // Obter a instância do Contexto
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;

            foreach (var changeSet in ChangeTracker.Entries())
            {
                var entity = changeSet.Entity;

                var entityType = entity.GetType();

                if (entityType == null)
                {
                    continue;
                }

                var entityCustomAttributes = TypeDescriptor.GetAttributes(entityType);

                if (entityCustomAttributes == null)
                {
                    continue;
                }

                if (entityCustomAttributes.Count == 0)
                {
                    continue;
                }

                if (changeSet.State != EntityState.Added)
                {
                    continue;
                }
            }

            try
            {
                int returnSave = base.SaveChanges();

                base.ChangeTracker.Entries().ToList().ForEach(i =>
                {
                    i.State = EntityState.Detached;
                });

                return returnSave;
            }
            catch (DbUpdateException err)
            {

                Exception inner = err;

                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                string erroMessage = inner.Message;



                throw new ArgumentException(err + "  " + erroMessage);
            }

        }

        public IEnumerable<string> GetPropertyKeys<TEntity>()
          where TEntity : class
        {
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;

            ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>();

            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                            .KeyMembers
                                            .Select(k => k.Name);

            return keyNames;
        }

        public List<object> GetPropertyKeyValues<TEntity>(TEntity entity)
            where TEntity : class
        {
            IEnumerable<string> keyNames = this.GetPropertyKeys<TEntity>();

            List<object> pksValues = new List<object>();

            foreach (string key in keyNames)
            {
                pksValues.Add(typeof(TEntity).GetProperty(key).GetValue(entity));
            }

            return pksValues;
        }

    }
}
