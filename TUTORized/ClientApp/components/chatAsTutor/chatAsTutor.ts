import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { User } from '../../models/User';
import { Message } from '../../models/Message';
import UserService from '../../services/user/userServices';
import ChatAsTutorServices from '../../services/chat/chatAsTutorServices';



@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})

export default class ChatUser extends Vue {

    
    user = new User();
    users: Array<User> = [];

    selectedUser = new User();

    messageTemp = new Message();
    messages: string = '';

    msgs: Array<Message> = [];
    isLoaded: boolean = false;


    mounted() {
        UserService.GetListOfUsersWorkedWith().then(result => {
            this.users = result;
            this.isLoaded = true;
        });

        ChatAsTutorServices.GetListOfMessages().then(result => {
            this.msgs = result;
            this.isLoaded = true;
        })

        
    }

 


    computeMessageFunction(){
        this.messageTemp.messageBody = (<HTMLInputElement>document.getElementById("message")).value;
        
    //    alert(this.messageTemp.messageBody);
        
    }


    sendButtonFunction(){
        this.computeMessageFunction();

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
                
            },
            
            type: "POST",
            url: 'api/chatAsTutor/createMessage',
            data: JSON.stringify({
                "Id": this.messageTemp.id,
                "TutorId": this.messageTemp.tutorId,
                "SendToId": this.user.id,
                "MessageBody": this.messageTemp.messageBody,
                "TutorFirstName": this.messageTemp.tutorFirstName,
                "TutorLastName": this.messageTemp.tutorLastName
                
            }),
            dataType: 'json',
            complete: function (response) {
                alert("Message sent successfully");
                window.location.href = "/chatAsTutor";
            }
        });

    }

    
}
