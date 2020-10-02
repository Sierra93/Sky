using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Sky.Core;
using Sky.Core.Data;
using Sky.Models;
using Sky.Services;

namespace Sky.Controllers {
    /// <summary>
    /// Контроллер описывает работу с услугами.
    /// </summary>
    [ApiController, Route("api/order")]
    public class OrderDetailController : Controller {
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

        /// <summary>
        /// Метод создает новую заявку.
        /// </summary>
        [HttpPost, Route("create-request")]
        public async Task<IActionResult> CreateRequest(RequestDto requestDto) {
            BaseOrder baseOrder = new OrderDetailService(_db);
            await baseOrder.CreateRequest(requestDto);

            return Ok("Заявка успешно создана");
        }
    }
}