<template>
	<div class="login">
		<h1>Login page</h1>
		<google-button :params="google" :onSuccess="onSuccess"
			>click here to log in</google-button
		>
	</div>
</template>

<script>
export default {
	data: () => ({
		google: {
			client_id:
				'771799538739-mjkfskfp0v9ms5hlrb41lc66qjucd4r4.apps.googleusercontent.com',
		},
	}),
	methods: {
		onSuccess(data) {
			this.axios
				.post(this.$store.getters.api + '/login', {
					tokenId: data.Zi.id_token,
				})
				.then(response => {
					this.$store.commit('login', response.data.token);
					this.$router.push({path: 'dashboard'});
				});
		},
	},
};
</script>
