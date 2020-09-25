"use strict";

const START = "Портфолио";
const LANDING = "Landing Page";

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

		// Функция получает работы выбранной категории.
		onGetWorkCategory(groupId) {
			console.log("onGetWorkCategory");
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
		}
	}
});