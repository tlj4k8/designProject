<template>
  <div class="menuPage">
    <h1>Master Menu</h1>
    <MenuSelect/>
    <Menu/>
  </div>
</template>

<script>
import Menu from '@/components/Menu.vue';
import MenuSelect from '@/components/MenuSelect.vue';
export default {
  name: "MenuPage",
  components: {
    Menu,
    MenuSelect
  }
};
</script>

<style scoped>
.menuPage{
  margin-top: 12em;
}
h1{
  text-align: center;
}

</style>