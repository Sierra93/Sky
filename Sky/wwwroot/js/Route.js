var index = new Vue({
	el: "#index",
	methods: {
		onAboutMe() {
			window.location.href = "https://localhost:44310/about-me";
		}		
	}
});

var header = new Vue({
	el: "#header",
	methods: {
		onMain() {
			window.location.href = "https://localhost:44310/index";
		},

		onAboutMe() {
			window.location.href = "https://localhost:44310/about-me";
		}	
	}
});