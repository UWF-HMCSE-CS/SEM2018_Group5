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

    selectedUser = new User();

    messageTemp = new Message();
    messages: string = '';

    
    isLoaded: boolean = false;


    mounted() {
        UserService.GetListOfUsersWorkedWith().then(result => {
            this.users = result;
            this.isLoaded = true;
        });
    }


    computeMessageFunction(){
        this.messages = (<HTMLInputElement>document.getElementById("message")).value;
     // alert(this.messages);
        
    }


    sendButtonFunction(){
        this.computeMessageFunction();

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: 'api/chat/sendMessage',
            data: JSON.stringify({
                "Id": this.messageTemp.id,
                "FromUserId": this.messageTemp.fromUserId,
                "ToUserId": this.messageTemp.toUserId,
                "MessageBody": this.messageTemp.messageBody
            }),
            dataType: 'json',
            complete: function (response) {
                alert("Message sent successfully");
                window.location.href = "/chat";
            }
        });

        /*

        var found_it;

        for (var i=0; i<document.asdf.usersNames.length; i++)  {
        if (document.asdf.usersNames[i].checked)  {
    
        found_it = document.asdf.usersNames[i].value
    
        }
        } 

        for (var i = 0; i < document.asdf.radio_name.length; i++) {
            if (document.asdf.radio_name[i].checked) {
                // ...
            }
        }
        */

        /*
            $('input[type=radio]').on("change",function() {
                alert($(this).val());
            });  
        */
        /*
        $(".radioClass").change(function(){
            alert("test2");
            var selected_value = $(this).val();
            alert(selected_value);
        })
        */

        /*
        // go through the users in User and see which user's radio button is checked and get the value for it
        for(var i = 0; i < this.users.length; i++){
            document.getElementsByName(this.users[i]).checked
            
        }
        */

        /*
        for(var i = 0; i < this.users.length; i++){
            
            
        }
        */
    
        /*
        selectFunction(){
            $('input[type="radio"]').on('click',function(){
                alert("test");
                var value = $(this).val();
                var name = $(this).attr('name');
                alert(name);
            });
        }
        */

    }


    

    

    

    
}
