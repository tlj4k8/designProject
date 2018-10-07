<template>
  <div class="employeeDash">
  <h1>Employee</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/employeeView">View Employees</b-button>
        <b-button to="/employee">Add/Modify/Delete Employee</b-button>
    </b-button-group>
  </div>
</template>

<script>
export default {
  name: "EmployeeDash"
};
</script>

<style scoped>
.employeeDash{
  margin-top: 10em;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
  padding-top: 10px;
}

</style>