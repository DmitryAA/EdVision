import "babel-polyfill"
import 'style/layout/work';
import 'block/common';
import 'axios';

import Vue from 'vue';
import vuex from 'vuex';
import vBem from 'v-bem';
import VueRouter from 'vue-router'

import store from './store';
import routes from './routes';

import top from 'component-vue/top';

Vue.use(VueRouter);
Vue.use(vuex);
Vue.use(vBem, {blockPrefix: 'b-', modSeparator: '--'});

const Store = new vuex.Store(store);
const router = new VueRouter({routes});

let app = new Vue({
	router,
	components: {top},
	store: Store
});

document.addEventListener("DOMContentLoaded", function() {
	app.$mount('#app');
});


new Vue({
	ell: '#app',
});


