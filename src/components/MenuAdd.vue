<template>
  <div class="menuAdd">
  <h1>Master Menu</h1>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
      <b-form-group id="name"
                    label="Name:"
                    label-for="name">
        <b-form-input id="name"
                      type="text"
                      v-model="form.name">
        </b-form-input>
      </b-form-group>
      <b-form-group id="ingrediants"
                    label="Ingrediants:"
                    label-for="ingrediants">
        <b-form-input id="ingrediants"
                      type="text"
                      v-model="form.ingrediants">
        </b-form-input>
      </b-form-group>
      <b-form-group id="instructions"
                    label="Instructions:"
                    label-for="instructions">
        <b-form-input id="instructions"
                      type="text"
                      v-model="form.instructions">
        </b-form-input>
      </b-form-group>
      <b-form-group id="servings"
                    label="Servings:"
                    label-for="servings">
        <b-form-input id="servings"
                      type="text"
                      v-model="form.servings">
        </b-form-input>
      </b-form-group>
      <b-form-group id="time"
                    label="Time:"
                    label-for="time">
        <b-form-input id="time"
                      type="text"
                      v-model="form.time">
        </b-form-input>
      </b-form-group>
      <b-form-group id="mealType"
                    label="Meal Type:"
                    label-for="mealType">
        <b-form-input id="mealType"
                      type="text"
                      v-model="form.mealType">
        </b-form-input>
      </b-form-group>
      <b-form-group id="menuNotes"
                    label="Other Notes:"
                    label-for="menuNotes">
        <b-form-textarea id="menuNotes"
                      :rows="3"
                      :max-rows="6"
                      type="text"
                      v-model="form.menuNotes">
        </b-form-textarea>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
export default {
  name: 'menuAdd',
  data () {
    return {
      form: {
        name: '',
        ingrediants: '',
        instructions: '',
        servings: '',
        time: '',
        mealType: '',
        menuNotes: ''
      },
      show: true,
    }
  },
  methods: {

  }
}
</script>
<style scoped>
.menuAdd{
    margin-top: 12em;
}
.form{
    padding: 0 15px;
}
h1{
    text-align: center;
}
</style>