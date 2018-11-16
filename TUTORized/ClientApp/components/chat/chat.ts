import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import $ from 'jquery';
import { Message } from '../../models/Message';

@Component
export default class ChatComponent extends Vue {

    message = new Message();

    

    sendButtonFunction() {

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/user/sendMessage',
            data: JSON.stringify({
                "FromUserId": this.message.fromUserId,
                "ToUserId": this.message.toUserId,
                "MessageBody": this.message.messageBody
            }),
            dataType: 'json',
            complete: function (response) {
                 alert("success");
            }

        });
    }


}

import {ComponentOptions} from 'Vue';

export declare type VueClass = {
    new (): Vue;
} & typeof Vue;
export declare type DecoratedClass = VueClass & {
    __decorators__?: ((options: ComponentOptions<Vue>) => void)[];
};




   

    




/*
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { User } from '../../models/User';
import { Message } from '../../models/Message';
import UserService from '../../services/user/userServices';



@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})

export default class ChatUser extends Vue {

    user = new User();
    users: Array<User> = [];

    message = new Message();

    isLoaded: boolean = false;

    sendButtonFunction(){

        this.message.messageBody = (<HTMLInputElement>document.getElementById("msg")).value;

    }

    
    mounted() {
        UserService.GetListOfUsersWorkedWith().then(result => {
            this.users = result;
            this.isLoaded = true;
        });
        UserService.GetMessageAsync(this.message.messageBody).then(result => {
            this.message = result;
            this.isLoaded = true;
        });
    }

}

*/



