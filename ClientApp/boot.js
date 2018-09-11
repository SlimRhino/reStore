import Vue from 'vue';
import VueRouter from 'vue-router';
import BootstrapVue from 'bootstrap-vue';

//import 'bootstrap/dist/css/bootstrap.css'
//import 'bootstrap-vue/dist/bootstrap-vue.css'
import Store from './pages/Store.vue';
import Product from './pages/Product.vue';

Vue.use(VueRouter);
Vue.use(BootstrapVue);
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