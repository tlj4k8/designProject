<template>
    <div class="addSchedule">
        <div class="end">
          <font-awesome-icon icon="question"/>
        </div>
        <div class="employeeSelect">
        <h3> Select Schedule </h3>
        <hr/>
        <b-form-group id="schedule"
                    class="select"
                    :label-cols="4"
                    breakpoint="md">
            <b-form-select v-on:input="getSchedules" v-model="form.selectedSchedule" :options="scheduleOptions" class="mb-1" />
        </b-form-group>
        </div>
        <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
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
        <h3> Scheduled Meal Items </h3>
         <hr/>
         <div>
             <ul v-for="menuOption in menuOptions" :key="menuOption.MenuId">
                 <li>
                     {{ menuOption }}
                </li>
            </ul>

         </div>
        <!-- <div class="clientMenuAdd">
            <b-form-group id="menu"
                        label="Menus:"
                        label-for="menu">
            <b-form-select 
                    v-model="form.menu" 
                    :options="menuOptions"/>
            </b-form-group>
        </div> -->
        <div class="timestamp">
            <h3>Track Time</h3>
            <hr/>
            <div class="timeflexGroup">
                <b-form-group class="timeflex"
                                id="clockIn">
                    <div>
                    <b-button v-on:click="clockIn" class="clock">Clock In</b-button>
                    </div>
                    <b-form-input id="clockIn"
                                type="time"
                                class="clockText"
                                required
                                :disabled="disabled"
                                v-model="form.timeIn"/>
                </b-form-group>
                <b-form-group class="timeflex"
                                id="clockOut">
                    <div>
                    <b-button v-on:click="clockOut" class="clock">Clock Out</b-button>
                    </div>
                    <b-form-input id="clockOut"
                                type= "time"
                                required
                                class="clockText"
                                :disabled="disabled"
                                v-model="form.timeOut"/>
                </b-form-group>
            </div>
        </div>
        <div v-if="isAdmin=='True'" class="disabledButtons">
            <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Time</b-button>
            <b-button class="update" v-if="!disabled" type="submit">Update Time</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
        </div>
        <div class="receipt">
        <h3> Customer Receipt Form </h3>
        <hr/>
            <div class="receiptflexGroup">
                <b-form-group id="mealCharged"
                                class="receiptflex"
                                label="Meal Charged:"
                                label-for="mealCharged">
                    <b-form-input id="mealCharged"
                                type="text"
                                v-model="form.mealCharged">
                    </b-form-input>
                </b-form-group>
                <b-form-group id="mealCost"
                                class="receiptflex"
                                label="Meal Cost:"
                                label-for="mealCost">
                    <b-form-input id="mealCost"
                                type="text"
                                v-model="form.mealCost">
                    </b-form-input>
                </b-form-group>
                <b-form-group id="receipt"
                    class="receiptflex"
                    label="Upload Receipt:"
                    label-for="receipt">
                    <b-form-file @change="onFileSelected" v-model="form.imagePath" >
                    </b-form-file>
                </b-form-group>
                </div>
            <div class="submitButton">
                <b-button class="imageButton" @click="onUpload">Upload Image</b-button>
            </div>
        </div>
        <b-form-group>
            <div class="submitButton">
                <b-button type="submit">Submit</b-button>
            </div>
        </b-form-group>
        </b-form>
        <Spinner v-if="loading"/>
    </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';
