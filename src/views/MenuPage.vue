<template>
  <div class="menuPage">
    <h1>View Master Menu</h1>
    <b-card bg-variant="light" class="card">
    <MenuSelect/>
    <Menu/>
    </b-card>
  </div>
</template>

<script>
import Menu from '@/components/Menu/Menu.vue';
import MenuSelect from '@/components/Menu/MenuSelect.vue';
export default {
  name: "MenuPage",
  components: {
    Menu,
    MenuSelect
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