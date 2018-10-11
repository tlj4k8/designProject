<template>
  <div class="menuPage">
    <h1>View Master Menu</h1>
    <b-card bg-variant="light" class="card">
      <ViewMenu/>
    </b-card>
  </div>
</template>

<script>
import ViewMenu from '@/components/Menu/ViewMenu.vue'
export default {
  name: "MenuPage",
  components: {
    ViewMenu
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.menuPage{
  margin-top: 10em;
}
h1{
  text-align: center;
}

</style>