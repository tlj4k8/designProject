<template>
  <div class="clientPage">
    <h1>Client Page</h1>
    <div class="space">
      <ViewClient/>
    </div>
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
.space{
  margin: 15px 15px;
}
.clientPage{
  margin-top: 8em;
  background-image: url("../../carrots-food-fresh-616404.jpg");
  background-size: cover;
}
h1{
  text-align: center;
}

</style>