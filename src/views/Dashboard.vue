<template>
  <div class="dashboard">
  <h1>Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/clientDash">Client</b-button>
        <b-button to="/menuDash">Menu</b-button>
        <b-button to="/chefDash">Chef</b-button>
        <b-button to="/employeeDash">Employee</b-button>
        <b-button to="/scheduleDash">Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>
export default {
  name: "Dashboard"
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