import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';

@Component
export default class ScheduleAppointment extends Vue {

    id: string = '';
    studentId: string = '';
    subject: string = '';
    tutor: string = '';

    submitFunction() {

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/student/scheduleAppointment',
            data: JSON.stringify({


            }),
            dataType: 'json',
            complete: function (response) {
                alert("Scheduled Successfully");
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




/*import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { User } from '../../models/User';
import StudentService from '../../services/student/studentServices';

@Component
export default class ScheduleAppointment extends Vue {

    tutors: Array<User> = [];
    tutor = new User();
    selectedTutor = new User();
    isLoaded: boolean = false;

    mounted() {
        StudentService.getListOfTutors().then(result => {
            this.tutors = result;
            this.isLoaded = true;
        });
    }
}
*/