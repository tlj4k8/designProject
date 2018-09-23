<template>
  <div class="dash">
  <h1>Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/client">Client</b-button>
        <b-button to="/menu">Menu</b-button>
        <b-button to="/chef">Chef</b-button>
        <b-button to="/schedule">Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>

export default {
  name: "DashMenu"

};
</script>

<style scoped>
.dash{
  padding-top: 25px;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}

</style>