<template>
    <div class="scheduleNew">
        <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
        <div class="employeeSelect">
        <h3> Select Employee </h3>
        <hr/>
        <b-form-group id="employee"
                    class="select"
                    :label-cols="4"
                    breakpoint="md"
                    label="Employees"
                    label-for="employee">
        <b-form-select required v-model="form.selectedEmployee" :options="employeeOptions" class="mb-1" />
        </b-form-group>
        </div>
        <div class="clientSelect">
        <h3> Select Chef </h3>
        <hr/>
        <b-form-group id="client"
                    class="select"
                    :label-cols="4"
                    breakpoint="md"
                    label="Clients"
                    label-for="client">
        <b-form-select required v-model="form.selectedClient" :options="clientOptions" class="mb-1" />
        </b-form-group>
        </div>
            <div class="scheduleVisit">
                <h3>Schedule New</h3>
                <hr/>
                <div class="flexGroup">
                    <b-form-group class="flex"
                                    id="startTime"
                                    label="Start Time:"
                                    label-for="startTime">
                        <b-form-input id="startTime"
                                    type="time"
                                    required
                                    v-model="form.startTime"/>
                    </b-form-group>
                    <b-form-group class="flex"
                                    id="endTime"
                                    label="End Time:"
                                    label-for="endTime">
                        <b-form-input id="endTime"
                                    type="time"
                                    required
                                    v-model="form.endTime"/>
                    </b-form-group>
                    <b-form-group class="flex"
                                    id="date "
                                    label="Visit Date:"
                                    label-for="date">
                        <b-form-input id="date"
                                    type="date"
                                    required
                                    v-on:blur.native="validateDate"
                                    v-model="form.date"/>
                    </b-form-group>
                </div>
            </div>
            <b-button type="submit" @click="handleSubmit('form')" variant="primary">Submit</b-button>
        </b-form>
    </div>
</template>
<script>
export default {
  name: 'ScheduleNew',
  data () {
    return {
        form: {
            date: '',
            startTime: '',
            endTime: '',
            selectedEmployee: null,
            selectedClient: null
        },
        clientOptions: [
            { value: 'client1', text: 'Client1' },
            { value: 'client2', text: 'client2' },
            { value: 'client3', text: 'client3' },
            { value: 'client4', text: 'client4' },
            { value: 'client5', text: 'client6' }
        ],
        employeeOptions: [
            { value: 'client1', text: 'Client1' },
            { value: 'client2', text: 'client2' },
            { value: 'client3', text: 'client3' },
            { value: 'client4', text: 'client4' },
            { value: 'client5', text: 'client6' }
        ],
        show: true
    }
  },
  methods: {
    validateDate: function(){
      const yesterday = moment().subtract(1, "day").format("YYYY-MM-DD");
      let SpecialToDate = this.form.date;

      if (moment(SpecialToDate, "YYYY-MM-DD", true).isAfter(yesterday)) {
        console.log("date is today or in future");
    } else {
        console.log("date is in the past");
      }
    },
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
}
</script>
<style scoped>
hr{
    background-color: #0d50bc;
    height: 1px;
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
@media(max-width: 480px){
  .flexGroup{
    flex-wrap: wrap;
  }
} 
</style>
    