import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';

@Component
export default class SignUpComponent extends Vue {

    appointment = new Appointment();
    id: string = '';
    studentId: string = '';
    tutorId: string = '';
    date: string = '';
    duration: string = '';
    subject: string = '';
    studentFirstName: string = '';
    studentLastName: string = '';
    tutorFirstName: string = '';
    tutorLastName: string = '';
    
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

    signUpFunction() {

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/user/registerUser',
            data: JSON.stringify({
                "Id": this.appointment.id,
                "StudentId": this.appointment.studentId,
                "TutorId": this.appointment.tutorId,
                "Date": this.appointment.date,
                "Duration": this.appointment.duration,
                "Subject": this.appointment.subject,
                "StudentFirstName": this.appointment.studentFirstName,
                "StudentLastName": this.appointment.studentLastName,
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
