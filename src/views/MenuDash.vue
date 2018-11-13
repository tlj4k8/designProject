<template>
  <div class="menuDash">
    <h1>Menu Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/menu">View Master Menu</b-button>
        <b-button v-if="show" to="/menuEdit">Add Master Menu Item</b-button>
        <b-button to="/clientMenu">Create Customer Menu</b-button>
    </b-button-group>
  </div>
</template>

<script>
import * as decoded from 'jwt-decode';
import { mapState } from 'vuex';
export default {
  name: "MenuDash",
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
.menuDash{
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