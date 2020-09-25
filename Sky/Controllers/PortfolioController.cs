using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sky.Core;
using Sky.Core.Data;
using Sky.Services;

namespace Sky.Controllers {
    [ApiController, Route("api/portfolio")]
    public class PortfolioController : ControllerBase {
        ApplicationDbContext _db;

        public PortfolioController(ApplicationDbContext db) {
            _db = db;
        }

        /// <summary>
        /// Метод получает список работ.
        /// </summary>
        [HttpGet, Route("get-works")]
        public async Task<IActionResult> GetAllWorks() {
            BasePortfolio basePortfolio = new PortfolioService(_db);

            return Ok(await basePortfolio.GetAllWorks());
        }

        /// <summary>
        /// Метод получает данные определенной работы.
        /// </summary>
        [HttpGet, Route("get-work")]
        public async Task<IActionResult> GetConcreteWork([FromQuery] int? groupId) {
            BasePortfolio basePortfolio = new PortfolioService(_db);

            return Ok(await basePortfolio.GetConcreteWork(groupId));
        }
    }
}
