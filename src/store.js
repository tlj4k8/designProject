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
      obtainJWT: 'https://chefemployees.com/api/Auth/Login',
    //   refreshJWT: 'https://slalom-health-api-staging.herokuapp.com/auth/refresh_token'
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
    // refreshToken(){
    //   const payload = {
    //     token: this.state.jwt
    //   }
    //   axios.post(this.state.endpoints.refreshJWT, payload)
    //     .then((response)=>{
    //         this.commit('updateToken', response.data.token)
    //       })
    //     .catch((error)=>{
    //         console.log(error)
    //       })
    // },
    // inspectToken({commit, dispatch}){
    //   const token = this.state.jwt;
    //   if(token){
    //     const exp = decoded.exp
    //     const orig_iat = decoded.orig_iat
    //     if(exp - (Date.now()/1000) < 1800 && (Date.now()/1000) - orig_iat < 628200){
    //       dispatch('refreshToken');
    //     } else if (exp -(Date.now()/1000) < 1800){
    //       // DO NOTHING, DO NOT REFRESH
    //     } else {

    //       // PROMPT USER TO RE-LOGIN, THIS ELSE CLAUSE COVERS THE CONDITION WHERE A TOKEN IS EXPIRED AS WELL
    //     }
    //   }

    // },
    storeUserInfo({commit},token){
      let userInfo = jwtDecoded(token);
      commit('setUserInfo', userInfo);
    }

  }
});
