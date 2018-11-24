<template>
  <div class="scheduleDash">
    <h1>Schedule Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button v-if="isAdmin=='True'" to="/viewSchedule">View Schedule</b-button>
        <b-button v-if="isAdmin=='True'" to="/scheduleNew">Add Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>
import { mapState } from 'vuex';
export default {
  name: "ScheduleDash",
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
    }
  })
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