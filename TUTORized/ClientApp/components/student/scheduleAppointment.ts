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
        return appointment.tutorFirstName + appointment.studentLastName + appointment.date
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
}

import { ComponentOptions } from 'Vue';

export declare type VueClass = {
    new(): Vue;
} & typeof Vue;
export declare type DecoratedClass = VueClass & {
    __decorators__?: ((options: ComponentOptions<Vue>) => void)[];
};