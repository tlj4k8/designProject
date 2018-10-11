<template>
  <div class="clientNew">
    <h1>New Client</h1>
    <b-card bg-variant="light" class="card">
      <AddClient/>
    </b-card>
  </div>
</template>

<script>
import AddClient from '@/components/Client/AddClient.vue';
export default {
  name: "ClientNew",
  components: {
    AddClient
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.clientNew{
  margin-top: 10em;
}
h1{
  text-align: center;
}

</style>