"use strict";

var order = new Vue({
	el: "#order",
	data: {
		aConcreteOrder: [],
		orderName: localStorage["orderName"],
		orderDetails: localStorage["orderDetails"]
	},
	methods: {
		// Функция получает данные услуги.
		GetOrder(orderName) {
			let sUrl = "https://localhost:44310/api/order/get-order?order=".concat(orderName);

			try {
				axios.get(sUrl)
					.then((response) => {
						this.aConcreteOrder = response.data;
						console.log("Данные услуги", this.aConcreteOrder);
						localStorage["orderName"] = this.aConcreteOrder.orderName;
						localStorage["orderDetails"] = this.aConcreteOrder.orderDetails;
						window.location.href = "https://localhost:44310/order-details";
					})
					.catch((XMLHttpRequest) => {
						throw new Error("Ошибка получения данных услуги", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		},

		// Функция записывает заготовку в сообщение.
		onSetBodyRequest(sKey) {
			switch (sKey) {
				case "lp":
					$("#id-area").val("Здравствуйте. Хочу заказать Landing Page.");
					break;

				case "site-viz":
					$("#id-area").val("Здравствуйте. Хочу заказать сайт-визитку.");
					break;

				case "personal":
					$("#id-area").val("Здравствуйте. Хочу заказать персональный сайт.");
					break;

				case "corporate":
					$("#id-area").val("Здравствуйте. Хочу заказать корпоративный сайт.");
					break;

				case "shop":
					$("#id-area").val("Здравствуйте. Хочу заказать интернет-магазин.");
					break;

				case "design":
					$("#id-area").val("Здравствуйте. Хочу заказать редизайн существующего сайта.");
					break;

				case "seo":
					$("#id-area").val("Здравствуйте. Хочу заказать продвижение сайта.");
					break;

				case "yandex":
					$("#id-area").val("Здравствуйте. Хочу заказать настройку рекламы в Яндекс.Директ.");
					break;

				case "google":
					$("#id-area").val("Здравствуйте. Хочу заказать настройку рекламы в Google.");
					break;

				case "web_app":
					$("#id-area").val("Здравствуйте. Хочу заказать разработку веб-приложения.");
					break;

				case "client_server":
					$("#id-area").val("Здравствуйте. Хочу заказать разработку клиент-серверного приложения.");
					break;

				case "mobile_app":
					$("#id-area").val("Здравствуйте. Хочу заказать разработку мобильного приложения.");
					break;
			}
		}
	}
});