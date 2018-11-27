<template>
  <div class="scheduleDash">
    <h1>Schedule Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button v-if="isAdmin=='True' || (isAdmin=='False' && isMenu=='False')" to="/viewSchedule"><b>View Schedule</b></b-button>
        <b-button v-if="isAdmin=='True'" to="/scheduleNew"><b>Add Schedule</b></b-button>
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
    },
    isMenu(state){
      return state.userInfo.admin;
    }
  })
};
</script>

<style scoped>
.scheduleDash{
  margin-top: 8em;
}
.btn-secondary{
  margin-top:10px;
  padding: 20px 0px;
  width: 80vw;
  border-left: none;
  border-right: none;
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
@media(max-width: 440px){
  .btn-secondary{
    width: 100vw;
  }
  .dashGroup{
    margin: 0 0;
  }
}
</style>