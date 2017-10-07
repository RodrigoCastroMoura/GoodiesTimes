using System;
using GoodiesTime.Domain.UnityOfWork;

namespace GoodiesTime.Domain.Service
{
    public abstract class AppService : IDisposable
    {
        private readonly IUnitiOfWork unitOfWork;

        public AppService(IUnitiOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
