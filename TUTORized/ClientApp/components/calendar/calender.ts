import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';
import studentSrvices from '../../services/student/studentServices';

@Component
export default class CalenderComponent extends Vue{


    appointments: Array<Appointment> = [];
    
    //appointments.id = "818FD2E1-1E3D-4EEB-A4B7-B7FF0A0A6D3D" ;
 
    method()
    {
        
        studentSrvices.getListOfAppointments().then(result =>{
            
            this.appointments = result;

        })
    }
    
}