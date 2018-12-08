<template>
    <div class="addMenu">
    <div class="end">
          <font-awesome-icon @click="help" class="qmark" icon="question"/>
    </div>
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
    <div class="menu">
        <b-form-group id="menuName"
                        label="Name:"
                        label-for="menuName">
            <b-form-input id="menuName"
                        type="text"
                        required
                        maxlength='200'
                        v-model="form.menuName">
            </b-form-input>
        </b-form-group>
        <b-form-group id="ingredients"
                        label="Ingredients:"
                        label-for="ingredients">
            <b-form-textarea id="ingrediants"
                        type="text"
                        :rows="3"
                        :max-rows="6"
                        required
                        maxlength='2000'
                        v-model="form.ingredients">
            </b-form-textarea>
        </b-form-group>
        <b-form-group id="instructions"
                        label="Instructions:"
                        label-for="instructions">
            <b-form-textarea id="instructions"
                        type="text"
                        :rows="3"
                        :max-rows="6"
                        required
                        maxlength='2000'
                        v-model="form.instructions">
            </b-form-textarea>
        </b-form-group>
        <b-form-group id="servings"
                        label="Servings:"
                        label-for="servings">
            <b-form-input id="servings"
                        type="number"
                        required
                        maxlength='10'
                        v-model="form.servings">
            </b-form-input>
        </b-form-group>
        <b-form-group id="time"
                        label="Time:"
                        label-for="time">
            <b-form-input id="time"
                        type="text"
                        required
                        maxlength='200'
                        v-model="form.time">
            </b-form-input>
        </b-form-group>
        <b-form-group id="mealType"
                        label="Meal Type:"
                        label-for="mealType">
            <b-form-input id="mealType"
                        type="text"
                        required
                        maxlength='200'
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
                        required
                        maxlength='400'
                        v-model="form.menuNotes">
            </b-form-textarea>
        </b-form-group>
        </div>
        <div class="submit">
            <b-button type="submit">Submit</b-button>
        </div>
    </b-form>
    <Spinner v-if="loading" />
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
      loading: false

    }
  },
    methods: {
        help(){
            window.open('https://salted-chef.herokuapp.com/#/addMenuHelp', "_blank");
        },
        handleSubmit(form){
            this.loading = true;
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
                this.loading = false;
                this.form.menuName = '',
                this.form.ingredients = '',
                this.form.instructions = '',
                this.form.servings = '',
                this.form.time = '',
                this.form.mealType = '',
                this.form.menuNotes = ''
            })
            .catch((error)=>{
                this.loading = false;
                console.log(error)
            })
        }
    }
}
</script>
<style scoped>
.qmark{
    cursor: pointer;
}
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