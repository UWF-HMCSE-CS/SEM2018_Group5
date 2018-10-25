import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';
import studentSrvices from '../../services/student/studentServices';

@Component
export default class CalenderComponent extends Vue{

    appointments: Array<Appointment> = [];
 
    method()
    {
        studentSrvices.getListOfAppointments().then(result =>{
            this.appointments = result;

        })
    }
    
}