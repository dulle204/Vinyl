using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Vinyl.Data.Entities;

namespace Vinyl.Data.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IVinylContext _vinylContext;

        public WorkerRepository(IVinylContext vinylContext)
        {
            _vinylContext = vinylContext;
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            var workers = _vinylContext.Workers;

            return workers;
        }

        public Worker GetWorkerById(BigInteger id)
        {
            var worker = _vinylContext.Workers.SingleOrDefault(x => x.Id == id);

            return worker;
        }

        public IEnumerable<Worker> SearchWorkers(Func<Worker, bool> q)
        {
            var workers = _vinylContext.Workers.Where(q);

            return workers;
        }

        public IEnumerable<Log> WorkerLogsThisMonth(BigInteger workerId)
        {
            DateTime date =DateTime.Now;
            var logs = _vinylContext.Logs.Where(x => x.WorkerId == workerId && x.Date.Month == date.Month);

            return logs;
        }
    }
}
