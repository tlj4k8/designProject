<template>
  <div class="clientMenu">
    <h1>Create Client Menu</h1>
    <b-card bg-variant="light" class="card">
    <ClientMenuAdd/>
    </b-card>
  </div>
</template>

<script>
import ClientMenuAdd from "@/components/Menu/ClientMenuAdd.vue";
export default {
  name: "MenuEdit",
  components: {
    ClientMenuAdd
  }
};
</script>

<style scoped>
.clientMenu{
  margin-top: 10em;
}
h1{
  text-align: center;
}
.card{
  margin: 15px 15px;
}

</style>