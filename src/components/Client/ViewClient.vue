<template>
  <div class="viewClient">
    <div class="end">
        <font-awesome-icon @click="help" icon="question"/>
    </div>
    <h3>Select Client</h3>
    <hr/>
    <div class="client">
        <b-form-group id="clientList">
            <b-form-select v-model="selected" v-on:input="getClient" :options="options" />
        </b-form-group>
    </div>
    <b-form ref="form" :model="form" v-if="show" class="form">
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
                      :disabled="disabled"
                      v-model="form.firstName"
                      @input.native="firstState"
                      :style="{ 'border-color': firstValid}"
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
                      :disabled="disabled"
                      v-model="form.lastName"
                      @input.native="lastState"
                      :style="{ 'border-color': lastValid}"
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
                      :disabled="disabled"
                      v-model="form.email"
                      @input.native="emailState"
                      :style="{ 'border-color' : emailValid }"
                      maxlength='50'
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group class="flex"
                    id="phone"
                    label="Phone:"
                    label-for="phone">
        <b-form-input id="phone"
                      type="text"
                      :disabled="disabled"
                      v-model="form.phone"
                      maxlength='15'
                      @input.native="phoneState"
                      :style="{ 'border-color': phoneValid}"
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
                      :disabled="disabled"
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
                      :disabled="disabled"
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
                      :disabled="disabled"
                      v-model="form.city"
                      maxlength='50'
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
                      :disabled="disabled"
                      v-model="form.state">
        </b-form-select>
      </b-form-group>
      <b-form-group class="flex"
                    id="zip"
                    label="Zip Code:"
                    label-for="zip">
        <b-form-input id="zip"
                      type="text"
                      :disabled="disabled"
                      v-model="form.zip"
                      @input.native="zipState"
                      :style="{ 'border-color': zipValid}"
                      maxlength='5'
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
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.mon"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.tue"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.wed"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.thur"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.fri"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.sat"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.sun"></b-form-input></td>
            </tr>
            <tr>
                <td>End</td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endMon"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endTue"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endWed"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endThur"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endFri"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endSat"></b-form-input></td>
                <td><b-form-input class="time" maxlength='7' type="time" :disabled="disabled" v-model="form.endSun"></b-form-input></td>
            </tr>
        </table>
    </div>
    </div>
    <div class="chef">
    <h3>Assigned Chef</h3>
    <hr/>
        <div class="flexGroup">
        <b-form-group id="chef"
                        class="flex"
                        label="Assigned Chef:"
                        label-for="chef">
            <b-form-input id="chef"
                        type="text"
                        :disabled="disabled"
                        v-model="form.chef"/>
        </b-form-group>
        <b-form-group v-if="!disabled" class="flex" id="chefAvailable" label="Available Chef:" label-for="chefAvailable">
            <b-form-select :disabled="disabled" v-model="selectedChef" :options="chefOptions" />
            <b-button  class="menuBtn" @click="updateChef">Reassign Chef</b-button>
        </b-form-group>
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
                        :disabled="disabled"
                        v-model="form.stove"/>
        </b-form-group>
        <b-form-group id="organic"
                        class="flex"
                        label="Select if Client is Organic:"
                        label-for="organic">
            <b-form-checkbox id="form.organic"
                        type="checkbox"
                        :disabled="disabled"
                        v-model="form.organic"/>
        </b-form-group>
        <b-form-group id="storageContainers"
                        class="flex"
                        label="Select if Client has Storage Containers:"
                        label-for="storageContainers">
            <b-form-checkbox id="form.storageContainers"
                        type="checkbox"
                        :disabled="disabled"
                        v-model="form.storageContainers"/>
        </b-form-group>
        </div>
        <div class="flexGroup">
        <b-form-group class="flex" id="preferredMeat"
                        label="Preferred Meats:"
                        label-for="preferredMeat">
            <b-form-input id="preferredMeat"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.meats"/>
        </b-form-group>
        <b-form-group class="flex" id="meatAvoid"
                        label="Meats to Avoid:"
                        label-for="meatAvoid">
            <b-form-input id="meatAvoid"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.meatAvoid"/>
        </b-form-group>
        </div> 
        <div class="flexGroup">
        <b-form-group class="flex" id="meatCookPreferrence"
                        label="Meat Cooked Preferrence:"
                        label-for="meatCookPreferrence">
            <b-form-input id="meatCookPreferrence"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.meatCookPref"/>
        </b-form-group>
        <b-form-group class="flex" id="preferredCheeses"
                        label="Preferred Cheeses:"
                        label-for="preferredCheeses">
            <b-form-input id="preferredCheeses"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.cheese"/>
        </b-form-group>
        </div> 
        <div class="flexGroup">
        <b-form-group class="flex" id="cheeseAvoid"
                        label="Cheeses to Avoid:"
                        label-for="cheeseAvoid">
            <b-form-input id="cheeseAvoid"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.cheeseAvoid"/>
        </b-form-group>
        <b-form-group class="flex" id="preferredGrains"
                        label="Preferred Grains:"
                        label-for="preferredGrains">
            <b-form-input id="preferredGrains"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.grains"/>
        </b-form-group>
        </div> 
        <div class="flexGroup">
        <b-form-group class="flex" id="spice"
                        label="Spice Level:"
                        label-for="spice">
            <b-form-input id="spice"
                        type="text"
                        placeholder="(e.g. 1 - 10)"
                        :disabled="disabled"
                        maxlength='100'
                        v-model="form.spice"/>
        </b-form-group>
        <b-form-group class="flex" id="other"
                        label="Other to Avoid:"
                        label-for="other">
            <b-form-input id="other"
                        type="text"
                        :disabled="disabled"
                        maxlength='300'
                        v-model="form.other"/>
        </b-form-group>
        </div>
        <div class="flexGroup">
        <b-form-group class="flex" id="allergies"
                        label="Allergies:"
                        label-for="allergies">
            <b-form-input id="allergies"
                        type="text"
                        :disabled="disabled"
                        maxlength='300'
                        v-model="form.allergies"/>
        </b-form-group>
        <b-form-group class="flex" id="dietRestrictions"
                        label="Dietary Restrictions:"
                        label-for="dietRestrictions">
            <b-form-input id="dietRestrictions"
                        type="text"
                        :disabled="disabled"
                        maxlength='300'
                        v-model="form.dietRestrictions"/>
        </b-form-group>
        </div>
        <div class="flexGroup">
        <b-form-group class="flex" id="dietGoals"
                        label="Dietary Goals:"
                        label-for="dietGoals">
            <b-form-input id="dietGoals"
                        type="text"
                        :disabled="disabled"
                        maxlength='300'
                        v-model="form.dietGoals"/>
        </b-form-group>
        <b-form-group class="flex" id="mainDish"
                        label="Main Dish:"
                        label-for="mainDish">
            <b-form-input id="mainDish"
                        type="text"
                        :disabled="disabled"
                        maxlength='100'
                        placeholder="(e.g. Soup, Salad, Stew, etc.)"
                        v-model="form.mainDish"/>
        </b-form-group>
        </div>
        <div class="flexGroup">
        <b-form-group class="flex" id="groceryStore"
                        label="Grocery Store:"
                        label-for="groceryStore">
            <b-form-input id="groceryStore"
                        type="text"
                        :disabled="disabled"
                        maxlength='200'
                        v-model="form.groceryStore"/>
        </b-form-group>
        <b-form-group class="flex" id="mealStructure"
                        label="Meal Structure:"
                        label-for="mealStructure">
            <b-form-input id="mealStructure"
                        type="text"
                        :disabled="disabled"
                        maxlength='100'
                        placeholder="(i.e. # of meals per/day)"
                        v-model="form.mealStructure"/>
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
                        maxlength='400'
                        v-model="form.notes"/>
        </b-form-group>
        </div>
        <div v-if="isAdmin=='True'" class="disabledButtons">
        <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Client</b-button>
        <b-button class="update" v-if="!disabled" @click="updateClient">Update Client</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
    </div>
    </b-form>
    <Spinner v-if="loading"/>
    </div>
