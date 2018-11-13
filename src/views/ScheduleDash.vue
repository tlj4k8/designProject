<template>
  <div class="scheduleDash">
    <h1>Menu Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/viewSchedule">View Schedule</b-button>
        <b-button v-if="show" to="/scheduleNew">Add Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>
import * as decoded from 'jwt-decode';
import { mapState } from 'vuex';
export default {
  name: "ScheduleDash",
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
.scheduleDash{
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