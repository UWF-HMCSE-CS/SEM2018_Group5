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
            alert("test");
        });
    }

}
