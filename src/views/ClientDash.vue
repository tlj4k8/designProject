<template>
  <div class="clientDash">
    <h1>Client Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/clients">View Clients</b-button>
        <b-button to="/clientPage">Add Client</b-button>
    </b-button-group>
  </div>
</template>

<script>
import ClientPage from '../views/ClientPage';
import Clients from '../components/Client/Clients';
export default {
  name: "ClientDash",
  components: {
    Clients,
    ClientPage
  }
};
</script>

<style scoped>
.clientDash{
  margin-top: 12em;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>