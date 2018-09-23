<template>
  <div class="dashboard">
    <h1>Welcome to Salted Chef</h1>
    <DashMenu/>
  </div>
</template>

<script>
import DashMenu from '@/components/DashMenu.vue';
export default {
  name: "Dashboard",
  components: {
    DashMenu
  }
};
</script>

<style scoped>
.dashboard{
    margin-top: 12em;
}
h1{
  text-align: center;
}

</style>