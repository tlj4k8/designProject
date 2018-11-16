<template>
  <div class="clientDash">
    <h1>Client Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/clientPage">View Clients</b-button>
        <b-button v-if="isAdmin=='True' || isMenu=='True'" to="/newclient">Add Client</b-button>
    </b-button-group>
  </div>
</template>

<script>
import ClientPage from '../views/ClientPage';
import ClientNew from '../views/ClientNew';
import { mapState } from 'vuex';
export default {
  name: "ClientDash",
  components: {
    ClientNew,
    ClientPage
  },
  data(){
    return{
      show: false
    }
  },
  computed: mapState({
    getToken(state){
      return state.jwt;
    },
    isAdmin (state){
      return state.userInfo.admin;
    },
    isMenu (state){
      return state.userInfo.menu;
    }
  })
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