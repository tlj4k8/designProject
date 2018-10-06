<template>
  <div class="employeeSelect">
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
.employeeSelect{
    display: flex;
    justify-content: space-evenly;
}
.select{
    width: 60vw;
}


</style>