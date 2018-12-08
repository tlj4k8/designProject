<template>
  <div class="menuEdit">
    <h1>Add Master Menu</h1>
    <b-card bg-variant="light" class="card">
    <AddMenu/>
    </b-card>
  </div>
</template>

<script>
import AddMenu from "@/components/Menu/AddMenu.vue";
export default {
  name: "MenuEdit",
  components: {
    AddMenu
  }
};
</script>

<style scoped>
.menuEdit {
  margin-top: 8em;
}
h1 {
  text-align: center;
}
.card {
  margin: 15px 15px;
}
</style>