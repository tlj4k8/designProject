<template>
  <div class="scheduleDash">
    <div class="logo">
      <img src="../assets/saltedChefEmployee.jpg" alt="saltedChefPic"/>
    </div>
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
  border-left: none;
  border-right: none;
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
  padding: 20px 0px;
}
.dashGroup{
  padding-top: 20px;
  width: 80vw;
  margin: 0 10%;
}
.logo{
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}
@media(max-width: 440px){
  .dashGroup{
    width: 100vw;
    margin: 0px 0px;
  }
}
</style>