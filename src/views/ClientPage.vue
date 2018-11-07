<template>
  <div class="clientPage">
    <div class="foodImage">
    <h1>Client Page</h1>
    <div class="space">
      <ViewClient/>
    </div>
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
  margin-top: 5em;
}
.foodImage{
  padding-top: 40px;
  background-image: url("../../carrots-food-fresh-616404.jpg");
  background-attachment: fixed ;
  background-repeat: no-repeat;
  background-size: 100% 100%;
  background-position: center;
}
h1{
  text-align: center;
  color: white;
}

</style>