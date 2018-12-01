import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { User } from '../../models/User';
import { Message } from '../../models/Message';
import UserService from '../../services/user/userServices';
import TutorService from '../../services/Tutor/tutorServices';


@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class Chat extends Vue {

    users: Array<User> = [];
    user = new User();
    selectedUser = new User();
    upgradeUser = new User();

    usersIsLoaded: boolean = false;

    mounted() {
        TutorService.getListOfStudents().then(result => {
            this.users = result;
            this.usersIsLoaded = true;
        });
    }

    submit() {
        this.selectQuizByIdFromListOfQuizzes(this.selectedUser.id);
        TutorService.upgradeStudentToTutor(this.upgradeUser);
        alert('Student: ' + this.upgradeUser.firstName + ' ' + this.upgradeUser.lastName + ' has been upgraded to Tutor');
        window.location.href = "/upgradeStudentToTutor";
    }

    selectQuizByIdFromListOfQuizzes(id: string) {
        for (var index: number = 0; index < this.users.length; index++) {
            if (this.users[index].id == id) {
                this.upgradeUser = this.users[index];
            }
        }
    }
}