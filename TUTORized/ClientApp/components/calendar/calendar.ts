import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Appointment } from '../../models/Appointment';
import UserService from '../../services/user/userServices';

@Component
export default class Calendar extends Vue {

    events: Array<Appointment> = [];
    event = new Appointment();
    selectedEvent = new Appointment();
    isLoaded: boolean = false;

    mounted() {
        UserService.GetListOfAppointments().then(result => {
            this.events = result;
            this.isLoaded = true;
        });
    }
}