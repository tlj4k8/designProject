<template>
    <div class="addSchedule">
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
        <div class="timestamp">
            <h3>Track Time</h3>
            <hr/>
            <div class="timeflexGroup">
                <b-form-group class="timeflex"
                                id="clockIn">
                    <b-button v-on:click="clockIn" class="btn">Clock In</b-button>
                    <b-form-input id="clockIn"
                                required
                                v-model="form.timeIn"/>
                </b-form-group>
                <b-form-group class="timeflex"
                                id="clockOut">
                    <b-button v-on:click="clockOut" class="btn">Clock Out</b-button>
                    <b-form-input id="clockOut"
                                required
                                v-model="form.timeOut"/>
                </b-form-group>
            </div>
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
                    <b-form-file v-model="form.receipt" :state="Boolean(form.file)" placeholder="Choose a file...">
                    </b-form-file>
                </b-form-group>
                <b-button @click="uploadImage">upload</b-button>
            </div>
        </div>
        <b-button class="submitButton" type="submit" variant="primary">Submit</b-button>
        </b-form>
    </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';
export default {
  name: 'ScheduleVisit',
  data () {
    return {
        form: {
            receipt: '',
            mealCharged: '',
            mealCost: '',
            file: null,
            timeIn: null,
            timeOut: null,
            date: '',
            startTime: '',
            endTime: '',
            selectedSchedule: null
        },
        scheduleOptions: [],
        show: true
    }
  },
  methods: {
    clockIn(){
        let timestamp = moment().format('LT');
        this.form.timeIn = timestamp;
    },
    clockOut(){
        let timestamp = moment().format('LT');
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
    formatTime(time){
        let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
        return timeStamp;
    },
    formatDate(date){
        let dateStamp = moment(date, 'YYYY-MM-DDTHH:mm:ss.SSS').format('YYYY-MM-DD');
        return dateStamp;
    }
  },
  computed: {
      getSchedules(){
        const schedule = this.scheduleOptions.indexOf(this.form.selectedSchedule);
        this.$axiosServer.get('https://chefemployees.com/odata/Schedules')
        .then((response)=>{
            let scheduleValue = response.data.value[schedule];
            if(scheduleValue == null || undefined){
                this.form.endTime = '',
                this.form.startTime = '',
                this.form.timeIn = '',
                this.form.timeOut = ''
            }
            else{
                this.form.date = this.formatDate(scheduleValue.ScheduleDate),
                this.form.startTime = this.formatTime(scheduleValue.StartTime),
                this.form.endTime = this.formatTime(scheduleValue.EndTime),
                this.form.timeIn = this.formatTime(scheduleValue.Clockin),
                this.form.timeOut = this.formatTime(scheduleValue.Clockout),
                this.form.mealCharged = scheduleValue.Charged,
                this.form.mealCost = scheduleValue.Cost
            }
        })
        .catch((error)=>{
            console.log(error);
        })
      },
      uploadImage(){
          this.$axiosServer.post('https://chefemployees.com/api/' + this.form.selectedSchedule +'/AddImage', {

          })

      }
  },
  mounted: function() {
      axios.get('https://chefemployees.com/odata/Schedules')
        .then((response) => {
            console.log(response);
            this.scheduleOptions = response.data.value.map(value => value.ScheduleId)
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
.btn.btn-secondary{
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
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
@media(max-width: 480px){
  .flexGroup{
    flex-wrap: wrap;
  }
  .timeflexGroup{
      flex-wrap: wrap;
  }
  .receiptflexGroup{
      flex-wrap: wrap;
  }
  .btn.btn.btn-secondary{
    width: 100%;
}
}
</style>