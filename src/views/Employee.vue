<template>
  <div class="employee">
  <h1>Edit/Add/Delete Employee</h1>
  <b-card bg-variant="light" class="card">
    <EditEmployee/>
  </b-card>
  </div>
</template>

<script>
import EditEmployee from '../components/Employee/EditEmployee';
export default {
  name: "Employee",
  components: {
    EditEmployee
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
.employee{
  margin-top: 8em;
}
</style>