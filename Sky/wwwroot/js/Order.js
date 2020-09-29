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

		// Функция отправляет заявку.
		//onSend() {
		//	console.log("onSend");
		//	//let sName = $("#id-client-name").val();
		//	//let sContact = $("#id-contact").val();
		//	//let sArea = $("#id-area").val();

		//	//let sUrl = "https://localhost:44310/api/order/create-request";

		//	//try {
		//	//	axios.post(sUrl, {
		//	//		Name: sName,
		//	//		EmailOrNumber: sContact,
		//	//		Comment: sArea
		//	//	})
		//	//		.then((response) => {
		//	//			console.log(response.data);
		//	//		})
		//	//		.catch((XMLHttpRequest) => {
		//	//			throw new Error("Ошибка отправки заявки", XMLHttpRequest.response.data);
		//	//		});
		//	//}
		//	//catch (ex) {
		//	//	throw new Error(ex);
		//	//}
		//}
	}
});