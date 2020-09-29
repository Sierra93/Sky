"use strict";

var footer = new Vue({
	el: "#footer",
	data: {

	},
	methods: {
		// Функция отправляет заявку.
		onSend() {
			let sName = $("#id-client-name").val();
			let sContact = $("#id-contact").val();
			let sArea = $("#id-area").val();

			let sUrl = "https://localhost:44310/api/order/create-request";

			$("#id-btn-send").prop("disabled", true);

			try {
				axios.post(sUrl, {
					Name: sName,
					EmailOrNumber: sContact,
					Comment: sArea
				})
					.then((response) => {
						$("#id-btn-send").prop("disabled", false);
						console.log(response.data);
					})
					.catch((XMLHttpRequest) => {
						$("#id-btn-send").prop("disabled", false);
						throw new Error("Ошибка отправки заявки", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		}
	}
});