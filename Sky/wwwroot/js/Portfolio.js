"use strict";

var portfolio = new Vue({
	el: "#portfolio",
	created() {
		this._loadAllWorks();
	},
	data: {
		aWorks: []
	},
	methods: {
		// Функция получает список всех работ.
		_loadAllWorks() {
			let sUrl = "https://localhost:44310/api/portfolio/get-works";

			try {
				axios.get(sUrl)
					.then((response) => {
						this.aWorks = response.data;
						console.log("Список работ", this.aWorks);						
					})
					.catch((XMLHttpRequest) => {
						throw new Error("Ошибка получения списка работ", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		},

		// Функция получает работы категории.
		onGetWorkCategory(groupId) {
			console.log("onGetWorkCategory");
		},

		// Функция получает все данные конкретной работы.
		onGetConcreteWork(id) {
			console.log("onGetConcreteWork");
		}
	}
});