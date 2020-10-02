using MailKit.Net.Smtp;
using MimeKit;
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

                case "yandex":
                    param = OrderType.YANDEX;
                    break;

                case "google":
                    param = OrderType.GOOGLE;
                    break;

                case "web_app":
                    param = OrderType.WEB_APP;
                    break;

                case "client_server":
                    param = OrderType.CLIENT_SERVER;
                    break;

                case "mobile_app":
                    param = OrderType.MOBILE_APP;
                    break;
            }

            if (param != null) {
                return param;
            }

            return null;
        }

        /// <summary>
        /// Метод отправляет заявку на email.
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        public async Task SendMessageToEmail(RequestDto requestDto) {
            try {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("sierra_93@mail.ru"));
                emailMessage.To.Add(new MailboxAddress("sierra_93@mail.ru"));
                emailMessage.Subject = "Новая заявка";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                    Text = "Имя: " + requestDto.Name + "</br>" +
                "E-mail или телефон: " + requestDto.EmailOrNumber + "</br>" +
                "Коротко о проекте: " + requestDto.Comment
                };
                using (var client = new SmtpClient()) {
                    await client.ConnectAsync("smtp.mail.ru", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("sierra_93@mail.ru", "13467982dd");
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
