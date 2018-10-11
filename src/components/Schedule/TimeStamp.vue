<template>
    <div class="timestamp">
        <h3>Track Time</h3>
        <hr/>
        <div class="buttonStamps">
        <div class="button">
            <b-button v-on:click="clockIn" class="btn">Clock In</b-button>
            <h5 class="flex">Clock In Time: {{ timeIn }}</h5>
        </div>
        <div class="button">
            <b-button v-on:click="clockOut" class="btn">Clock Out</b-button>
            <h5 class="flex">Clock Out Time: {{ timeOut }}</h5>
        </div>
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
hr{
    background-color: #0d50bc;
    height: 1px;
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
.flex{
    padding: 10px 0;
}
.btn{
    width: 38vw;
}
</style>