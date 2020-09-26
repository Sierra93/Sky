"use strict";

const START = "Портфолио";

var portfolio = new Vue({
	el: "#portfolio",
	created() {		
		// Если в режиме деталей.
		if (!localStorage["bDetail"]) {
			this._loadAllWorks();
			return;
		}			

		this.onGetConcreteWork();
	},
	data: {
		aWorks: [],
		title: ""
	},
	methods: {
		// Функция получает список всех работ.
		_loadAllWorks() {
			let sUrl = "https://localhost:44310/api/portfolio/get-works";

			try {
				axios.get(sUrl)
					.then((response) => {
						this.aWorks = response.data;
						this.title = START;
						localStorage["bDetail"] = false;
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

		// Функция получает все данные конкретной работы.
		onGetConcreteWork() {			
			let sUrl = "https://localhost:44310/api/portfolio/get-work?groupId=".concat(+localStorage["groupId"]);

			try {
				axios.get(sUrl)
					.then((response) => {
						this.aWorks = response.data;
						this.title = START;						
						console.log("Данные работы", this.aWorks);
					})
					.catch((XMLHttpRequest) => {
						throw new Error("Ошибка получения данных работы", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		},

		// Функция записывает в кэш groupId работы.
		setGroupId(e) {
			this.aWorks = [];
			let groupId = e.target.value;
			localStorage["bDetail"] = true;
			localStorage["groupId"] = groupId;
			window.location.href = "https://localhost:44310/get-work";
		},

		// Функция получает все работы типа.
		onFilter(type, name) {
			this.title = name;
			let sUrl = "https://localhost:44310/api/portfolio/type-work?type=".concat(type);

			try {
				axios.get(sUrl)
					.then((response) => {
						this.aWorks = response.data;
						console.log("Работа типа", this.aWorks);
					})
					.catch((XMLHttpRequest) => {
						throw new Error("Ошибка получения работы", XMLHttpRequest.response.data);
					});
			}
			catch (ex) {
				throw new Error(ex);
			}
		},

		// Функция загружает все работы.
		onLoadAllWorks() {
			this._loadAllWorks();
		}
	}
});