<template>
  <div class="menuEdit">
    <h1>Menu Page</h1>
    <b-card bg-variant="light" class="card">
    <Menu/>
    </b-card>
  </div>
</template>

<script>
import Menu from "@/components/Menu/Menu.vue";
export default {
  name: "MenuEdit",
  components: {
    Menu
  }
};
</script>

<style scoped>
.menuEdit{
    margin-top: 10em;
}
h1{
  text-align: center;
}
.card{
  margin: 15px 15px;
}

</style>