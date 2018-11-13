import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { User } from '../../models/User';
import UserService from '../../services/user/userServices';


@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class ChatUser extends Vue {

    users: Array<User> = [];
    user = new User();
    selectedUser = new User();
    isLoaded: boolean = false;

    mounted() {
        UserService.GetListOfUsersWorkedWith().then(result => {
            this.users = result;
            this.isLoaded = true;
        });
    }

    chatFunction(){
        $(".radioClass").change(function(){
            alert("test2");
            var selected_value = $(this).val();
            alert(selected_value);
        })
    }
}
