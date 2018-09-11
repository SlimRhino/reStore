import Vue from 'vue';
import VueRouter from 'vue-router';

import Store from './pages/Store.vue';
import Product from './pages/Product.vue';

Vue.use(VueRouter);
const routes = [
    { path: "/products", component: Store },
    { path: "/products/:slug", component: Product },
    { path: "*", redirect: "/products"}
];
new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/App.vue'))
});