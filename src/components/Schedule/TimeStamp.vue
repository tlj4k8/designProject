<template>
    <div class="timestamp">
        <h3>Track Time</h3>
        <div class="buttons">
            <b-button v-on:click="clockIn">Clock In</b-button>
            <b-button v-on:click="clockOut">Clock Out</b-button>
        </div>
        <div class="stamp">
            <p>Clock In Time: {{ timeIn }}</p>
            <span>Clock Out Time: {{ timeOut }}</span>
        </div>
    </div>
</template>
<script>
export default {
  name: 'TimeStamp',
  data () {
    return {
        timeIn: null,
        timeOut: null
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>