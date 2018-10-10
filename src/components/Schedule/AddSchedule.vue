<template>
    <div class="addSchedule">
    <b-form ref="form" @submit.prevent="handleSubmit" :model="form" v-if="show" class="form">
        <div class="scheduleVisit">
            <h3>Schedule</h3>
            <hr/>
            <div class="flexGroup">
                <b-form-group class="flex"
                                id="date "
                                label="Visit Date:"
                                label-for="date">
                    <b-form-input id="date"
                                type="date"
                                v-model="visit.date"/>
                </b-form-group>
                <b-form-group class="flex"
                                id="startTime"
                                label="Start Time:"
                                label-for="startTime">
                    <b-form-input id="startTime"
                                type="time"
                                v-model="visit.startTime"/>
                </b-form-group>
                <b-form-group class="flex"
                                id="endTime"
                                label="End Time:"
                                label-for="endTime">
                    <b-form-input id="endTime"
                                type="time"
                                v-model="visit.endTime"/>
                </b-form-group>
            </div>
        </div>
        <div class="employeeSelect">
        <h3> Select Chef </h3>
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
        <div class="timestamp">
            <h3>Track Time</h3>
            <hr/>
            <div class="buttonStamps">
            <div class="button">
                <b-button v-on:click="clockIn" class="btn">Clock In</b-button>
                <h5 class="timeflex">Clock In Time: {{ timeIn }}</h5>
            </div>
            <div class="button">
                <b-button v-on:click="clockOut" class="btn">Clock Out</b-button>
                <h5 class="timeflex">Clock Out Time: {{ timeOut }}</h5>
            </div>
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
            </div>
            <div class="receiptflexGroup">
                <b-form-group id="paylink"
                                class="receiptflex"
                                label="Pay Link:"
                                label-for="paylink">
                    <b-form-input id="paylink"
                                type="text"
                                v-model="form.paylink">
                    </b-form-input>
                </b-form-group>
                <b-form-group id="receipt"
                                class="receiptflex"
                                label="Upload Receipt:"
                                label-for="receipt">
                    <b-form-file v-model="form.receipt" :state="Boolean(file)" placeholder="Choose a file...">
                    </b-form-file>
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
  name: 'ScheduleVisit',
  data () {
    return {
        form: {
            receipt: '',
            mealCharged: '',
            paylink: '',
            mealCost: '',
            file: null
        },
        timeIn: null,
        timeOut: null,
        visit:{
            date: '',
            startTime: '',
            endTime: ''
        },
        selected: null,
        options: [
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
    clockIn: function (){
        let now = new Date();
        let timestamp = now.toLocaleTimeString();
        this.timeIn = timestamp;
    },
    clockOut: function (){
        let now = new Date();
        let timestamp = now.toLocaleTimeString();
        this.timeOut = timestamp;
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
.employeeSelect{
  padding-top: 5px 0px;
}
.buttonStamps{
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
}
.button{
    flex-grow: 1;
    padding: 0 2px;
}
.timeflex{
    padding: 10px 0;
}
.btn{
    width: 38vw;
}
.receiptflexGroup{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
}
.receiptflex{
    flex-grow: 1;
    padding: 0 2px;
}
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>