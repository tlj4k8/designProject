<template>
  <div class="employeeDash">
  <h1>Employee Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/employee"><b>View Employee</b></b-button>
        <b-button to="/employeeNew"><b>Add New Employee</b></b-button>
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
  margin-top: 8em;
}
.btn-secondary{
  margin-top:10px;
  padding: 20px 0px;
  width: 80vw;
  border-left: none;
  border-right: none;
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
  padding-top: 10px;
}
@media(max-width: 440px){
  .btn-secondary{
    width: 100vw;
  }
  .dashGroup{
    margin: 0 0;
  }
}
</style>