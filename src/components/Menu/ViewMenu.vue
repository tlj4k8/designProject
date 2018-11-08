<template>
    <div class="viewMenu">
        <div class="menuSelect">
            <b-form-group id="menu"
                        class="select"
                        :label-cols="4"
                        breakpoint="md"
                        label="Menus:"
                        label-for="menu">
            <b-form-select v-model="selected" v-on:input="getMenus" :options="options" class="mb-1" />
            </b-form-group>
        </div>
        <b-form ref="form" v-if="show" class="form">
        <div class="menu">
            <b-form-group id="menuName"
                            label="Name:"
                            label-for="menuName">
                <b-form-input id="menuName"
                            type="text"
                            v-model="form.menuName">
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
        </b-form>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  name: 'viewmenu',
  data () {
    return {
      form: {
        menuName: '',
        ingrediants: '',
        instructions: '',
        servings: 0,
        time: '',
        mealType: '',
        menuNotes: ''
      },
      selected: null,
      options: [],
      show: true,
    }
  },
    computed:{
        getMenus(){
            const menu = this.selected - 1;
            this.$axiosServer.get('https://chefemployees.com/odata/Menus')
            .then((response)=>{
                let menuValue = response.data.value[menu]
                this.form.menuName = menuValue.Name,
                this.form.ingrediants = menuValue.Ingrendients,
                this.form.instructions = menuValue.Instructions,
                this.form.servings = menuValue.Servings,
                this.form.time = menuValue.Time,
                this.form.mealType = menuValue.MealType,
                this.form.menuNotes = menuValue.Notes
            })
            .catch((error)=>{
                console.log(error)
            })
        }
    },
    mounted: function(){
        axios.get('https://chefemployees.com/odata/Menus')
        .then((response) => {
            console.log(response)
            this.options = response.data.value.map(value => value.MenuId)
        })
        .catch((error) => {
            console.log(error);
        })
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