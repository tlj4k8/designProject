<template>
  <div class="dashboard">
  <h1>Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/clientDash">Client</b-button>
        <b-button to="/menuDash">Menu</b-button>
        <b-button to="/profile">Profile</b-button>
        <b-button v-if="isAdmin=='True'" to="/employeeDash">Employee</b-button>
        <b-button v-if="isAdmin=='True'" to="/scheduleDash">Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>
import { mapState } from 'vuex';
export default {
  name: "Dashboard",
  data(){
    return{
      show: true
    }
  },
  computed: mapState({
    getToken (state){
      return state.jwt;
    },
    isAdmin (state){
      return state.userInfo.admin;
    }
  })
};
</script>

<style scoped>
.dashboard{
  margin-top: 8em;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
  padding-top: 10px;
}

</style>