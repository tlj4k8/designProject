<template>
  <div class="employee">
  <h1>Employee</h1>
  <div class="forms">
    <EmployeeSelect/>
    <div class="formUser">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form1">
        <b-form-group id="username"
                    label="Username:"
                    label-for="username">
        <b-form-input id="username"
                      type="text"
                      v-model="form1.username">
        </b-form-input>
       </b-form-group>
       <b-form-group id="password"
                    label="password:"
                    label-for="password">
        <b-form-input id="password"
                      type="text"
                      v-model="form1.paswword">
        </b-form-input>
      </b-form-group>
    </b-form>
    </div>
<!--    <b-button type="submit" variant="primary">Submit</b-button>
    <b-button type="reset" variant="danger">Reset</b-button>-->
    <Person/>
    </div>
  </div>
</template>

<script>
import Person from '../components/Person';
import EmployeeSelect from '../components/EmployeeSelect';
export default {
  name: "Employee",
  components: {
    Person,
    EmployeeSelect
  },
  data() {
      return{
          form1: {
              username: '',
              password: ''
          },
          show: true
      }
  }
};
</script>

<style scoped>
.employee{
  margin-top: 12em;
}
h1{
  text-align: center;
}
.forms{
    padding: 5px 15px;
}
.form1{
    width: 60vw;
}
.formUser{
    display: flex;
    justify-content: space-evenly;
}
</style>