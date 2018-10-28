<template>
  <div class="viewClient">
  <div class="client">
    <b-form-group id="clientList"
                label="Client Search:"
                label-for="clientList">
        <b-form-select v-on:select="checkSelected" v-model="selected" :options="option" />
    </b-form-group>
  </div>
    <!-- <b-button v-if="!update" @click="update=true" type="primary">Update Client</b-button>
    <b-button v-if="update" @click="alert('updated')" type="primary">Save</b-button> -->
    <b-form ref="form" :disabled="!update" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
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
    <div class="visitDate">
    <h3>Scheduled Visit</h3>
    <hr/>
        <b-form-group id="visit"
                    class="select">
        <b-form-select v-model="visit" :options="visitDates" />
        </b-form-group>
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
        <b-button type="submit" variant="primary">Submit</b-button>
        <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
    </div>
</template>

<script>
import axios from 'axios';
import moment from 'moment';
export default {
  data () {
    return {
      update: false,
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
        cheese: '',
        cheeseAvoid: '',
        grains: '',
        grainsAvoid: '',
        spice: '',
        other: '',
        allergies: '',
        dietRestrictions: '',
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
    computed:{   
        checkSelected() {                                                                    
            console.log(this.selected);
            var clientValue = this.selected - 1;
            axios.get('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/People')
            .then((response)=>{
                this.form.firstName = response.data.value[clientValue].FirstName,
                this.form.lastName = response.data.value[clientValue].LastName,
                this.form.email = response.data.value[clientValue].Email,
                this.form.phone = response.data.value[clientValue].CellPhone,
                this.form.address = response.data.value[clientValue].Address1,
                this.form.addressTwo = response.data.value[clientValue].Address2,
                this.form.state = response.data.value[clientValue].State,
                this.form.city = response.data.value[clientValue].City,
                this.form.zip = response.data.value[clientValue].ZipCode
                axios.get('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/Availabilities')
                .then((response)=>{
                    console.log(response)
                    var clientTime = response.data.value[clientValue];
                    if(clientTime == null || undefined){
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
                    this.form.mon = this.formatTime(clientTime.StartMonday)
                    this.form.tue = this.formatTime(clientTime.StartTuesday)
                    this.form.wed = this.formatTime(clientTime.StartWednesday)
                    this.form.thur = this.formatTime(clientTime.StartThursday)
                    this.form.fri = this.formatTime(clientTime.StartFriday)
                    this.form.sat = this.formatTime(clientTime.StartSaturday)
                    this.form.sun = this.formatTime(clientTime.StartSunday)
                    this.form.endMon = this.formatTime(clientTime.EndMonday)
                    this.form.endTue = this.formatTime(clientTime.EndTuesday)
                    this.form.endWed = this.formatTime(clientTime.EndWednesday)
                    this.form.endThur = this.formatTime(clientTime.EndThursday)
                    this.form.endFri = this.formatTime(clientTime.EndFriday)
                    this.form.endSat = this.formatTime(clientTime.EndSaturday)
                    this.form.endSun = this.formatTime(clientTime.EndSunday)
                    axios.get('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/ClientNeeds')
                    .then((response)=>{
                        var clientMealResponse = response.data.value[clientValue];
                        if(clientMealResponse == null || undefined){
                            this.form.meats = ''
                            this.form.meatAvoid = ''
                            this.form.cheese = ''
                            this.form.cheeseAvoid = ''
                            this.form.grains = ''
                            this.form.grainsAvoid = ''
                            this.form.spice = ''
                            this.form.other = ''
                            this.form.allergies = ''
                            this.form.dietRestrictions = ''
                            this.form.mainDish = ''
                            this.form.storageContainers = ''
                            this.form.stove = ''
                            this.form.organic = ''
                            this.form.groceryStore = ''
                            this.form.mealStructure = ''
                            this.form.notes = ''
                        }
                        console.log(response.data.value[clientValue])
                        this.form.meats = clientMealResponse.PreferredMeats
                        this.form.meatAvoid = clientMealResponse.MeatsToAvoid
                        this.form.cheese = clientMealResponse.PreferredCheeses
                        this.form.cheeseAvoid = clientMealResponse.CheesesToAvoid
                        this.form.grains = clientMealResponse.PreferredGrains
                        this.form.grainsAvoid = clientMealResponse.GrainsToAvoid
                        this.form.spice = clientMealResponse.SpiceLevel
                        this.form.other = clientMealResponse.OtherToAvoid
                        this.form.allergies = clientMealResponse.Allergies
                        this.form.dietRestrictions = clientMealResponse.DietRestrictions
                        this.form.mainDish = clientMealResponse.MainDishSoupSaladStew
                        this.form.storageContainers = clientMealResponse.StoreContainers
                        this.form.stove = clientMealResponse.StoveOven
                        this.form.organic = clientMealResponse.OrganicMeals
                        this.form.groceryStore = clientMealResponse.PreferredGroceryStore
                        this.form.mealStructure = clientMealResponse.MealSize
                        this.form.notes = clientMealResponse.ExtraNotes
                        
                    })
                })
                .catch((error)=>{
                    console.log(error)
                })
            })
            .catch((error)=>{
                console.log(error);
            })

        }
    },
    mounted: function(){
        axios.get('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/People')
        .then((response) => {
            console.log(response);
            this.option = response.data.value.map(value => (
                // "Client #: " + value.Id + " " + value.FirstName + " " + value.LastName
                value.Id
            ))
        })
        .catch((error) => {
            console.log(error);
        });
    },
    methods:{
        formatTime(time){
            var timeStamp = moment(time, moment.HTML5_FMT.TIME).format('HH:mm');
            return timeStamp;
        }

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
