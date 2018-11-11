<template>
  <div class="scheduleDash">
    <h1>Menu Dashboard</h1>
    <b-button-group vertical class="dashGroup">
        <b-button to="/scheduleNew">Add Schedule</b-button>
        <b-button to="/viewSchedule">View Schedule</b-button>
    </b-button-group>
  </div>
</template>

<script>
export default {
  name: "ScheduleDash"
};
</script>

<style scoped>
.scheduleDash{
  margin-top: 8em;
}
.dashGroup{
  width: 80vw;
  margin: 0 10%;
}
h1{
  text-align: center;
}
</style>