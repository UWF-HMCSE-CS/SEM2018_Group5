import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';

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
        } if ((<HTMLInputElement>document.getElementById("tutorRole")).checked) {

             this.role = (<HTMLInputElement>document.getElementById("tutorRole")).value;
        }
        
        
       $.ajax({
             headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
                },
              type: "POST",
              url: 'api/user/registerUser',
              data: JSON.stringify({FirstName: this.firstName,
                  LastName: this.lastName,
                  Email: this.userEmail,
                  Password: this.userPassword,
                  Role: this.role
                  }),
              dataType: 'json'
        });
          
    
    }

   
}

   
   


   

    

