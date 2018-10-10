<template>
    <div class="editEmployee">
    <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
    <div class="employee">
    <div class="employeeSelect">
    <h3>Select Chef</h3>
    <hr/>
        <b-form-group id="employee"
                    class="select"
                    :label-cols="4"
                    breakpoint="md"
                    label="Employees"
                    label-for="employee">
        <b-form-select v-model="selected" :options="options" class="mb-1" />
        </b-form-group>
    </div>
        <div class="formUser">
            <b-form-group id="username"
                        label="Username:"
                        label-for="username">
            <b-form-input id="username"
                        type="text"
                        v-model="form.username">
            </b-form-input>
        </b-form-group>
        <b-form-group id="password"
                        label="password:"
                        label-for="password">
            <b-form-input id="password"
                        type="text"
                        v-model="form.paswword">
            </b-form-input>
        </b-form-group>
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
        <div class="personflexGroup">
        <b-form-group class="personflex"
                        id="address"
                        label="Address:"
                        label-for="address">
            <b-form-input id="address"
                        type="text"
                        v-model="form.address"
                        required>
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
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
        <div class="personflexGroup">
        <b-form-group class="personflex"
                        id="city"
                        label="City:"
                        label-for="city">
            <b-form-input id="city"
                        type="text"
                        v-model="form.city"
                        required>
            </b-form-input>
        </b-form-group>
        <b-form-group class="personflex"
                        id="state"
                        label="State:"
                        label-for="state">
            <b-form-select id="state"
                        :options="state"
                        required
                        v-model="form.state">
            </b-form-select>
        </b-form-group>
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
    </div>
    <b-button type="submit" variant="primary">Submit</b-button>
    <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
    </div>
</template>
<script>
export default {
  name: "editEmployee",
  data () {
    return{
        form: {
            username: '',
            password: '',
            email: '',
            firstName: '',
            lastName: '',
            phone: '',
            address: '',
            addressTwo: '',
            state: null,
            city: '',
            zip: ''
          },
        selected: null,
        options: [
            { value: 'client1', text: 'Client1' },
            { value: 'client2', text: 'client2' },
            { value: 'client3', text: 'client3' },
            { value: 'client4', text: 'client4' },
            { value: 'client5', text: 'client6' }
        ],
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
        onSubmit (evt) {
        evt.preventDefault();
        alert(JSON.stringify(this.form));
        },
        onReset (evt) {
        evt.preventDefault();
        /* Reset our form values */
        this.form.email = '';
        this.form.name = '';
        this.form.food = null;
        /* Trick to reset/clear native browser form validation state */
        this.show = false;
        this.$nextTick(() => { this.show = true });
        }
    }
};
</script>

<style scoped>
hr{
    background-color: #0d50bc;
    height: 1px;
}
.employeeSelect{
  padding-top: 5px 0px;
}
h1{
  text-align: center;
}
.form1{
    width: 60vw;
}
.formUser{
    display: flex;
    justify-content: space-evenly;
}
.personflexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.personflex{
    flex-grow: 1;
    padding: 0 2px;
}
@media(max-width: 440px){
  .personflexGroup{
    flex-wrap: wrap;
  }
  .formUser{
      flex-wrap: wrap;
  }
  
}

</style>