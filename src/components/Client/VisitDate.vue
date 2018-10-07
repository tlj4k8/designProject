<template>
  <div class="visitDate">
  <h3>Scheduled Visit</h3>
  <hr/>
    <b-form-group id="visit"
                class="select">
    <b-form-select v-model="visit" :options="visitDates" />
    </b-form-group>
  </div>
</template>

<script>

export default {
  name: "VisitDate",
  data () {
    return{
      visit: null,
      visitDates: [
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
</style>