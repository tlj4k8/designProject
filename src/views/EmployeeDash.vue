<template>
  <div class="employeeDash">
  <h1>Employee Dashboard</h1>
    <b-button-group vertical class="dashGroup">
      <div class="buttons">
        <b-button to="/employee"><b>View Employee</b></b-button>
        <b-button to="/employeeNew"><b>Add New Employee</b></b-button>
      </div>
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
.dashGroup{
  width: 100vw;
  display: flex;
  justify-content: center;
}
.buttons{
  margin-top: 10px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-self: center;    
}
.btn-secondary{
  padding: 20px 0px;
  width: 80vw;
  border-left: none;
  border-top: none;
  border-right: none;
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
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