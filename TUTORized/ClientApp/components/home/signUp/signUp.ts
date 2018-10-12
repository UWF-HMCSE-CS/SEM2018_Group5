import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
//import { MdRadioChange } from '@angular/material';
//import userSignUpModules from '././module/userSignUpModules';


@Component
export default class SignUpComponent extends Vue{
  
    firstName: string = '';
    lastName: string = '';
    userEmail: string = '';
    userPassword: string = '';
    conPassword: string = '';
    role: string='';

    signUpFunction(){

        this.firstName =  (<HTMLInputElement>document.getElementById("firstName")).value;
        this.lastName =  (<HTMLInputElement>document.getElementById("lastName")).value;
        this.userEmail = (<HTMLInputElement>document.getElementById("userEmail")).value;
        this.userPassword = (<HTMLInputElement>document.getElementById("userPassword")).value;
        this.conPassword = (<HTMLInputElement>document.getElementById("conPassword")).value;

        //check which role the user selected
        if ((<HTMLInputElement>document.getElementById("studentRole")).checked) {

             this.role = (<HTMLInputElement>document.getElementById("studentRole")).value;
        } if ((<HTMLInputElement>document.getElementById("teacherRole")).checked) {

             this.role = (<HTMLInputElement>document.getElementById("teacherRole")).value;
        }

        $.ajax({
             headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
                },
              type: "POST",
              url: 'api/user/registerUser',
              data: {userFirstName: this.firstName,
                  userLastName: this.lastName,
                  userInputEmail: this.userEmail,
                  userInputPassword: this.userPassword,
                  role: this.role
                  },

              dataType: 'json'
        });
          
    
    }

   
}

   
   


   

    

