<template>
  <div class="zipCode">
  <h3> Zip Radius </h3>
  <hr/>
  <b-form ref="zipForm" @submit.prevent="handleSubmit" :model="zipForm" v-if="show" class="form">
    <div class="flexGroup">
    <b-form-group class="flex"
                id="zip"
                label="Zip Code"
                label-for="zip">
    <b-form-select 
                v-model="zip.selected" 
                :options="options"/>
    </b-form-group>
    <b-form-group class="flex"
                id="zipCode"
                label="Add Zip Code"
                label-for="zipCode">
        <b-form-input
                v-model="zip.zipCode"
                type="text"/>
    </b-form-group>
    </div>
    </b-form>
  </div>
</template>

<script>

export default {
  name: "zipCode",
  data () {
    return{
        zip: {
            selected: null,
            zipCode: ''
        },
        options: [
            { value: 'zip1', text: 'zip1' },
            { value: 'zip2', text: 'zip2' },
            { value: 'zip3', text: 'zip3' },
            { value: 'zip4', text: 'zip4' },
            { value: 'zip5', text: 'zip5' }
        ],
        show: true
    }
  }
};
</script>

<style scoped>
.flexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.flex{
    flex-grow: 1;
    padding: 0 2px;
}
hr{
    background-color: #0d50bc;
    height: 1px;
}
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>