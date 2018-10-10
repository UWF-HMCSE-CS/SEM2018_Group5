import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface signUpScreen{
    userEmail: string;
    userPassword: string;
    conPassword: string;
}

@Component
export default class SignUpComponent extends Vue {

    signUpButton : number = 0;

    incrementCounter() {

        console.log("This button is clicked");
    }
    
}
