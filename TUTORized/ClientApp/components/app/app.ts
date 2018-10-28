import Vue from "vue";
import { Component } from 'vue-property-decorator';
import LoginComponent from '../home/login/login';
import * as Cookie from 'es-cookie'
@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class AppComponent extends Vue {

    isLoaded: boolean = false;

    get isReady() {
        if(Cookie.get('role')) {
            this.isLoaded = true;
        }
        return this.isLoaded;
    }
}
