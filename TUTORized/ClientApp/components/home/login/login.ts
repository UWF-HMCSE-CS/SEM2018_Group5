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
                "Email": this.user.Email,
                "Password": this.user.Password
            }),
        });
          
    
    }

   
}

   
   


   

    


