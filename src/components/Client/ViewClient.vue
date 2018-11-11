<template>
  <div class="viewClient">
    <h3>Select Client</h3>
    <hr/>
    <div class="client">
        <b-form-group id="clientList">
            <b-form-select v-model="selected" v-on:input="getClient" :options="option" />
        </b-form-group>
    </div>
    <b-form ref="form"  @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
    <div class= "person">
    <h3>Profile</h3>
    <hr/>
    <div class="flexGroup">
      <b-form-group class="flex"
                    id="firstName"
                    label="First Name:"
                    label-for="firstName">
        <b-form-input id="firstName"
                      type="text"
                      v-model="form.firstName"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group class="flex"
                    id="lastName"
                    label="Last Name:"
                    label-for="lastName">
        <b-form-input id="lastName"
                      type="text"
                      v-model="form.lastName"
                      required>
        </b-form-input>
        </b-form-group>
    </div>
    <div class="flexGroup">
      <b-form-group class="flex"
                    id="email"
                    label="Email:"
                    label-for="email">
        <b-form-input id="email"
                      type="email"
                      v-model="form.email"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group class="flex"
                    id="phone"
                    label="Phone:"
                    label-for="phone">
        <b-form-input id="phone"
                      type="text"
                      v-model="form.phone"
                      pattern="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"
                      required>
        </b-form-input>
        </b-form-group>
        </div>
      <div class="flexGroup">
      <b-form-group class="flex"
                    id="address"
                    label="Address:"
                    label-for="address">
        <b-form-input id="address"
                      type="text"
                      v-model="form.address"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group class="flex"
                    id="addressTwo"
                    label="Address 2:"
                    label-for="addressTwo">
        <b-form-input id="addressTwo"
                      type="text"
                      v-model="form.addressTwo"
                      placeholder="Optional">
        </b-form-input>
      </b-form-group>
      </div>
      <div class="flexGroup">
      <b-form-group class="flex"
                    id="city"
                    label="City:"
                    label-for="city">
        <b-form-input id="city"
                      type="text"
                      v-model="form.city"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group class="flex"
                    id="state"
                    label="State:"
                    label-for="state">
        <b-form-select id="state"
                      :options="state"
                      required
                      v-model="form.state">
        </b-form-select>
      </b-form-group>
      <b-form-group class="flex"
                    id="zip"
                    label="Zip Code:"
                    label-for="zip">
        <b-form-input id="zip"
                      type="text"
                      v-model="form.zip"
                      required>
        </b-form-input>
      </b-form-group>
    </div>
    </div>
    <div class="availability">
    <h3>Availability</h3>
    <hr/>
    <div class="table">
        <table>
            <tr>
                <th></th>
                <th>Mon.</th>
                <th>Tue.</th>
                <th>Wed.</th>
                <th>Thur.</th>
                <th>Fri.</th>
                <th>Sat.</th>
                <th>Sun.</th>
            </tr>
            <tr>
                <td>Start</td>
                <td><b-form-input type="time" v-model="form.mon"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.tue"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.wed"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.thur"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.fri"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.sat"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.sun"></b-form-input></td>
            </tr>
            <tr>
                <td>End</td>
                <td><b-form-input type="time" v-model="form.endMon"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endTue"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endWed"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endThur"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endFri"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endSat"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endSun"></b-form-input></td>
            </tr>
        </table>
    </div>
    </div>
    <div class="needform">
    <h3>Client Need Assessment</h3>
    <hr/>
        <div class="flexGroup">
        <b-form-group id="stove"
                        class="flex"
                        label="Select if Client has a Stove:"
                        label-for="stove">
            <b-form-checkbox id="form.stove"
                        type="checkbox"
                        v-model="form.stove"/>
        </b-form-group>
        <b-form-group id="organic"
                        class="flex"
                        label="Select if Client is Organic:"
                        label-for="organic">
            <b-form-checkbox id="form.organic"
                        type="checkbox"
                        v-model="form.organic"/>
        </b-form-group>
        <b-form-group id="storageContainers"
                        class="flex"
                        label="Select if Client has Storage Containers:"
                        label-for="storageContainers">
            <b-form-checkbox id="form.storageContainers"
                        type="checkbox"
                        v-model="form.storageContainers"/>
        </b-form-group>
        </div>
        <b-form-group id="preferredMeat"
                        label="Preferred Meats:"
                        label-for="preferredMeat">
            <b-form-input id="preferredMeat"
                        type="text"
                        v-model="form.meats"/>
        </b-form-group>
        <b-form-group id="meatAvoid"
                        label="Meats to Avoid:"
                        label-for="meatAvoid">
            <b-form-input id="meatAvoid"
                        type="text"
                        v-model="form.meatAvoid"/>
        </b-form-group>
        <b-form-group id="meatCookPreferrence"
                        label="Meat Cooked Preferrence:"
                        label-for="meatCookPreferrence">
            <b-form-input id="meatCookPreferrence"
                        type="text"
                        v-model="form.meatCookPref"/>
        </b-form-group>
        <b-form-group id="preferredCheeses"
                        label="Preferred Cheeses:"
                        label-for="preferredCheeses">
            <b-form-input id="preferredCheeses"
                        type="text"
                        v-model="form.cheese"/>
        </b-form-group>
        <b-form-group id="cheeseAvoid"
                        label="Cheeses to Avoid:"
                        label-for="cheeseAvoid">
            <b-form-input id="cheeseAvoid"
                        type="text"
                        v-model="form.cheeseAvoid"/>
        </b-form-group>
        <b-form-group id="preferredGrains"
                        label="Preferred Grains:"
                        label-for="preferredGrains">
            <b-form-input id="preferredGrains"
                        type="text"
                        v-model="form.grains"/>
        </b-form-group>
        <b-form-group id="spice"
                        label="Spice Level:"
                        label-for="spice">
            <b-form-input id="spice"
                        type="text"
                        placeholder="ex. (1 - 10)"
                        v-model="form.spice"/>
        </b-form-group>
        <b-form-group id="other"
                        label="Other to Avoid:"
                        label-for="other">
            <b-form-input id="other"
                        type="text"
                        v-model="form.other"/>
        </b-form-group>
        <b-form-group id="allergies"
                        label="Allergies:"
                        label-for="allergies">
            <b-form-input id="allergies"
                        type="text"
                        v-model="form.allergies"/>
        </b-form-group>
        <b-form-group id="dietRestrictions"
                        label="Dietary Restrictions:"
                        label-for="dietRestrictions">
            <b-form-input id="dietRestrictions"
                        type="text"
                        v-model="form.dietRestrictions"/>
        </b-form-group>
        <b-form-group id="dietGoals"
                        label="Dietary Goals:"
                        label-for="dietGoals">
            <b-form-input id="dietGoals"
                        type="text"
                        v-model="form.dietGoals"/>
        </b-form-group>
        <b-form-group id="mainDish"
                        label="Main Dish:"
                        label-for="mainDish">
            <b-form-input id="mainDish"
                        type="text"
                        v-model="form.mainDish"/>
        </b-form-group>
        <b-form-group id="groceryStore"
                        label="Grocery Store:"
                        label-for="groceryStore">
            <b-form-input id="groceryStore"
                        type="text"
                        v-model="form.groceryStore"/>
        </b-form-group>
        <b-form-group id="mealStructure"
                        label="Meal Structure:"
                        label-for="mealStructure">
            <b-form-input id="mealStructure"
                        type="text"
                        v-model="form.mealStructure"/>
        </b-form-group>
        <b-form-group id="notes"
                        label="Other Notes:"
                        label-for="notes">
            <b-form-textarea id="notes"
                        :rows="3"
                        :max-rows="6"
                        type="text"
                        v-model="form.notes"/>
        </b-form-group>
        </div>
    </b-form>
    </div>
