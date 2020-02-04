import Vue from 'vue';
import Vuex from 'vuex';
import VuexPersist from 'vuex-persist';

Vue.use(Vuex);

const vuexLocalStorage = new VuexPersist({
	key: 'vuex',
	storage: window.localStorage,
});

export default new Vuex.Store({
	plugins: [vuexLocalStorage.plugin],
	state: {
		API_URL: 'http://localhost:5000',
		usertoken: null,
	},
	mutations: {
		login(state, token) {
			state.usertoken = token;
		},
	},
	actions: {},
	modules: {},
	getters: {
		api: state => state.API_URL,
		token: state => state.usertoken,
	},
});
