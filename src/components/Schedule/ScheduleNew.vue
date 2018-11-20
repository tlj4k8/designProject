<template>
    <div class="scheduleNew">
    <div class="end">
          <font-awesome-icon icon="question"/>
    </div>
        <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
            <div class="employeeSelect">
                <h3> Select Employee </h3>
                <hr/>
                <b-form-group id="employee"
                            class="select"
                            :label-cols="4"
                            breakpoint="md">
                <b-form-select required v-model="form.selectedEmployee" :options="employeeOptions" class="mb-1" />
                </b-form-group>
            </div>
            <div class="clientSelect">
                <h3> Select Client </h3>
                <hr/>
                <b-form-group id="client"
                            class="select"
                            :label-cols="4"
                            breakpoint="md">
                <b-form-select required v-model="form.selectedClient" :options="clientOptions" class="mb-1" />
                </b-form-group>
            </div>
            <div class="scheduleVisit">
                <h3>Schedule Date/Time</h3>
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
                                    v-model="form.date"/>
                    </b-form-group>
                </div>
            </div>
            <div class="submit">
                <b-button type="submit">Submit</b-button>
            </div>
        </b-form>
    </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';
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
        clientOptions: [],
        employeeOptions: [],
        show: true
    }
  },
  methods: {
    handleSubmit(form) {
        let self = this;
        this.$axiosServer.post('https://chefemployees.com/odata/Schedules', {
            EmployeeId: this.form.selectedEmployee,
            ClientId: this.form.selectedClient,
            StartTime: this.formatTime(this.form.startTime),
            EndTime: this.formatTime(this.form.endTime),
            ScheduleDate: this.formatDate(this.form.date)
        })
        .then((response)=>{
            console.log(response);
            this.form.selectedEmployee = null,
            this.form.selectedClient =  null,
            this.form.startTime = '',
            this.form.endTime = '',
            this.form.date = ''
        })
        .catch((error)=>{
            console.log(error)
        })
    },
    validateDate(){
        const yesterday = moment().subtract(1, "day").format("YYYY-MM-DD");
        let SpecialToDate = this.form.date;

        if (moment(SpecialToDate, "YYYY-MM-DD", true).isAfter(yesterday)) {
            console.log("date is today or in future");
        } else {
            alert("Please enter a valid date. The date entered has passed.");
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
    },
    formatDate(){
        this.validateDate();
        let dateStamp = this.form.date.split('/').reverse().join('-');
        let formatedDate = dateStamp + "T00:00:00";
        return formatedDate;

    }
  },
    mounted: function(){
        axios.get('https://chefemployees.com/odata/Clients')
        .then((response) => {
            console.log(response);
            this.clientOptions = response.data.value.map(value => value.ClientId)
        })
        .catch((error) => {
            console.log(error);
        });
        axios.get('https://chefemployees.com/odata/Employees')
        .then((response) => {
            console.log(response);
            this.employeeOptions = response.data.value.map(value => value.EmployeeId)
        })
        .catch((error) => {
            console.log(error);
        });
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
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.flex{
    flex-grow: 1;
    padding: 0 2px;
}
.submit{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
@media(max-width: 480px){
  .flexGroup{
    flex-wrap: wrap;
  }
} 
</style>
    