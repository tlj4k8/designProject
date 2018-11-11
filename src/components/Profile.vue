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
    <div class="zipCode">
    <h3> Zip Radius </h3>
    <hr/>
      <div class="zipflexGroup">
      <b-form-group class="zipflex"
                  id="zip"
                  label="Zip Code"
                  label-for="zip">
      <b-form-select 
                  v-model="form.zipSelected" 
                  :options="zipOptions"/>
      </b-form-group>
      <b-form-group class="zipflex"
                  id="zipCode"
                  label="Add Zip Code"
                  label-for="zipCode">
          <b-form-input
                  v-model="form.zipCode"
                  type="text"/>
      </b-form-group>
      </div>
    </div>
    </b-form>
    </div>
</template>

<script>
import moment from 'moment';
import axios from 'axios';
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
        zipSelected: '',
        zipOptions: [],
        zipCode: []
      },
      selected: null,
      options: [],
      employee: '',
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
    getProfile(){
            let profileSelection = this.options.indexOf(this.selected);
            this.$axiosServer.get('https://chefemployees.com/odata/Employees')
            .then((response)=>{
                let profileValue = response.data.value[profileSelection]
                if(profileValue == null || undefined){
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
                this.form.firstName = profileValue.EmFirstName,
                this.form.lastName = profileValue.EmLastName,
                this.form.username = profileValue.Username,
                this.form.password = profileValue.Password,
                this.form.phone = profileValue.EmCellPhone,
                this.form.email = profileValue.EmEmail,
                this.form.zip = profileValue.EmZipCode,
                this.form.mon = this.returnTime(profileValue.EmStartMonday),
                this.form.endMon = this.returnTime(profileValue.EmEndMonday),
                this.form.tue = this.returnTime(profileValue.EmStartTuesday),
                this.form.endTue = this.returnTime(profileValue.EmEndTuesday),
                this.form.wed = this.returnTime(profileValue.EmStartWednesday),
                this.form.endWed = this.returnTime(profileValue.EmEndWednesday),
                this.form.thur = this.returnTime(profileValue.EmStartThursday),
                this.form.endThur = this.returnTime(profileValue.EmEndThursday),
                this.form.fri = this.returnTime(profileValue.EmStartFriday),
                this.form.endFri = this.returnTime(profileValue.EmEndFriday),
                this.form.sat = this.returnTime(profileValue.EmStartSaturday),
                this.form.endSat = this.returnTime(profileValue.EmEndSaturday),
                this.form.sun = this.returnTime(profileValue.EmStartSunday),
                this.form.endSun = this.returnTime(profileValue.EmEndSunday),
                this.form.isAdmin = profileValue.IsAdmin,
                this.form.isMenu = profileValue.IsMenu

            })
            .catch((error)=>{
                console.log(error);
            })
        }
    },
    mounted: function(){
        axios.get('https://chefemployees.com/odata/Employees')
        .then((response) => {
            this.options = response.data.value.map(value => value.EmployeeId)
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