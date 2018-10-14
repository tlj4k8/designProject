<template>
    <div class="scheduleVisit">
        <h3>Schedule</h3>
        <hr/>
        <b-form ref="needForm" @submit.prevent="handleSubmit" :model="needForm" v-if="show" class="form">
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
        visit:{
            date: '',
            startTime: '',
            endTime: ''
        },
        show: true

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
@media(max-width: 440px){
  .flexGroup{
    flex-wrap: wrap;
  }
}
</style>