<template>
    <div class="clientMenuAdd">
    <div class="end">
          <font-awesome-icon icon="question"/>
    </div>
    <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
    <h3> Select Schedule </h3>
    <hr/>
    <div class="clientMenuAdd">
        <b-form-group id="schedule"
                        label="Schedule:"
                        label-for="schedule">
            <b-form-select 
                    v-on:input="getClientMenusIds"
                    v-model="form.schedule" 
                    :options="scheduleOptions"/>
        </b-form-group>
    </div>
    <h3> Menu </h3>
    <hr/>
    <div class="menuSelection">
      <div class="menuSelect">
          <b-form-group id="menu"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Master Menu Items:"
                      label-for="menu">
              <b-form-select v-model="form.menus" :options="menuOptions" />
          </b-form-group>
          
      </div>
      <div class="menuNotes">
        <b-form-group id="notes"
                  label="Menu Notes:"
                  label-for="notes">
              <b-form-textarea id="notes"
                    :rows="3"
                    :max-rows="6"
                    type="text"
                    v-model="form.notes"/>
        </b-form-group>
      </div>
      <div class="submit">
        <b-button @click="submitMenu">Add Menu Item</b-button>
      </div>
      <div class="menuSelect">
          <b-form-group id="selectedMenus"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Scheduled Menus:"
                      label-for="selectedMenus">
            <b-form-select v-model="form.clientMenus" :options="selectedOptions" />
          </b-form-group>
      </div>
       <div class="submit">
        <b-button class="menuBtn" @click="removeMenu">Remove Menu</b-button>
      </div>
    </div>
    </b-form>
    <b-button @click="showClient = !showClient">Show Client Info </b-button>
    <div class="clientInfo" v-if="showClient">
    <div class="needform">
    <h3>Client Needs Assessment</h3>
    <hr/>
    <div class="flexGroup">
    <b-form-group id="stove"
                    class="flex"
                    label="Select if Client has a Stove:"
                    label-for="stove">
        <b-form-checkbox id="client.stove"
                    type="checkbox"
                    :disabled="disabled"
                    v-model="client.stove"/>
    </b-form-group>
    <b-form-group id="organic"
                    class="flex"
                    label="Select if Client is Organic:"
                    label-for="organic">
        <b-form-checkbox id="client.organic"
                    type="checkbox"
                    :disabled="disabled"
                    v-model="client.organic"/>
    </b-form-group>
    <b-form-group id="storageContainers"
                    class="flex"
                    label="Select if Client has Storage Containers:"
                    label-for="storageContainers">
        <b-form-checkbox id="client.storageContainers"
                    type="checkbox"
                    :disabled="disabled"
                    v-model="client.storageContainers"/>
    </b-form-group>
    </div>
    <div class="flexGroup">
    <b-form-group class="flex" id="preferredMeat"
                    label="Preferred Meats:"
                    label-for="preferredMeat">
        <b-form-input id="preferredMeat"
                    type="text"
                    :disabled="disabled"
                    v-model="client.meats"/>
    </b-form-group>
    <b-form-group class="flex" id="meatAvoid"
                    label="Meats to Avoid:"
                    label-for="meatAvoid">
        <b-form-input id="meatAvoid"
                    type="text"
                    :disabled="disabled"
                    v-model="client.meatAvoid"/>
    </b-form-group>
    </div>
     <div class="flexGroup">
    <b-form-group class="flex" id="meatCookPreferrence"
                    label="Meat Cooked Preferrence:"
                    label-for="meatCookPreferrence">
        <b-form-input id="meatCookPreferrence"
                    type="text"
                    :disabled="disabled"
                    v-model="client.meatCookPref"/>
    </b-form-group>
    <b-form-group class="flex" id="preferredCheeses"
                    label="Preferred Cheeses:"
                    label-for="preferredCheeses">
        <b-form-input id="preferredCheeses"
                    type="text"
                    :disabled="disabled"
                    v-model="client.cheese"/>
    </b-form-group>
    </div>
     <div class="flexGroup">
    <b-form-group class="flex" id="cheeseAvoid"
                    label="Cheeses to Avoid:"
                    label-for="cheeseAvoid">
        <b-form-input id="cheeseAvoid"
                    type="text"
                    :disabled="disabled"
                    v-model="client.cheeseAvoid"/>
    </b-form-group>
    <b-form-group class="flex" id="preferredGrains"
                    label="Preferred Grains:"
                    label-for="preferredGrains">
        <b-form-input id="preferredGrains"
                    type="text"
                    :disabled="disabled"
                    v-model="client.grains"/>
    </b-form-group>
    </div>
     <div class="flexGroup">
    <b-form-group class="flex" id="spice"
                    label="Spice Level:"
                    label-for="spice">
        <b-form-input id="spice"
                    type="text"
                    placeholder="ex. (1 - 10)"
                    :disabled="disabled"
                    v-model="client.spice"/>
    </b-form-group>
    <b-form-group class="flex" id="other"
                    label="Other to Avoid:"
                    label-for="other">
        <b-form-input id="other"
                    type="text"
                    :disabled="disabled"
                    v-model="client.other"/>
    </b-form-group>
    </div>
    <div class="flexGroup">
    <b-form-group class="flex" id="allergies"
                    label="Allergies:"
                    label-for="allergies">
        <b-form-input id="allergies"
                    type="text"
                    :disabled="disabled"
                    v-model="client.allergies"/>
    </b-form-group>
    <b-form-group class="flex" id="dietRestrictions"
                    label="Dietary Restrictions:"
                    label-for="dietRestrictions">
        <b-form-input id="dietRestrictions"
                    type="text"
                    :disabled="disabled"
                    v-model="client.dietRestrictions"/>
    </b-form-group>
    </div>
    <div class="flexGroup">
    <b-form-group class="flex" id="dietGoals"
                    label="Dietary Goals:"
                    label-for="dietGoals">
        <b-form-input id="dietGoals"
                    type="text"
                    :disabled="disabled"
                    v-model="client.dietGoals"/>
    </b-form-group>
    <b-form-group class="flex" id="mainDish"
                    label="Main Dish:"
                    label-for="mainDish">
        <b-form-input id="mainDish"
                    type="text"
                    :disabled="disabled"
                    v-model="client.mainDish"/>
    </b-form-group>
    </div>
    <div class="flexGroup">
    <b-form-group class="flex" id="groceryStore"
                    label="Grocery Store:"
                    label-for="groceryStore">
        <b-form-input id="groceryStore"
                    type="text"
                    :disabled="disabled"
                    v-model="client.groceryStore"/>
    </b-form-group>
    <b-form-group  class="flex" id="mealStructure"
                    label="Meal Structure:"
                    label-for="mealStructure">
        <b-form-input id="mealStructure"
                    type="text"
                    :disabled="disabled"
                    v-model="client.mealStructure"/>
    </b-form-group>
    </div>
    <b-form-group id="notes"
                    label="Other Notes:"
                    label-for="notes">
        <b-form-textarea id="notes"
                    :rows="3"
                    :max-rows="6"
                    type="text"
                    :disabled="disabled"
                    v-model="client.notesClient"/>
    </b-form-group>
    </div>
    </div>
    <Spinner v-if="loading" />
  </div>
