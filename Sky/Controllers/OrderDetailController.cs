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
    /// <summary>
    /// Контроллер описывает работу с услугами.
    /// </summary>
    [ApiController, Route("api/order")]
    public class OrderDetailController : ControllerBase {
        ApplicationDbContext _db;

        public OrderDetailController(ApplicationDbContext db) {
            _db = db;
        }

        /// <summary>
        /// Метод получает данные услуги.
        /// </summary>
        [HttpGet, Route("get-order")]
        public async Task<IActionResult> GetOrderDetail([FromQuery] string order) {
            BaseOrder baseOrder = new OrderDetailService(_db);

            return Ok(await baseOrder.GetOrderDetail(order));
        }
    }
}