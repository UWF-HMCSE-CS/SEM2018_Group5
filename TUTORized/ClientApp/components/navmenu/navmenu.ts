import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as Cookie from 'es-cookie';

@Component
export default class NavMenu extends Vue {

    role: any;
    isLoaded: boolean = false;
    get isStudent() {
        if(this.role === 'Student') {
            return true;
        }
        return false;
    }

    get isTutor() {
        if(this.role === 'Tutor') {
            return true;
        }
        return false;
    }

    getRole() {
        this.role = Cookie.get('role');
        this.isLoaded = true;
        return this.role;
    }

    mounted() {
        console.log("MOUNTED");
        this.getRole();
    }
}