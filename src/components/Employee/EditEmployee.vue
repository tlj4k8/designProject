<template>
    <div class="editEmployee">
      <div class="employeeSelect">
      <h3>Select Employee</h3>
      <hr/>
          <b-form-group id="employee"
                      class="select"
                      :label-cols="4"
                      breakpoint="md"
                      label="Employees"
                      label-for="employee">
          <b-form-select v-model="selected" v-on:input="getEmployees" :options="options" class="mb-1" />
          </b-form-group>
      </div>
    <b-form ref="form" @submit="handleSubmit(form)" :model="form" v-if="show" class="form">
        <div class="personflexGroup">
            <b-form-group class="personflex" 
                        id="username"
                        label="Username:"
                        label-for="username">
            <b-form-input id="username"
                        type="text"
                        :disabled="userDisabled"
                        v-model="form.username">
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
                        id="password"
                        label="Password:"
                        label-for="password">
            <b-form-input id="password"
                        type="password"
                        :disabled="passwordDisabled"
                        v-model="form.password">
            </b-form-input>
        </b-form-group>
        </div>
        <div v-if="isAdmin=='True'">
            <div v-if="!passwordDisabled" class="inputPass">
                <b-form-group id="resetPass"
                                label="New Password"
                                label-for="resetPass">
                    <b-form-input id="resetPass"
                                type="password"
                                :disabled="passwordDisabled"
                                v-model="form.resetPass">
                    </b-form-input>
                </b-form-group>
            </div>
            <div class="stackedButtons">
                <b-button class="disabled" v-if="passwordDisabled" v-on:click="passwordDisabled = !passwordDisabled">Edit Password</b-button>
                <b-button class="update" v-if="!passwordDisabled" @click="updatePassword">Update Password</b-button><b-button class="cancel" v-if="!passwordDisabled" v-on:click="passwordDisabled = !passwordDisabled">Cancel</b-button>
            </div>
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
  <div class="needform">
  <h3>Employee Status</h3>
  <hr/>
    <div class="flexGroup">
      <b-form-group id="ismenu"
                    class="flex"
                    label="Menu Team:"
                    label-for="ismenu">
        <b-form-checkbox id="form.ismenu"
                    type="checkbox"
                    :disabled="disabled"
                    v-model="form.ismenu"/>
      </b-form-group>
      <b-form-group id="isadmin"
                    class="flex"
                    label="Admin Team:"
                    label-for="isadmin">
        <b-form-checkbox id="form.isadmin"
                    type="checkbox"
                    :disabled="disabled"
                    v-model="form.isadmin"/>
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
                  <td><b-form-input type="time" v-model="form.mon" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.tue" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.wed" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.thur" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.fri" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.sat" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.sun" :disabled="disabled"></b-form-input></td>
              </tr>
              <tr>
                  <td>End</td>
                  <td><b-form-input type="time" v-model="form.endMon" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.endTue" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.endWed" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.endThur" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.endFri" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.endSat" :disabled="disabled"></b-form-input></td>
                  <td><b-form-input type="time" v-model="form.endSun" :disabled="disabled"></b-form-input></td>
              </tr>
          </table>
      </div>
    </div>
    </b-form>
    <div v-if="isAdmin=='True'" class="disabledButtons">
        <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Employee</b-button>
        <b-button class="update" v-if="!disabled" @click="updateEmployee">Update Employee</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
    </div>
    </div>
</template>

