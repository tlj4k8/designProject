<template>
  <div class="chefSelect">
  <h3> Select Chef </h3>
  <hr/>
    <b-form-group id="chef"
                class="select"
                :label-cols="4"
                breakpoint="md"
                label="Chefs:"
                label-for="chef">
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
        { value: 'chef1', text: 'chef1' },
        { value: 'chef2', text: 'chef2' },
        { value: 'chef3', text: 'chef3' },
        { value: 'chef4', text: 'chef4' },
        { value: 'chef5', text: 'chef5' }
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
.chefSelect{
  padding-top: 5px 0px;
}



</style>