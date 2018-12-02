<template>
    <div class="addEmpployee">
      <div class="end">
          <font-awesome-icon @click="help" icon="question"/>
      </div>
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
        <h3>Login Credentials</h3>
        <hr/>
        <div class="personflexGroup">
            <b-form-group class="personflex" 
                        id="username"
                        label="Username:"
                        label-for="username">
            <b-form-input class="input" 
                        id="username"
                        type="text"
                        :formatter="format"
                        @input.native="usernameState"
                        :style="{ 'border-color' : usernameValid }"
                        v-model="form.username"
                        maxlength='200'
                        required>
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
                        id="password"
                        label="Password:"
                        label-for="password">
            <b-form-input id="password"
                        type="password"
                        v-model="form.password"
                        maxlength='200'
                        required>
            </b-form-input>
        </b-form-group>
        </div>
      <div class="person">
        <h3>Profile</h3>
        <hr/>
        <div class="personflexGroup">
        <b-form-group class="personflex"
                        id="firstName"
                        label="First Name:"
                        label-for="firstName">
            <b-form-input id="firstName"
                        type="text"
                        v-model="form.firstName"
                        @input.native="firstState"
                        :style="{ 'border-color': firstValid}"
                        maxlength='50'
                        required>
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
                        id="lastName"
                        label="Last Name:"
                        label-for="lastName">
            <b-form-input id="lastName"
                        type="text"
                        v-model="form.lastName"
                        @input.native="lastState"
                        :style="{ 'border-color': lastValid}"
                        maxlength='50'
                        required>
            </b-form-input>
            </b-form-group>
        </div>
        <div class="personflexGroup">
        <b-form-group class="personflex"
                        id="email"
                        label="Email:"
                        label-for="email">
            <b-form-input id="email"
                        type="email"
                        @input.native="emailState"
                        :style="{ 'border-color' : emailValid }"
                        v-model="form.email"
                        maxlength='50'
                        required>
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
                        id="phone"
                        label="Phone:"
                        label-for="phone">
            <b-form-input id="phone"
                        type="tel"
                        v-model="form.phone"
                        @input.native="phoneState"
                        :style="{ 'border-color': phoneValid}"
                        maxlength='15'
                        required>
            </b-form-input>
            </b-form-group>
            </div>
        <b-form-group class="personflex"
                        id="zip"
                        label="Zip Code:"
                        label-for="zip">
            <b-form-input id="zip"
                        type="text"
                        @input.native="zipState"
                        :style="{ 'border-color': zipValid}"
                        v-model="form.zip"
                        placeholder="(i.e. List your zip codes, separated by a comma)"
                        maxlength='400'
                        required>
            </b-form-input>
        </b-form-group>
    </div>
  <div class="needform">
  <h3>Employee Status</h3>
  <hr/>
    <div class="flexGroup">
      <b-form-group id="isMenu"
                    class="flex"
                    label="Menu:"
                    label-for="isMenu">
        <b-form-checkbox id="form.isMenu"
                    type="checkbox"
                    v-on:input="checkType"
                    :disabled="disabledMenu"
                    v-model="form.isMenu"/>
      </b-form-group>
      <b-form-group id="isAdmin"
                    class="flex"
                    label="Admin:"
                    label-for="isAdmin">
        <b-form-checkbox id="form.isAdmin"
                    type="checkbox"
                    v-on:input="checkType"
                    :disabled="disabledAdmin"
                    v-model="form.isAdmin"/>
      </b-form-group>
      <b-form-group id="isChef"
                    class="flex"
                    label="Chef:"
                    label-for="isChef">
        <b-form-checkbox id="form.isChef"
                    type="checkbox"
                    v-on:input="checkType"
                    :disabled="disabledChef"
                    v-model="form.isChef"/>
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
    <div class="submit">
      <b-button type="submit">Submit</b-button>
    </div>
    </b-form>
    <Spinner v-if="loading"/>
    </div>
</template>

