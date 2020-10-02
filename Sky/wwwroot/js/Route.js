var index = new Vue({
	el: "#index",
	created() {
		localStorage.removeItem("bDetail");

		// Блокирует определенные пункты меню.
		if (window.location.href.includes("about-me")) {
			$(".my-orders").prop("disabled", true);
		}			

		if (window.location.href.includes("portfolio")) {
			$(".my-orders").prop("disabled", true);
			$(".my-portfolio").prop("disabled", true);
		}		

		if (window.location.href.includes("order-details")) {
			$(".my-orders").prop("disabled", true);
		}	
	},
	methods: {
		onAboutMe() {
			window.location.href = "https://devmyprojects24.xyz/about-me";
		}		
	}
});

var header = new Vue({
	el: "#header",
	methods: {
		onMain() {
			localStorage.removeItem("bDetail");
			window.location.href = "https://devmyprojects24.xyz/index";
		},

		onAboutMe() {
			window.location.href = "https://devmyprojects24.xyz/about-me";
		},

		onPortfolio() {
			window.location.href = "https://devmyprojects24.xyz/portfolio";
		}
	}
});