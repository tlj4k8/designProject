<template>
    <div class="scheduleNew">
    <div class="end">
          <font-awesome-icon @click="help" icon="question"/>
    </div>
        <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
            <div class="employeeSelect">
                <h3> Select Employee </h3>
                <hr/>
                <b-form-group id="employee"
                            class="select"
                            :label-cols="4"
                            breakpoint="md">
                <b-form-select required @input="filterClients" v-model="form.selectedEmployee" :options="employeeOptions" class="mb-1" />
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
        <Spinner v-if="loading" />
    </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';
import { mapState } from 'vuex';
import Spinner from './../Spinner';
export default {
    name: 'ScheduleNew',
    components:{
        Spinner
    },
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
            show: true,
            loading: false,
            checked: false
        }
    },
    methods: {
        help(){
            window.open('http://localhost:8080/?#/help', "_blank");
        },
        handleSubmit(form) {
            this.validateDate();
            if(this.checked === true){
                this.loading = true;
                let token = localStorage.getItem('t');
                let headers = {'Authorization': "Bearer " + token};
                this.$axiosServer.post('https://chefemployees.com/odata/Schedules', {
                    EmployeeId: this.form.selectedEmployee,
                    ClientId: this.form.selectedClient,
                    StartTime: this.formatTime(this.form.startTime),
                    EndTime: this.formatTime(this.form.endTime),
                    ScheduleDate: this.formatDate(this.form.date)
                },{headers: headers}
                )
                .then((response)=>{
                    this.loading = false;
                    console.log(response);
                    this.form.selectedEmployee = null,
                    this.form.selectedClient =  null,
                    this.form.startTime = '',
                    this.form.endTime = '',
                    this.form.date = ''
                    alert('Schedule added successfully!');
                })
                .catch((error)=>{
                    this.loading = false;
                    console.log(error)
                    alert('Error: Please select a new date. This employee is already scheduled at this date');
                })
            }
        },
        filterClients(){
            this.loading = true;
            let token = localStorage.getItem('t');
            this.$axiosServer.get('https://chefemployees.com/odata/Clients', { headers: { 'Authorization': "Bearer " + token }})
            .then((response)=>{
                this.clientOptions = [];
                let filterClients = response.data.value.filter(value => value.EmployeeId == this.form.selectedEmployee);
                filterClients.forEach((item) =>{
                    this.clientOptions.push({ value: item.ClientId, text: item.ClFirstName + ' ' + item.ClLastName })
                })
                this.loading = false;
            })
            .catch((error)=>{
                this.loading = false
                console.log(error)
            })
        },
        validateDate(){
            const yesterday = moment().subtract(1, "day").format("YYYY-MM-DD");
            let SpecialToDate = this.form.date;

            if (moment(SpecialToDate, "YYYY-MM-DD", true).isAfter(yesterday)) {
                console.log("date is today or in future");
                this.checked = true;
            } else {
                this.checked = false;
                alert("Error: Please enter a valid date. The date entered has passed.");
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
    computed: mapState({
        getToken (state){
            return state.jwt;
        },
        isAdmin (state){
            return state.userInfo.admin;
        },
        isMenu (state){
            return state.userInfo.menu;
        }
    }),
    mounted(){
        this.loading = true;
        let token = localStorage.getItem('t');
        axios.get('https://chefemployees.com/odata/Clients', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            response.data.value.forEach((value) => {
                this.clientOptions.push({ value: value.ClientId, text: value.ClFirstName + ' ' + value.ClLastName })
            })
            this.loading = false;
        })
        .catch((error) => {
            this.loading = false;
            console.log(error);
        });
        axios.get('https://chefemployees.com/odata/Employees', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            let filteredEmployees = response.data.value.filter(value => value.IsMenu === false && value.IsAdmin === false);
            filteredEmployees.forEach((item) => {
                this.employeeOptions.push({ value: item.EmployeeId, text: item.EmFirstName + ' ' + item.EmLastName })
            })
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
    