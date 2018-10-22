import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';

@Component
export default class SignUpComponent extends Vue {

    user = new User();
    confirmPassword: string = '';

    roles: any[] =  [
        { role: 'Tutor' },
        { role: 'Student'}
    ];

    signUpFunction() {

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/user/registerUser',
            data: JSON.stringify({
                "Firstname": this.user.firstName,
                "Lastname": this.user.lastName,
                "Email": this.user.email,
                "Password": this.user.password,
                "Role": this.user.role
            }),
            dataType: 'json',
            complete: function (response) {
                 window.location.href = "/";
            }

        });
    }


}









   

    

