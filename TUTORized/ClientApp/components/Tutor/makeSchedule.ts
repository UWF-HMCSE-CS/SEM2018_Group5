import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Appointment } from '../../models/Appointment';

@Component
export default class SignUpComponent extends Vue {

    date: string = '';
    duration: string = '';
    subject: string = '';
   
    submitFunction() {

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/user/makeSchedule',
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
