<template>
  <div class="client">
    <Clients/>
  </div>
</template>

<script>
import Clients from '@/components/Clients.vue';
export default {
  name: "ClientPage",
  components: {
    Clients
  }
};
</script>

<style scoped>
.client{
  margin-top: 12em;
}

</style>