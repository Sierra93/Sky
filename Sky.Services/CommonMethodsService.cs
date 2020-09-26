using Sky.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sky.Services {
    /// <summary>
    /// Сервис общих методов.
    /// </summary>
    public class CommonMethodsService {
        /// <summary>
        /// Метод определяет тип по параметру.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string IdentityType(string type) {
            string param = "";

            // Определяет тип.
            switch (type) {
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

            if (param != null) {
                return param;
            }

            return null;
        }
    }
}
