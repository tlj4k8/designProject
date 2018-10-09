<template>
  <div class="clientMenuAdd">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
      <b-form-group id="client"
                    label="Client:"
                    label-for="client">
        <b-form-select
                v-model="form.client" 
                :options="clientOptions"/>
      </b-form-group>
      <b-form-group id="schedule"
                    label="Schedule:"
                    label-for="schedule">
        <b-form-select 
                v-model="form.schedule" 
                :options="scheduleOptions"/>
      </b-form-group>
      <h3> Menu </h3>
      <hr/>
      <MenuSelect/>
      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
import MenuSelect from './MenuSelect';
export default {
  name: 'clientMenu',
  components: {
    MenuSelect
  },
  data () {
    return {
      form: {
        name: '',
        ingrediants: '',
        instructions: '',
        servings: '',
        time: '',
        mealType: '',
        menuNotes: '',
        schedule: null,
        client: null

      },
      show: true,
      scheduleOptions:[
        { value: 'schedule1', text: 'schedule1' },
        { value: 'schedule2', text: 'schedule2' },
      ],
      clientOptions:[
        { value: 'option1', text: 'option1' },
        { value: 'option2', text: 'option2' },
      ]
    }
  },
  methods: {

  }
}
</script>
<style scoped>
.clientMenuAdd{
  padding: 0 0;
}
hr{
    background-color: #0d50bc;
    height: 1px;
}
</style>