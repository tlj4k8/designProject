import Vue from "vue";
import Vuex from "vuex";
import VueAxios from 'vue-axios';
import axios from "axios";
import jwtDecoded from "jwt-decode";

Vue.use(VueAxios, axios);
Vue.use(Vuex);


export default new Vuex.Store({
  state: {
    userId: '',
    userInfo:{},
    jwt: localStorage.getItem('t'),
    endpoints: {
      obtainJWT: 'https://chefemployees.com/api/Auth/Login'
    }
  },
  mutations: {
    setUser(state, id){
      state.userId = id;
    },
    resetUser(state){
      state.userId = '';
    },
    updateToken(state, newToken){
      localStorage.setItem('t', newToken);
      state.jwt = newToken;
    },
    removeToken(state){
      localStorage.removeItem('t');
      localStorage.clear();
      state.jwt = null;
    },
    setUserInfo(state, userInfo){
      state.userInfo = userInfo;
    },
    resetUserInfo(state){
      state.userInfo = {}
    }
  },
  getters: {
    isLoggedIn: state => !!state.jwt,
    isAdmin: state => state.userInfo.admin,
    isMenu: state => state.userInfo.menu
  },
  actions: {
    logout({commit}){
      commit('resetUser');
      commit('removeToken');
      commit('resetUserInfo');
    },
    loginToken({commit}, token){
      commit('updateToken', token);
    },
    obtainToken({commit}, person){
      const payload = {
        Username: person.username,
        password: person.password
      }
      axios.post(this.state.endpoints.obtainJWT, payload)
        .then((response)=>{
            this.commit('updateToken', response.data.token);
          })
        .catch((error)=>{
            console.log(error);
          })
    },
    storeUserInfo({commit},token){
      let userInfo = jwtDecoded(token);
      commit('setUserInfo', userInfo);
    }

  }
});