import { mapState } from 'vuex';
import Spinner from './../Spinner';
export default {
  name: 'ScheduleVisit',
  components:{
    Spinner
  },
  data () {
    return {
        form: {
            receipt: '',
            mealCharged: '',
            mealCost: '',
            timeIn: null,
            timeOut: null,
            date: '',
            startTime: '',
            endTime: '',
            menu: [],
            imagePath: '',
            selectedSchedule: null
        },
        scheduleOptions: [],
        employeeId: null,
        clientId: null,
        selectedFile: null,
        menuOptions: [],
        disabled: true,
        show: true,
        loading: true
    }
  },

  methods: {
    onFileSelected(event){
        this.selectedFile = event.target.files[0];
    },
    onUpload(){
        this.loading = true;
        let token = localStorage.getItem('t');
        let formData = new FormData();
        formData.append('file', this.selectedFile, this.selectedFile.name);
        this.$axiosServer.post('https://chefemployees.com/api/' + this.form.selectedSchedule +'/AddImage', formData, {
            headers:{
                'Content-Type':'multipart/form-data',
                'Authorization': 'Bearer ' + token
            }
        })
        .then((response)=>{
            this.loading = false;
            alert('Receipt uploaded for ' + this.form.selectedSchedule);
            console.log(response);
        })
        .catch((error)=>{
            this.loading = false;
            alert('Receipt failed to upload. Please try again.');
            console.log(error);
        })
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
    clockIn(){
        let timestamp = moment().format("HH:mm");
        this.form.timeIn = timestamp;
        this.loading = true;
        let token = localStorage.getItem('t');
        let headers = {'Authorization': "Bearer " + token};
        console.log(this.form.selectedSchedule);
        console.log(this.formatTime(this.form.timeIn));
        this.$axiosServer.patch('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')', {
            ScheduleId: this.form.selectedSchedule,
            Clockin: this.formatTime(this.form.timeIn)
        }, {headers: headers}
        )
        .then((response)=>{
            console.log(response);
            this.loading = false;
            alert('You are clocked in! Don\'t forget to clock out.');
            this.disabled = true;
        })
        .catch((error)=>{
            this.loading = false;
            alert('There was a problem clocking in. Please try again.');
            console.log(error);
        })
    },
    clockOut(){
        let timestamp = moment().format("HH:mm");
        this.form.timeOut = timestamp;
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
    returnTime(time){
        let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
        return timeStamp;
    },
    returnDate(date){
        let dateStamp = moment(date, 'YYYY-MM-DDTHH:mm:ss.SSS').format('YYYY-MM-DD');
        return dateStamp;
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
      getSchedules(){
        this.loading = true;
        let token = localStorage.getItem('t');
        this.$axiosServer.get('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')', { headers: { 'Authorization': "Bearer " + token }})
        .then((response)=>{
            let scheduleValue = response.data;
            console.log(scheduleValue);
            if(scheduleValue == null || undefined){
                this.form.endTime = '',
                this.form.startTime = '',
                this.form.timeIn = '',
                this.form.timeOut = ''
            }
            else{
                this.form.date = this.returnDate(scheduleValue.ScheduleDate),
                this.form.startTime = this.returnTime(scheduleValue.StartTime),
                this.form.endTime = this.returnTime(scheduleValue.EndTime),
                this.form.timeIn = this.returnTime(scheduleValue.Clockin),
                this.form.timeOut = this.returnTime(scheduleValue.Clockout),
                this.form.mealCharged = scheduleValue.Charged,
                this.form.mealCost = scheduleValue.Cost,
                this.form.imagePath = scheduleValue.ImagePath,
                this.employeeId = scheduleValue.EmployeeId,
                this.clientId = scheduleValue.ClientId
            }
            this.$axiosServer.get('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')ClientMenus', { headers: { 'Authorization': "Bearer " + token }})
            .then((response)=>{
                this.menuOptions = response.data.value.map(value => value.MenuId);
                this.loading = false;
            })
            .catch((error)=>{
                this.loading = false;
                console.log(error);
            })
        })
        .catch((error)=>{
            this.loading = false;
            console.log(error);
        })
      }
  },
  mounted() {
      this.loading = true;
      let token = localStorage.getItem('t');
      axios.get('https://chefemployees.com/odata/Schedules', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            response.data.value.forEach((value) => {
                this.scheduleOptions.push({ value: value.ScheduleId, text: 'Employee Id:   ' + value.EmployeeId + '   Schedule Id:   ' + value.ScheduleId })
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
.clockText{
    text-align: center;
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
.employeeSelect{
  padding-top: 5px 0px;
}
.button{
    flex-grow: 1;
    padding: 0 2px;
}
.timeflexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.timeflex{
    padding: 10px 0;
}
.clock{
    width: 38vw;
}
.receiptflexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
}
.receiptflex{
    flex-grow: 1;
    padding: 0 2px;
}
.submitButton{
    padding-top: 10px;
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
.end{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.disabledButtons{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
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
@media(max-width: 500px){
  .flexGroup{
    flex-wrap: wrap;
  }
  .timeflexGroup{
      flex-wrap: wrap;
  }
  .receiptflexGroup{
      flex-wrap: wrap;
  }
  .clock{
    width: 100%;
    }
  .disabledButtons{
      justify-content: center;
  }
}
@media(max-width: 440px){
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
@media (max-width: 900px) {
  .disabledButtons{
      justify-content: center;
  }
  .disabled{
      width: 90%;
  }
  .update{
      width: 40%
  }
  .cancel{
      width: 40%;
  }
}
</style>