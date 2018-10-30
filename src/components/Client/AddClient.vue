<template>
  <div class="addClient">
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
      <b-form-group id="grainsAvoid"
                    label="Grains to Avoid:"
                    label-for="grainsAvoid">
        <b-form-input id="grainsAvoid"
                      type="text"
                      v-model="form.grainsAvoid"/>
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
    <b-form-group>
      <b-button type="primary">Submit</b-button>
    </b-form-group>
    </b-form>
    </div>
</template>

<script>
import axios from 'axios';
export default {
  data () {
    return {
      userId:'',
      clientId: '',
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
      state: [
        { text: 'Select One', value: null },
        'AL', 'AK', 'AZ', 'AR','CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'ID', 'IL',
        'IN', 'IA', 'KS', 'KY', 'LA', 'ME', 'MD', 'MA', 'MI', 'MN', 'MO', 'MS', 'MT', 
        'NE', 'NY', 'NV', 'NH', 'NJ', 'NM','NC', 'ND', 'OH', 'OK', 'OR', 'PA', 'RI',
        'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY'
      ],
      show: true
    }
  },
    methods: {
        handleSubmit(form){
          var self = this;
          this.$axiosServer.post('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/People', {
              FirstName: this.form.firstName,
              LastName: this.form.lastName,
              CellPhone: this.form.phone,
              Email: this.form.email,
              Address1: this.form.address,
              Address2: this.form.addressTwo,
              City: this.form.city,
              State: this.form.state,
              ZipCode: this.form.zip,
              IsActive: this.form.isActive
          })
          .then((response) => {
            console.log(response);
            console.log("USER ID:" + response.data.Id);
            this.userId = response.data.Id;
            this.$axiosServer.post('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/Clients',{
              PersonId: this.userId,
              CurrentChefId: 1,
	            ImportantNotes: "I hope this all works"
            })
            .then((response)=>{
              console.log(response);
              console.log("CLIENT ID:" + response.data.Id);
              this.clientId = response.data.Id;
              this.$axiosServer.post('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/Availabilities',{
                PersonId: this.userId,
                StartMonday: this.formatTime(this.form.mon),
                EndMonday: this.formatTime(this.form.endMon),
                StartTuesday: this.formatTime(this.form.tue),
                EndTuesday: this.formatTime(this.form.endTue),
                StartWednesday: this.formatTime(this.form.wed),
                EndWednesday: this.formatTime(this.form.endWed),
                StartThursday: this.formatTime(this.form.thur),
                EndThursday: this.formatTime(this.form.endThur),
                StartFriday: this.formatTime(this.form.fri),
                EndFriday: this.formatTime(this.form.endFri),
                StartSaturday: this.formatTime(this.form.sat),
                EndSaturday: this.formatTime(this.form.endSat),
                StartSunday: this.formatTime(this.form.sun),
                EndSunday: this.formatTime(this.form.endSun)
              })
              .then((response)=>{
              console.log(response);
              console.log("AVAILABILITY ID:" + response.data.Id);
              this.$axiosServer.post('http://saltedchefapi-dev.us-east-2.elasticbeanstalk.com/odata/ClientNeeds', {
                ClientId: this.clientId,
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
                MainDishSoupSaladStew: this.form.mainDish,
                StoreContainers: this.form.storageContainers,
                StoveOven: this.form.stove,
                OrganicMeals: this.form.organic,
                PreferredGroceryStore: this.form.groceryStore,
                MealSize: this.form.mealStructure,
                ExtraNotes: this.form.notes
              })
              .then((response)=>{
                console.log(response);
                console.log("NEEDS ID:" + response.data.Id);
              })
              .catch((error)=>{
                console.log(error)
              })
             })
            })
          })
        },
            formatTime(time){
              var timeStamp = time.split(':');
              var timeHour = timeStamp[0];
              var timeMinutes = timeStamp[1];
              var formatedTime= "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
              return formatedTime;
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
.button{
  margin-left: 25%;
  margin-top: 3.5%;
  width: 25vw;
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
