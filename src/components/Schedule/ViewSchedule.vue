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
                                required
                                class="clockText"
                                :disabled="disabled"
                                v-model="form.timeOut"/>
                </b-form-group>
            </div>
        </div>
        <div v-if="isAdmin=='True'" class="disabledButtons">
            <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Employee</b-button>
            <b-button class="update" v-if="!disabled" type="submit">Update Employee</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
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
        <b-form-group>
            <div class="submitButton">
                <b-button type="submit">Submit</b-button>
            </div>
        </b-form-group>
        </b-form>
    </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';
import { mapState } from 'vuex';
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
            menu: [],
            selectedSchedule: null
        },
        scheduleOptions: [],
        menuOptions: [],
        disabled: true,
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
      ...mapState({
            getToken(state){
                return state.jwt;
            },
            isAdmin (state){
                return state.userInfo.admin;
            }
        }),
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
            this.$axiosServer.get('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')ClientMenus')
            .then((response)=>{
                this.menuOptions = response.data.value.map(value => value.MenuId);
            })
            .catch((error)=>{
                console.log(error);
            })
        })
        .catch((error)=>{
            console.log(error);
        })
      },
      uploadImage(){
          this.$axiosServer.post('https://chefemployees.com/api/' + this.form.selectedSchedule +'/AddImage', {
              UploadedImage: this.form.receipt
          })
          .then((response)=>{
              console.log(response);
          })
          .catch((error)=>{
              console.log(error);
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