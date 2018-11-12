import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';
import UserService from '../../../services/user/userServices';
import * as Cookie from 'es-cookie';

@Component
export default class LoginComponent extends Vue{
    
    user = new User();

    validatedUserInputFunction()
    {
        if(this.user.email.length != 0)
        {

            if(this.user.password.length != 0)
            {
                return true;

            }else{
                alert("Please enter your password ");
            }
        }else{
            alert("Please enter your email");
        }
    }
       
    loginButtonFunction(){ 
        
        if(this.validatedUserInputFunction())
        {
            
            UserService.UserLogin(this.user.email, this.user.password)
            .then(result => {
                Cookie.set('role', result.role);
                
                this.routeToHome();
            });
        }
    }

    routeToSignup(){
        this.$router.push({
            path: '/signUp'
        });
    }

    routeToHome() {
        this.$router.push({
            path: '/home'
        });
    }

}

   
   


   

    


