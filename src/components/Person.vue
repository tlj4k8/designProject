<!--
<template>
    <div class="person">
        <h1>Create Profile</h1>
        <form @submit="onSubmit" @reset="onReset" v-if="show">
        <div class="form-row">
            <div class="form-group col-md-6">
            <label for="email">Email</label>
            <input type="email" class="form-control" id="email" placeholder="Email">
            </div>
            <div class="form-group col-md-6">
            <label for="password">Password</label>
            <input type="password" class="form-control" id="password" placeholder="Password">
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
            <label for="firstName">FirstName</label>
            <input type="text" class="form-control" id="firstName" placeholder="First Name" required>
            </div>
            <div class="form-group col-md-4">
            <label for="lastName">Last Name</label>
            <input type="text" class="form-control" id="lastName" placeholder="Last Name" required>
            </div>
            <div class="form-group col-md-4">
            <label for="phoneNumber">Phone Number</label>
            <input type="tel" class="form-control" id="phoneNumber"
                placeholder="123-456-7890"
                pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
                required >
            <span class="validity"></span>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
            <label for="address">Address</label>
            <input type="text" class="form-control" id="address" placeholder="1234 Main St" required>
            </div>
            <div class="form-group col-md-6">
            <label for="addressTwo">Address 2</label>
            <input type="text" class="form-control" id="addressTwo" placeholder="Apartment, studio, or floor">
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
            <label for="city">City</label>
            <input type="text" class="form-control" id="city" required>
            </div>
            <div class="form-group col-md-4">
            <label for="states">State</label>
            <select id="states" class="form-control" :options="states" v-model="form.states" required>
                option selected>Choose...</option>
                <option>...</option>
            </select>
            </div>
            <div class="form-group col-md-2">
            <label for="zip">Zip</label>
            <input type="text" class="form-control" id="zip" required>
            </div>
        </div>
        <fieldset class="form-group">
            <div class="row">
            <legend class="col-form-label col-sm-2 pt-0">Job Title</legend>
            <div class="col-sm-10">
                <div class="form-check">
                <input class="form-check-input" type="radio" name="gridRadios" id="chefGrid" value="option1" checked>
                <label class="form-check-label" for="chefGrid">
                    Chef
                </label>
                </div>
                <div class="form-check">
                <input class="form-check-input" type="radio" name="gridRadios" id="hrGrid" value="option2">
                <label class="form-check-label" for="hrGrid">
                    HR
                </label>
                </div>
                <div class="form-check disabled">
                <input class="form-check-input" type="radio" name="gridRadios" id="menuGrid" value="option3">
                <label class="form-check-label" for="menuGrid">
                    Menu Team
                </label>
                </div>
            </div>
            </div>
        </fieldset>
        <button type="submit" class="btn btn-primary">Create</button>
        </form>
    </div>
</template>
 -->
<template>
  <div class="person">
  <h1>Create Profile</h1>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
      <b-form-group id="firstName"
                    label="First Name:"
                    label-for="firstName">
        <b-form-input id="firstName"
                      type="text"
                      v-model="form.firstName"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group id="lastName"
                    label="Last Name:"
                    label-for="lastName">
        <b-form-input id="lastName"
                      type="text"
                      v-model="form.lastName"
                      required>
        </b-form-input>
        </b-form-group>
      <b-form-group id="phone"
                    label="Phone:"
                    label-for="phone">
        <b-form-input id="phone"
                      type="text"
                      v-model="form.phone"
                      pattern="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group id="address"
                    label="Address:"
                    label-for="address">
        <b-form-input id="address"
                      type="text"
                      v-model="form.address"
                      required
                      placeholder="Street Address or P.O. Box">
        </b-form-input>
      </b-form-group>
      <b-form-group id="addressTwo"
                    label="Address 2:"
                    label-for="addressTwo">
        <b-form-input id="addressTwo"
                      type="text"
                      v-model="form.addressTwo"
                      placeholder="Company, C/O, Suite, Unit, Building, Floor">
        </b-form-input>
      </b-form-group>
      <b-form-group id="city"
                    label="City:"
                    label-for="city">
        <b-form-input id="city"
                      type="text"
                      v-model="form.city"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group id="state"
                    label="State:"
                    label-for="state">
        <b-form-select id="state"
                      :options="state"
                      required
                      v-model="form.state">
        </b-form-select>
      </b-form-group>
      <b-form-group id="zip"
                    label="Zip Code:"
                    label-for="zip">
        <b-form-input id="zip"
                      type="text"
                      v-model="form.zip"
                      required>
        </b-form-input>
      </b-form-group>
      <b-form-group id="checks">
        <b-form-checkbox-group v-model="form.checked" id="checks">
          <b-form-checkbox value="menu">Menu Team</b-form-checkbox>
          <b-form-checkbox value="hr">Human Resources</b-form-checkbox>
          <b-form-checkbox value="chef">Chef</b-form-checkbox>
        </b-form-checkbox-group>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
export default {
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
        checked: []
      },
      state: [
        { text: 'Select One', value: null },
        'MO', 'IL', 'TX', 'NY'
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
      this.form.checked = [];
      /* Trick to reset/clear native browser form validation state */
      this.show = false;
      this.$nextTick(() => { this.show = true });
    }
  }
}
</script>
<style scoped>
.person{
  padding: 0 10px;
}
.form{
    padding: 0 15px;
}
h1{
    text-align: center;
}

</style>
