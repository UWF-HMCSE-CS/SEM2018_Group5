import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';

@Component
export default class SignUpComponent extends Vue {

    user = new User();
    confirmPassword: string = '';
    isUserInputValidated: boolean = false;

    roles: any[] =  [
        { role: 'Tutor' },
        { role: 'Student'}
    ];

    //validating user input
    validatUserInoutFunction(){

        if(this.user.firstName.length != 0 && this.user.lastName.length != 0 && this.user.email.length != 0)
        {
            //this.isUserInputValidated = true;
            if(this.user.password == this.confirmPassword)
            {
                if(this.user.role.length != 0)
                {
                    this.isUserInputValidated = true;
                    return true;
                }else{
                    alert("Please select a role");
                }

            }else{
                alert("Password doesn't match, please try again");
            }
        }else{
            alert("Please check your inputs.");
        }

    }


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

import {ComponentOptions} from 'Vue';

export declare type VueClass = {
    new (): Vue;
} & typeof Vue;
export declare type DecoratedClass = VueClass & {
    __decorators__?: ((options: ComponentOptions<Vue>) => void)[];
};




   

    

