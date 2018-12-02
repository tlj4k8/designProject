<template>
    <div class="addSchedule">
        <div class="end">
          <font-awesome-icon @click="help" icon="question"/>
        </div>
        <div class="employeeSelect">
        <h3> Select Schedule </h3>
        <hr/>
        <b-form-group id="schedule"
                    class="select"
                    :label-cols="4"
                    breakpoint="md">
            <b-form-select @input="getSchedules" v-model="form.selectedSchedule" :options="scheduleOptions" class="mb-1" />
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
                                :disabled="disabled"
                                maxlength='7'
                                v-model="form.startTime"/>
                </b-form-group>
                <b-form-group class="flex"
                                id="endTime"
                                label="End Time:"
                                label-for="endTime">
                    <b-form-input id="endTime"
                                type="time"
                                required
                                :disabled="disabled"
                                maxlength='7'
                                v-model="form.endTime"/>
                </b-form-group>
                <b-form-group class="flex"
                                id="date "
                                label="Visit Date:"
                                label-for="date">
                    <b-form-input id="date"
                                type="date"
                                required
                                :disabled="disabled"
                                v-model="form.date"/>
                </b-form-group>
            </div>
        </div>
        <div class="menu">
        <h3> Scheduled Meal Items </h3>
        <hr/>
            <div v-if="menuOptions.length == 0">
                <p class="menuError">* No menus have been scheduled *</p>
            </div>
            <div v-if="menuOptions.length > 0">
                <ul v-for="menuOption in menuOptions" :key="menuOption.MenuId">
                    <b-card v-if="ready == true">
                        <h5> {{menuOption.name}}</h5>
                        <p class="card-text"><b>Notes:</b> {{ menuOption.notes}}</p>
                    </b-card>
                </ul>
            </div>
        </div>
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
                                :disabled="disabledTime"
                                maxlength='7'
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
                                :disabled="disabledTime"
                                maxlength='7'
                                v-model="form.timeOut"/>
                </b-form-group>
            </div>
        </div>
        <div v-if="isAdmin=='True'" class="disabledButtons">
            <b-button class="disabled" v-if="disabledTime" v-on:click="disabledTime = !disabledTime">Edit Time</b-button>
            <b-button class="update" v-if="!disabledTime" @click="updateTime">Update Time</b-button><b-button class="cancel" v-if="!disabledTime" v-on:click="disabledTime = !disabledTime">Cancel</b-button>
        </div>
        <div class="receipt">
        <h3> Customer Receipt Form </h3>
        <hr/>
            <div class="receiptflexGroup">
                <b-form-group id="mealCharged"
                                class="receiptflex"
                                label="Cost Charged to Client:"
                                label-for="mealCharged">
                    <b-input-group size="md" prepend="$" append=".00">
                        <b-form-input id="mealCharged"
                                    type="number"
                                    :disabled="disabled"
                                    maxlength='6'
                                    @input.native="chargedState"
                                    v-model="form.mealCharged">
                        </b-form-input>
                     </b-input-group>
                </b-form-group>
                <b-form-group id="mealCost"
                                class="receiptflex"
                                label="Meal Cost:"
                                label-for="mealCost">
                    <b-input-group size="md" prepend="$" append=".00">
                        <b-form-input id="mealCost"
                                    type="number"
                                    :disabled="disabled"
                                    maxlength='6'
                                    @input.native="costState"
                                    v-model="form.mealCost">
                        </b-form-input>
                    </b-input-group>
                </b-form-group>
                <b-form-group v-if="this.imagePath === null" id="receipt"
                    class="receiptflex"
                    label="Upload Receipt:"
                    label-for="receipt">
                    <b-form-file accept=".jpg, .png, .jpeg" :disabled="disabled" @change="onFileSelected" class="imageUpload" v-model="form.imagePath" >
                    </b-form-file>
                </b-form-group>
                </div>
            <div class="imageGroup">
                <div class="imageButton">
                    <b-button v-if="this.imagePath !== null" @click="openImage">View Uploaded Image</b-button>
                </div>
                <div class="imageButton">
                    <b-button v-if="this.imagePath === null" @click="onUpload">Upload Image</b-button>
                </div>
            </div>
        </div>
        <b-form-group>
        <div class="disabledButtons">
            <b-button class="disabled" v-if="disabled" v-on:click="disabled = !disabled">Edit Schedule</b-button>
            <b-button class="update" v-if="!disabled" @click="updateSchedule">Update Schedule</b-button><b-button class="cancel" v-if="!disabled" v-on:click="disabled = !disabled">Cancel</b-button>
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
            selectedSchedule: null
        },
        imagePath: '',
        scheduleOptions: [],
        employeeId: null,
        clientId: null,
        menuOptions: [{name: '', notes: ''}],
        disabled: true,
        disabledTime: true,
        show: true,
        checked: false,
        loading: false,
        ready: false,
        selectedFile: null,
        imageUploaded: false,
        timeCheck: false
    }
  },

  methods: {
    help(){
        window.open('http://localhost:8080/#/help', "_blank");
    },
    onFileSelected(event){
        this.selectedFile = event.target.files[0];
    },
    costState(){
        let cost = /^[0-9]*$/;
        cost.test(this.form.mealCost);
        if(!cost.test(this.form.mealCost)){return false;}else{return true;}
    },
    chargedState(){
        let charged = /^[0-9]*$/;
        charged.test(this.form.mealCharged);
        if(!charged.test(this.form.mealCharged)){return false;}else{return true;}
    },
    onUpload(){
        if(this.ready == true){
            if(this.selectedFile !==  null){
                let image = this.imagePath;
                if(image === null){
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
                        alert('Receipt uploaded!');
                        this.imagePath = response.data;
                    })
                    .catch((error)=>{
                        this.loading = false;
                        alert('Error: Receipt failed to upload. Please try again.');
                        console.log(error);
                    })
                }else{
                    alert('Error: Image has already been uploaded for this schedule.');
                }
            }else{
                alert('Error: File must be selected before upload.');
            }
        }else{
            alert('Error: Schedule must be selected to upload an image.');
        }
    },
    openImage(){
        if(this.ready == true){
            if(this.imagePath !== null){
                window.open(this.imagePath, "_blank");
            }else{
                alert('Error: Schedule does not have an image uploaded.');
            }
        }else{
            alert('Error: Schedule must be selected before viewing image.')
        }
    },
    updateTime(){
        this.loading = true;
        this.checkClock();
        if(this.timeCheck == true){
            let token = localStorage.getItem('t');
            let headers = {'Authorization': "Bearer " + token};
            this.$axiosServer.patch('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')', {
                ScheduleId: this.form.selectedSchedule,
                Clockout: this.formatTime(this.form.timeOut),
                Clockin: this.formatTime(this.form.timeIn)
            }, {headers: headers}
            )
            .then((response)=>{
                this.loading = false;
                alert('Times are updated!');
                this.disabled = true;
            })
            .catch((error)=>{
                this.loading = false;
                alert('Error: Please make sure that times are correct.');
                console.log(error);
            })
        }else{
            this.loading = false;
            alert('Error: Please make sure that times are correct.');
        }
    },
    formatTime(time){
        let timeStamp = time.split(':');
        let timeHour = timeStamp[0];
        let timeMinutes = timeStamp[1];
        let formatedTime= "PT" + timeHour + "H" + timeMinutes + "M" + "00S";
        return formatedTime;
    },
    formatDate(){
        let dateStamp = this.form.date.split('/').reverse().join('-');
        let formatedDate = dateStamp + "T00:00:00";
        return formatedDate;
    },
    clockIn(){
        if(this.ready == true){
            let time = this.form.timeIn;
            if(time === 'Invalid date' || time === null || time ==='' || time === '00:00'){
                let timestamp = moment().format("HH:mm");
                this.form.timeIn = timestamp;
                this.loading = true;
                console.log(this.form.timeIn);
                let token = localStorage.getItem('t');
                let headers = {'Authorization': "Bearer " + token};
                this.$axiosServer.patch('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')', {
                    ScheduleId: this.form.selectedSchedule,
                    Clockin: this.formatTime(this.form.timeIn)
                }, {headers: headers}
                )
                .then((response)=>{
                    console.log(this.form.timeIn);
                    this.loading = false;
                    alert('You are clocked in! Don\'t forget to clock out.');
                })
                .catch((error)=>{
                    this.loading = false;
                    alert('Error: There was a problem clocking in. Please try again.');
                    console.log(error);
                })
            }else{
                alert('Error: You are already clocked in!');
            }
        }else{
            alert('Error: Schedule must be selected before clock in.')
        }
    },
    clockOut(){
        if(this.ready == true){
            let time = this.form.timeIn;
            if(time !== 'Invalid date' && time !== null & (time !== '' && time !== '00:00')){
                let clockout = this.form.timeOut;
                if(clockout === 'Invalid date' || clockout === null || clockout === '' || clockout === '00:00' ){
                    let timestamp = moment().format("HH:mm");
                    this.form.timeOut = timestamp;
                    this.loading = true;
                    let token = localStorage.getItem('t');
                    let headers = {'Authorization': "Bearer " + token};
                    this.$axiosServer.patch('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')', {
                        ScheduleId: this.form.selectedSchedule,
                        Clockout: this.formatTime(this.form.timeOut)
                    }, {headers: headers}
                    )
                    .then((response)=>{
                        this.loading = false;
                        alert('You are clocked out!');
                        this.disabled = true;
                    })
                    .catch((error)=>{
                        this.loading = false;
                        alert('Error: There was a problem clocking out. Please try again.');
                        console.log(error);
                    })
                }else{
                    alert('Error: You are already clocked out!');
                }
            }else{
                alert('Error: You must clock in first.');
            }
        }else{
            alert('Error: Schedule must be selected before clock out.')
        }
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
    returnTime(time){
        let timeStamp = moment(time, 'HH:mm:ss.SSS').format('HH:mm');
        return timeStamp;
    },
    returnDate(date){
        let dateStamp = moment(date, 'YYYY-MM-DDTHH:mm:ss.SSS').format('YYYY-MM-DD');
        return dateStamp;
    },
    updateSchedule(){
        this.validateDate();
        if(this.checked == true){
            if(this.costState() == true && this.chargedState() ==  true){
                this.checkTimeSchedule();
                if(this.timeCheck == true){
                    this.loading = true;
                    let token = localStorage.getItem('t');
                    let headers = {'Authorization': 'Bearer ' + token}
                    this.$axiosServer.patch('https://chefemployees.com/odata/Schedules(' + this.form.selectedSchedule + ')', {
                        ScheduleId: this.form.selectedSchedule,
                        ScheduleDate: this.formatDate(this.form.date),
                        StartTime: this.formatTime(this.form.startTime),
                        EndTime: this.formatTime(this.form.endTime),
                        Charged: this.form.mealCharged,
                        Cost: this.form.mealCost,
                    }, {headers: headers}
                    )
                    .then((response)=>{
                        this.loading = false;
                        alert('Schedule updated!');
                        this.disabled = true;
                    })
                    .catch((error)=>{
                        this.loading = false;
                        alert('Error: There was a problem updating schedule. Please try again.');
                        console.log(error);
                    })
                }else{  
                    this.loading = false;
                    alert('Error: Please make sure that schedule times are correct.');
                }
            }else{
                this.loading = false;
                alert('Error: Please make sure that "Customer Receipt Form" is correct.');
            }
        }
    },
    checkTimeSchedule(){
        let start = this.form.startTime;
        let end = this.form.endTime;
        if(end > start){
            this.timeCheck = true;
        }else{
            this.timeCheck = false;
        }
    },
    checkClock(){
        let start = this.form.timeIn;
        let end = this.form.timeOut;
        if(end > start){
            this.timeCheck = true;
        }else{
            this.timeCheck = false;
        }
    },
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
                this.form.date = this.returnDate(scheduleValue.ScheduleDate),
                this.form.startTime = this.returnTime(scheduleValue.StartTime),
                this.form.endTime = this.returnTime(scheduleValue.EndTime),
                this.form.timeIn = this.returnTime(scheduleValue.Clockin),
                this.form.timeOut = this.returnTime(scheduleValue.Clockout),
                this.form.mealCharged = scheduleValue.Charged,
                this.form.mealCost = scheduleValue.Cost,
                this.imagePath = scheduleValue.ImagePath,
                this.employeeId = scheduleValue.EmployeeId,
                this.clientId = scheduleValue.ClientId,
                this.menuOptions = []
                this.$axiosServer.get('https://chefemployees.com/api/ScheduleMenuInfo/' + this.form.selectedSchedule + '',{ headers: { 'Authorization': "Bearer " + token }})
                .then((response)=>{
                    response.data.forEach((data) => {
                        this.menuOptions.push({name: data.MenuName, notes: data.ClientMenuNotes})
                    })
                    this.ready = true;
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
      axios.get('https://chefemployees.com/api/ScheduleEmpClient', { headers: { 'Authorization': "Bearer " + token }})
        .then((response) => {
            response.data.forEach((data) => {
                this.scheduleOptions.push({ value: data.ScheduleId, text: 'Client:   ' + data.ClFirstName + ' ' + data.ClLastName + ', ' + 'Employee:   ' + data.EmFirstName + ' ' + data.EmLastName + ', ' +' Date: ' + this.returnDate(data.ScheduleDate) })
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
.menuError{
    text-align: center;
}
ul{
    padding-inline-start: 0;
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
.imageUpload{
    overflow: hidden;
}
.timeflexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.imageGroup{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.timeflex{
    padding: 10px 0;
}
.clock{
    width: 38vw;
}
.imageButton{
    padding-bottom: 10px;
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
  .imageGroup{
    flex-wrap: wrap;
  }
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
    .disabledButtons{
      justify-content: center;
  }
  .disabled{
      width: 90%;
  }
  .update{
      width: 70%
  }
  .cancel{
      width: 70%;
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
      width: 60%
  }
  .cancel{
      width: 60%;
  }
}
</style>