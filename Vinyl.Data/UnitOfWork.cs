using System;
using System.Collections.Generic;
using System.Text;
using Vinyl.Data.Repositories;

namespace Vinyl.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IVinylContext _vinylContext;
        private readonly IWorkerRepository _workerRepository;


        public UnitOfWork(IVinylContext vinylContext)
        {
            _vinylContext = vinylContext;
        }


        public IWorkerRepository WorkerRepository => _workerRepository ?? (new WorkerRepository(_vinylContext));


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _vinylContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
