import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Appointment } from '../../models/Appointment';
import StudentService from '../../services/student/studentServices';
import * as Cookie from 'es-cookie';

@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class ScheduleAppointment extends Vue {

    appointment = new Appointment();
    id: string = '';
    email: string = '';
    appointments: Array<Appointment> = [];
    tempAppointments: Array<Appointment> = [];
    event = new Appointment();
    selectedEvent = new Appointment();
    isLoaded: boolean = false;

    submitFunction() {
        this.email = Cookie.get('email');
        console.log(this.appointment.tutorId);
        this.isLoaded = false;
        StudentService.MakeStudentAppointment(this.appointment, this.email).then(x => {
            StudentService.GetListOfAllAvailableAppointments().then(result => {
                this.appointments = result;
                this.isLoaded = true;
            })
        });
        alert('Scheduled Successfully');
        window.location.href = "/scheduleAppointment";
    }

    filterFunction(search: string) {
        this.appointments = this.getFilteredAppointments(search);
        alert('Filtered Successfully');
    }

    resetFilterFunction() {
        window.location.href = "/scheduleAppointment";
    }

    itemText(appointment: Appointment) {
        return appointment.tutorFirstName + appointment.studentLastName + this.dateText(appointment.date)
    }

    mounted() {
        StudentService.GetListOfAllAvailableAppointments().then(result => {
            console.log(result);
            this.appointments = result;
            this.isLoaded = true;
        });
    }

    getFilteredAppointments(search: string) {
        var tempApptCounter = 0;
        var lowerCaseSearch = search.toString().toLowerCase();

        for (var index: number = 0; index < this.appointments.length; index++) {
            if (this.appointments[index].tutorFirstName.toLowerCase() === lowerCaseSearch) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
            if (this.appointments[index].tutorLastName.toLowerCase() === lowerCaseSearch) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
            if (this.appointments[index].subject.toLowerCase() === lowerCaseSearch) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
            if (this.appointments[index].date.toLowerCase() === lowerCaseSearch) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
        }
        return this.tempAppointments;
    }

    dateText(date: string): string {
        var year = date.substring(0, 4);
        var month = date.substring(5, 7);
        var day = date.substring(8, 10);
        var hour = date.substring(11, 13);
        var min = date.substring(14, 16);

        var newMonth = this.month(month);
        var time = this.time(hour, min);

        var newDate = (newMonth + ' ' + day + ', ' + year + ' at ' + time);

        return newDate;
    }

    time(hour, min) {
        var meridiem = '';
        if (hour === '00') {
            hour = '12';
            meridiem = 'AM';
        }
        else if (hour === '01') {
            hour = '1';
            meridiem = 'AM';
        }
        else if (hour === '02') {
            hour = '2';
            meridiem = 'AM';
        }
        else if (hour === '03') {
            hour = '3';
            meridiem = 'AM';
        }
        else if (hour === '04') {
            hour = '4';
            meridiem = 'AM';
        }
        else if (hour === '05') {
            hour = '5';
            meridiem = 'AM';
        }
        else if (hour === '06') {
            hour = '6';
            meridiem = 'AM';
        }
        else if (hour === '07') {
            hour = '7';
            meridiem = 'AM';
        }
        else if (hour === '08') {
            hour = '8';
            meridiem = 'AM';
        }
        else if (hour === '09') {
            hour = '9';
            meridiem = 'AM';
        }
        else if (hour === '10') {
            hour = '10';
            meridiem = 'AM';
        }
        else if (hour === '11') {
            hour = '11';
            meridiem = 'AM';
        }
        else if (hour === '12') {
            hour = '12';
            meridiem = 'PM';
        }
        else if (hour === '13') {
            hour = '1';
            meridiem = 'PM';
        }
        else if (hour === '14') {
            hour = '2';
            meridiem = 'PM';
        } else if (hour === '15') {
            hour = '3';
            meridiem = 'PM';
        }
        else if (hour === '16') {
            hour = '4';
            meridiem = 'PM';
        }
        else if (hour === '17') {
            hour = '5';
            meridiem = 'PM';
        }
        else if (hour === '18') {
            hour = '6';
            meridiem = 'PM';
        }
        else if (hour === '19') {
            hour = '7';
            meridiem = 'PM';
        }
        else if (hour === '20') {
            hour = '8';
            meridiem = 'PM';
        }
        else if (hour === '21') {
            hour = '9';
            meridiem = 'PM';
        }
        else if (hour === '22') {
            hour = '10';
            meridiem = 'PM';
        }
        else {
            hour = '11';
            meridiem = 'PM';
        }

        return (hour + ':' + min + ' ' + meridiem);

    }

    month(month: string): string {
        if (month === '01') {
            return 'December';
        }
        else if (month === '01') {
            return 'January';
        }
        else if (month === '02') {
            return 'February';
        }
        else if (month === '03') {
            return 'March';
        }
        else if (month === '04') {
            return 'April';
        }
        else if (month === '05') {
            return 'May';
        }
        else if (month === '06') {
            return 'June';
        }
        else if (month === '07') {
            return 'July';
        }
        else if (month === '08') {
            return 'August';
        }
        else if (month === '08') {
            return 'September';
        }
        else if (month === '08') {
            return 'October';
        }
        else if (month === '08') {
            return 'November';
        }
        else {
            return 'December';
        }
    }

}

import { ComponentOptions } from 'Vue';

export declare type VueClass = {
    new(): Vue;
} & typeof Vue;
export declare type DecoratedClass = VueClass & {
    __decorators__?: ((options: ComponentOptions<Vue>) => void)[];
};