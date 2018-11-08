import Vue from 'vue'
import App from './App'
import router from './router'
import VeeValidate from 'vee-validate'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faBars } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import axios from "axios";

library.add(faBars)
Vue.component('font-awesome-icon', FontAwesomeIcon)

const config = {
  fieldsBagName: 'validateFields'
} 

Vue.use(BootstrapVue);
Vue.use(VeeValidate, config);

Vue.config.productionTip = false
Vue.prototype.$axiosServer = axios.create({
  baseURL: 'https://saltedchefapi-dev.us-east-2.elasticbeanstalk.com',
  withCredentials: false,
  headers: {
    "Content-Type": "application/json"
  }
});
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
