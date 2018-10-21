import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';

@Component
export default class LoginComponent extends Vue{
    
    user = new User();
   
    loginButtonFunction(){     
        $.ajax({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: 'api/user/loginUser',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify({
                "Email": this.user.email,
                "Password": this.user.password
            }),
            success: function (response) {

                alert("Welcome to TUTORized");
                //window.location.href = "http://localhost:53352/";
            },
        });
    }

    routeToSignup(){
        this.$router.push({
            path: '/signUp'
        });
    }

   
}

   
   


   

    


