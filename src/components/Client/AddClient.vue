<template>
  <div class="addClient">
    <div class="end">
        <font-awesome-icon @click="help" icon="question"/>
    </div>
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
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
                      :state="firstState"
                      maxlength='50'
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
                      :state="lastState"
                      maxlength='50'
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
                      :state="emailState"
                      maxlength='50'
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group class="flex"
                    id="phone"
                    label="Phone:"
                    label-for="phone">
        <b-form-input id="phone"
                      type="tel"
                      v-model="form.phone"
                      maxlength='15'
                      :state="phoneState"
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
                      maxlength='50'
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
                      maxlength='50'
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
                      maxlength='50'
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
                      maxlength='5'
                      :state="checkRegex"
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
            <th>Monday</th>
            <th>Tuesday</th>
            <th>Wednesday</th>
            <th>Thursday</th>
            <th>Friday</th>
            <th>Saturday</th>
            <th>Sunday</th>
          </tr>
          <tr>
              <td>Start</td>
              <td><b-form-input maxlength='7' type="time" v-model="form.mon"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.tue"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.wed"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.thur"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.fri"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.sat"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.sun"></b-form-input></td>
          </tr>
          <tr>
              <td>End</td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endMon"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endTue"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endWed"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endThur"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endFri"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endSat"></b-form-input></td>
              <td><b-form-input maxlength='7' type="time" v-model="form.endSun"></b-form-input></td>
          </tr>
      </table>
  </div>
  </div>
  <div class="needform">
  <h3>Client Needs Assessment</h3>
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
                      maxlength='200'
                      v-model="form.meats"/>
      </b-form-group>
      <b-form-group id="meatAvoid"
                    label="Meats to Avoid:"
                    label-for="meatAvoid">
        <b-form-input id="meatAvoid"
                      type="text"
                      maxlength='200'
                      v-model="form.meatAvoid"/>
      </b-form-group>
      <b-form-group id="preferredCheeses"
                    label="Preferred Cheeses:"
                    label-for="preferredCheeses">
        <b-form-input id="preferredCheeses"
                      type="text"
                      maxlength='200'
                      v-model="form.cheese"/>
      </b-form-group>
      <b-form-group id="cheeseAvoid"
                    label="Cheeses to Avoid:"
                    label-for="cheeseAvoid">
        <b-form-input id="cheeseAvoid"
                      type="text"
                      maxlength='200'
                      v-model="form.cheeseAvoid"/>
      </b-form-group>
      <b-form-group id="preferredGrains"
                    label="Preferred Grains:"
                    label-for="preferredGrains">
        <b-form-input id="preferredGrains"
                      type="text"
                      maxlength='200'
                      v-model="form.grains"/>
      </b-form-group>
      <b-form-group id="grainsAvoid"
                    label="Grains to Avoid:"
                    label-for="grainsAvoid">
        <b-form-input id="grainsAvoid"
                      type="text"
                      maxlength='200'
                      v-model="form.grainsAvoid"/>
      </b-form-group>
      <b-form-group id="spice"
                    label="Spice Level:"
                    label-for="spice">
        <b-form-input id="spice"
                      type="text"
                      placeholder="(e.g. 1 - 10)"
                      maxlength='100'
                      v-model="form.spice"/>
      </b-form-group>
      <b-form-group id="other"
                    label="Other to Avoid:"
                    label-for="other">
        <b-form-input id="other"
                      type="text"
                      maxlength='300'
                      v-model="form.other"/>
      </b-form-group>
      <b-form-group id="allergies"
                    label="Allergies:"
                    label-for="allergies">
        <b-form-input id="allergies"
                      type="text"
                      maxlength='300'
                      v-model="form.allergies"/>
      </b-form-group>
      <b-form-group id="dietRestrictions"
                    label="Dietary Restrictions:"
                    label-for="dietRestrictions">
        <b-form-input id="dietRestrictions"
                      type="text"
                      maxlength='300'
                      v-model="form.dietRestrictions"/>
      </b-form-group>
      <b-form-group id="dietGoals"
                    label="Diet Goals:"
                    label-for="dietGoals">
        <b-form-input id="dietGoals"
                      type="text"
                      maxlength='300'
                      v-model="form.dietGoals"/>
      </b-form-group>
      <b-form-group id="mainDish"
                    label="Main Dish:"
                    label-for="mainDish">
        <b-form-input id="mainDish"
                      type="text"
                      maxlength='100'
                      placeholder="(e.g. Soup, Salad, Stew, etc.)"
                      v-model="form.mainDish"/>
      </b-form-group>
      <b-form-group id="groceryStore"
                    label="Grocery Store:"
                    label-for="groceryStore">
        <b-form-input id="groceryStore"
                      type="text"
                      maxlength='200'
                      v-model="form.groceryStore"/>
      </b-form-group>
      <b-form-group id="mealStructure"
                    label="Meal Structure:"
                    label-for="mealStructure">
        <b-form-input id="mealStructure"
                      type="text"
                      maxlength='100'
                      placeholder="(i.e. # of meals per/day)"
                      v-model="form.mealStructure"/>
      </b-form-group>
      <b-form-group id="notes"
                    label="Other Notes:"
                    label-for="notes">
        <b-form-textarea id="notes"
                      :rows="3"
                      :max-rows="6"
                      type="text"
                      maxlength='400'
                      v-model="form.notes"/>
      </b-form-group>
    </div>
    <b-form-group>
      <div class="submit">
        <b-button type="submit">Submit</b-button>
      </div>
    </b-form-group>
    </b-form>
    <Spinner v-if="loading"/>
    </div>
