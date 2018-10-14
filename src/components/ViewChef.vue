<template>
    <div class="viewChef">
    <div class="chefSelect">
    <h3> Select Chef </h3>
    <hr/>
        <b-form-group id="chef"
                    class="select"
                    :label-cols="4"
                    breakpoint="md"
                    label="Chefs:"
                    label-for="chef">
        <b-form-select v-model="selected" :options="options" class="mb-1" />
        </b-form-group>
    </div>
    <div class="person">
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
    <b-button type="submit" variant="primary">Submit</b-button>
    <b-button type="reset" variant="danger">Reset</b-button>
  </div>
  </div>
</template>

<script>

export default {
  name: "viewChef",
  data () {
    return{
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
        zipSelected: null,
        zipCode: ''
      },
      selected: null,
      options: [
        { value: 'chef1', text: 'chef1' },
        { value: 'chef2', text: 'chef2' },
        { value: 'chef3', text: 'chef3' },
        { value: 'chef4', text: 'chef4' },
        { value: 'chef5', text: 'chef5' }
      ],
      state: [
        { text: 'Select One', value: null },
        'AL', 'AK', 'AZ', 'AR','CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'ID', 'IL',
        'IN', 'IA', 'KS', 'KY', 'LA', 'ME', 'MD', 'MA', 'MI', 'MN', 'MO', 'MS', 'MT', 
        'NE', 'NY', 'NV', 'NH', 'NJ', 'NM','NC', 'ND', 'OH', 'OK', 'OR', 'PA', 'RI',
        'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WV', 'WI', 'WY'
      ],
      zipOptions: [
        { value: 'zip1', text: 'zip1' },
        { value: 'zip2', text: 'zip2' },
        { value: 'zip3', text: 'zip3' },
        { value: 'zip4', text: 'zip4' },
        { value: 'zip5', text: 'zip5' }
    ],
      show: true
    }
  },
    methods: {
        handleSubmit: function(form){
            var self = this;
            this.$ref[form].validate((valid => {
                if(valid){
                    //http request goes here
                }
                else{
                    this.emptyFields();
                    return false;
                }
            }))
        },
        emptyFields() {
            this.$alert("Please complete all required fields", "Registration failed", {
            confirmButtonText: 'OK'
            });
        }
    }
};
</script>

<style scoped>
hr{
    background-color: #0d50bc;
    height: 1px;
}
.chefSelect{
  padding-top: 5px 0px;
}
.zipflexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.zipflex{
    flex-grow: 1;
    padding: 0 2px;
}
.table{
    overflow-x:auto;
    padding: 5px 15px;
}
@media(max-width: 440px){
  .zipflexGroup{
    flex-wrap: wrap;
  }
}



</style>