import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../../models/User';
import UserService from '../../../services/user/userServices';
import * as Cookie from 'es-cookie';

@Component
export default class LoginComponent extends Vue{
    
    user = new User();
   
    loginButtonFunction(){     
        
        UserService.UserLogin(this.user.email, this.user.password)
        .then(result => {
            Cookie.set('role', result.role);
            this.routeToScheduleAppt();
        });
    }

    routeToSignup(){
        this.$router.push({
            path: '/signUp'
        });
    }

    routeToScheduleAppt() {
        this.$router.push({
            path: '/scheduleappointment'
        });
    }

}

   
   


   

    


