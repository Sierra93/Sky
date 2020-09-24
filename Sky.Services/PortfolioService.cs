using Microsoft.EntityFrameworkCore;
using Sky.Core;
using Sky.Core.Data;
using Sky.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Services {
    /// <summary>
    /// Сервис реализует методы портфолио.
    /// </summary>
    public class PortfolioService : BasePortfolio {
        ApplicationDbContext _db;

        public PortfolioService(ApplicationDbContext db) {
            _db = db;
        }

        /// <summary>
        /// Метод получает список работ.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable<PortfolioDto>> GetAllWorks() {
            try {
                var oWorks = await _db.Portfolio.ToListAsync();
                foreach (var el in oWorks) {
                    el.ImagePath = el.ImagePath.Insert(0, "~/").Replace("wwwroot/", "");
                }

                return oWorks;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
