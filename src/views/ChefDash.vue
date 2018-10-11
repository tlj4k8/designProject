<template>
  <div class="chefDash">
    <h1>Chef Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/chef">View Chef</b-button>
    </b-button-group>
  </div>
</template>

<script>
export default {
  name: "ChefDash",
  components: {

  }
};
</script>

<style scoped>
.chefDash{
  margin-top: 10em;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>