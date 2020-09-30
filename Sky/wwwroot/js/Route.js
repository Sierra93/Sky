var index = new Vue({
	el: "#index",
	created() {
		localStorage.removeItem("bDetail");
	},
	methods: {
		onAboutMe() {
			window.location.href = "https://localhost:44310/about-me";
		}

		// Функция записывает заготовку в сообщение.
		//onSetBodyRequest(e) {
		//	console.log("onSetBodyRequest");
		//	let sBody = e.target.value;
		//}
	}
});

var header = new Vue({
	el: "#header",
	methods: {
		onMain() {
			localStorage.removeItem("bDetail");
			window.location.href = "https://localhost:44310/index";
		},

		onAboutMe() {
			window.location.href = "https://localhost:44310/about-me";
		},

		onPortfolio() {
			window.location.href = "https://localhost:44310/portfolio";
		}
	}
});