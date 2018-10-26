import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Appointment } from '../../models/Appointment';
import UserService from '../../services/user/userServices';

@Component
export default class Calendar extends Vue {

    events: Array<Appointment> = [];
    event = new Appointment();
    selectedEvent = new Appointment();
    isLoaded: boolean = false;

    mounted() {
        UserService.getListOfAppointments().then(result => {
            this.events = result;
            this.isLoaded = true;
        });
    }
}



//import Vue from 'vue';
//import { Component } from 'vue-property-decorator';
//import $ from 'jquery';
//import { Appointment } from '../../models/Appointment';
//import studentSrvices from '../../services/student/studentServices'; 
//import userSrvices from '../../services/user/userServices';

//@Component
//export default class CalendarComponent extends Vue{

//    appointments: Array<Appointment> = [];
    
//    //appointments.id = "818FD2E1-1E3D-4EEB-A4B7-B7FF0A0A6D3D" ;
 
//    method()
//    {
//        userSrvices.getListOfAppointments().then(result =>{
//            this.appointments = result;
            
//        })
//    }
    
//}