</template>

<script>
import axios from 'axios';
import moment from 'moment';
export default {
  data () {
    return {
      form: {
        email: '',
        firstName: '',
        lastName: '',
        phone: '',
        address: '',
        addressTwo: '',
        state: null,
        city: '',
        zip: '',
        meats: '',
        meatAvoid: '',
        meatCookPref: '',
        cheese: '',
        cheeseAvoid: '',
        grains: '',
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
        mealStructure:'',
        notes: '',
        mon: '',
        tue: '',
        wed: '',
        thur: '',
        fri: '',
        sat: '',
        sun: '',
        endMon: '',
        endTue: '',
        endWed: '',
        endThur: '',
        endFri: '',
        endSat: '',
        endSun: ''
      },
        selected: null,
        option: [],
        state: [
        { text: 'Select One', value: null },
        'AL', 'AK', 'AZ', 'AR','CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'ID', 'IL',
        'IN', 'IA', 'KS', 'KY', 'LA', 'ME', 'MD', 'MA', 'MI', 'MN', 'MO', 'MS', 'MT', 
        'NE', 'NY', 'NV', 'NH', 'NJ', 'NM','NC', 'ND', 'OH', 'OK', 'OR', 'PA', 'RI',
        'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY'
        ],
        visit: null,
        visitDates: [
            { value: 'client1', text: 'Client1' },
            { value: 'client2', text: 'client2' },
            { value: 'client3', text: 'client3' },
            { value: 'client4', text: 'client4' },
            { value: 'client5', text: 'client6' }
        ],
        show: true
    }
    },
    methods:{
        formatTime(time){
            let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
            return timeStamp;
        }
    },
    computed: {
        getClient(){
            const client = this.option.indexOf(this.selected);
            this.$axiosServer.get('https://chefemployees.com/odata/Clients')
            .then((response)=>{
                let clientValue = response.data.value[client]
                if(clientValue == null || undefined){
                    this.form.mon = '',
                    this.form.tue = '',
                    this.form.wed = '',
                    this.form.thur = '',
                    this.form.fri = '',
                    this.form.sat = '',
                    this.form.sun = '',
                    this.form.endMon = '',
                    this.form.endTue = '',
                    this.form.endWed = '',
                    this.form.endThur = '',
                    this.form.endFri = '',
                    this.form.endSat = '',
                    this.form.endSun = ''
                }
                this.form.firstName = clientValue.ClFirstName,
                this.form.lastName = clientValue.ClLastName,
                this.form.phone = clientValue.ClCellPhone,
                this.form.email = clientValue.ClEmail,
                this.form.address = clientValue.Address1,
                this.form.addressTwo = clientValue.Address2,
                this.form.city = clientValue.City,
                this.form.state = clientValue.State,
                this.form.zip = clientValue.ZipCode,
                this.form.mon = this.formatTime(clientValue.ClStartMonday),
                this.form.endMon = this.formatTime(clientValue.ClEndMonday),
                this.form.tue = this.formatTime(clientValue.ClStartTuesday),
                this.form.endTue = this.formatTime(clientValue.ClEndTuesday),
                this.form.wed = this.formatTime(clientValue.ClStartWednesday),
                this.form.endWed = this.formatTime(clientValue.ClEndWednesday),
                this.form.thur = this.formatTime(clientValue.ClStartThursday),
                this.form.endThur = this.formatTime(clientValue.ClEndThursday),
                this.form.fri = this.formatTime(clientValue.ClStartFriday),
                this.form.endFri = this.formatTime(clientValue.ClEndFriday),
                this.form.sat = this.formatTime(clientValue.ClStartSaturday),
                this.form.endSat = this.formatTime(clientValue.ClEndSaturday),
                this.form.sun = this.formatTime(clientValue.ClStartSunday),
                this.form.endSun = this.formatTime(clientValue.ClEndSunday),
                this.form.meats = clientValue.PreferredMeats,
                this.form.meatAvoid = clientValue.MeatsToAvoid,
                this.form.cheese = clientValue.PreferredCheeses,
                this.form.cheeseAvoid = clientValue.CheesesToAvoid,
                this.form.grains = clientValue.PreferredGrains,
                this.form.grainsAvoid = clientValue.GrainsToAvoid,
                this.form.spice = clientValue.SpiceLevel,
                this.form.other = clientValue.OtherToAvoid,
                this.form.allergies = clientValue.Allergies,
                this.form.dietRestrictions = clientValue.DietRestrictions,
                this.form.dietGoals = clientValue.DietGoals,
                this.form.mainDish = clientValue.MainDishSoupSaladStew,
                this.form.storageContainers = clientValue.StoreContainers,
                this.form.stove = clientValue.StoveOven,
                this.form.organic = clientValue.OrganicMeals,
                this.form.groceryStore = clientValue.PreferredGroceryStore,
                this.form.mealStructure = clientValue.MealSize,
                this.form.notes = clientValue.ExtraNotes
            })
            .catch((error)=>{
                console.log(error);
            })
        }
    },
    mounted: function(){
        axios.get('https://chefemployees.com/odata/Clients')
        .then((response) => {
            console.log(response);
            this.option = response.data.value.map(value => value.ClientId)
        })
        .catch((error) => {
            console.log(error);
        });
    }
}
</script>
<style scoped>
hr{
    background-color: #0d50bc;
    height: 1px;
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
.table{
    overflow-x:auto;
    padding: 5px 15px;
}
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>
