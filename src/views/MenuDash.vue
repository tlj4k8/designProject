<template>
  <div class="menuDash">
    <h1>Menu Dashboard</h1>
    <b-button-group vertical class="dashGroup">
      <div class="buttons">
        <b-button to="/menu"><b>View Master Menu</b></b-button>
        <b-button v-if="isAdmin=='True' || isMenu=='True'" to="/menuEdit"><b>Add Master Menu Item</b></b-button>
        <b-button to="/clientMenu"><b>Create Customer Menu</b></b-button>
      </div>
    </b-button-group>
  </div>
</template>

<script>
import { mapState } from 'vuex';
export default {
  name: "MenuDash",
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
.menuDash{
  margin-top: 8em;
}
.dashGroup{
  width: 100vw;
  display: flex;
  justify-content: center;
}
.buttons{
  margin-top: 10px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-self: center;    
}
.btn-secondary{
  padding: 20px 0px;
  width: 80vw;
  border-left: none;
  border-top: none;
  border-right: none;
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
}
h1{
  text-align: center;
}
@media only screen and (max-width: 480px){
  .btn-secondary{
    width: 100vw;
  }
  .dashGroup{
    margin: 0 0;
  }
}
</style>