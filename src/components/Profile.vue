<template>
    <div class="profilePage">
    <div class="end">
        <font-awesome-icon @click="help" icon="question"/>
    </div>
    <b-form ref="form" :model="form" v-if="show" class="form">
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
                        :disabled="disabled"
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
                        :disabled="disabled"
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
                        :disabled="disabled"
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
                        :disabled="disabled"
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
                        :disabled="disabled"
                        v-model="form.zip"
                        required>
            </b-form-input>
        </b-form-group>
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
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.mon"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.tue"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.wed"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.thur"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.fri"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.sat"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.sun"></b-form-input></td>
              </tr>
              <tr>
                  <td>End</td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endMon"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endTue"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endWed"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endThur"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endFri"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endSat"></b-form-input></td>
                  <td><b-form-input type="time" :disabled="disabled" v-model="form.endSun"></b-form-input></td>
              </tr>
          </table>
      </div>
    </div>
    </b-form>
    <div class="disabledButtons">
        <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Profile</b-button>
        <b-button class="update" v-if="!disabled" @click="updateProfile">Update Profile</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
    </div>
    <Spinner v-if="loading"/>
    </div>
</template>

<script>
import moment from 'moment';
import axios from 'axios';
import { mapState } from 'vuex';
import * as decoded from 'jwt-decode';
import Spinner from '././Spinner';
export default {
    name: "profile",
    components:{
        Spinner
    },
    data() {
        return {
        disabled: true,
        form: {
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
            zipSelected: ''
            },
        employee: '',
        employeeInfo: {},
        show: true,
        loading: true,
        zipRegex: false
        };
    },
    methods: {
        help(){
            window.open('http://localhost:8080/?#/help', "_blank");
        },
        checkRegex(){
            let patt = new RegExp(/(?:[^\d]|^)(\d{5})(?:[^\d]|$)/g);
            let letterPatt = new RegExp(/[^\d,\s]/g);
            let letterPattResult = letterPatt.test(this.form.zip);
            let pattResult = patt.test(this.form.zip);
            if(letterPattResult === true){
                this.zipRegex = false;
            }else
            if(pattResult === true){
                this.zipRegex = true;
            }
        },
        returnTime(time){
            let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
            return timeStamp;
        },
        formatTime(time){
            let timeStamp = time.split(':');
            let timeHour = timeStamp[0];
            let timeMinutes = timeStamp[1];
            let formatedTime = "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
            if(time === '' || 'Invalid date' || undefined){
                let formatedTime = "PT00H00M00S";
                return formatedTime;
            }
            return formatedTime;
        },
        updateProfile(){
          this.checkRegex();
          this.loading = true;
          if(this.zipRegex == true){
            this.loading = true;
            console.log(this.employeeInfo);
            let token = localStorage.getItem('t');
            let headers = {'Authorization' : 'Bearer ' + token}
            this.$axiosServer.patch('https://chefemployees.com/odata/Employees(' + this.employeeInfo.employeeid + ')', {
                EmployeeId: this.employeeInfo.employeeid,
                EmFirstName: this.form.firstName,
                EmLastName: this.form.lastName,
                Username: this.username,
                Password: this.password,
                EmCellPhone: this.form.phone,
                EmEmail: this.form.email,
                EmZipCodes: this.form.zip,
                IsMenu: this.employeeInfo.menu,
                IsAdmin: this.employeeInfo.admin,
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
                }, {headers: headers}
            )
            .then((response)=>{
            console.log(response)
            this.disabled = true
            this.loading = false;
            })
            .catch((error)=>{
            this.loading = false;
            console.log(error);
            })
        }else{
            this.loading = false;
            alert('Error: Please check that your fields are correct.');
        }
      } 
    },
    computed: mapState({
        getToken(state){
            return state.jwt;
        }
    }),
    mounted(){
        this.loading = true;
        let token = localStorage.getItem('t');
        this.$store.dispatch('storeUserInfo',token);
        this.employeeInfo = decoded(token)
        axios.get('https://chefemployees.com/odata/Employees(' + this.employeeInfo.employeeid + ')', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            this.username = response.data.Username;
            this.password = response.data.Password;
            this.form.firstName = response.data.EmFirstName;
            this.form.lastName = response.data.EmLastName;
            this.form.phone = response.data.EmCellPhone;
            this.form.email = response.data.EmEmail;
            this.form.zip = response.data.EmZipCodes;
            this.form.mon = this.returnTime(response.data.EmStartMonday);
            this.form.endMon = this.returnTime(response.data.EmEndMonday);
            this.form.tue = this.returnTime(response.data.EmStartTuesday);
            this.form.endTue = this.returnTime(response.data.EmEndTuesday);
            this.form.wed = this.returnTime(response.data.EmStartWednesday);
            this.form.endWed = this.returnTime(response.data.EmEndWednesday);
            this.form.thur = this.returnTime(response.data.EmStartThursday);
            this.form.endThur = this.returnTime(response.data.EmEndThursday);
            this.form.fri = this.returnTime(response.data.EmStartFriday);
            this.form.endFri = this.returnTime(response.data.EmEndFriday);
            this.form.sat = this.returnTime(response.data.EmStartSaturday);
            this.form.endSat = this.returnTime(response.data.EmEndSaturday);
            this.form.sun = this.returnTime(response.data.EmStartSunday);
            this.form.endSun = this.returnTime(response.data.EmEndSunday);
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
hr {
  background-color: #0d50bc;
  height: 1px;
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
.cancel{
    width: 15%;
    color:white;
    background-color:red;
    border-color: darkred;  
    padding: 7px 2px;
}
.disabledButtons{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.update{
    width: 15%;
    color:white;
    background-color: #0d50bc;
    border-color: darkblue;
    padding: 7px 2px;
}
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.disabled{
    width: 15%;
    color:black;
    background-color:white;
    border-color: lightgray;
}
@media (max-width: 440px) {
  .personflexGroup {
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