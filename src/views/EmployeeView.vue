<template>
  <div class="employeeView">
  <h1> Employees </h1>
    <div class="employeeTable">
        <b-form-group horizontal label="Search Employee" class="filter">
            <b-input-group>
                <b-form-input v-model="filter" placeholder="Type to Search" />
                <b-input-group-append>
                <b-btn :disabled="!filter" @click="filter = ''">Clear</b-btn>
                </b-input-group-append>
            </b-input-group>
        </b-form-group>
        <b-table
            :fields="fields"
            :items="items"
            :filter="filter"
        >
        </b-table>
        </div>
  </div>
</template>

<script>

export default {
  name: "EmployeeTable",
  data(){
      return {
          field: [
              {key: "employee_id"},
              {key: "first_name"},
              {key: "last_name"}
              ],
          items: [
              {employee_id: 10234, first_name: "Taylor", last_name: "Jackson"},
              {employee_id: 13454, first_name: "Justin", last_name: "Keth"},
              {employee_id: 13456, first_name: "Scooby", last_name: "Doo"},
              {employee_id: 10454, first_name: "Scrappy", last_name: "Keth"}
          ],
          filter: null
      }
  },
  computed: {
        sortOptions () {
        // Create an options list from our fields
        return this.fields
            .filter(f => f.sortable)
            .map(f => { return { text: f.client_id, value: f.key } })
        }
    }
}  
</script>

<style scoped>
.employeeView{
    margin-top: 12em;
}
.filter{
    padding: 10px;
    width: 50%;
}
h1{
    text-align: center;
}


</style>