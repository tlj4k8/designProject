<template> 
  <div v-if="isLoggedIn">
    <div class="menu">
      <div class="chef">
        <img src="../assets/saltedChefEmployee.jpg" @click="redirect" class="chefLogo" alt="saltedChefPic"/><col/>
      </div>
      <div class="chef">
        <div class="chefItem">
          <b-button class="logoutButton" @click="logout"><b>Logout</b></b-button>
          <col class="menuLogo"><font-awesome-icon icon="bars" @click="show = !show" class="fontAwesome"/>
        </div>
      </div>
    </div>
    <transition name="fade">
        <div class="overlay" v-if="show" >
	        <div class="wrap" v-on:click="show = !show">
            <router-link class="nav-links" to="/dash">Home</router-link>
            <router-link class="nav-links" to="/clientDash">Client</router-link>
            <router-link class="nav-links" to="/menuDash">Menu</router-link>
            <router-link class="nav-links" to="/profile">Profile</router-link>
            <router-link v-if="isAdmin=='True'" class="nav-links" to="/employeeDash">Employee</router-link>
            <router-link v-if="isAdmin=='True' || (isAdmin=='False' && isMenu=='False')" class="nav-links" to="/scheduleDash">Schedule</router-link>
            <a class="nav-links" @click="logout">Logout</a>
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
    },
    redirect(){
      this.$router.push('/dash');
    }
  },
  computed: mapState({
    isLoggedIn (state){
      return !(state.jwt === null);
    },
    isAdmin (state){
      return state.userInfo.admin;
    },
    isMenu (state){
      return state.userInfo.menu;
    },
    getToken (state){
      return state.jwt;
    }
  })
}
</script>
<style scoped>
.chefLogo{
  width: 130px;
  margin-left: 10px;
  cursor: pointer;
}
.chefItem{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
.logoutButton{
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
  padding-bottom: 1.8em;
  margin-top: .8em;
  height: 2em;
}
.fontAwesome{
  color: black;
  height: 2em;
  width: 1.6em;
  margin-right: 10px;
  margin-top: 13px;
  cursor: pointer;
}
.menu {
  display: flex;
  align-items: center;
  position: fixed;
  background-color: #fff;
  top: 0;
  z-index: 5;
  width: 100%;
  padding-bottom: 1em;
  padding-right: .5em;
  padding-top: .5em;
  justify-content: space-between;
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
  padding-top: 30px;
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

@media (max-width: 605px){
  .logs {
    display: block;
  }
  .logBtn {
    display: none;
  }
  .chefLogo{
    width: 130px;
    margin-left: 10px;
  }
  .logoutButton{
    visibility: hidden;
  }
}
</style>
