<template>
  <div class="employeeSelect">
  <h3> Select Chef </h3>
  <hr/>
    <b-form-group id="employee"
                class="select"
                :label-cols="4"
                breakpoint="md"
                label="Employees"
                label-for="employee">
    <b-form-select v-model="selected" :options="options" class="mb-1" />
    </b-form-group>
  </div>
</template>

<script>

export default {
  name: "EmployeeSelect",
  data () {
    return{
      selected: null,
      options: [
        { value: 'client1', text: 'Client1' },
        { value: 'client2', text: 'client2' },
        { value: 'client3', text: 'client3' },
        { value: 'client4', text: 'client4' },
        { value: 'client5', text: 'client6' }
      ]
    }
  }
};
</script>

<style scoped>
hr{
    background-color: #0d50bc;
    height: 1px;
}
.employeeSelect{
  padding-top: 5px 0px;
}



</style>