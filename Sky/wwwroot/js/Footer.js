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

			if (!sName || !sContact || !sArea) {
				$('#id-send-modal').modal('toggle');
				return;
			}

			let sUrl = "https://devmyprojects24.xyz/api/order/create-request";

			$("#id-btn-send").prop("disabled", true);

			try {
				axios.post(sUrl, {
					Name: sName,
					EmailOrNumber: sContact,
					Comment: sArea
				})
					.then((response) => {
						$("#id-btn-send").prop("disabled", false);
						$('#id-access-modal').modal('toggle');

						// Очищает все поля.
						this._removeFields();
						console.log(response.data);
					})
					.catch((XMLHttpRequest) => {
						$("#id-btn-send").prop("disabled", false);
						this._removeFields();
						throw new Error("Ошибка отправки заявки", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		},

		// Функция очищает все поля.
		_removeFields: function () {
			$("#id-client-name").val("");
			$("#id-contact").val("");
			$("#id-area").val("");
		}	
	}
});