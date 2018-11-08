<template>
  <div class="employeeNew">
  <h1>Add Employee</h1>
  <b-card bg-variant="light" class="card">
    <AddEmployee/>
  </b-card>
  </div>
</template>

<script>
import AddEmployee from '../components/Employee/AddEmployee';
export default {
  name: "Employee",
  components: {
    AddEmployee
  }
};
</script>

<style scoped>
h1{
  text-align:center;
}
.card{
    margin: 15px 15px;
}
.employeeNew{
  margin-top: 8em;
}
</style>