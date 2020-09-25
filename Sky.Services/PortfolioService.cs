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

                // Приводит путь изображений к нужному виду для фронта.
                foreach (var el in oWorks) {
                    el.Url = el.Url.Insert(0, "/").Replace("wwwroot/", "");
                }

                return oWorks;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод получает данные определенной работы.
        /// </summary>
        public async override Task<IEnumerable<PortfolioDetailsDto>> GetConcreteWork(int? groupId) {
            try {
                if (groupId == 0 || groupId == null) {
                    throw new ArgumentNullException();
                }

                var oWorks = await _db.DetailsWorks.Where(g => g.GroupId == groupId).ToListAsync();

                // Приводит путь изображений к нужному виду для фронта.
                foreach (var el in oWorks) {
                    el.Url = el.Url.Insert(0, "/").Replace("wwwroot/", "");
                }

                return oWorks;
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Не передана группа работы", ex.Message.ToString());
            }
            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
