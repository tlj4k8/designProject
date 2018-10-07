<template>
  <div class="zipCode">
  <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
    <div class="flexGroup">
    <b-form-group class="flex" 
                id="zip"
                :label-cols="4"
                breakpoint="md"
                label="Zip Code"
                label-for="zip">
    <b-form-select v-model="selected" :options="options" class="mb-1" />
    </b-form-group>
    <b-form-group class="flex" 
                id="addZip"
                label="New Zip Code"
                label-form="addZip"
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
      selected: null,
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
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>