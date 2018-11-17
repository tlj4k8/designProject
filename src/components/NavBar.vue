<template> 
  <div v-if="isLoggedIn">
    <div class="menu">
        <b-button class="logoutButton" @click="logout">Logout</b-button><col/>
        <col class="menuLogo"><font-awesome-icon icon="bars" @click="show = !show" class="fontAwesome"/>
    </div>
    <transition name="fade">
        <div class="overlay" v-if="show" >
	        <div class="wrap" v-on:click="show = !show">
            <router-link class="nav-links" to="/clientDash">Client</router-link>
            <router-link class="nav-links" to="/menuDash">Menu</router-link>
            <router-link class="nav-links" to="/profile">Profile</router-link>
            <router-link v-if="isAdmin=='True'" class="nav-links" to="/employeeDash">Employee</router-link>
            <router-link class="nav-links" to="/scheduleDash">Schedule</router-link>
		      </div>
	      </div>
    </transition>
  </div>
</template>

<script>
import { mapState } from 'vuex';
export default {
  name: "NavBar",
  data(){
      return{
          show: false
      }
  },    
  methods:{
    logout(){
      this.$store.dispatch('logout')
      .then(()=>{
        this.$router.push('/');
      })
    }
  },
  computed: mapState({
    isLoggedIn (state){
      return !(state.jwt === null);
    },
    isAdmin (state){
      return state.userInfo.admin;
    },
    getToken(state){
      return state.jwt;
    }
  })
}
</script>
<style scoped>
.logoutButton{
  padding-bottom: 1.8em;
  margin-top: .8em;
  height: 2em;
  background-color: steelblue;
  border-color: steelblue;
}
.fontAwesome{
  color: black;
  height: 2em;
  width: 1.6em;
  margin-right: 10px;
  margin-top: 10px;
}
.menu {
  display: flex;
  align-items: center;
  position: fixed;
  background-color: #fff;
  top: 0;
  z-index: 15;
  width: 100%;
  padding-bottom: 1em;
  padding-right: .5em;
  padding-top: .5em;
  justify-content: flex-end;
}
.link-inner {
    display: flex;
    flex-direction: row;
    align-items: center;
}
.menu a {
    color: #fff;
    text-decoration: none;
}
.menuR {
  display: flex;
}
.menu .menuLogo {
color: #fff;
padding: 21px 20px 21px 10px;
}
.overlay i {
  color: #e5e5e5;
  position: absolute;
  right: 0;
  margin-right: 50px;
  margin-top: 40px;
  cursor: pointer;
}
.overlay i:hover {
  color:#a0d7fc;
}
.logo {
  display: flex;
}
ul {
  list-style: none;
}
/*overlay*/
.overlay {
  position: fixed;
  top: 0;
  height: 100vh;
  width: 100vw;
  background: #333;
  overflow: auto;
  z-index: 3;
  opacity: 0.96;
}
.wrap {
  color: #e9e9e9;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
}
.wrap .nav-links {
  list-style: none;
  color: #fff;
  padding: 10px 0;
  text-decoration: none;
  font-size: 25px;
}
.menu .menuLogo:hover {
  color: #e5e5e5;
  cursor: pointer;
}
.nav-links:hover {
  color:#15a6ff;
}
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}

.logs {
  display: none;
}

@media (max-width: 600px){
  .logs {
    display: block;
  }
    .logBtn {
      display: none;
    }
    .menu {
      justify-content: flex-end;
    }
}
</style>
