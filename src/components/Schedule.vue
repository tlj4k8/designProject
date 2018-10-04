<template>
  <div class="schedule">
  <h3>Availability</h3>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show" class="form">
    <div class="table">
        <table>
            <tr>
                <th></th>
                <th>Mon.</th>
                <th>Tue.</th>
                <th>Wed.</th>
                <th>Thur.</th>
                <th>Fri.</th>
                <th>Sat.</th>
                <th>Sun.</th>
            </tr>
            <tr>
                <td>Start</td>
                <td><b-form-input type="time" v-model="form.mon"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.tue"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.wed"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.thur"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.fri"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.sat"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.sun"></b-form-input></td>
            </tr>
            <tr>
                <td>End</td>
                <td><b-form-input type="time" v-model="form.endMon"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endTue"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endWed"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endThur"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endFri"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endSat"></b-form-input></td>
                <td><b-form-input type="time" v-model="form.endSun"></b-form-input></td>
            </tr>
        </table>
    </div>
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
.table{
    overflow-x:auto;
    padding: 5px 15px;
}
</style>