<template>
  <div class="client">
  <h1> Clients </h1>
  <b-card bg-variant="light" class="card">
    <div class="clientTable">
        <b-form-group horizontal label="Search Client" class="filter">
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
    </b-card>
  </div>
</template>

<script>

export default {
  name: "Clients",
  data(){
      return {
          field: [
              {key: "client_id"},
              {key: "first_name"},
              {key: "last_name"}
              ],
          items: [
              {client_id: 10234, first_name: "Taylor", last_name: "Jackson"},
              {client_id: 13454, first_name: "Justin", last_name: "Keth"},
              {client_id: 13456, first_name: "Scooby", last_name: "Doo"},
              {client_id: 10454, first_name: "Scrappy", last_name: "Keth"}
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
.card{
    margin: 15px 15px;
}
.client{
    margin-top: 10em;
}
.filter{
    padding: 10px;
    width: 50%;
}
h1{
    text-align: center;
}


</style>