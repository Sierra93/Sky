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
                string param = "";

                // Если нет названия услуги.
                if (string.IsNullOrEmpty(order)) {
                    throw new ArgumentNullException();
                }                
                
                // Определяет тип услуги.
                switch (order) {
                    case "lp":
                        param = OrderType.LANDING;
                        break;

                    case "site-viz":
                        param = OrderType.SITE_VIZ;
                        break;

                    case "personal":
                        param = OrderType.PERSONAL_SITE;
                        break;

                    case "corporate":
                        param = OrderType.CORPORATE_SITE;
                        break;

                    case "shop":
                        param = OrderType.SHOP;
                        break;

                    case "design":
                        param = OrderType.DESIGN;
                        break;

                    case "seo":
                        param = OrderType.SEO;
                        break;

                    case "setting-yandex":
                        param = OrderType.SETTINGS_YANDEX;
                        break;

                    case "setting-google":
                        param = OrderType.SETTINGS_GOOGLE;
                        break;
                }

                return await _db.OrdersDetails.Where(o => o.OrderName.Equals(param)).FirstOrDefaultAsync(); ;
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
