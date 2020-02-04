<template>
	<v-app-bar color="black" dark>
		<v-toolbar-items>
			<img src="../assets/logo.png" style="height: inherit;" />
		</v-toolbar-items>

		<v-spacer></v-spacer>

		<v-menu bottom left>
			<template v-slot:activator="{on}">
				<v-btn dark icon v-on="on">
					<v-icon>mdi-dots-vertical</v-icon>
				</v-btn>
			</template>

			<v-list>
				<v-list-item v-for="(item, i) in items" :key="i" :to="item.to">
					<v-list-item-title>{{ item.title }}</v-list-item-title>
				</v-list-item>
			</v-list>
		</v-menu>
	</v-app-bar>
</template>

<script>
export default {
	data: () => ({
		items: [
			{to: '/dashboard', title: 'Dashboard'},
			{to: '/dashboard/link', title: 'Home links'},
			{to: '/dashboard/event', title: 'Info events'},
		],
	}),
};
</script>
