<template>
  <div class="menuSelect">
    <b-form-group id="menu"
                class="select"
                :label-cols="4"
                breakpoint="md"
                label="Menus:"
                label-for="menu">
    <b-form-select v-model="selected" :options="options" class="mb-1" />
    </b-form-group>
  </div>
</template>

<script>

export default {
  name: "MenuSelect",
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
.menuSelect{
    display: flex;
    justify-content: space-evenly;
}
.select{
    width: 100vw;
}


</style>