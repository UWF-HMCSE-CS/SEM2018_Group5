import Vue from 'vue';
import { Component, Watch } from 'vue-property-decorator';
import { Appointment } from '../../models/Appointment';
import StudentService from '../../services/student/studentServices';


@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class ScheduleAppointment extends Vue {
    appointment = new Appointment(); 
    id: string = '';

    appointments: Array<Appointment> = [];
    event = new Appointment();
    selectedEvent = new Appointment();
    tempAppointments: Array<Appointment> = [];
    search: string = '';
    isLoaded: boolean = false;
    isUpdated: boolean = false;

    submitFunction() {
        this.isLoaded = false;
        StudentService.MakeStudentAppointment(this.appointment.id).then(x => {
            StudentService.GetListOfAllAvailableAppointments().then(result => {
                this.appointments = result;
                this.isLoaded = true;
            })
        });
        alert('Scheduled Successfully');
        window.location.href = "/scheduleAppointment";
    }

    filterFunction(search: string) {
        //this.resetFilter();
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
            this.appointments = result;
            this.isLoaded = true;
        });
    }

    getFilteredAppointments(search){
        var tempApptCounter = 0;

        for (var index: number = 0; index < this.appointments.length; index++) {
            if (this.appointments[index].tutorFirstName === search) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
            if (this.appointments[index].tutorLastName === search) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
            if (this.appointments[index].subject === search) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
            if (this.appointments[index].date === search) {
                this.tempAppointments[tempApptCounter++] = this.appointments[index];
            }
        }
        return this.tempAppointments;
    }

    resetFilter() {
        StudentService.GetListOfAllAvailableAppointments().then(result => {
            this.appointments = result;
            this.isUpdated = true;
        })
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