<template>
  <div class="menuDash">
    <h1>Menu Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/menu">View Master Menu</b-button>
        <b-button to="/menuEdit">Add Master Menu Item</b-button>
        <b-button to="/clientMenu">Create Customer Menu</b-button>
    </b-button-group>
  </div>
</template>

<script>
export default {
  name: "MenuDash"
};
</script>

<style scoped>
.menuDash{
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