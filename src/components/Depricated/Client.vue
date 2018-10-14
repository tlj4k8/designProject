<template>
  <div class="client">
    <b-form-group id="clientList"
                label="Client Search:"
                label-for="clientList">
    <b-form-select v-model="selected" :options="options"/>
    </b-form-group>
  </div>
</template>

<script>

export default {
  name: "Client",
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



</style>