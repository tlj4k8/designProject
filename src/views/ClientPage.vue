<template>
  <div class="client">
    <Client/>
  </div>
</template>

<script>
import Client from '@/components/Client.vue';
export default {
  name: "ClientPage",
  components: {
    Client
  }
};
</script>

<style scoped>
.client{
  margin-top: 12em;
}

</style>