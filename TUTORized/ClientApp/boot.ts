import './css/site.css';
import './stylus/main.styl';
import Vue from 'vue';
import Vuetify from 'vuetify';
import VueRouter from 'vue-router';
Vue.use(Vuetify);
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/login/login.vue.html').default },

    { path: '/signUp', component: require('./components/home/signUp/signUp.vue.html').default },
    { path: '/listAppointments', component: require('./components/calendar/calendar.vue.html').default },
    { path: '/scheduleappointment', component: require('./components/student/scheduleAppointment.vue.html').default }

];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html').default )
});
