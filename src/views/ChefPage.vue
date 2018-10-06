<template>
  <div class="chef">
    <h1> Chef Portal </h1>
    <b-card bg-variant="light" class="card">
      <Person/>
      <Availability/>
    </b-card>
  </div>
</template>

<script>
import Availability from '../components/Schedule/Availability';
import Person from '../components/Person';
export default {
  name: "ChefPage",
  components: {
    Availability,
    Person
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.chef{
  margin-top: 10em;
}
.buttons{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>