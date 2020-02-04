<template>
	<v-data-table
		:headers="headers"
		:items="links"
		sort-by="name"
		class="elevation-9"
	>
		<template v-slot:top>
			<v-toolbar flat color="white">
				<v-toolbar-title>AR Links</v-toolbar-title>
				<v-divider class="mx-4" inset vertical></v-divider>
				<v-spacer></v-spacer>
				<v-dialog v-model="dialog" max-width="500px">
					<template v-slot:activator="{on}">
						<v-btn color="primary" dark class="mb-2" v-on="on"
							>New Link
						</v-btn>
					</template>
					<v-card>
						<v-card-title>
							<span class="headline">{{ formTitle }}</span>
						</v-card-title>
						<v-card-text>
							<v-container>
								<v-row>
									<v-col cols="12" md="6">
										<v-text-field
											v-model="editedLink.name"
											label="Link title"
										></v-text-field>
									</v-col>
									<v-col cols="12" sm="6">
										<v-autocomplete
											:items="[
												'AR',
												'Accounting',
												'IT',
												'Marketing',
												'HMS',
												'HR',
												'PMO',
												'Technical',
												'Electronics',
												'Leaders',
											]"
											label="Category"
											multiple
										></v-autocomplete>
									</v-col>
									<v-col cols="12" sm="12" md="12">
										<v-text-field
											v-model="editedLink.text"
											label="Description"
										></v-text-field>
									</v-col>
									<v-col cols="12" sm="12" md="12">
										<v-text-field
											v-model="editedLink.url"
											label="Link"
										></v-text-field>
									</v-col>
								</v-row>
							</v-container>
						</v-card-text>
						<v-card-actions>
							<v-spacer></v-spacer>
							<v-btn color="blue darken-1" text @click="close"
								>Cancel</v-btn
							>
							<v-btn color="blue darken-1" text @click="save"
								>Save</v-btn
							>
						</v-card-actions>
					</v-card>
				</v-dialog>
			</v-toolbar>
		</template>
		<template v-slot:item.action="{item}">
			<v-icon small class="mr-2" @click="editLink(item)">
				edit
			</v-icon>
			<v-icon small @click="deleteLink(item)">
				delete
			</v-icon>
		</template>
		<template v-slot:no-data>
			<!--<v-btn color="primary" @click="initialize">Reset</v-btn>-->
		</template>
	</v-data-table>
</template>

<script>
import Vue from 'vue';
import GoogleLogin from 'vue-google-login';

Vue.component('google-login', GoogleLogin);

export default {
	data: () => ({
		dialog: false,
		headers: [
			{
				text: 'Title',
				value: 'name',
				align: 'left',
			},
			{
				text: 'Description',
				value: 'text',
			},
			{
				text: 'URL',
				value: 'url',
				sortable: false,
			},
			{
				text: 'Actions',
				value: 'action',
				sortable: false,
			},
		],
		links: [],
		editedIndex: -1,
		editedLink: {
			name: '',
			text: '',
			url: '',
		},
		defaultItem: {
			name: '',
			text: '',
			url: '',
		},
	}),

	computed: {
		formTitle() {
			return this.editedIndex === -1 ? 'New Link' : 'Edit Link';
		},
	},

	watch: {
		dialog(val) {
			val || this.close();
		},
	},

	created() {
		this.getLinks();
	},

	methods: {
		getLinks() {
			this.axios
				.get(this.$store.getters.api + '/home/shortcuts')
				.then(response => {
					this.links = response.data;
				});
		},

		editLink(link) {
			if (!this.$store.getters.token) return;

			this.editedIndex = this.links.indexOf(link);
			this.editedLink = Object.assign({}, link);
			this.dialog = true;
		},

		deleteLink(link) {
			if (!this.$store.getters.token) return;

			const index = this.links.indexOf(link);
			if (confirm('Are you sure you want to delete this link?')) {
				this.links.splice(index, 1);
				this.axios
					.delete(
						this.$store.getters.api + '/home/shortcuts/' + link.id,
						{
							headers: {
								Authorization:
									'Bearer ' + this.$store.getters.token,
							},
						}
					)
					.then(function(response) {
						console.log(response);
					})
					.catch(function(error) {
						console.log(error);
					});
			}
		},

		close() {
			this.dialog = false;
			setTimeout(() => {
				this.editedLink = Object.assign({}, this.defaultItem);
				this.editedIndex = -1;
			}, 300);
		},

		save() {
			if (this.editedIndex > -1) {
				Object.assign(this.links[this.editedIndex], this.editedLink);

				this.axios
					.put(
						this.$store.getters.api +
							'/home/shortcuts/' +
							this.editedLink.id,
						this.editedLink,
						{
							headers: {
								Authorization:
									'Bearer ' + this.$store.getters.token,
							},
						}
					)
					.then(function(response) {
						console.log(response);
					})
					.catch(function(error) {
						console.log(error);
					});
			} else {
				this.links.push(this.editedLink);

				this.axios
					.post(
						this.$store.getters.api + '/home/shortcuts',
						this.editedLink
					)
					.then(function(response) {
						console.log(response);
					})
					.catch(function(error) {
						console.log(error);
					});
			}
			this.close();
		},
	},
};
</script>
