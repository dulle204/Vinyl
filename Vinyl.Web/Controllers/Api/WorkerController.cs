using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vinyl.Domain;
using Vinyl.Domain.Contracts;
using Vinyl.Web.Models;

namespace Vinyl.Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkersManager _workersManager;

        public WorkerController(IWorkersManager workersManager)
        {
            _workersManager = workersManager;
        }

        public ActionResult<IEnumerable<WorkerModel>> Get()
        {
            List<WorkerModel> result = new List<WorkerModel>();

            var workers = _workersManager.GetWorkersWithSalaries();

            foreach (var worker in workers)
            {
                WorkerModel model = new WorkerModel()
                {
                    Role = worker.Role.ToString(),
                    Position = worker.Position.ToString(),
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    MonthSalary = worker.MonthSalary,
                    Id = worker.Id
                };

                result.Add(model);
            }

            return Ok(result);
        }

        public ActionResult Post(WorkerModel model)
        {
            WorkerContract worker = new WorkerContract()
            {
                Position = Enum.Parse<Position>(model.Position),
                FirstName = model.FirstName,
                LastName = model.LastName,
                MonthSalary = model.MonthSalary,
                Role = Role.USER
            };

            _workersManager.InsertWorker(worker);

            return Accepted();
        }
    }
}