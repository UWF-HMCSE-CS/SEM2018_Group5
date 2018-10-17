import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';

@Component
export default class LoginComponent extends Vue{
    
    user = new User();
   
    loginButtonFunction(){

       this.user.email = (<HTMLInputElement>document.getElementById("userEmail")).value;
       this.user.password = (<HTMLInputElement>document.getElementById("userPassword")).value;
       
       
        $.ajax({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: 'api/user/loginUser',
            type: 'POST',
            data: JSON.stringify({
                email: this.user.email,
                password: this.user.password

            }),
            dataType: 'json'
        });
          
    
    }

   
}

   
   


   

    


