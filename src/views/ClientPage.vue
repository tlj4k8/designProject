<template>
  <div class="clientPage">
    <h1>Client Page</h1>
    <b-card bg-variant="light" class="card">
      <ViewClient/>
    </b-card>
  </div>
</template>

<script>
import ViewClient from '@/components/Client/ViewClient.vue';
export default {
  name: "ClientPage",
  components: {
    ViewClient
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.clientPage{
  margin-top: 8em;
}
h1{
  text-align: center;
}

</style>