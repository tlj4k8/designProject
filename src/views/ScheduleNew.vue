<template>
  <div class="scheduleNewPage">
    <h1>Schedule</h1>
    <b-card bg-variant="light" class="card">
        <ScheduleNew/>
    </b-card>
  </div>
</template>

<script>
import ScheduleNew from '../components/Schedule/ScheduleNew.vue';
export default {
  name: "SchedulePage",
  components: {
    ScheduleNew
  }
};
</script>

<style scoped>
.card{
  margin: 15px 15px;
}
.scheduleNewPage{
  margin-top: 8em;
}
h1{
  text-align: center;
}

</style>