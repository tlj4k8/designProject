<template>
  <div class="dashboard">
  <h1>Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/clientDash">Client</b-button>
        <b-button to="/menuDash">Menu</b-button>
        <b-button to="/profile">Profile</b-button>
        <b-button v-if="show" to="/employeeDash">Employee</b-button>
        <b-button to="/scheduleDash">Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>
import { mapState } from 'vuex';
import * as decoded from 'jwt-decode';
export default {
  name: "Dashboard",
  data(){
    return{
      show: true,
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
    if(this.employeeInfo.menu === 'False' && this.employeeInfo.admin === 'False'){
      this.show = false
    }
    else if(this.employeeInfo.admin === "True" && this.employeeInfo.menu === "False"){
      this.show = true
    }

  }
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