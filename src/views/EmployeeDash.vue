<template>
  <div class="employeeDash">
    <div class="logo">
      <img src="../assets/saltedChefEmployee.jpg" alt="saltedChefPic"/>
    </div>
    <b-button-group vertical class="dashGroup">
      <b-button to="/employee"><b>View Employee</b></b-button>
      <b-button to="/employeeNew"><b>Add Employee</b></b-button>
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
  border-left: none;
  border-right: none;
  border-color: rgba(110, 110, 110, 0.781);
  background-color: rgb(235, 235, 235);
  color: rgb(68, 68, 68);
  padding: 20px 0px;
}
.dashGroup{
  padding-top: 20px;
  width: 80vw;
  margin: 0 10%;
}
.logo{
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}
@media(max-width: 440px){
  .dashGroup{
    width: 100vw;
    margin: 0px 0px;
  }
}
</style>