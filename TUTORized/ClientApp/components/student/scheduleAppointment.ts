import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { User } from '../../models/User';

@Component
export default class ScheduleAppointment extends Vue {

    tutors: Array<User> = [];
    tutor = new User();
    isLoaded: boolean = false;

    getListOfTutors() {
        $.ajax({

            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "GET",
            url: 'api/student',
            dataType: 'json',
            success: function(data) {
                this.tutors = data
                console.log(this.tutors);
                this.isLoaded = true;
            }
        });
    }

    mounted() {
        this.getListOfTutors();
    }
}