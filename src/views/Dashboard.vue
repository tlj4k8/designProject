<template>
  <div class="dashboard">
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

</style>