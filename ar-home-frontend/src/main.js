import Vue from 'vue';
import App from './App.vue';
import './registerServiceWorker';
import router from './router';
import store from './store';
import vuetify from './plugins/vuetify';
import 'material-design-icons-iconfont/dist/material-design-icons.css';
import axios from 'axios';
import VueAxios from 'vue-axios';

Vue.use(VueAxios, axios);

import Default from './layouts/Default';
import SidebarLayout from './layouts/SidebarLayout';
import InfoLayout from './layouts/InfoLayout';
import GoogleLogin from 'vue-google-login';

Vue.component('default-layout', Default);
Vue.component('sidebar-layout', SidebarLayout);
Vue.component('info-layout', InfoLayout);
Vue.component('google-button', GoogleLogin);

Vue.config.productionTip = false;

new Vue({
	router,
	store,
	vuetify,
	render: h => h(App),
}).$mount('#app');
