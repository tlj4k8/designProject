<template>
    <div class="profilePage">
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
        <!-- <div class="personflexGroup">
            <b-form-group class="personflex" 
                        id="username"
                        label="Username:"
                        label-for="username">
                <b-form-input id="username"
                            type="text"
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
        </div> -->
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
    </b-form>
    </div>
</template>

<script>
import moment from 'moment';
import axios from 'axios';
import { mapState } from 'vuex';
import * as decoded from 'jwt-decode';
export default {
  name: "profile",
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
        zipSelected: ''
        },
      employee: '',
      employeeInfo: {},
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
        getProfile(data){

        },
  },
    computed: mapState({
        getToken(state){
            return state.jwt;
        }
    }),
    mounted: function(){
        let token = localStorage.getItem('t');
        this.$store.dispatch('storeUserInfo',token);
        this.employeeInfo = decoded(token)
        axios.get('https://chefemployees.com/odata/Employees(' + this.employeeInfo.nameid + ')')
        .then((response) => {
            this.form.firstName = response.data.EmFirstName;
            this.form.lastName = response.data.EmLastName;
            this.form.phone = response.data.EmCellPhone;
            this.form.email = response.data.EmEmail;
            this.form.zip = response.data.EmZipCode;
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
        })
        .catch((error) => {
            console.log(error);
            return error;
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
@media (max-width: 440px) {
  .personflexGroup {
    flex-wrap: wrap;
  }
}
</style>