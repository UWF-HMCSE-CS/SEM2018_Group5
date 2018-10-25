import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';
import { User } from '../../models/User';



@Component
export default class CalenderComponent extends Vue{

    appointment = new Appointment();
    user = new User();
    

    getData(appo: Appointment){
        $.ajax({
            type: "GET",
            url:'api/listAppointments',
            dataType:'text/json',
            success: function(){
                return appo;
            }
        });

    this.appointment.id = appo.id;
    this.appointment.date = appo.date;
    this.appointment.tutorId = appo.tutorId;
    this.appointment.duration = appo.duration;
    this.appointment.subject = appo.subject;


    }
  
}