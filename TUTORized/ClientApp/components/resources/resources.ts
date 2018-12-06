import Vue from 'vue';
import { Component } from 'vue-property-decorator';


@Component({
    components: {
        NavMenu: require('../navmenu/navmenu.vue.html').default
    }
})
export default class Resources extends Vue {

    submitFile(){
        alert("test");
}


    
}


/*function readURL(input) {
    
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah')
                .attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
    
   alert("fdsf");
}
*/