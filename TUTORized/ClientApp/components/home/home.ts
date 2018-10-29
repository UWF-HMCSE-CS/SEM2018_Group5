import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as Cookie from 'es-cookie';
import LoginComponent from './login/login';
import NavMenu from '../navmenu/navmenu';

@Component({
    components: {
        LoginComponent: require('./login/login.vue.html').default,
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})

export default class Home extends Vue {

}