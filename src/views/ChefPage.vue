<template>
  <div class="chef">
    <h1> Chef Portal </h1>
    <div>
      <Person/>
      <Availability/>
      <Receipt/>
    </div>
  </div>
</template>

<script>
import Availability from '../components/Availability';
import Person from '../components/Person';
import Receipt from '../components/Receipt';
export default {
  name: "ChefPage",
  components: {
    Availability,
    Person,
    Receipt
  }
};
</script>

<style scoped>
.chef{
  margin-top: 12em;
}
.buttons{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>