</template>

<script>
import axios from 'axios';
import moment from 'moment';
import Spinner from './../Spinner';
export default {
  name: "clientMenuAdd",
  components:{
    Spinner
  },
  data() {
    return {
      form: {
        schedule: null,
        menus: null,
        clientMenus: null,
        selectedMenus: null,
        notes: ''
      },
      client: {
        firstName: '',
        lastName: '',
        meats: '',
        meatsAvoid: '',
        grains: '',
        grainsAvoid: '',
        cheese: '',
        cheeseAvoid: '',
        spice: '',
        other: '',
        allergies: '',
        dietRestrictions: '',
        dietGoals: '',
        mainDish: '',
        storageContainers: false,
        stove: false,
        organic: false,
        groceryStore: '',
        mealStructure: '',
        notesClient: ''
      },
      menuOptions: [],
      clientMenuOptions: [],
      selectedOptions: [],
      scheduleOptions: [],
      showClient: false,
      clientId: null,
      show: true,
      loading: false,
      disabled: true
    };
  },
  methods: {
    returnDate(date){
        let dateStamp = moment(date, 'YYYY-MM-DDTHH:mm:ss.SSS').format('YYYY-MM-DD');
        return dateStamp;
    },
    submitMenu() {
      this.loading = true;
      let token = localStorage.getItem('t');
      let headers = {'Authorization': "Bearer " + token};
      this.$axiosServer.post('https://chefemployees.com/odata/ClientMenus', {
        ScheduleId: this.form.schedule,
        ClientMenuNotes: this.form.notes,
        MenuId: this.form.menus
      },{headers: headers}
      )
      .then((response)=>{
        console.log(response);
        this.selectedOptions = [];
        this.updateScheduledMenus();
        alert('Successfully added to the scheduled menu!');
        this.loading = false;
      })
      .catch((error)=>{
        this.loading = false;
        alert('Issue adding new menu, try again!');
        console.log(error);
      })
    },
    removeMenu(){
      this.loading = true;
      let token = localStorage.getItem('t');
      this.$axiosServer.delete('https://chefemployees.com/odata/ClientMenus(' + this.form.clientMenus + ')', {
        params: {
          ClientMenuId: this.form.clientMenus
        },
        headers: { 'Authorization': "Bearer " + token }
      })
      .then((response)=>{
        this.loading = false;
        alert('Menu item deleted!');
        this.selectedOptions = [];
        this.updateScheduledMenus();
        console.log(response);
      })
      .catch((error)=>{
        this.loading = false;
        alert('Issue deleting menu, try again!');
        console.log(error);
      })
    },
    updateScheduledMenus(){
      this.loading = true;
      let token = localStorage.getItem('t');
      this.$axiosServer.get('https://chefemployees.com/api/ScheduleMenuInfo/' + this.form.schedule + '',{ headers: { 'Authorization': "Bearer " + token }} )
        .then((response)=>{
          response.data.forEach((data) => {
            this.selectedOptions.push({ value: data.ClientMenuId, text: data.MenuName })
          })
          this.loading = false;
      })
      .catch((error)=>{
        this.loading = false;
        console.log(error);
      })
    },
    getClientMenusIds(){
      this.loading = true;
      let token = localStorage.getItem('t');
      this.$axiosServer.get('https://chefemployees.com/api/ScheduleMenuInfo/' + this.form.schedule + '',{ headers: { 'Authorization': "Bearer " + token }} )
      .then((response)=>{
        response.data.forEach((data) => {
          this.selectedOptions.push({ value: data.ClientMenuId, text: data.MenuName })
        })
        this.$axiosServer.get('https://chefemployees.com/odata/Schedules(' + this.form.schedule + ')', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
          this.clientId = response.data.ClientId;
          this.$axiosServer.get('https://chefemployees.com/odata/Clients(' + this.clientId + ')', { headers: { 'Authorization': "Bearer " + token }})
          .then((response) => {
            this.loading = false;
            let clientValue = response.data;
            this.client.firstName = clientValue.ClFirstName,
            this.client.lastname = clientValue.ClLastName,
            this.client.meats = clientValue.PreferredMeats,
            this.client.meatAvoid = clientValue.MeatsToAvoid,
            this.client.cheese = clientValue.PreferredCheeses,
            this.client.cheeseAvoid = clientValue.CheesesToAvoid,
            this.client.grains = clientValue.PreferredGrains,
            this.client.grainsAvoid = clientValue.GrainsToAvoid,
            this.client.spice = clientValue.SpiceLevel,
            this.client.other = clientValue.OtherToAvoid,
            this.client.allergies = clientValue.Allergies,
            this.client.dietRestrictions = clientValue.DietRestrictions,
            this.client.dietGoals = clientValue.DietGoals,
            this.client.mainDish = clientValue.MainDishSoupSaladStew,
            this.client.storageContainers = clientValue.StoreContainers,
            this.client.stove = clientValue.StoveOven,
            this.client.organic = clientValue.OrganicMeals,
            this.client.groceryStore = clientValue.PreferredGroceryStore,
            this.client.mealStructure = clientValue.MealSize,
            this.client.notesClient = clientValue.ExtraNotes
          })
        })
      })
      .catch((error) => {
        this.loading = false;
        console.log(error);
      })
    }
  },
    mounted(){
      this.loading = true;
      let token = localStorage.getItem('t');
      axios.get('https://chefemployees.com/odata/Menus', { headers: { 'Authorization': "Bearer " + token }})
      .then((response) => {
        response.data.value.forEach((value) => {
          this.menuOptions.push({ value: value.MenuId, text: value.Name })
        })
        this.loading = false;
      })
      .catch((error) => {
        this.loading = false;
        console.log(error);
      })
      axios.get('https://chefemployees.com/api/ScheduleEmpClient', { headers: { 'Authorization': "Bearer " + token }})
      .then((response) => {
          response.data.forEach((data) => {
              this.scheduleOptions.push({ value: data.ScheduleId, text: 'Employee:   ' + data.EmFirstName + ' ' + data.EmLastName + ', ' + '   Client:   ' + data.ClFirstName + ' ' + data.ClLastName + ', ' +' Date: ' + this.returnDate(data.ScheduleDate) })
          })
          this.loading = false;
      })
      .catch((error) => {
          this.loading = false;
          console.log(error);
      });
    },
};
</script>
<style scoped>
.clientMenuAdd {
  padding: 0 0;
}
.clientInfo{
  padding-top: 10px;
}
.menuSelect {
  display: flex;
  justify-content: space-evenly;
}
.select {
  width: 100vw;
}
hr{
  background-color: #0d50bc;
  height: 1px;
}
.submit{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.menuBtn{
  padding-top: 10px;
}
.flexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.flex{
    flex-grow: 1;
    padding: 0 2px;
}
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>