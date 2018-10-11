<template>
    <div class="viewMenu">
    <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
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
    <div class="menu">
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
            <b-form-textarea id="instructions"
                        type="text"
                        :rows="3"
                        :max-rows="6"
                        v-model="form.instructions">
            </b-form-textarea>
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
        </div>
    <b-button type="submit" variant="primary">Submit</b-button>
    <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
export default {
  name: 'menu',
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
      selected: null,
      options: [
        { value: 'client1', text: 'Client1' },
        { value: 'client2', text: 'client2' },
        { value: 'client3', text: 'client3' },
        { value: 'client4', text: 'client4' },
        { value: 'client5', text: 'client6' }
      ],
      show: true,
    }
  },
    methods: {
        handleSubmit: function(form){
            var self = this;
            this.$ref[form].validate((valid => {
                if(valid){
                    //http request goes here
                }
                else{
                    this.emptyFields();
                    return false;
                }
            }))
        },
        emptyFields() {
            this.$alert("Please complete all required fields", "Registration failed", {
            confirmButtonText: 'OK'
            });
        }
    }
}
</script>
<style scoped>
.menu{
  padding: 0 0;
}
.menuSelect{
    display: flex;
    justify-content: space-evenly;
}
.select{
    width: 100vw;
}
</style>