</template>

<script>
import axios from 'axios';
import moment from 'moment';
import { mapState } from 'vuex';
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
        endSun: '',
        chef: ''
      },
        disabled: true,
        selected: null,
        selectedChef: null,
        chefOptions: [],
        options: [],
        state: [
        { text: 'Select One', value: null },
        'AL', 'AK', 'AZ', 'AR','CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'ID', 'IL',
        'IN', 'IA', 'KS', 'KY', 'LA', 'ME', 'MD', 'MA', 'MI', 'MN', 'MO', 'MS', 'MT', 
        'NE', 'NY', 'NV', 'NH', 'NJ', 'NM','NC', 'ND', 'OH', 'OK', 'OR', 'PA', 'RI',
        'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY'
        ],
        show: true,
        loading: false,
        timeCheck: false,
        emailValid: '',
        zipValid: '',
        firstValid: '',
        lastValid: '',
        phoneValid: '',
        chefId: null,
        employees: [],
        filter: []
        }
    },
    methods:{
        returnTime(time){
            let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
            return timeStamp;
        },
        updateChef(){
            let newChef = this.employees.value.filter((value)=> value.EmployeeId == this.selectedChef);
            this.chefId = newChef[0].EmployeeId;
            this.form.chef = newChef[0].EmFirstName + ' ' + newChef[0].EmLastName;
        },
        help(){
            window.open('http://localhost:8080/#/help', "_blank");
        },
        emailState(){
            let re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            re.test(this.form.email);
            if(this.form.email === ''){ this.emailValid = ''}
            if(!re.test(this.form.email)){this.emailValid = 'red';}else{this.emailValid = 'lightgreen';}
        },
        zipState(){
            let patt = /^\d{5}$/;
            let pattCheck = patt.exec(this.form.zip);
            patt.test(this.form.zip);
            if(this.form.zip === ''){ this.zipValid = ''}
            if(!patt.test(this.form.zip)){this.zipValid = 'red';}else{this.zipValid = 'lightgreen';}
        },
        firstState(){
            let name = /^[a-zA-Z-]{2,}(?: [a-zA-Z]+){0,2}$/
            name.test(this.form.firstName);
            if(!name.test(this.form.firstName)){this.firstValid = 'red';}else{this.firstValid = 'lightgreen';}
        },
        lastState(){
            let name = /^[a-zA-Z-]{2,}(?: [a-zA-Z]+){0,2}$/
            name.test(this.form.lastName);
            if(!name.test(this.form.lastName)){this.lastValid = 'red';}else{this.lastValid = 'lightgreen';}
        },
        phoneState(){
            let num = /^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/
            num.test(this.form.phone);
            if(!num.test(this.form.phone)){this.phoneValid = 'red';}else{this.phoneValid = 'lightgreen';}
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
        formatTime(time){
            let timeStamp = time.split(':');
            let timeHour = timeStamp[0];
            let timeMinutes = timeStamp[1];
            let formatedTime= "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
            if(time === '' || time === 'Invalid date' || time === undefined){
                let formatedTime = "PT00H00M00S";
                return formatedTime;
            }
            return formatedTime;
        },
        updateClient(){
            this.loading = true;
            if((this.firstValid === 'lightgreen' || this.firstValid === '') && (this.lastValid === 'lightgreen' || this.lastValid === '') && (this.emailValid === 'lightgreen' || this.emailValid === '') && (this.phoneValid === 'lightgreen' || this.phoneValid === '') && (this.zipValid === 'lightgreen' || this.zipValid === '')){
                this.check();
                if(this.timeCheck == true){
                let token = localStorage.getItem('t');
                let headers = {'Authorization': "Bearer " + token};
                this.$axiosServer.patch('https://chefemployees.com/odata/Clients(' + this.selected + ')',{
                    ClientId: this.selected,
                    EmployeeId: this.chefId,
                    ClFirstName: this.form.firstName,
                    ClLastName: this.form.lastName,
                    ClCellPhone: this.form.phone,
                    Address1: this.form.address,
                    Address2: this.form.addressTwo,
                    ClEmail: this.form.email,
                    City: this.form.city,
                    State: this.form.state,
                    ZipCode: this.form.zip,
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
                    OtherToAvoid: this.other,
                    Allergies: this.form.allergies,
                    DietRestrictions: this.form.dietRestrictions,
                    DietGoals: this.form.dietGoals,
                    MainDishSoupSaladStew: this.form.mainDish,
                    StoreContainers: this.form.storageContainers,
                    StoveOven: this.form.stove,
                    OrganicMeals: this.form.organic,
                    PreferredGroceryStore: this.form.groceryStore,
                    MealSize: this.form.mealStructure,
                    ExtraNotes: this.form.notes
                    }, {headers: headers}
                )
                .then((response)=>{
                    this.emailValid = ''
                    this.zipValid = ''
                    this.firstValid = ''
                    this.lastValid = ''
                    this.phoneValid = ''
                    this.loading = false;
                    this.disabled = true;
                    alert('Client updated successfully!');
                    this.options = [];
                    this.updateClientList();
                })
                .catch((error)=>{
                    console.log(error);
                    this.loading = false;
                    alert('Error: Client not updated. Check to make sure fields are filled correctly.');
                })
                }else{
                    this.loading = false;
                }
            }else{
                this.loading = false;
                alert('Error: Please check your form for incomplete/incorrect input.');
            }
        },
        updateClientList(){
            this.loading = true;
            let token = localStorage.getItem('t');
            this.$axiosServer.get('https://chefemployees.com/odata/Clients', { headers: { 'Authorization': "Bearer " + token }})
            .then((response) => {
                response.data.value.forEach((value) => {
                    this.options.push({ value: value.ClientId, text: value.ClFirstName + ' ' + value.ClLastName })
                })
                this.loading = false;
            })
            .catch((error) => {
                this.loading = false;
                console.log(error);
            });
        }
    },
    computed: {
        ...mapState({
            getToken(state){
                return state.jwt;
            },
            isAdmin (state){
                return state.userInfo.admin;
            }
        }),
        getClient(){
            this.form.chef = '';
            this.chefId = null;
            this.loading = true;
            let token = localStorage.getItem('t');
            this.$axiosServer.get('https://chefemployees.com/odata/Clients(' + this.selected + ')', { headers: { 'Authorization': "Bearer " + token }})
            .then((response)=>{
                let clientValue = response.data;
                this.chefId = clientValue.EmployeeId,
                this.form.firstName = clientValue.ClFirstName,
                this.form.lastName = clientValue.ClLastName,
                this.form.phone = clientValue.ClCellPhone,
                this.form.email = clientValue.ClEmail,
                this.form.address = clientValue.Address1,
                this.form.addressTwo = clientValue.Address2,
                this.form.city = clientValue.City,
                this.form.state = clientValue.State,
                this.form.zip = clientValue.ZipCode,
                this.form.mon = this.returnTime(clientValue.ClStartMonday),
                this.form.endMon = this.returnTime(clientValue.ClEndMonday),
                this.form.tue = this.returnTime(clientValue.ClStartTuesday),
                this.form.endTue = this.returnTime(clientValue.ClEndTuesday),
                this.form.wed = this.returnTime(clientValue.ClStartWednesday),
                this.form.endWed = this.returnTime(clientValue.ClEndWednesday),
                this.form.thur = this.returnTime(clientValue.ClStartThursday),
                this.form.endThur = this.returnTime(clientValue.ClEndThursday),
                this.form.fri = this.returnTime(clientValue.ClStartFriday),
                this.form.endFri = this.returnTime(clientValue.ClEndFriday),
                this.form.sat = this.returnTime(clientValue.ClStartSaturday),
                this.form.endSat = this.returnTime(clientValue.ClEndSaturday),
                this.form.sun = this.returnTime(clientValue.ClStartSunday),
                this.form.endSun = this.returnTime(clientValue.ClEndSunday),
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
                if(this.chefId != null || this.chefId != undefined){
                    this.filter = this.employees.value.filter((value)=> value.EmployeeId == clientValue.EmployeeId);
                    this.form.chef = this.filter[0].EmFirstName + ' ' + this.filter[0].EmLastName;
                    this.chefId = this.filter[0].EmployeeId;
                    console.log(this.chefId);
                }
                this.$axiosServer.get('https://chefemployees.com/api/EmpClientZip/' + this.selected + '', { headers: { 'Authorization': "Bearer " + token }})
                .then((response)=>{
                    this.loading = false;
                    this.chefOptions = [];
                    response.data.forEach((data) => {
                        this.chefOptions.push({ value: data.EmployeeId, text: data.EmFirstName + ' ' + data.EmLastName });
                    })
                })
                .catch((error)=>{
                    this.loading = false;
                    console.log(error);
                })
            })
            .catch((error)=>{
                this.loading = false;
                console.log(error);
            })
        }
    },
    mounted(){
        this.loading = true;
        let token = localStorage.getItem('t');
        axios.get('https://chefemployees.com/odata/Clients', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            response.data.value.forEach((value) => {
                this.options.push({ value: value.ClientId, text: value.ClFirstName + ' ' + value.ClLastName })
            })
            this.loading = false;
        })
        .catch((error) => {
            this.loading = false;
            console.log(error);
        });
        axios.get('https://chefemployees.com/odata/Employees', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            this.employees = response.data;
            this.loading = false;
        })
        .catch((error) => {
            this.loading = false;
            console.log(error);
        });
    }
}
</script>
<style scoped>
.time{
  width: 125px;
}
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
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.table{
    overflow-x:auto;
    padding: 5px 15px;
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
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
  .disabledButtons{
      justify-content: center;
  }
  .disabled{
      width: 90%;
  }
  .update{
      width: 70%
  }
  .cancel{
      width: 70%;
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
      width: 60%
  }
  .cancel{
      width: 60%;
  }
}
</style>
