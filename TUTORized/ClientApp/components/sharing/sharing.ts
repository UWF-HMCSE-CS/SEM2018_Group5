import Vue from 'vue';
import { Component } from 'vue-property-decorator';


@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class Sharing extends Vue {

    upload(){
        alert("upload successful!");
    }
 
}