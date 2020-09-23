"use strict";

var order = new Vue({
	el: "#order",
	data: {
		aConcreteOrder: []
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
					})
					.catch((XMLHttpRequest) => {
						throw new Error("Ошибка получения данных услуги", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		}
	}
});