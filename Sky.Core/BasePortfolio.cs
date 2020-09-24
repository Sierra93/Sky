using Sky.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Core {
    /// <summary>
    /// Базовый абстрактный класс описывающий портфолио.
    /// </summary>
    public abstract class BasePortfolio {
        /// <summary>
        /// Метод получает список работ.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IEnumerable<PortfolioDto>> GetAllWorks();
    }
}