<script>
import moment from 'moment';
import axios from 'axios';
import { mapState } from 'vuex';
export default {
  name: "editEmployee",
  data() {
    return {
      disabled: true,
      userDisabled: true,
      passwordDisabled: true,
      form: {
        username: '',
        password: '',
        resetPass: '',
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
        isactive: true,
        ismenu: false,
        isadmin: false
      },
      selected: '',
      options: [],
      show: true
    };
  },
  methods: {
    //   updateEmployee(){
    //     this.$axiosServer.patch('https://chefemployees.com/odata/Employees(' + this.selected + ')', {
    //         EmployeeId: this.selected,
    //         EmFirstName: this.form.firstName,
    //         EmLastName: this.form.lastName,
    //         Username: this.form.username,
    //         Password: this.form.password,
    //         EmCellPhone: this.form.phone,
    //         EmEmail: this.form.email,
    //         EmZipCodes: this.form.zip,
    //         EmStartMonday: this.formatTime(this.form.mon),
    //         EmEndMonday: this.formatTime(this.form.endMon),
    //         EmStartTuesday: this.formatTime(this.form.tue),
    //         EmEndTuesday: this.formatTime(this.form.endTue),
    //         EmStartWednesday: this.formatTime(this.form.wed),
    //         EmEndWednesday: this.formatTime(this.form.endWed),
    //         EmStartThursday: this.formatTime(this.form.thur),
    //         EmEndThursday: this.formatTime(this.form.endThur),
    //         EmStartFriday: this.formatTime(this.form.fri),
    //         EmEndFriday: this.formatTime(this.form.endFri),
    //         EmStartSaturday: this.formatTime(this.form.sat),
    //         EmEndSaturday: this.formatTime(this.form.endSat),
    //         EmStartSunday: this.formatTime(this.form.sun),
    //         EmEndSunday: this.formatTime(this.form.endSun),
    //         IsMenu: this.form.ismenu,
    //         IsAdmin: this.form.isadmin,
    //         EmIsActive: this.form.isactive
    //     })
    //     .then((response)=>{
    //       console.log(response)
    //       this.disabled = true
    //     })
    //     .catch((error)=>{
    //       console.log(error);
    //     })
    //   },
      formatTime(time){
        var timeStamp = time.split(':');
        var timeHour = timeStamp[0];
        var timeMinutes = timeStamp[1];
        var formatedTime = "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
        return formatedTime;
      },
      returnTime(time){
        let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
        return timeStamp;
      },
      updatePassword(){
        this.$axiosServer.post('https://chefemployees.com/api/EmployeesPW', {
            EmployeeId: this.selected,
            Username: this.form.username,
            Password: this.form.resetPass,
            EmFirstName: this.form.firstName,
            EmLastName: this.form.lastName,
            EmCellPhone: this.form.phone,
            EmEmail: this.form.email,
            EmZipCodes: this.form.zip,
            EmStartMonday: this.form.mon,
            EmEndMonday: this.form.endMon,
            EmStartTuesday: this.form.tue,
            EmEndTuesday: this.form.endTue,
            EmStartWednesday: this.form.wed,
            EmEndWednesday: this.form.endWed,
            EmStartThursday: this.form.thur,
            EmEndThursday: this.form.endThur,
            EmStartFriday: this.form.fri,
            EmEndFriday: this.form.endFri,
            EmStartSaturday: this.form.sat,
            EmEndSaturday: this.form.endSat,
            EmStartSunday: this.form.sun,
            EmEndSunday: this.form.endSun,
            IsMenu: this.form.ismenu,
            IsAdmin: this.form.isadmin,
            EmIsActive: this.form.isactive
          })
          .then((response)=>{
              console.log(response);
              this.form.password = response.data.Password;
              this.passwordDisabled = true;
              this.form.resetPass = '';
          })
          .catch((error)=>{
              console.log(error);
          })
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
        getEmployees(){
            console.log(this.selected);
            let employee = this.options.indexOf(this.selected);
            console.log(employee);
            this.passwordDisabled = true;
            this.$axiosServer.get('https://chefemployees.com/odata/Employees')
            .then((response)=>{
                let employeeValue = response.data.value[employee]
                if(employeeValue == null || undefined){
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
                else{
                    this.form.firstName = employeeValue.EmFirstName,
                    this.form.lastName = employeeValue.EmLastName,
                    this.form.username = employeeValue.Username,
                    this.form.password = employeeValue.Password,
                    this.form.phone = employeeValue.EmCellPhone,
                    this.form.email = employeeValue.EmEmail,
                    this.form.zip = employeeValue.EmZipCodes,
                    this.form.mon = this.returnTime(employeeValue.EmStartMonday),
                    this.form.endMon = this.returnTime(employeeValue.EmEndMonday),
                    this.form.tue = this.returnTime(employeeValue.EmStartTuesday),
                    this.form.endTue = this.returnTime(employeeValue.EmEndTuesday),
                    this.form.wed = this.returnTime(employeeValue.EmStartWednesday),
                    this.form.endWed = this.returnTime(employeeValue.EmEndWednesday),
                    this.form.thur = this.returnTime(employeeValue.EmStartThursday),
                    this.form.endThur = this.returnTime(employeeValue.EmEndThursday),
                    this.form.fri = this.returnTime(employeeValue.EmStartFriday),
                    this.form.endFri = this.returnTime(employeeValue.EmEndFriday),
                    this.form.sat = this.returnTime(employeeValue.EmStartSaturday),
                    this.form.endSat = this.returnTime(employeeValue.EmEndSaturday),
                    this.form.sun = this.returnTime(employeeValue.EmStartSunday),
                    this.form.endSun = this.returnTime(employeeValue.EmEndSunday),
                    this.form.isadmin = employeeValue.IsAdmin,
                    this.form.ismenu = employeeValue.IsMenu,
                    this.form.isactive = employeeValue.EmIsActive
                }

            })
            .catch((error)=>{
                console.log(error);
            })
        }
    },
    mounted: function(){
        axios.get('https://chefemployees.com/odata/Employees')
        .then((response) => {
            response.data.value.forEach((value) => {
                this.options.push({ value: value.EmployeeId, text: value.EmFirstName + ' ' + value.EmLastName })
            })
            console.log(this.options);
        })
        .catch((error) => {
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
.employeeSelect {
    padding-top: 5px 0px;
}
.resetPassSection{
    display: flex;
    flex-direction: column;
    justify-content: flex-end;  
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
.inputPass{
    width: 100%;
}
.stackedButtons{
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
@media (max-width: 440px) {
  .personflexGroup {
    flex-wrap: wrap;
  }
  .disabledButtons, .stackedButtons{
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
  .disabledButtons, .stackedButtons{
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