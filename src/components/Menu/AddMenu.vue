<template>
    <div class="addMenu">
    <div class="end">
          <font-awesome-icon icon="question"/>
    </div>
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
    <div class="menu">
        <b-form-group id="menuName"
                        label="Name:"
                        label-for="menuName">
            <b-form-input id="menuName"
                        type="text"
                        v-model="form.menuName">
            </b-form-input>
        </b-form-group>
        <b-form-group id="ingredients"
                        label="Ingredients:"
                        label-for="ingredients">
            <b-form-input id="ingrediants"
                        type="text"
                        v-model="form.ingredients">
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
                        type="number"
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
        <div class="submit">
            <b-button type="submit">Submit</b-button>
        </div>
    </b-form>
  </div>
</template>

<script>
import axios from 'axios';
import Spinner from './../Spinner';
export default {
  name: 'addmenu',
  components:{
    Spinner
  },
  data () {
    return {
      form: {
        menuName: '',
        ingredients: '',
        instructions: '',
        servings: 0,
        time: '',
        mealType: '',
        menuNotes: ''
      },
      show: true,
    }
  },
    methods: {
        handleSubmit(form){
            let token = localStorage.getItem('t');
            let headers = {'Authorization': "Bearer " + token};
            this.$axiosServer.post('https://chefemployees.com/odata/Menus', {
                Name: this.form.menuName,
                Ingrendients: this.form.ingredients,
                Instructions: this.form.instructions,
                Servings: this.form.servings,
                Time: this.form.time,
                MealType: this.form.mealType,
                Notes: this.form.menuNotes
                },{headers:headers}
            )
            .then((response)=>{
                console.log(response)
            })
            .catch((error)=>{
                console.log(error)
            })
        }
    }
}
</script>
<style scoped>
.menu{
  padding: 0 0;
}
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.submit{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
</style>