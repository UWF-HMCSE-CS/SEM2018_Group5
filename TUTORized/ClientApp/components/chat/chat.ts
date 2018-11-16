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
export default class Chat extends Vue {

    users: Array<User> = [];
    user = new User();
    selectedUser = new User();
    message: Message = new Message();
    isLoaded: boolean = false;

    mounted() {
        UserService.GetListOfUsersWorkedWith().then(result => {
            this.users = result;
            this.isLoaded = true;
        });
    }

    goToNextQuestionButtonFunction() {
        this.message.toUserId = (<HTMLInputElement>document.getElementById("user.id")).value;
        this.message.messageBody = (<HTMLInputElement>document.getElementById("msg")).value;
        UserService.sendMessage(this.message);
        alert('Message sent successfully');

    }
}
