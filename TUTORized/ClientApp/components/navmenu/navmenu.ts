import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as Cookie from 'es-cookie';
export default class NavMenu extends Vue {

    role: any;

    get isStudent() {
        if(this.role === 'student') {
            return true;
        }
        return false;
    }

    get isTutor() {
        if(this.role === 'tutor') {
            return true;
        }
        return false;
    }

    getRole() {
        console.log(Cookie.get('role'));
        this.role = Cookie.get('role');
        return this.role;
    }

    mounted() {
        this.getRole();
    }
}