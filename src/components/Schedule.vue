<template>
  <div class="schedule">
  <h1>Availability</h1>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
      <b-container>
        <b-row>
            <b-col></b-col>
            <b-col>Mon.</b-col>
            <b-col>Tue.</b-col>
            <b-col>Wed.</b-col>
            <b-col>Thur.</b-col>
            <b-col>Fri.</b-col>
            <b-col>Sat.</b-col>
            <b-col>Sun.</b-col>
        </b-row>
        <b-row>
            <b-col>Start</b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.mon">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.tue">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.wed">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.thur">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.fri">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.sat">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.sun">
            </b-form-input></b-col>
        </b-row>
        <b-row>
            <b-col>End</b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endMon">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endTue">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endWed">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endThur">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endFri">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endSat">
            </b-form-input></b-col>
            <b-col><b-form-input
                type="text"
                v-model="form.endSun">
            </b-form-input></b-col>
        </b-row>
      </b-container>
      <b-button type="submit" variant="primary">Update</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
export default {
  name: 'schedule',
  data () {
    return {
      form: {
          mon: '',
          tue: '',
          wed: '',
          thur: '',
          fri: '',
          sat: '',
          sun: '',
          endMon: '',
          endTue: '',
          endWed: '',
          endThur: '',
          endFri: '',
          endSat: '',
          endSun: ''
      },
      show: true,
    }
  },
  methods: {
    onSubmit (evt) {
      evt.preventDefault();
      alert(JSON.stringify(this.form));
    }
  }
}
</script>
<style scoped>
.schedule{
    padding: 5px 15px;
}
h1{
    text-align: center;
}
</style>