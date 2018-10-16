import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';

@Component
export default class LoginComponent extends Vue{

    userEmail: string = '';
    userPassword: string = '';
   
    loginButtonFunction(){

       this.userEmail = (<HTMLInputElement>document.getElementById("userEmail")).value;
       this.userPassword = (<HTMLInputElement>document.getElementById("userPassword")).value;
       
       
        $.ajax({
              url: 'api/user/loginUser',
              type: 'get',
              data: {
                  email: this.userEmail,
                  password: this.userPassword
                  }
                
        });
          
    
    }

   
}

   
   


   

    