<script>
import moment from 'moment';
import axios from 'axios';
import Spinner from './../Spinner';
export default {
  name: "editEmployee",
  components:{
    Spinner
  },
  data() {
    return {
      disabledAdmin: false,
      disabledMenu: false,
      disabledChef: false,
      form: {
        username: '',
        password: '',
        email: '',
        firstName: '',
        lastName: '',
        phone: '',
        zip: '',
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
        isActive: true,
        isMenu: false,
        isChef: false,
        isAdmin: false
      },
      employeeNames: [],
      usernameValid: '',
      emailValid: '',
      zipValid: '',
      firstValid: '',
      lastValid: '',
      phoneValid: '',
      show: true,
      loading: false,
      timeCheck: false
    };
  },
  methods: {
      format (value, event) {
        return value.toLowerCase()
      },
      help(){
        window.open('http://localhost:8080/#/help', "_blank");
      },
      usernameState(){
        this.employeeNames.includes(this.form.username) ? this.usernameValid = 'red' : this.usernameValid = 'lightgreen';
        if(this.form.username === '') { this.usernameValid = ''}
      },
      emailState(){
        let re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        re.test(this.form.email);
        if(this.form.email === ''){ this.emailValid = ''}
        if(!re.test(this.form.email)){this.emailValid = 'red';}else{this.emailValid = 'lightgreen';}
      },
      zipState(){
        let patt = /^\d{5}(?:-\d{4})?(?:,\s*\d{5}(?:-\d{4})?)?()+$/;
        let pattCheck = patt.exec(this.form.zip);
        patt.test(this.form.zip);
        if(this.form.zip === ''){ this.zipValid = ''}
        if(!patt.test(this.form.zip)){this.zipValid = 'red';}else{this.zipValid = 'lightgreen';}
      },
      firstState(){
        let name = /^[a-zA-Z]{3,}(?: [a-zA-Z]+){0,2}$/
        name.test(this.form.firstName);
        if(!name.test(this.form.firstName)){this.firstValid = 'red';}else{this.firstValid = 'lightgreen';}
      },
      lastState(){
        let name = /^[a-zA-Z]{3,}(?: [a-zA-Z]+){0,2}$/
        name.test(this.form.lastName);
        if(!name.test(this.form.lastName)){this.lastValid = 'red';}else{this.lastValid = 'lightgreen';}
      },
      phoneState(){
        let num = /^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/
        num.test(this.form.phone);
        if(!num.test(this.form.phone)){this.phoneValid = 'red';}else{this.phoneValid = 'lightgreen';}
      },
      checkType(){
        if(this.form.isMenu === true ){
          this.disabledAdmin = true;
          this.disabledChef = true;
        }
        else if(this.form.isAdmin === true){
          this.disabledMenu = true;
          this.disabledChef = true;
        }
        else if(this.form.isChef === true){
          this.disabledMenu = true;
          this.disabledAdmin = true;
        }
        else{
          this.disabledAdmin = false;
          this.disabledMenu = false;
          this.disabledChef = false;
        }
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
        if(this.usernameValid === 'lightgreen' && this.firstValid === 'lightgreen' && this.lastValid === 'lightgreen' && this.emailValid === 'lightgreen' && this.phoneValid === 'lightgreen' && this.zipValid === 'lightgreen'){
          this.check();
          if(this.timeCheck == true){
          let token = localStorage.getItem('t');
          let headers = {'Authorization': "Bearer " + token};
          this.$axiosServer.post('https://chefemployees.com/odata/Employees', {
              Username: this.form.username,
              Password: this.form.password,
              EmFirstName: this.form.firstName,
              EmLastName: this.form.lastName,
              EmCellPhone: this.form.phone,
              EmEmail: this.form.email,
              EmZipCodes: this.form.zip,
              EmStartMonday: this.formatTime(this.form.mon),
              EmEndMonday: this.formatTime(this.form.endMon),
              EmStartTuesday: this.formatTime(this.form.tue),
              EmEndTuesday: this.formatTime(this.form.endTue),
              EmStartWednesday: this.formatTime(this.form.wed),
              EmEndWednesday: this.formatTime(this.form.endWed),
              EmStartThursday: this.formatTime(this.form.thur),
              EmEndThursday: this.formatTime(this.form.endThur),
              EmStartFriday: this.formatTime(this.form.fri),
              EmEndFriday: this.formatTime(this.form.endFri),
              EmStartSaturday: this.formatTime(this.form.sat),
              EmEndSaturday: this.formatTime(this.form.endSat),
              EmStartSunday: this.formatTime(this.form.sun),
              EmEndSunday: this.formatTime(this.form.endSun),
              IsMenu: this.form.isMenu,
              IsAdmin: this.form.isAdmin,
              EmIsActive: this.form.IsActive
            },{headers: headers}
          )
          .then((response)=>{
            console.log(response)
            this.form.username = '',
            this.form.password = '',
            this.form.email = '',
            this.form.firstName = '',
            this.form.lastName = '',
            this.form.phone = '', 
            this.form.zip = '',
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
            this.form.endSun = '',
            this.form.isMenu = false,
            this.form.isAdmin = false,
            this.usernameValid = '',
            this.emailValid = '',
            this.zipValid = '',
            this.fisrtValid = '',
            this.lastVAlid = '',
            this .phoneValid = '',
            this.loading = false
            alert('Employee added successfully!');
          })
          .catch((error)=>{
            this.loading = false;
            alert('Error: Issue adding employee. Please try again.');
            console.log(error);
          })
        }else{
          this.loading = false;
        }
      }
      else{
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
      }
  },
  mounted(){
    this.loading = true;
    let token = localStorage.getItem('t');
    axios.get('https://chefemployees.com/odata/Employees', { headers: { 'Authorization': "Bearer " + token }})
    .then((response) => {
      this.employeeNames = response.data.value.map(value => value.Username)
      this.loading = false;
    })
    .catch((error)=>{
      this.loading = false;
      console.log(error);
    })
  }
}
</script>

<style scoped>
hr {
  background-color: #0d50bc;
  height: 1px;
}
.employeeSelect {
  padding-top: 5px 0px;
}
.personflexGroup {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
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
.personflex {
  flex-grow: 1;
  padding: 0 2px;
}
.submit{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
@media (max-width: 440px) {
  .personflexGroup {
    flex-wrap: wrap;
  }
}
</style>