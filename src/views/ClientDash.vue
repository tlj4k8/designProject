<template>
  <div class="clientDash">
    <h1>Client Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/clientPage">View Clients</b-button>
        <b-button v-if="show" to="/newclient">Add Client</b-button>
    </b-button-group>
  </div>
</template>

<script>
import ClientPage from '../views/ClientPage';
import ClientNew from '../views/ClientNew';
import * as decoded from 'jwt-decode';
import { mapState } from 'vuex';
export default {
  name: "ClientDash",
  components: {
    ClientNew,
    ClientPage
  },
  data(){
    return{
      show: false,
      employeeInfo: {}
    }
  },
  computed: mapState({
    getToken(state){
      return state.jwt;
    }
  }),
  mounted: function(){
    let token = localStorage.getItem('t');
    this.$store.dispatch('storeUserInfo',token);
    this.employeeInfo = decoded(token)
    if(this.employeeInfo.menu === 'True' || this.employeeInfo.admin === 'True'){this.show = true}
  }
};
</script>

<style scoped>
.clientDash{
  margin-top: 8em;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>