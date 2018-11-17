<template>
    <div class="addEmpployee">
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
                        v-on:input.native="checkName"
                        v-bind:style="{ 'border-color' : valid }"
                        v-model="form.username">
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
                        id="password"
                        label="Password:"
                        label-for="password">
            <b-form-input id="password"
                        type="password"
                        v-model="form.password">
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
                        v-model="form.email"
                        required>
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
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
        <b-form-group class="personflex"
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
  <div class="needform">
  <h3>Employee Status</h3>
  <hr/>
    <div class="flexGroup">
      <b-form-group id="isMenu"
                    class="flex"
                    label="Menu Team:"
                    label-for="isMenu">
        <b-form-checkbox id="form.isMenu"
                    type="checkbox"
                    v-model="form.isMenu"/>
      </b-form-group>
      <b-form-group id="isAdmin"
                    class="flex"
                    label="Admin Team:"
                    label-for="isAdmin">
        <b-form-checkbox id="form.isAdmin"
                    type="checkbox"
                    v-model="form.isAdmin"/>
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
    <div class="submit">
      <b-button type="submit">Submit</b-button>
    </div>
    </b-form>
    </div>
</template>

<script>
import moment from 'moment';
import axios from 'axios';
export default {
  name: "editEmployee",
  data() {
    return {
      disabled: true,
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
        isAdmin: false
      },
      employeeNames: [],
      valid: '', 
      state: [
        { text: 'Select One', value: null },
        'AL', 'AK', 'AZ', 'AR','CA','CO','CT','DE','FL','GA','HI','ID','IL','IN','IA','KS',
        'KY','LA','ME','MD','MA','MI','MN','MO','MS','MT','NE','NY','NV','NH','NJ','NM','NC',
        'ND','OH','OK','OR','PA','RI','SC','SD','TN','TX','UT','VT','VA','WA','WV','WI','WY'
      ],
      show: true
    };
  },
  methods: {
      checkName(){
        this.employeeNames.includes(this.form.username) ? this.valid = 'red' : this.valid = 'lightgreen';
        if(this.form.username === '') { this.valid = ''}
      },
      handleSubmit(form){
        if(this.valid === 'lightgreen'){
          let self = this;
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
              IsActive: this.form.IsActive
          })
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
            this.valid = ''
          })
          .catch((error)=>{
            console.log(error);
          })
      }
      else{
        alert('Please check your form for missing or invalid input');
      }
      },
      formatTime(time){
        let timeStamp = time.split(':');
        let timeHour = timeStamp[0];
        let timeMinutes = timeStamp[1];
        let formatedTime= "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
        if(time === ''){
          let formatedTime = "PT00H00M00S";
          return formatedTime;
        }
        return formatedTime;
      }
  },
  mounted(){
    axios.get('https://chefemployees.com/odata/Employees')
    .then((response) => {
      this.employeeNames = response.data.value.map(value => value.Username)
    })
    .catch((error)=>{
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