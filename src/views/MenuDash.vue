<template>
  <div class="menuDash">
    <h1>Menu Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/menuAdd">View Master Menu</b-button>
        <b-button to="/">Add Master Menu Item</b-button>
    </b-button-group>
  </div>
</template>

<script>
import MenuAdd from '../components/MenuAdd';
export default {
  name: "MenuDash",
  components: {
      MenuAdd
  }
};
</script>

<style scoped>
.menuDash{
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