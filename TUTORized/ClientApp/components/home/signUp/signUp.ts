import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
//import userSignUpModules from '././module/userSignUpModules';


@Component
export default class SignUpComponent extends Vue{
  
    firstName: string = '';
    lastName: string = '';
    userEmail: string = '';
    userPassword: string = '';
    conPassword: string = '';
    debug: string = '';
    studentRole: boolean = false;
    teacherRole: boolean = false;

    signUpFunction(){

        this.firstName =  (<HTMLInputElement>document.getElementById("firstName")).value;
        this.lastName =  (<HTMLInputElement>document.getElementById("lastName")).value;
        this.userEmail = (<HTMLInputElement>document.getElementById("userEmail")).value;
        this.userPassword = (<HTMLInputElement>document.getElementById("userPassword")).value;
        this.conPassword = (<HTMLInputElement>document.getElementById("conPassword")).value;

        
         $.ajax({
          type: "POST",
          url: 'api/user/signUp',
          data: {userFirstName: this.firstName,
              userLastName: this.lastName,
              userInputEmail: this.userEmail,
              userInputPassword: this.userPassword
              },

          dataType: 'json'
        });
          
    
    }

   
}

   
   


   

    

