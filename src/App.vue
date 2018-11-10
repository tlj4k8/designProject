<template>
  <div id="app">
    <NavBar/>
    <router-view/>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar.vue";
import { mapState } from 'vuex';
export default {
  name: 'App',
  components:{
    NavBar
  },
  computed: mapState({
    getToken(state){
      return state.jwt;
    }
  })
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
