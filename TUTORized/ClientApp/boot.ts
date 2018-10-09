import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import Component from '../node_modules/vue-class-component';
Vue.use(VueRouter);

const routes = [
//{ path: '/', component: require('./components/home/login/login.vue.html')},
    { path: '/', component: require('./components/home/signUp/signUp.vue.html')},
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
