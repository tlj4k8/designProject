<template>
  <div class="employee">
  <h1>Employee</h1>
    <Person/>
  </div>
</template>

<script>
import Person from '../components/Person';
export default {
  name: "Employee",
  components: {
    Person
  }
};
</script>

<style scoped>
.employee{
  margin-top: 12em;
}
h1{
  text-align: center;
}
</style>