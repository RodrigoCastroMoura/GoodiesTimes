using System;
using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.UnityOfWork;

namespace GoodiesTime.Infrastructure.UnityOfWork
{
    public class UnitiOfWork : IUnitiOfWork
    {
        protected readonly IDataContext context;


        public UnitiOfWork(IDataContext context)
        {

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
        }

    }
}

