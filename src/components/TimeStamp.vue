<template>
    <div class="timestamp">
        <h3>Track Time</h3>
        <div class="buttons">
            <b-button v-on:click="clockIn">Clock In</b-button>
            <b-button v-on:click="clockIn">Clock Out</b-button>
        </div>
        <div class="stamp">
            <p>Clock In Time: {{ timeIn }}</p>
            <span>Clock Out Time: {}</span>
        </div>
    </div>
</template>
<script>
export default {
  name: 'TimeStamp',
  props: {
      timeIn: String
  },
  data () {
    return {
    }
  },
  methods: {
    clockIn: function (){
        var now = new Date();
        var timestamp = now.toLocaleTimeString();
        console.log(timestamp);
    },
    
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>