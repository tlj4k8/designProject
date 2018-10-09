<template>
  <div class="chef">
    <h1> Chef Portal </h1>
    <b-card bg-variant="light" class="card">
      <ChefSelect/>
      <Person/>
      <Availability/>
      <ZipCode/>
    </b-card>
  </div>
</template>

<script>
import Availability from '../components/Schedule/Availability';
import Person from '../components/Person';
import ZipCode from '../components/ZipCode';
import ChefSelect from '../components/ChefSelect'
export default {
  name: "ChefPage",
  components: {
    Availability,
    Person,
    ZipCode,
    ChefSelect
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