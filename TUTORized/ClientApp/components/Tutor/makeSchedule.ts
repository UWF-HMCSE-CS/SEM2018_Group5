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
    year: string = '';
    month: string = '';
    day: string = '';
    dateTime: string = '';

    //set subject array
    subjects: any[] = [
        {subject: 'Math'},
        {subject: 'CS'},
        {subject: 'Science'},
        {subject: 'History'},
        {subject: 'English'}
    ];

    //set time array
    times: any[] = [
        { time: '08:00' },
        { time: '09:00' },
        { time: '10:00' },
        { time: '11:00' },
        { time: '12:00' },
        { time: '13:00' },
        { time: '14:00' },
        { time: '15:00' },
        { time: '16:00' },
];

    computeDateFunction() {
        this.year = (<HTMLInputElement>document.getElementById("year")).value;
        this.month = (<HTMLInputElement>document.getElementById("month")).value;
        this.day = (<HTMLInputElement>document.getElementById("day")).value;

        this.dateTime = (<HTMLInputElement>document.getElementById("dateTime")).value;
        var fullDateTime = this.year + '-' + this.month + '-' + this.day + ' ' + this.dateTime + ':00.000';
        this.appointment.date = fullDateTime;
    }

    submitFunction() {

        this.computeDateFunction();

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
                alert('Scheduled Successfully');
                window.location.href = "/makeSchedule";
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
