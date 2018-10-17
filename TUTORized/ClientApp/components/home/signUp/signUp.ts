import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';

@Component
export default class SignUpComponent extends Vue{

    user = new User();
    conPassword: string = '';

    signUpFunction(){

        this.user.firstName =  (<HTMLInputElement>document.getElementById("firstName")).value;
        this.user.lastName =  (<HTMLInputElement>document.getElementById("lastName")).value;
        this.user.email = (<HTMLInputElement>document.getElementById("userEmail")).value;
        this.user.password = (<HTMLInputElement>document.getElementById("userPassword")).value;
        this.conPassword = (<HTMLInputElement>document.getElementById("conPassword")).value;

        //check which role the user selected
        if ((<HTMLInputElement>document.getElementById("studentRole")).checked) {

             this.user.role = (<HTMLInputElement>document.getElementById("studentRole")).value;
        } if ((<HTMLInputElement>document.getElementById("tutorRole")).checked) {

             this.user.role = (<HTMLInputElement>document.getElementById("tutorRole")).value;
        }
        
        
       $.ajax({
             headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
                },
              type: "POST",
              url: 'api/user/registerUser',
              data: JSON.stringify({
                  user:this.user
                  }),
              dataType: 'json'
        });
          
    
    }

   
}

   
   


   

    

