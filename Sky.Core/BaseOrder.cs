using Sky.Core.Data;
using Sky.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы услуг.
    /// </summary>
    public abstract class BaseOrder {
        /// <summary>
        /// Метод получает данные услуги.
        /// </summary>
        /// <returns></returns>
        public abstract Task<OrderDetailDto> GetOrderDetail(string order);
    }
}
