<template>
	<v-row>
		<LinkItem v-for="(link, index) in links" :link="link" :key="index" />
	</v-row>
</template>

<script>
import LinkItem from '../components/Home/LinkItem';

export default {
	name: 'home',
	data: () => {
		return {
			links: null,
		};
	},
	mounted: function() {
		this.axios
			.get(this.$store.getters.api + '/home/shortcuts')
			.then(response => {
				this.links = response.data;
			});
	},
	components: {
		LinkItem,
	},
};
</script>
