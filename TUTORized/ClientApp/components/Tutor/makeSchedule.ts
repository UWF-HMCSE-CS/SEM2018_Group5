import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';

@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class SignUpComponent extends Vue {

    appointment = new Appointment();

    //set subject array
    subjects: any[] = [
        {subject: 'Math'},
        {subject: 'CS'},
        {subject: 'Science'},
        {subject: 'History'},
        {subject: 'English'}
    ];

    //set duration array
    durations: any[] = [
        {duration: 1},
        {duration: 2},
        {duration: 3},
        {duration: 4},
        {duration: 5},
        {duration: 6},
    ];

    submitFunction() {

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/tutor/createAppointment',
            data: JSON.stringify({
                "Id": this.appointment.id,
                "TutorId": this.appointment.tutorId,
                "Date": this.appointment.date,
                "Duration": this.appointment.duration,
                "Subject": this.appointment.subject,
                "TutorFirstName": this.appointment.tutorFirstName,
                "TutorLastName": this.appointment.tutorLastName
            }),
            dataType: 'json',
            complete: function (response) {

                //alert('Scheduled Successfully');
                //window.location.href = "/makeSchedule";
                
            }
        });
    }
}

import { ComponentOptions } from 'Vue';

export declare type VueClass = {
    new(): Vue;
} & typeof Vue;
export declare type DecoratedClass = VueClass & {
    __decorators__?: ((options: ComponentOptions<Vue>) => void)[];
};
