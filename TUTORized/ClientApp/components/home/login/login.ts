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
             headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
                },
              type: "GET",
              url: 'api/user/loginUser',
              data: JSON.stringify({ Email: this.userEmail,
                  Password: this.userPassword
                 }),
              dataType: 'json'
        });
          
    
    }

   
}

   
   


   

    


