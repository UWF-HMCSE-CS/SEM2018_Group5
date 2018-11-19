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
    sentMessages: Array<Message> = [];
    sentMessage = new Message();
    receivedMessages: Array<Message> = [];
    receivedMessage = new Message();
    usersIsLoaded: boolean = false;
    receivedMessagesIsLoaded: boolean = false;
    sentMessagesIsLoaded: boolean = false;

    mounted() {
        UserService.GetListOfUsersWorkedWith().then(result => {
            this.users = result;
            this.usersIsLoaded = true;
        });

        UserService.GetListOfUsersReceivedMessages().then(result => {
            this.receivedMessages = result;
            this.receivedMessagesIsLoaded = true;
        });

        UserService.GetListOfUsersSentMessages().then(result => {
            this.sentMessages = result;
            this.sentMessagesIsLoaded = true;
        });
    }

    submit() {
        console.log(this.selectedUser.id);
        UserService.sendMessage(this.selectedUser, this.message.messageBody);
        alert('Message Sent Successfully');
        window.location.href = "/chat";
    }
}