</template>

<script>
import axios from 'axios';
import Spinner from './../Spinner';
export default {
  components:{
    Spinner
  },
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
        isActive: true,
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
      options: [],
      chefFiltered: [],
      state: [
        { text: 'Select One', value: null },
        'AL', 'AK', 'AZ', 'AR','CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'ID', 'IL',
        'IN', 'IA', 'KS', 'KY', 'LA', 'ME', 'MD', 'MA', 'MI', 'MN', 'MO', 'MS', 'MT', 
        'NE', 'NY', 'NV', 'NH', 'NJ', 'NM','NC', 'ND', 'OH', 'OK', 'OR', 'PA', 'RI',
        'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY'
      ],
      show: true,
      loading: false,
      timeCheck: false
    }
  },
    methods: {
      help(){
          window.open('http://localhost:8080/#/help', "_blank");
      },
      check(){
        if((this.form.endMon >= this.form.mon) && (this.form.endTue >= this.form.tue) && (this.form.endWed >= this.form.wed)
        && (this.form.endThur >= this.form.thur) && (this.form.endFri >= this.form.fri) 
        && (this.form.endSat >= this.form.sat) && (this.form.endSun >= this.form.sun))
        {
          this.timeCheck = true;
        }else{
          alert('Error: Please check that availability end times are after start times');
          this.timeCheck = false;
        }
      },
      handleSubmit(form){
        this.loading = true;
        if(this.lastState == true && this.firstState == true && this.phoneState == true && this.emailState == true && this.checkRegex == true){
          this.check();
          if(this.timeCheck == true){
            let token = localStorage.getItem('t');
            let headers = {'Authorization': "Bearer " + token};
            this.$axiosServer.post('https://chefemployees.com/odata/Clients', {
              EmployeeId: this.selected,
              ClFirstName: this.form.firstName,
              ClLastName: this.form.lastName,
              ClCellPhone: this.form.phone,
              ClEmail: this.form.email,
              Address1: this.form.address,
              Address2: this.form.addressTwo,
              City: this.form.city,
              State: this.form.state,
              ZipCode: this.form.zip,
              ClIsActive: this.form.isActive,
              ClStartMonday: this.formatTime(this.form.mon),
              ClEndMonday: this.formatTime(this.form.endMon),
              ClStartTuesday: this.formatTime(this.form.tue),
              ClEndTuesday: this.formatTime(this.form.endTue),
              ClStartWednesday: this.formatTime(this.form.wed),
              ClEndWednesday: this.formatTime(this.form.endWed),
              ClStartThursday: this.formatTime(this.form.thur),
              ClEndThursday: this.formatTime(this.form.endThur),
              ClStartFriday: this.formatTime(this.form.fri),
              ClEndFriday: this.formatTime(this.form.endFri),
              ClStartSaturday: this.formatTime(this.form.sat),
              ClEndSaturday: this.formatTime(this.form.endSat),
              ClStartSunday: this.formatTime(this.form.sun),
              ClEndSunday: this.formatTime(this.form.endSun),
              PreferredMeats: this.form.meats,
              MeatsToAvoid: this.form.meatAvoid,
              PreferredCheeses: this.form.cheese,
              CheesesToAvoid: this.form.cheeseAvoid,
              PreferredGrains: this.form.grains,
              GrainsToAvoid: this.form.grainsAvoid,
              SpiceLevel: this.form.spice,
              OtherToAvoid: this.form.other,
              Allergies: this.form.allergies,
              DietRestrictions: this.form.dietRestrictions,
              DietGoals: this.form.dietGoals,
              MainDishSoupSaladStew: this.form.mainDish,
              StoreContainers: this.form.storageContainers,
              StoveOven: this.form.stove,
              OrganicMeals: this.form.organic,
              PreferredGroceryStore: this.form.groceryStore,
              MealSize: this.form.mealStructure,
              ExtraNotes: this.form.notes,
              }, {headers: headers}
            )
            .then((response)=>{
              this.loading = false,
              alert(this.form.firstName + ' ' + this.form.lastName + 'successfully added to clients!');
              this.selected = null,
              this.form.firstName = '',
              this.form.lastName = '',
              this.form.phone = '',
              this.form.email = '',
              this.form.address = '',
              this.form.addressTwo = '',
              this.form.city = '',
              this.form.state = '',
              this.form.zip = '',
              this.form.meats = '',
              this.form.meatAvoid = '',
              this.form.cheese = '',
              this.form.cheeseAvoid = '',
              this.form.grains = '',
              this.form.grainsAvoid = '',
              this.form.spice = '',
              this.form.other = '',
              this.form.allergies = '',
              this.form.dietRestrictions = '',
              this.form.dietGoals = '',
              this.form.mainDish = '',
              this.form.storageContainers = '',
              this.form.stove = '',
              this.form.organic = '',
              this.form.groceryStore = '',
              this.form.mealStructure = '',
              this.form.notes = '',
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
            })
            .catch((error)=>{
              this.loading = false;
              alert('Error: Please check to make sure the fields were filled out correctly.')
              console.log(error);
            })
          }else{
            this.loading = false;
          }
        }else{
          this.loading = false;
          alert('Error: Please check your form for incomplete/incorrect input.');
        }
      },
      formatTime(time){
        let timeStamp = time.split(':');
        let timeHour = timeStamp[0];
        let timeMinutes = timeStamp[1];
        let formatedTime= "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
        if(time === '' || 'Invalid date' || undefined){
          let formatedTime = "PT00H00M00S";
          return formatedTime;
        }
        return formatedTime;
      },
    },
    computed: {
      emailState(){
          let re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return re.test(this.form.email);
          if(re.test(this.form.email)){
              return true;
          }else{
              return false;
          }
      },
      checkRegex(){
          let patt = /^\d{5}$/;
          let pattCheck = patt.exec(this.form.zip);
          patt.test(this.form.zip);
          if(patt.test(this.form.zip)){
              return true;
          }else{
              return false;
          }
      },
      firstState(){
          let name = /^[a-zA-Z]{3,}(?: [a-zA-Z]+){0,2}$/
          return name.test(this.form.firstName);
          if(name.test(this.form.firstName)){
              return true;
          }else{
              return false;
          }
      },
      lastState(){
          let name = /^[a-zA-Z]{3,}(?: [a-zA-Z]+){0,2}$/
          return name.test(this.form.lastName);
          if(name.test(this.form.lastName)){
              return true;
          }else{
              return false;
          }
      },
      phoneState(){
          let num = /^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/
          return num.test(this.form.phone);
          if(num.test(this.form.phone)){
              return true;
          }else{
              return false;
          }
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
.scheduleFlexGroup{
    display: flex;
    flex-direction: row;
}
.scheduleFlex{
    flex-grow: 1;
    padding: 0 2px;
}
.table{
    overflow-x:auto;
    padding: 5px 15px;
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
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>
