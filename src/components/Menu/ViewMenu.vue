<template>
    <div class="viewMenu">
        <div class="end">
          <font-awesome-icon icon="question"/>
        </div>
        <h3>Select Menu</h3>
        <hr/>
        <div class="menuSelect">
            <b-form-group id="menu"
                        class="select"
                        :label-cols="4"
                        breakpoint="md">
            <b-form-select v-model="selected" v-on:input="getMenus" :options="options" class="mb-1" />
            </b-form-group>
        </div>
        <h3>Menu Info</h3>
        <hr/>
        <b-form ref="form" v-if="show" class="form">
        <div class="menu">
            <b-form-group id="menuName"
                            label="Name:"
                            label-for="menuName">
                <b-form-input id="menuName"
                            type="text"
                            :disabled="disabled"
                            v-model="form.menuName">
                </b-form-input>
            </b-form-group>
            <b-form-group id="ingredients"
                            label="Ingredients:"
                            label-for="ingredients">
                <b-form-input id="ingredients"
                            type="text"
                            :disabled="disabled"
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
                            :disabled="disabled"
                            v-model="form.instructions">
                </b-form-textarea>
            </b-form-group>
            <b-form-group id="servings"
                            label="Servings:"
                            label-for="servings">
                <b-form-input id="servings"
                            type="text"
                            :disabled="disabled"
                            v-model="form.servings">
                </b-form-input>
            </b-form-group>
            <b-form-group id="time"
                            label="Time:"
                            label-for="time">
                <b-form-input id="time"
                            type="text"
                            :disabled="disabled"
                            v-model="form.time">
                </b-form-input>
            </b-form-group>
            <b-form-group id="mealType"
                            label="Meal Type:"
                            label-for="mealType">
                <b-form-input id="mealType"
                            type="text"
                            :disabled="disabled"
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
                            :disabled="disabled"
                            v-model="form.menuNotes">
                </b-form-textarea>
            </b-form-group>
            </div>
        </b-form>
        <div v-if="isAdmin=='True' || isMenu=='True'" class="disabledButtons">
            <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Menu</b-button>
            <b-button class="update" v-if="!disabled" @click="updateMenu">Update Menu</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
        </div>
        <Spinner v-if="loading" />
  </div>
</template>

<script>
import axios from 'axios';
import { mapState } from 'vuex';
import Spinner from './../Spinner';
export default {
    name: 'viewmenu',
    components:{
        Spinner
    },
    data () {
        return {
            disabled: true,
            form: {
                menuName: '',
                ingredients: '',
                instructions: '',
                servings: 0,
                time: '',
                mealType: '',
                menuNotes: ''
            },
            selected: null,
            options: [],
            show: true,
            loading: false
        }
    },
    methods:{
        updateMenu(){
            this.loading = true;
            let token = localStorage.getItem('t');
            let headers = {'Authorization': "Bearer " + token};
            this.$axiosServer.patch('https://chefemployees.com/odata/Menus(' + this.selected + ')', {
                Name: this.form.menuName,
                Ingrendients: this.form.ingredients,
                Instructions: this.form.instructions,
                Servings: this.form.servings,
                Time: this.form.time,
                MealType: this.form.mealType,
                Notes: this.form.menuNotes
            }, {headers: headers}
            )
            .then((response)=>{
                this.disabled = true;
                this.loading = false;
                this.options = [];
                this.updateMenuList();
                alert('Menu updated!');
            })
            .catch((error)=>{
                this.loading = false;
                alert('Issue updating menu, please check your fields.');
                console.log(error)
            })
        },
        updateMenuList(){
            this.loading = true;
            let token = localStorage.getItem('t');
            axios.get('https://chefemployees.com/odata/Menus', { headers: { 'Authorization': "Bearer " + token }})
            .then((response) => {
                response.data.value.forEach((value) => {
                    this.options.push({ value: value.MenuId, text: value.Name })
                })
            this.loading = false;
            })
            .catch((error) => {
                this.loading = false;
                console.log(error);
            })
        }
    },
    computed:{
          ...mapState({
            getToken(state){
                return state.jwt;
            },
            isAdmin (state){
                return state.userInfo.admin;
            },
            isMenu (state){
                return state.userInfo.menu;
            }
        }),
        getMenus(){
            this.loading = true;
            let token = localStorage.getItem('t');
            this.$axiosServer.get('https://chefemployees.com/odata/Menus(' + this.selected + ')', { headers: { 'Authorization': "Bearer " + token }})
            .then((response)=>{
                let menuValue = response.data;
                this.form.menuName = menuValue.Name,
                this.form.ingredients = menuValue.Ingrendients,
                this.form.instructions = menuValue.Instructions,
                this.form.servings = menuValue.Servings,
                this.form.time = menuValue.Time,
                this.form.mealType = menuValue.MealType,
                this.form.menuNotes = menuValue.Notes
                this.loading = false
            })
            .catch((error)=>{
                this.loading = false
                console.log(error)
            })
        }
    },
    mounted(){
        this.loading = true;
        let token = localStorage.getItem('t');
        axios.get('https://chefemployees.com/odata/Menus', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            response.data.value.forEach((value) => {
                this.options.push({ value: value.MenuId, text: value.Name })
            })
            this.loading = false;
        })
        .catch((error) => {
            this.loading = false;
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
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.disabledButtons{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.cancel{
    width: 15%;
    color:white;
    background-color:red;
    border-color: darkred;  
    padding: 7px 2px;
}
.update{
    width: 15%;
    color:white;
    background-color: #0d50bc;
    border-color: darkblue;
    padding: 7px 2px;
}
.disabled{
    width: 15%;
    color:black;
    background-color:white;
    border-color: lightgray;
    padding: 7px 2px;
}
hr{
  background-color: #0d50bc;
  height: 1px;
}
@media (max-width: 440px) {
  .disabledButtons{
      justify-content: center;
  }
  .disabled{
      width: 90%;
  }
  .update{
      width: 60%
  }
  .cancel{
      width: 60%;
  }
}
@media (max-width: 810px) {
  .disabledButtons{
      justify-content: center;
  }
  .disabled{
      width: 90%;
  }
  .update{
      width: 40%
  }
  .cancel{
      width: 40%;
  }
}
</style>