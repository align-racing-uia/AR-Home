import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import store from '../store/index';

Vue.use(VueRouter);

const routes = [
	{
		path: '/',
		name: 'home',
		component: Home,
	},
	{
		path: '/info',
		name: 'info',
		meta: {layout: 'info'},
		component: () => import('../views/Info.vue'),
	},
	{
		path: '/dashboard',
		name: 'dashboard',
		meta: {layout: 'sidebar'},
		component: () => import('../views/Dashboard/Dashboard.vue'),
	},
	{
		path: '/dashboard/link',
		name: 'link',
		meta: {layout: 'sidebar'},
		component: () => import('../views/Dashboard/Link.vue'),
	},
	{
		path: '/dashboard/event',
		name: 'event',
		meta: {layout: 'sidebar'},
		component: () => import('../views/Dashboard/Event.vue'),
	},
	{
		path: '/login',
		name: 'event',
		component: () => import('../views/Login.vue'),
	},
	{
		path: '/about',
		name: 'about',
		// route level code-splitting
		// this generates a separate chunk (about.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () =>
			import(/* webpackChunkName: "about" */ '../views/About.vue'),
	},
];

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
});

router.beforeEach((to, from, next) => {
	const legalRoutes = ['/login', '/'];
	if (!store.getters.token && !legalRoutes.includes(to.path)) next('/login');
	else {
		next();
	}
});

export default router;
