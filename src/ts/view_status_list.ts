import Vue from "vue";
import 'vue2-timepicker/dist/VueTimepicker.css'
import StatusList from './components/StatusList.vue'
import 'vue2-timepicker/dist/VueTimepicker.css'
import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
library.add(fas)
Vue.component('font-awesome-icon', FontAwesomeIcon)

const app = new Vue({
    el: '#app',
    render: h => {
        return h(StatusList)
    }
});