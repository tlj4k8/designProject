<template>
  <div class="clientDash">
    <div class="logo">
      <img src="../assets/saltedChefEmployee.jpg" @click="redirect" alt="saltedChefPic"/>
    </div>
    <b-button-group vertical class="dashGroup">
      <b-button to="/clientPage"><b>View Client</b></b-button>
      <b-button v-if="isAdmin=='True'" to="/newclient"><b>Add Client</b></b-button>
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
  methods: {
    redirect(){
      this.$router.push('/dash');
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
.clientDash{
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
  img{
    width: 200px;
    height: 120px;
  }
}
</style>