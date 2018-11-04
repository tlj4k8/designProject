<template> 
    <!-- <div class="bar">    
        <div class="menu">
                <router-link to="/dash" class="flex"><b-button>Dashboard</b-button></router-link>
                <router-link to="/" class="flex"><b-button>Login</b-button></router-link>
        </div>
    </div> -->
  <div>
    <div class="menu">
        <col class="menuLogo"><font-awesome-icon icon="coffee" @click="show = !show" class="fontAwesome"/>
    </div>
    <transition name="fade">
        <div class="overlay" v-if="show" >
	        <div class="wrap">
            <router-link class="nav-links" to="/">Home</router-link>
                <router-link class="nav-links" to="/clientDash">Client</router-link>
                <router-link class="nav-links" to="/menuDash">Menu</router-link>
                <router-link class="nav-links" to="/chefDash">Chef</router-link>
                <router-link class="nav-links" to="/employeeDash">Employee</router-link>
                <router-link class="nav-links" to="/scheduleDash">Schedule</router-link>
		    </div>
	      </div>
    </transition>
  </div>
</template>

<script>
export default {
    name: "NavBar",
    data(){
        return{
            show: false,
        }
    }
}    
</script>

<style scoped>
/* .bar {
    display: flex;
    position: fixed;
    top: 0;
    z-index: 15;
    width: 100vw;
    height: 5em;
    background: #5ad0ed;
    justify-content: flex-end;
}
.menu{
    padding: 20px 20px;
}
.btn{
    background-color: #efefef;
    color: black;
    border-color: #efefef;
}
.flex{
    padding: 5px 5px;
} */
.fontAwesome{
    color: black;
}
.menu {
  display: flex;
  align-items: center;
  position: fixed;
  background-color: #fff;
  top: 0;
  z-index: 15;
  width: 100%;
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
