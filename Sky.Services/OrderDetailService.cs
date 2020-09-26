using Microsoft.EntityFrameworkCore;
using Sky.Core;
using Sky.Core.Constants;
using Sky.Core.Data;
using Sky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Services {
    /// <summary>
    /// Сервис описывает услуги.
    /// </summary>
    public class OrderDetailService : BaseOrder {
        ApplicationDbContext _db;
        
        public OrderDetailService(ApplicationDbContext db) {
            _db = db;
        }

        /// <summary>
        /// Метод получает данные услуги.
        /// </summary>
        /// <returns></returns>
        public async override Task<OrderDetailDto> GetOrderDetail(string order) {
            try {
                // Если нет названия услуги.
                if (string.IsNullOrEmpty(order)) {
                    throw new ArgumentNullException();
                }

                CommonMethodsService commonMethodsService = new CommonMethodsService();
                var isType = commonMethodsService.IdentityType(order);

                if (isType != null)
                    return await _db.OrdersDetails.Where(o => o.OrderName.Equals(isType)).FirstOrDefaultAsync();

                throw new ArgumentNullException();
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Не передано название услуги", ex.Message.ToString());
            }
            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
