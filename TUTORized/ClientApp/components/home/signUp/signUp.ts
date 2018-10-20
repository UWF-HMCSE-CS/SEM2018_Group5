import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';

@Component
export default class SignUpComponent extends Vue {

    user = new User();
    ConfirmPassword: string = '';

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
                firstname: this.user.FirstName,
                lastname: this.user.LastName,
                email: this.user.Email,
                password: this.user.Password,
                role: this.user.Role
            }),
            dataType: 'json',
            complete: function (response) {
                 window.location.href = "/";
            }

        });
    }


}









   

    

